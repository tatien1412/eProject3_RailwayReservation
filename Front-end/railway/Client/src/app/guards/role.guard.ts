import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';

export const roleGuard: CanActivateFn = (route, state) => {
  const role = route.data['role'] as string;
  const authService = inject(AuthService);
  const matSnackBar = inject(MatSnackBar);
  const router = inject(Router);

  const userRole = authService.getRole();
  console.log('User role:', userRole); // Kiểm tra vai trò người dùng

  if(!authService.isLoggedIn()) {
    router.navigate(['/login']);

    matSnackBar.open('You must log in to view this page', 'OK', {
      duration: 5001,
    });
    return false;
  }

  if (userRole === role) {
    return true;
  }
  router.navigate(['/']);
  matSnackBar.open('You dont have permission to view this page', 'OK', {
    duration: 5001,
  });
  return false;
  
}; 
