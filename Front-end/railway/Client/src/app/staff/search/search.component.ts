import { Component, inject, OnInit } from '@angular/core';
import {  Observable,of, combineLatest } from 'rxjs';
import { map } from 'rxjs';
import { Router,ActivatedRoute,Params } from '@angular/router';
import { AsyncPipe, CommonModule } from '@angular/common';
import { BookingService } from '../../services/booking.service';
import { FormsModule } from '@angular/forms';
import { Compartment } from '../../interfaces/compartment';
import { Fareschedule } from '../../interfaces/fareschedulemap';
import { ScheduleSearch } from '../../interfaces/schedulesearch';
import { Fare } from '../../interfaces/fare';

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
  compartment$: Observable<Compartment[]> =this.bookingservice.getCompartmentData();
  fareschedule$: Observable<Fareschedule[]> = new Observable<Fareschedule[]>();
  router = inject(Router);
  route = inject(ActivatedRoute);
  currentPage: number = 1;  // Trang hiện tại
  pageSize: number = 5;     // Số lượng mục trên mỗi trang
  FromStationId: number = 0;
  ToStationId: number = 0;
  DateOfTravel: string = '';
  TotalPassengers: number = 1;
  CompartmentType : string ='';
  Name : string = '';
  Age : number = 0;
  Gender : string ='';
  Fare$ : Observable<Fare[]> = new Observable<Fare[]>;
  seats : any[]=[];
  totalfare : number =0;
  serverResponse: any;
  value1: number =0;
  value2: number =0;
  value3: number =0;
  ngOnInit(): void {
    const fromStationIdString = this.route.snapshot.paramMap.get('FromStationId');
    const toStationIdString = this.route.snapshot.paramMap.get('ToStationId');
    const dateOfTravelString = this.route.snapshot.paramMap.get('DateOfTravel');
    const totalPassengerString = this.route.snapshot.paramMap.get('TotalPassengers');

    // Chuyển đổi các giá trị từ string thành số hoặc giữ nguyên nếu là string
    this.FromStationId = fromStationIdString ? +fromStationIdString:0;
    this.ToStationId = toStationIdString ? +toStationIdString : 0;
    this.DateOfTravel = dateOfTravelString ? dateOfTravelString : '';
    this.TotalPassengers = totalPassengerString ? +totalPassengerString : 1;
    // Sau khi lấy các giá trị, thực hiện các logic tiếp theo
    this.loadSchedule();
    this.loadFare();
    this.Fare$ = combineLatest([this.schedule$, this.compartment$]).pipe(
      map(([schedules, compartments]) => {
        return schedules.map(schedule => {
          // Lọc các khoang thuộc về trainID hiện tại
          const compartmentsForTrain = compartments.filter(c => c.trainID === schedule.trainID);
    
          // Khởi tạo giá vé cho mỗi loại khoang
          let fareAC1 = 0;
          let fareAC2 = 0;
          let fareAC3 = 0;
    
          // Tính toán giá vé cho từng loại khoang
          compartmentsForTrain.forEach(compartment => {
            if (compartment.compartmentType === 'AC1') {
              fareAC1 = this.calculateFare(compartment);
            } else if (compartment.compartmentType === 'AC2') {
              fareAC2 = this.calculateFare(compartment);
            } else if (compartment.compartmentType === 'AC3') {
              fareAC3 = this.calculateFare(compartment);
            }
          });
    
          // Trả về một đối tượng Fare
          return {
            trainId: schedule.trainID,
            FareAC1: fareAC1,
            FareAC2: fareAC2,
            FareAC3: fareAC3
          };
        });
      })
    );
    // Subscribe để nhận danh sách fare
    this.Fare$.subscribe(fares => {
      console.log('Danh sách Fare:', fares);
    });
    this.fareschedule$ = combineLatest([this.Fare$, this.schedule$]).pipe(
      map(([fares, schedules]) => {
        return schedules.map(schedule => {
          // Tìm giá vé tương ứng với trainID từ fare$ cho từng lịch trình
          const fare = fares.find(f => f.trainId === schedule.trainID);
    
          // Nếu tìm thấy giá vé tương ứng, tạo đối tượng Fareschedule
          if (fare) {
            return {
              FareAC1: fare.FareAC1,
              FareAC2: fare.FareAC2,
              FareAC3: fare.FareAC3,
              scheduleID: schedule.scheduleID,
              trainID: schedule.trainID,
              trainRouteID: schedule.trainRouteID,
              departureTime: schedule.departureTime,
              arrivalTime: schedule.arrivalTime,
              dayOfWeek: schedule.dayOfWeek,
              dateOfTravel: schedule.dateOfTravel
            };
          } else {
            // Nếu không tìm thấy giá vé, trả về một đối tượng Fareschedule với giá trị mặc định
            return {
              FareAC1: 0,
              FareAC2: 0,
              FareAC3: 0,
              scheduleID: schedule.scheduleID,
              trainID: schedule.trainID,
              trainRouteID: schedule.trainRouteID,
              departureTime: schedule.departureTime,
              arrivalTime: schedule.arrivalTime,
              dayOfWeek: schedule.dayOfWeek,
              dateOfTravel: schedule.dateOfTravel
            };
          }
        });
      })
    );
    
    // Subscribe để nhận giá trị từ fareschedule$
    this.fareschedule$.subscribe(fareschedules => {
      console.log('Danh sách fareschedule:', fareschedules);
    });
  }
  calculateFare(compartment: Compartment): number {
    // Ví dụ tính giá vé dựa trên số ghế
    let pricePerSeat = 100;
    if(compartment.seatType="Sleep") pricePerSeat +=50;
    // Điều kiện tính giá vé theo compartmentType
    if (compartment.compartmentType === 'AC1') {
        pricePerSeat +=  200;  // Tính theo AC1
    } else if (compartment.compartmentType === 'AC2') {
        pricePerSeat +=  100;  // Tính theo AC2
    } else if (compartment.compartmentType === 'AC3') {
        pricePerSeat +=  50;  // Tính theo AC3
    } 
    console.log(this.TotalPassengers);
    let res =Math.abs(this.FromStationId-this.ToStationId) * pricePerSeat*this.TotalPassengers;
    // Đảm bảo trả về giá trị tuyệt đối
    return res;
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
  loadFare(): void {
    
  }
  // Phương thức chuyển trang
  changePage(pageNumber: number): void {
    this.currentPage = pageNumber;
    this.loadSchedule();
  }
  isModalOpen = false;

  openModal(value1 : number , value2 : number,value3 : number) {
    this.isModalOpen = true;
    this.value1=value1;
    this.value2=value2;
    this.value3=value3;
  }

  closeModal() {
    this.isModalOpen = false;
  }
  onSubmit(Namee : string,Agee:number,Genderr:string,compartmentTypee:string)
  {
    if(compartmentTypee=='AC1')
    {
      this.totalfare=this.value1;
    }
    if(compartmentTypee=='AC2')
    {
      this.totalfare=this.value2;
    }
    if(compartmentTypee=='AC3')
    {
      this.totalfare=this.value3;
    }
    const ticket ={
      name : Namee,
      age : Agee,
      gender : Genderr,
      totalPassengers : this.TotalPassengers
    };
    this.bookingservice.createTicket(ticket).subscribe(response => {
      // Xử lý phản hồi từ server
      console.log('Server response:', response);
      this.serverResponse = response;
    },
    error => {
      // Xử lý lỗi
      console.error('There was an error!', error);
    }
  );
    const reservation ={
      PnrNo : this.serverResponse,
      DateOfJourney : this.DateOfTravel,
      TotalFare : this.totalfare
    }
    this.bookingservice.createReservation(reservation).subscribe({
      next: (ticket) => {
        console.log('Reservation created successfully:', reservation);
        
      },
      error: (err) => console.error('Error creating reservation:', err)
    });
    this.router.navigate([`booking`]);
  }
}
