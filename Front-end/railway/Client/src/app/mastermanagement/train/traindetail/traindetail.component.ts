import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { Train } from '../../../interfaces/train';
import { TrainService } from '../../../services/train.service';
import { CompartmentService } from '../../../services/compartment.service';
import { ScheduleService } from '../../../services/schedule.service';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-train-detail',
  standalone: true,  
  imports: [CommonModule, ReactiveFormsModule, MatIconModule],  
  templateUrl: './traindetail.component.html',
  styleUrls: ['./traindetail.component.css']
})
export class TraindetailComponent implements OnInit {
  trainDetail$!: Observable<Train>;  // Observable chứa dữ liệu chi tiết tàu
  compartments: number[] = [];
  createdCompartments: number[] = [];  // Để theo dõi các khoang đã tạo
  selectedCompartment: number | null = null;
  showCompartmentForm = false;
  showScheduleForm = false;

  compartmentForm!: FormGroup;  // Form cho tạo khoang
  scheduleForm!: FormGroup;  // Form cho tạo lịch trình

  private trainService = inject(TrainService);
  private compartmentService = inject(CompartmentService);
  private scheduleService = inject(ScheduleService);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private fb = inject(FormBuilder);

  ngOnInit(): void {
    const trainID = +this.route.snapshot.paramMap.get('trainID')!;
    this.trainDetail$ = this.trainService.getDetail(trainID);  // Gọi API để lấy chi tiết tàu

    this.trainDetail$.subscribe((train) => {
      // Lưu danh sách khoang đã được tạo (để hiện dấu tích)
      this.createdCompartments = train.compartments.map(c => c.compartmentID);
      
      // Tạo danh sách các khoang chưa tạo dựa trên tổng số khoang và số khoang đã tạo
      const totalCompartments = train.numberOfCompartments;
      const createdCount = train.compartments.length;
      this.compartments = Array.from({ length: totalCompartments - createdCount }, (_, i) => i + 1);
    });

    // Tạo form khoang
    this.compartmentForm = this.fb.group({
      compartmentType: ['', Validators.required],
      seatType: ['Normal', Validators.required],
      numberOfSeats: [50, Validators.required]
    });

    // Tạo form lịch trình
    this.scheduleForm = this.fb.group({
      dayOfWeek: ['', Validators.required],
      departureTime: ['', [Validators.required, Validators.pattern('^([01]\\d|2[0-3]):([0-5]\\d)$')]],
      arrivalTime: ['', [Validators.required, Validators.pattern('^([01]\\d|2[0-3]):([0-5]\\d)$')]],
      dateOfTravel: ['', Validators.required],
    });
  }
  // Xử lý quay lại
  goBack(): void {
    this.router.navigate(['/trains']);  // Điều hướng về trang danh sách tàu
  }

  // Mở form tạo khoang
  openCompartmentForm(): void {
    this.showCompartmentForm = true;
  }

  // Đóng form tạo khoang
  closeCompartmentForm(): void {
    this.showCompartmentForm = false;
  }

  // Mở form tạo lịch trình
  openScheduleForm(): void {
    this.showScheduleForm = true;
  }

  // Đóng form tạo lịch trình
  closeScheduleForm(): void {
    this.showScheduleForm = false;
  }

  // Xử lý khi chọn khoang
  selectCompartment(compartment: number): void {
    if (this.createdCompartments.includes(compartment)) {
      return;  // Không cho phép chọn lại nếu đã tạo khoang
    }
    this.selectedCompartment = compartment;
  }

  // Tạo khoang mới
  createCompartment(): void {
    if (this.compartmentForm.invalid || this.selectedCompartment === null) {
      return;
    }

    const compartmentData = {
      trainID: +this.route.snapshot.paramMap.get('trainID')!,  // Lấy trainID hiện tại
      ...this.compartmentForm.value
    };

    this.compartmentService.addCompartment(compartmentData).subscribe({
      next: () => {
        this.createdCompartments.push(this.selectedCompartment!);  // Thêm khoang đã tạo vào danh sách
        this.selectedCompartment = null;  // Reset lại lựa chọn
        this.compartmentForm.reset();  // Reset form sau khi tạo
        this.trainDetail$ = this.trainService.getDetail(+this.route.snapshot.paramMap.get('trainID')!);  // Cập nhật lại chi tiết tàu
      },
      error: (err) => console.error('Error creating compartment', err)
    });
  }

  // Tạo lịch trình mới
  createSchedule(): void {
    if (this.scheduleForm.invalid) {
      return;
    }

    const scheduleData = {
      trainID: +this.route.snapshot.paramMap.get('trainID')!,  // Lấy trainID hiện tại
      ...this.scheduleForm.value
    };

    this.scheduleService.addSchedule(scheduleData).subscribe({
      next: () => {
        this.closeScheduleForm();  // Đóng form tạo lịch trình sau khi tạo thành công
        this.trainDetail$ = this.trainService.getDetail(+this.route.snapshot.paramMap.get('trainID')!);  // Cập nhật lại chi tiết tàu
      },
      error: (err) => console.error('Error creating schedule:', err.error)  // In ra lỗi chi tiết
    });
  }
}
