import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth.service';
import { UserDetail } from '../../interfaces/user-detail';
import { RoleService } from '../../services/role.service';
import { Role } from '../../interfaces/role';

@Component({
  selector: 'app-userupdate',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './userupdate.component.html',
  styleUrls: ['./userupdate.component.css']
})
export class UserupdateComponent implements OnInit {
  fb = inject(FormBuilder);
  authService = inject(AuthService);
  roleService = inject(RoleService);
  router = inject(Router);
  route = inject(ActivatedRoute);

  userForm!: FormGroup;
  roles: Role[] = [];
  userId: string = '';  // Lưu trữ ID của người dùng để cập nhật
  isEditing: boolean = false;  // Cờ để theo dõi trạng thái chỉnh sửa của input

  ngOnInit(): void {
    this.initForm();
    this.userId = this.route.snapshot.paramMap.get('id')!;  // Lấy user ID từ route
    this.getUserDetail(this.userId);
    this.getRoles();  // Lấy danh sách vai trò
  }

  initForm(): void {
    this.userForm = this.fb.group({
      fullName: ['', [Validators.required]],  // Disabled ban đầu
      userName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      password: [''],  // Không yêu cầu password trong update
      phoneNumber: ['', [Validators.required]],
      role: ['', [Validators.required]]
    });
  }

  getUserDetail(id: string): void {
    this.authService.getDetail(id).subscribe({
      next: (user: UserDetail) => {
        this.userForm.patchValue({
          fullName: user.fullName,
          userName: user.userName,
          email: user.email,
          phoneNumber: user.phoneNumber,
          role: user.role  
        });
      },
      error: (err) => console.error('Error fetching user details', err)
    });
  }

  getRoles(): void {
    this.roleService.getRoles().subscribe({
      next: (roles: Role[]) => {
        this.roles = roles;
      },
      error: (err) => console.error('Error fetching roles', err)
    });
  }

  // Khi người dùng bấm vào input để chỉnh sửa
  enableEditing(fieldName: string): void {
    this.userForm.get(fieldName)?.enable();  // Cho phép chỉnh sửa trường
  }
  
  goBack(): void {
    this.router.navigate(['/users']);  // Trở lại trang danh sách người dùng
  }

  onSubmit(): void {
    if (this.userForm.invalid) {
      return;
    }

    const updatedUser: UserDetail = {
      ...this.userForm.value,
      id: this.userId  // Gán lại id của người dùng
    };

    this.authService.updateUser(this.userId, updatedUser).subscribe({
      next: () => {
        console.log('User updated successfully');
        this.router.navigate(['/users']);  
      },
      error: (err) => console.error('Error updating user', err)
    });
  }
}
