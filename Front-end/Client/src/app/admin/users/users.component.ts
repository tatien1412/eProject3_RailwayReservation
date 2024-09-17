import { Component, inject } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { AsyncPipe, CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { UserDetail } from '../../interfaces/user-detail';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [AsyncPipe, CommonModule],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css' 
})
export class UsersComponent {
  authService = inject(AuthService);
  users$: Observable<UserDetail[]> = this.authService.getAll(); 
  paginatedUsers$!: Observable<UserDetail[]>; // Lưu danh sách người dùng sau khi phân trang
  router = inject(Router);
  currentPage: number = 1; 
  pageSize: number = 5;

  ngOnInit(): void {
    this.loadUsers();
  }

  // Hàm lấy danh sách người dùng với phân trang
  loadUsers(): void {
    this.paginatedUsers$ = this.users$.pipe(
      map(users => {
        const start = (this.currentPage - 1) * this.pageSize;
        const end = start + this.pageSize;
        return users.slice(start, end);  // Lọc danh sách người dùng theo trang hiện tại
      })
    );
  }
  onDetailUser(id: string): void {
    this.router.navigate([`/users/detail/${id}`]);  
  }

  onUpdateUser(id: string): void {
    this.router.navigate([`/users/update/${id}`]);  
  }

  onAddUser(): void {
    this.router.navigate(['/users/create']);  
  }

  viewUserDetail(id: string): void {
    this.router.navigate([`/users/delete/${id}`]); 
  }

  onPreviousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.loadUsers();
    }
  }

  onNextPage(): void {
    this.currentPage++;
    this.loadUsers();
  }
  trackById(index: number, item: UserDetail): string {
    return item.id;
  }
}
