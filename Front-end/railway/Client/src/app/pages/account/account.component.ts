import { Component, inject, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { UserDetail } from '../../interfaces/user-detail';

@Component({
  selector: 'app-account',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']  // Đảm bảo "styleUrls" thay vì "styleUrl"
})
export class AccountComponent implements OnInit {
  authService = inject(AuthService);
  route = inject(ActivatedRoute);

  accountDetail$!: Observable<UserDetail>;

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      const userId = params.get('id');  // Lấy id từ route params
      if (userId) {
        // Gọi API lấy thông tin chi tiết tài khoản
        this.accountDetail$ = this.authService.getDetail(userId);
      }
    });
  }
}
