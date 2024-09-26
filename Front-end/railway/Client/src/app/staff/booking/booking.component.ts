import { Component, OnInit ,inject} from '@angular/core';
import { map, Observable, combineLatest } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { StationService } from '../../services/station.service';
import { Station } from '../../interfaces/station';
import { AsyncPipe, CommonModule } from '@angular/common';
import { CounterComponent } from "../../components/counter/counter.component";
@Component({
  selector: 'app-booking',
  standalone: true,
  imports: [AsyncPipe, FormsModule, CommonModule, CounterComponent],
  templateUrl: './booking.component.html',
  styleUrl: './booking.component.css'
})
export class BookingComponent implements OnInit{
  StationService = inject(StationService);
  station$: Observable<Station[]> = this.StationService.getAll();
  FromStationId: number = 0;
  ToStationId: number = 0;
  DateOfTravel: string = '';
  arrivaldate: string='';
  router = inject(Router);
  ngOnInit(): void {
    
  }
  Onsearch(FromStationId:number , ToStationId:number, DateOfTravel:string,TotalPassengers:number): void{
    this.router.navigate([`search/${FromStationId}/${ToStationId}/${DateOfTravel}/${TotalPassengers}`]);
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
}
