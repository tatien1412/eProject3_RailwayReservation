import { Component, inject } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserDetail } from '../../interfaces/user-detail';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-userdelete',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './userdelete.component.html',
  styleUrl: './userdelete.component.css'
})
export class UserdeleteComponent {
  authService = inject(AuthService);
  router = inject(Router);
  route = inject(ActivatedRoute);

  userDetail$!: Observable<UserDetail>;

  ngOnInit(): void {
    const useId = this.route.snapshot.paramMap.get('id')!;
    this.userDetail$ = this.authService.getDetail(useId);
  }

  confirmDelete(userId: string): void {
    const confirmation = confirm('Are you sure you want to delete this user?');
    if(confirmation) {
      this.authService.deleteUser(userId).subscribe({
        next: () => {
          console.log('User deleted successfully');
          this.router.navigate(['/users']);
        },
        error: (err) => console.error('Error deleting user:', err)
      });
    }
  }

  goBack(): void {
    this.router.navigate(['/users']);  // Trở lại trang danh sách người dùng
  }
}
