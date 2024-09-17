import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { Router } from '@angular/router';
import { TrainService } from '../../../services/train.service';
import { CompartmentService } from '../../../services/compartment.service';
import { TrainRouteService } from '../../../services/train-route.service';
import { TrainRoute } from '../../../interfaces/train-route';

@Component({
  selector: 'app-create-train',
  standalone: true,  // Sử dụng standalone component
  imports: [CommonModule, ReactiveFormsModule,MatIconModule],  // Import CommonModule vào đây
  templateUrl: './traincreate.component.html',
  styleUrls: ['./traincreate.component.css']
})
export class TraincreateComponent implements OnInit {
  trainForm!: FormGroup;
  trainRoutes: TrainRoute[] = [];  // Danh sách TrainRoute lấy từ API
  fb = inject(FormBuilder);
  router = inject(Router);
  trainService = inject(TrainService);
  trainRouteService = inject(TrainRouteService);

  ngOnInit(): void {
    this.trainForm = this.fb.group({
      trainName: ['', Validators.required],
      trainRouteDetails: ['', Validators.required],
      numberOfCompartments: [0, Validators.required], // Số lượng khoang
      trainRouteID: ['', Validators.required] 
    });
    this.trainRouteService.getAllTrainRoutes().subscribe({
      next: (routes: TrainRoute[]) => {
        this.trainRoutes = routes;
      },
      error: (err) => console.error('Error fetching train routes', err)
    });
  }

  // Xử lý khi bấm "Create Train"
  onSubmit(): void {
    if (this.trainForm.invalid) {
      return;
    }

    const trainData = {
      ...this.trainForm.value
    };

    // Gọi API để tạo tàu
    this.trainService.addTrain(trainData).subscribe({
      next: (train) => {
        console.log('Train created successfully:', train);
        this.router.navigate(['/trains']);
      },
      error: (err) => console.error('Error creating train:', err)
    });
  }

  goBack(): void {
    this.router.navigate(['/trains']); // Điều hướng quay lại danh sách tàu
  }
}

