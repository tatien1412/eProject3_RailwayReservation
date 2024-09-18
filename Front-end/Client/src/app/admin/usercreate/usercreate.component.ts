import { Component, inject } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { UserDetail } from '../../interfaces/user-detail';
import { RoleService } from '../../services/role.service';
import { Role } from '../../interfaces/role';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-usercreate',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './usercreate.component.html',
  styleUrl: './usercreate.component.css'
})
export class UsercreateComponent {
  authService = inject(AuthService);
  roleService = inject(RoleService);
  fb = inject(FormBuilder);
  router = inject(Router);

  userForm!: FormGroup;

  roles: Role[] = [];
  snackBar = inject(MatSnackBar);

  ngOnInit(): void {
    this.initForm();
    this.getRoles();
  }

  initForm():void {
    this.userForm = this.fb.group({
      fullName: ['', [Validators.required]], 
      userName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]], 
      password: ['', [Validators.required]],
      phoneNumber: ['', [Validators.required]],
      role: ['', [Validators.required]] 
    });
  }
  getRoles(): void {
    this.roleService.getRoles().subscribe({
      next: (roles : Role[]) => {
        console.log('Roles fetched:', roles);
        this.roles = roles;
      },
      error: (err) => {
        console.error('Error fetching roles:', err);
      }
    });
  }
  goBack(): void {
    this.router.navigate(['/users']);  // Trở lại trang danh sách người dùng
  }
  onSubmit(): void {
    if (this.userForm.invalid) {
      // Đánh dấu tất cả các trường là touched để hiển thị lỗi
      this.userForm.markAllAsTouched();
  
      // Hiển thị thông báo lỗi bằng MatSnackBar
      this.snackBar.open('Please fill out all required fields', 'Close', {
        duration: 5001,
        panelClass: ['error-snackbar'],  // Class CSS tùy chọn cho snackbar
      });
      
      return; // Ngăn chặn việc tạo user nếu form không hợp lệ
    }
  
    const newUser: UserDetail = {
      id: '',
      ...this.userForm.value, // Lấy các giá trị từ form
    };
  
    this.authService.addUser(newUser).subscribe({
      next: (user) => {
        this.snackBar.open('User created successfully', 'Close', {
          duration: 5001,
          panelClass: ['success-snackbar'],  // Class CSS tùy chọn cho snackbar thành công
        });
        this.router.navigate(['/users']);
      },
      error: (err) => {
        // Hiển thị thông báo lỗi khi trùng username
        if (err.error.includes('UserName')) {
          this.snackBar.open('Username is already taken', 'Close', {
            duration: 5001,
            panelClass: ['error-snackbar'],  // Class CSS tùy chọn cho snackbar lỗi
          });
        } else {
          this.snackBar.open('Error creating user', 'Close', {
            duration: 5001,
            panelClass: ['error-snackbar'],
          });
        }
        console.error('Error creating user', err);
      },
    });
  }
}
