import { Component, inject, OnInit } from '@angular/core';
import { Observable, combineLatest, forkJoin } from 'rxjs';
import { map, mergeMap, switchMap } from 'rxjs/operators';
import { Router, ActivatedRoute } from '@angular/router';
import { AsyncPipe, CommonModule } from '@angular/common';
import { BookingService } from '../../services/booking.service';
import { FormsModule } from '@angular/forms';
import { Compartment } from '../../interfaces/compartment';
import { Fareschedule } from '../../interfaces/fareschedulemap';
import { ScheduleSearch } from '../../interfaces/schedulesearch';
import { Fare } from '../../interfaces/fare';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { Seat } from '../../interfaces/seat';
import { TrainService } from '../../services/train.service';
import { Train } from '../../interfaces/train';
import { Trainall } from '../../interfaces/traingetall';
import { Availableseat } from '../../interfaces/availableseat';
import { AvailableSeatMap } from '../../interfaces/availableseatmap';
@Component({
  selector: 'app-trains',
  standalone: true,
  imports: [AsyncPipe, CommonModule, FormsModule, MatSnackBarModule],
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  bookingservice = inject(BookingService);
  trainservice = inject(TrainService);
  schedule$: Observable<ScheduleSearch[]> = new Observable<ScheduleSearch[]>();
  compartment$: Observable<Compartment[]> = this.bookingservice.getCompartmentData();
  fareschedule$: Observable<Fareschedule[]> = new Observable<Fareschedule[]>();
  router = inject(Router);
  route = inject(ActivatedRoute);
  
  currentPage: number = 1;  // Trang hiện tại
  pageSize: number = 5;     // Số lượng mục trên mỗi trang
  totalSchedules: number = 0;
  FromStationId: number = 0;
  ToStationId: number = 0;
  DateOfTravel: string = '';
  TotalPassengers: number = 1;
  CompartmentType: string = '';
  Name: string = '';
  Age: number = 0;
  Gender: string = '';
  trainID :number =0;

  Fare$: Observable<Fare[]> = new Observable<Fare[]>();
  seats: any[] = [];
  totalfare: number = 0;
  serverResponse: any;
  value1: number = 0;
  value2: number = 0;
  value3: number = 0;
  selectedFare: number = 0;
  snackBar = inject(MatSnackBar);
  isModalOpen = false;
  Availableseattype1 = false;
  Availableseattype2 = false;
  Availableseattype3 = false;
  timeoutId: any;
  count : number = 0;
  AvailableSeat$: Observable<Availableseat> = new Observable<Availableseat>();
  AvailableSeatMap$: Observable<AvailableSeatMap[]> = new Observable<AvailableSeatMap[]>();
  ngOnInit(): void {
    const fromStationIdString = this.route.snapshot.paramMap.get('FromStationId');
    const toStationIdString = this.route.snapshot.paramMap.get('ToStationId');
    const dateOfTravelString = this.route.snapshot.paramMap.get('DateOfTravel');
    const totalPassengerString = this.route.snapshot.paramMap.get('TotalPassengers');

    this.FromStationId = fromStationIdString ? +fromStationIdString : 0;
    this.ToStationId = toStationIdString ? +toStationIdString : 0;
    this.DateOfTravel = dateOfTravelString ? dateOfTravelString : '';
    this.TotalPassengers = totalPassengerString ? +totalPassengerString : 1;

    this.loadSchedule();
    this.loadFare();

    this.Fare$ = combineLatest([this.schedule$, this.compartment$]).pipe(
      map(([schedules, compartments]) => {
        return schedules.map(schedule => {
          const compartmentsForTrain = compartments.filter(c => c.trainID === schedule.trainID);

          let fareAC1 = 0;
          let fareAC2 = 0;
          let fareAC3 = 0;

          compartmentsForTrain.forEach(compartment => {
            if (compartment.compartmentType === 'AC1') {
              fareAC1 = this.calculateFare(compartment);
            } else if (compartment.compartmentType === 'AC2') {
              fareAC2 = this.calculateFare(compartment);
            } else if (compartment.compartmentType === 'AC3') {
              fareAC3 = this.calculateFare(compartment);
            }
          });

          return {
            trainId: schedule.trainID,
            FareAC1: fareAC1,
            FareAC2: fareAC2,
            FareAC3: fareAC3
          };
        });
      })
    );

    this.fareschedule$ = combineLatest([this.Fare$, this.schedule$]).pipe(
      map(([fares, schedules]) => {
        return schedules.map(schedule => {
          const fare = fares.find(f => f.trainId === schedule.trainID);

          return fare
            ? {
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
              }
            : {
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
        });
      })
    );
    
  }

  calculateFare(compartment: Compartment): number {
    let pricePerSeat = 100;
    if (compartment.seatType === 'Sleep') pricePerSeat += 50;

    if (compartment.compartmentType === 'AC1') {
      pricePerSeat += 200;
    } else if (compartment.compartmentType === 'AC2') {
      pricePerSeat += 100;
    } else if (compartment.compartmentType === 'AC3') {
      pricePerSeat += 50;
    }

    let res = Math.abs(this.FromStationId - this.ToStationId) * pricePerSeat * this.TotalPassengers;
    return res;
  }

  loadSchedule(): void {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;

    this.schedule$ = this.bookingservice.getAll(
      this.FromStationId,
      this.ToStationId,
      this.DateOfTravel,
      this.TotalPassengers
    ).pipe(
      map(schedules => schedules.slice(startIndex, endIndex)) // Cắt lịch trình dựa trên trang hiện tại
    );
  }
  loadAvailableSeat(ttrainID:string):void{
    
  }
  loadFare(): void {}

  openModal(value1: number, value2: number, value3: number,value4:number) {
    this.Age=0;
    this.Name="";
    this.Gender="";
    this.CompartmentType='';
    this.isModalOpen = true;
    this.value1 = value1;
    this.value2 = value2;
    this.value3 = value3;
    this.trainID =value4;
    this.bookingservice.updateseatqueuestatus(this.trainID,this.CompartmentType,this.TotalPassengers);
    this.timeoutId = setTimeout(() => {
      this.closeModal();
    }, 30000);
  }

  closeModal() {
    this.isModalOpen = false;
    if (this.timeoutId) {
      clearTimeout(this.timeoutId);
    }
  }

  updateFare(): void {
    if (this.CompartmentType === 'AC1') {
      this.selectedFare = this.value1;
      this.Availableseattype1 = true;
      this.Availableseattype2 =false;
      this.Availableseattype3 =false;
      this.AvailableSeat$ = this.bookingservice.getAvailableSeats(this.trainID);
    } else if (this.CompartmentType === 'AC2') {
      this.selectedFare = this.value2;
      this.Availableseattype2 = true;
      this.Availableseattype1 =false;
      this.Availableseattype3 =false;
      this.AvailableSeat$ = this.bookingservice.getAvailableSeats(this.trainID);
    } else if (this.CompartmentType === 'AC3') {
      this.selectedFare = this.value3;
      this.Availableseattype3 = true;
      this.Availableseattype2 =false;
      this.Availableseattype1 =false;
      this.AvailableSeat$ = this.bookingservice.getAvailableSeats(this.trainID);
    }
  }

  // Phương thức chuyển trang
  onPreviousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.loadSchedule();
    }
  }

  onNextPage(): void {
      this.currentPage++;
      this.loadSchedule();
  }

  onSubmit(Name: string, Age: number, Gender: string, CompartmentType: string) {
    if (CompartmentType === 'AC1') {
      this.totalfare = this.value1;
    } else if (CompartmentType === 'AC2') {
      this.totalfare = this.value2;
    } else if (CompartmentType === 'AC3') {
      this.totalfare = this.value3;
    }

    const ticket = {
      name: Name,
      age: Age,
      gender: Gender,
      totalPassengers: this.TotalPassengers
    };

    this.bookingservice.createTicket(ticket).subscribe(
      (response: any) => {
        if (response && response.PnrNo) {
          this.serverResponse = response.PnrNo;

          const reservation = {
            PnrNo: this.serverResponse,
            DateOfJourney: this.DateOfTravel,
            TotalFare: this.totalfare
          };

          this.bookingservice.createReservation(reservation).subscribe({
            next: (res) => {
              this.snackBar.open('Reservation created successfully!', 'Close', {
                duration: 5001,
                panelClass: ['bg-red-500', 'text-white'],
              });
              this.router.navigate(['booking']);
            },
            error: (err) => console.error('Error creating reservation:', err)
          });
        } else {
          console.error('PnrNo is missing in the response!');
        }
      },
      (error) => {
        console.error('There was an error!', error);
      }
    );
    this.bookingservice.updateseatstatus(this.trainID,this.CompartmentType,this.TotalPassengers);
  }

  
}
