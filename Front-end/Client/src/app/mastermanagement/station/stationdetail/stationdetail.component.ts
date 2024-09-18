import { Component, inject } from '@angular/core';
import { StationService } from '../../../services/station.service';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { Station } from '../../../interfaces/station';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-stationdetail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './stationdetail.component.html',
  styleUrl: './stationdetail.component.css'
})
export class StationdetailComponent {
  private stationService = inject(StationService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  stationDetail$!: Observable<Station>;

  ngOnInit(): void {
    const stationIdString = this.route.snapshot.paramMap.get('stationID'); // Lấy 'stationId' từ URL
    console.log('Station ID from URL:', stationIdString); // Kiểm tra giá trị của stationIdString
    if (stationIdString) {
      const stationId = Number(stationIdString); // Chuyển đổi từ chuỗi sang số
      if (!isNaN(stationId)) {
        this.getStationDetail(stationId); // Gọi API với stationId
      } else {
        console.error(`Station ID is not a valid number: ${stationIdString}`);
      }
    } else {
      console.error('Station ID is missing in the route');
    }
  }
  getStationDetail(stationID:number):void {
    this.stationDetail$ = this.stationService.getDetail(stationID); //Lưu kết quả vào observable
  }

  goBack():void {
    this.router.navigate(['/stations']);
  }
}
