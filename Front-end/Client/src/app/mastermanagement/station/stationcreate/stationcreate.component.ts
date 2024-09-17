import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { StationService } from '../../../services/station.service';
import { Station } from '../../../interfaces/station';

@Component({
  selector: 'app-stationcreate',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './stationcreate.component.html',
  styleUrl: './stationcreate.component.css'
})
export class StationcreateComponent {
  stationService = inject(StationService);
  fb = inject(FormBuilder);
  router = inject(Router);

  stationForm!: FormGroup;

  ngOnInit(): void {
    this.initForm();
  }

  initForm():void {
    this.stationForm = this.fb.group({
      stationCode: ['', [Validators.required]], 
      stationName: ['', [Validators.required]],
      railwayDivisionName: ['', [Validators.required]]
    });
  }

  goBack(): void {
    this.router.navigate(['/stations']);  // Trở lại trang danh sách trạm
  }

  onSubmit(): void {
    if (this.stationForm.invalid) {
      return;
    }

    const newStation: Station = {
      stationId: 0,  // ID có thể được server gán sau khi tạo
      ...this.stationForm.value // Lấy các giá trị từ form
    };

    console.log('Data being sent:', newStation);

    this.stationService.addStation(newStation).subscribe({
      next: (station) => {
        console.log('Station created: ', station);
        this.router.navigate(['/stations']);
      },
      error: (err) => console.error('Error creating station', err)
    });
  }
}
