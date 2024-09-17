import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserDetail } from '../../interfaces/user-detail';

@Component({
  selector: 'app-userdetail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './userdetail.component.html',
  styleUrl: './userdetail.component.css'
})
export class UserdetailComponent {
  private authService = inject(AuthService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  userDetail$!: Observable<UserDetail>;

  ngOnInit():void {
    const userId = this.route.snapshot.paramMap.get('id');
    if(userId) {
      this.getUserDetail(userId);
    }
  }
  getUserDetail(id:string):void {
    this.userDetail$ = this.authService.getDetail(id); //Lưu kết quả vào observable
  }
  goBack():void {
    this.router.navigate(['/users']);
  }
}
