import { Component, inject, OnInit } from '@angular/core';
import { map, Observable, combineLatest } from 'rxjs';
import { Router,ActivatedRoute,Params } from '@angular/router';
import { AsyncPipe, CommonModule } from '@angular/common';
import { ScheduleSearch } from '../../interfaces/schedulesearch';
import { BookingService } from '../../services/booking.service';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-trains',
  standalone: true,
  imports: [AsyncPipe, CommonModule,FormsModule],
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  bookingservice = inject(BookingService);
  schedule$: Observable<ScheduleSearch[]> = new Observable<ScheduleSearch[]>();
  router = inject(Router);
  route = inject(ActivatedRoute);
  currentPage: number = 1;  // Trang hiện tại
  pageSize: number = 5;     // Số lượng mục trên mỗi trang
  FromStationId: number = 0;
  ToStationId: number = 0;
  DateOfTravel: string = '';
  TotalPassengers: number = 1;
  Name : string = '';
  Age : number = 0;
  Gender : string ='';
  ngOnInit(): void {
    const fromStationIdString = this.route.snapshot.paramMap.get('FromStationId');
    const toStationIdString = this.route.snapshot.paramMap.get('ToStationId');
    const dateOfTravelString = this.route.snapshot.paramMap.get('DateOfTravel');
    const totalPassengerString = this.route.snapshot.paramMap.get('TotalPassenger');

    // Chuyển đổi các giá trị từ string thành số hoặc giữ nguyên nếu là string
    this.FromStationId = fromStationIdString ? +fromStationIdString:0;
    this.ToStationId = toStationIdString ? +toStationIdString : 0;
    this.DateOfTravel = dateOfTravelString ? dateOfTravelString : '';
    this.TotalPassengers = totalPassengerString ? +totalPassengerString : 1;

    // Sau khi lấy các giá trị, thực hiện các logic tiếp theo
    this.loadSchedule();
  }

  loadSchedule(): void {
    // Gọi API với tham số phân trang
    this.schedule$ = this.bookingservice.getAll(
      this.FromStationId,
      this.ToStationId,
      this.DateOfTravel,
      this.TotalPassengers,
    );
  }

  // Phương thức chuyển trang
  changePage(pageNumber: number): void {
    this.currentPage = pageNumber;
    this.loadSchedule();
  }
  BookTicket(): void{

  }
  isModalOpen = false;

  openModal(train: any) {
    this.isModalOpen = true;
  }

  closeModal() {
    this.isModalOpen = false;
  }
  onSubmit(Namee : string,Agee:number,Genderr:string)
  {
    const ticket ={
      Name : Namee,
      Age : Agee,
      Gender : Genderr,
      TotalPassengers : this.TotalPassengers
    };
    console.log(ticket.TotalPassengers);
    this.bookingservice.createTicket(ticket).subscribe({
      next: (ticket) => {
        console.log('Ticket created successfully:', ticket);
        
      },
      error: (err) => console.error('Error creating ticket:', err)
    });
    this.router.navigate([`booking`]);
  }
}
