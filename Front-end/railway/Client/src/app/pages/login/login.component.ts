import { Component, OnInit, inject } from '@angular/core';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink } from '@angular/router';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar'
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatIconModule, MatInputModule, MatSnackBarModule, ReactiveFormsModule, RouterLink],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  authService = inject(AuthService);
  matSnackBar = inject(MatSnackBar);
  router = inject(Router);
  hide = true;
  form!: FormGroup;
  fb = inject(FormBuilder);

  login() {
    const rememberMe = this.form.get('rememberMe')?.value;
    this.authService.login(this.form.value).subscribe(
      {
        next:(response)=>{
          // Lưu token và thông tin người dùng vào localStorage hoặc sessionStorage
          if (rememberMe) {
            // Lưu thông tin vào localStorage nếu chọn "Remember Me"
            localStorage.setItem('authToken', response.token);  // Lưu token
            // localStorage.setItem('username', this.form.get('username')?.value); // Lưu username
            // localStorage.setItem('password', this.form.get('password')?.value); // Lưu password (cẩn thận khi lưu mật khẩu)
          } else {
            // Chỉ lưu token vào sessionStorage nếu không chọn "Remember Me"
            sessionStorage.setItem('authToken', response.token);
          }

          this.matSnackBar.open('Login Successfully','Close',{
            duration: 5001,
            horizontalPosition:'center'
          });
          this.router.navigate(['/'])
        },
        error:(error) => {
          this.matSnackBar.open('Wrong username or password, try again','Close',{
            duration: 5001,
            horizontalPosition:'center'
          });
        },
      }
    );
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', Validators.required],
      rememberMe: [false]
    });
  }
}
