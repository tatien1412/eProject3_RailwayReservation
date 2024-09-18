import { Component, inject, OnInit } from '@angular/core';
import { map, Observable, combineLatest } from 'rxjs';
import { Train } from '../../../interfaces/train';
import { TrainRoute } from '../../../interfaces/train-route';
import { Router } from '@angular/router';
import { TrainService } from '../../../services/train.service';
import { TrainRouteService } from '../../../services/train-route.service';  // Sử dụng TrainRouteService
import { AsyncPipe, CommonModule } from '@angular/common';

@Component({
  selector: 'app-trains',
  standalone: true,
  imports: [AsyncPipe, CommonModule],
  templateUrl: './trains.component.html',
  styleUrls: ['./trains.component.css']
})
export class TrainsComponent implements OnInit {
  trainService = inject(TrainService);
  trainRouteService = inject(TrainRouteService);  // Inject TrainRouteService
  trains$: Observable<Train[]> = this.trainService.getAll();
  trainRoutes$: Observable<TrainRoute[]> = this.trainRouteService.getAllTrainRoutes();  // Gọi API từ TrainRouteService

  paginatedTrains$!: Observable<(Train & { trainRouteName: string })[]>; // Observable cho trang

  router = inject(Router);
  currentPage: number = 1; 
  pageSize: number = 5;

  ngOnInit(): void {
    this.loadTrains();
  }

  loadTrains(): void {
    // Sử dụng combineLatest để kết hợp dữ liệu từ trains và train routes
    this.paginatedTrains$ = combineLatest([this.trains$, this.trainRoutes$]).pipe(
      map(([trains, routes]) => {
        return trains.map(train => {
          // Tìm trainRouteName từ trainRoute dựa trên trainRouteID
          const route = routes.find(route => route.trainRouteID === train.trainRouteID);
          return {
            ...train,
            trainRouteName: route ? route.trainRouteName : 'No Route'  // Thêm trainRouteName vào train
          };
        });
      }),
      map(trains => {
        const start = (this.currentPage - 1) * this.pageSize;
        const end = start + this.pageSize;
        return trains.slice(start, end);  // Ánh xạ dữ liệu theo số trang
      })
    );
  }

  onDetailTrain(trainID: number): void {
    this.router.navigate([`/train/detail/${trainID}`]);
  }

  onUpdateTrain(trainID: number): void {
    this.router.navigate([`/train/update/${trainID}`]);
  }

  onAddTrain(): void {
    this.router.navigate(['/train/create']);
  }
  viewTrainDetail(trainID: number): void {
    this.router.navigate([`/train/delete/${trainID}`]); 
  }
  onPreviousPage(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.loadTrains();
    }
  }

  onNextPage(): void {
    this.currentPage++;
    this.loadTrains();
  }

  trackById(index: number, item: Train): number {
    return item.trainID;
  }
}
