import { Component, OnInit ,inject} from '@angular/core';
import { map, Observable, combineLatest } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { StationService } from '../../services/station.service';
import { Station } from '../../interfaces/station';
import { AsyncPipe, CommonModule } from '@angular/common';
import { CounterComponent } from "../../components/counter/counter.component";
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { BookingService } from '../../services/booking.service';
@Component({
  selector: 'app-booking',
  standalone: true,
  imports: [AsyncPipe, FormsModule, CommonModule, CounterComponent, MatSnackBarModule],
  templateUrl: './booking.component.html',
  styleUrl: './booking.component.css'
})

export class BookingComponent implements OnInit{
  StationService = inject(StationService);
  BookingService = inject(BookingService);
  station$: Observable<Station[]> = this.StationService.getAll();
  FromStationId: number = 0;
  ToStationId: number = 0;
  DateOfTravel: string = '';
  arrivaldate: string='';
  router = inject(Router);
  snackBar = inject(MatSnackBar);
  noTrainFound: boolean = false;
  ngOnInit(): void {
    
  }
  Onsearch(FromStationId: number, ToStationId: number, DateOfTravel: string, TotalPassengers: number): void {
    // Kiểm tra xem các giá trị có được chọn hay không
    if (FromStationId === 0 || ToStationId === 0 || !DateOfTravel || TotalPassengers <= 0) {
      // Hiển thị lỗi nếu chưa nhập đủ thông tin
      this.snackBar.open('Please fill out all fields before searching!', 'Close', {
        duration: 5001,
        panelClass: ['bg-red-500', 'text-white'], // Thêm lớp CSS cho snackbar
      });
    } else {
      // Thực hiện điều hướng nếu thông tin hợp lệ
      this.BookingService.getAll(FromStationId,ToStationId,DateOfTravel,TotalPassengers)
          .subscribe(
            (result) =>{
              
                this.noTrainFound = false;
                this.router.navigate([`search/${FromStationId}/${ToStationId}/${DateOfTravel}/${TotalPassengers}`]);
             
            },
            (error) => {
              this.snackBar.open('No train found', 'Close', {
                duration: 5001,
                panelClass: ['bg-red-500', 'text-white'], // Thêm lớp CSS cho snackbar
              });
            }
          );
    }
  }
  value: number = 0;

  increase() {
    this.value++;
  }
  decrease() {
    if (this.value > 1) {
      this.value--;
    }
  }
  closeModal() {
    this.noTrainFound = false; // Đóng modal
  }
}
