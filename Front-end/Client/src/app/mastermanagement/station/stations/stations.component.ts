import { ScrollStrategyOptions } from '@angular/cdk/overlay';
import { AsyncPipe, CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { StationService } from '../../../services/station.service';
import { map, Observable } from 'rxjs';
import { Station } from '../../../interfaces/station';
import { Router } from '@angular/router';

@Component({
  selector: 'app-stations',
  standalone: true,
  imports: [AsyncPipe, CommonModule],
  templateUrl: './stations.component.html',
  styleUrl: './stations.component.css'
})
export class StationsComponent {
  stationService = inject(StationService);
  stations$: Observable<Station[]> = this.stationService.getAll();
  paginatedStations$!: Observable<Station[]>;
  router = inject(Router);
  currentPage: number = 1; 
  pageSize: number = 5;

  ngOnInit(): void {
    this.loadStations();
  }

  loadStations(): void {
    this.paginatedStations$ = this.stations$.pipe(
      map(staions => {
        const start = (this.currentPage - 1) * this.pageSize;
        const end = start + this.pageSize;
        return staions.slice(start, end);  
      })
    );
  }
  onDetailStation(stationID: number): void {
    console.log('Navigating with stationID:', stationID); // Debug để kiểm tra giá trị stationId
    this.router.navigate([`/station/detail/${stationID}`]);  // Điều hướng với stationId
  }

  onUpdateStation(id: number): void {
    this.router.navigate([`/station/update/${id}`]);  
  }

  onAddStation(): void {
    this.router.navigate(['/station/create']);  
  }

  viewStationDetail(id: number): void {
    this.router.navigate([`/station/delete/${id}`]); 
  }

  onPreviousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.loadStations();
    }
  }

  onNextPage(): void {
    this.currentPage++;
    this.loadStations();
  }
  trackById(index: number, item: Station): number {
    return item.stationID;
  }
}
