import { Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { StationService } from '../../../services/station.service';
import { Station } from '../../../interfaces/station';

@Component({
  selector: 'app-stationupdate',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './stationupdate.component.html',
  styleUrls: ['./stationupdate.component.css']
})
export class StationupdateComponent implements OnInit {
  fb = inject(FormBuilder);
  stationService = inject(StationService);
  router = inject(Router);
  route = inject(ActivatedRoute);

  stationForm!: FormGroup;
  stationID: string = '';  // Lưu trữ ID của trạm để cập nhật
  isEditing: boolean = false;  // Cờ để theo dõi trạng thái chỉnh sửa của input

  ngOnInit(): void {
    this.initForm();
    this.stationID = this.route.snapshot.paramMap.get('stationID')!;  // Lấy station ID từ route
    this.getStationDetail(+this.stationID);
  }

  initForm(): void {
    this.stationForm = this.fb.group({
      stationCode: ['', [Validators.required]],
      stationName: ['', [Validators.required]],
      railwayDivisionName: ['', [Validators.required]]
    });
  }

  getStationDetail(stationID: number): void {
    this.stationService.getDetail(stationID).subscribe({
      next: (station: Station) => {
        this.stationForm.patchValue({
          stationCode: station.stationCode,
          stationName: station.stationName,
          railwayDivisionName: station.railwayDivisionName
        });
      },
      error: (err) => console.error('Error fetching station details', err)
    });
  }
  
  goBack(): void {
    this.router.navigate(['/stations']);  // Trở lại trang danh sách trạm
  }

  onSubmit(): void {
    if (this.stationForm.invalid) {
      return;
    }

    const updatedStation: Station = {
      ...this.stationForm.value,
      stationID: +this.stationID  // Gán lại id của trạm
    };

    this.stationService.updateStation(+this.stationID, updatedStation).subscribe({
      next: () => {
        console.log('Station updated successfully');
        this.router.navigate(['/stations']);  
      },
      error: (err) => console.error('Error updating station', err)
    });
  }
}
