import { Component, inject } from '@angular/core';
import { RoleService } from '../../services/role.service';
import { response } from 'express';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { HttpErrorResponse } from '@angular/common/http';
import { RoleListComponent } from '../../components/role-list/role-list.component';
import { AsyncPipe, CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { map } from 'rxjs';

@Component({
  selector: 'app-role',
  standalone: true,
  imports: [MatSelectModule, MatInputModule, RoleListComponent, AsyncPipe, MatSnackBarModule, CommonModule],
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css']
})
export class RoleComponent {
  roleService = inject(RoleService);// Observable cho roles
  errorMessage = '';
  roles$ = this.roleService.getRoles().pipe(
    map((roles: any[]) => {
      const order = ['Admin', 'Master Manager', 'Transaction Staff'];  // Thứ tự mong muốn
      return roles.sort((a, b) => {
        return order.indexOf(a.name) - order.indexOf(b.name);  // Sắp xếp dựa trên thứ tự
      });
    })
  );

  ngOnInit(): void {
  }
} 
