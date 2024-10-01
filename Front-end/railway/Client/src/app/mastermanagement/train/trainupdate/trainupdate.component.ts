import { Component, OnInit, VERSION, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule, FormArray } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { TrainService } from '../../../services/train.service';
import { CompartmentService } from '../../../services/compartment.service';
import { ScheduleService } from '../../../services/schedule.service';
import { Train } from '../../../interfaces/train';
import { Compartment } from '../../../interfaces/compartment';
import { Schedule } from '../../../interfaces/schedule';
import { TrainRoute } from '../../../interfaces/train-route';
import { TrainRouteService } from '../../../services/train-route.service';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-trainupdate',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, MatSnackBarModule,  MatIconModule],
  templateUrl: './trainupdate.component.html',
  styleUrls: ['./trainupdate.component.css']
})
export class TrainupdateComponent implements OnInit {
  fb = inject(FormBuilder);
  trainService = inject(TrainService);
  trainRouteService = inject(TrainRouteService);
  compartmentService = inject(CompartmentService);
  scheduleService = inject(ScheduleService);
  router = inject(Router);
  route = inject(ActivatedRoute);
  snackBar = inject(MatSnackBar);
  showCompartmentForm = false;
  compartments: number[] = [];
  createdCompartments: number[] = [];  // Để theo dõi các khoang đã tạo
  selectedCompartment: number | null = null;

  trainForm!: FormGroup; // Form chính
  trainID: string = '';  // ID tàu để cập nhật
  trainDetail!: Train ;
  trainRoutes: TrainRoute[] = [];
  compartmentForm!: FormGroup;  // Form cho tạo khoang
  showDeleteButtons = false;

  ngOnInit(): void {
    this.initForm();
    this.trainID = this.route.snapshot.paramMap.get('trainID')!;  // Lấy train ID từ route
    this.getTrainDetail(+this.trainID);  // Lấy chi tiết tàu và điền vào form
    this.getTrainRoutes();
    // Lắng nghe sự thay đổi của số lượng khoang trong form
    this.trainForm.get('numberOfCompartments')?.valueChanges.subscribe((newCount) => {
      this.updateCompartmentsList(newCount);
    });
  }

  // Hàm cập nhật danh sách khoang mới cần tạo khi số lượng khoang thay đổi
  updateCompartmentsList(newCount: number): void {
    if (!this.trainDetail) return;

    // Lấy số khoang đã tạo và tổng số khoang mới cần tạo
    const createdCount = this.trainDetail.compartments.length;
    const remainingCompartments = newCount - createdCount;

    // Cập nhật trạng thái của nút delete
     this.showDeleteButtons = createdCount > newCount;

    // Tạo danh sách các khoang mới dựa trên số khoang còn lại
    this.compartments = Array.from({ length: remainingCompartments }, (_, i) => createdCount + i + 1);
  }
  // Khởi tạo form chính
  initForm(): void {
    this.trainForm = this.fb.group({
      trainName: ['', [Validators.required]],
      trainStatus: ['', [Validators.required]],
      numberOfCompartments: ['', [Validators.required]],
      trainRouteID: ['', [Validators.required]], // Lưu trainRouteID
      compartments: this.fb.array([]),  // FormArray cho compartments
      schedules: this.fb.array([])  // FormArray cho schedules
    });
    // Tạo form khoang
    this.compartmentForm = this.fb.group({
      compartmentType: ['AC1', Validators.required],
      seatType: ['Normal', Validators.required],
      numberOfSeats: [50, Validators.required]
    });
  }

  // FormArray cho Compartments
  get compartmentsFormArray(): FormArray {
    return this.trainForm.get('compartments') as FormArray;
  }

  // FormArray cho Schedules
  get schedulesFormArray(): FormArray {
    return this.trainForm.get('schedules') as FormArray;
  }

  // Khởi tạo FormGroup cho từng Compartment
  createCompartmentFormGroup(compartment: Compartment): FormGroup {
    return this.fb.group({
      compartmentType: [compartment.compartmentType || '', Validators.required],
      seatType: [compartment.seatType || '', Validators.required],
      numberOfSeats: [compartment.numberOfSeats || '', Validators.required]
    });
  }

  // Khởi tạo FormGroup cho từng Schedule
  createScheduleFormGroup(schedule: Schedule): FormGroup {
    return this.fb.group({
      dayOfWeek: [schedule.dayOfWeek || '', Validators.required],
      departureTime: [schedule.departureTime || '', Validators.required],
      arrivalTime: [schedule.arrivalTime || '', Validators.required],
      dateOfTravel: [schedule.dateOfTravel || '', Validators.required],
    });
  }

  // Lấy chi tiết tàu và cập nhật vào form
  getTrainDetail(trainID: number): void {
    this.trainService.getDetail(trainID).subscribe({
      next: (train: Train) => {
        this.trainDetail = train;
        // Cập nhật các giá trị của tàu
        this.trainForm.patchValue({
          trainName: train.trainName,
          trainStatus: train.trainStatus,
          numberOfCompartments: train.numberOfCompartments,
          trainRouteID: train.trainRoute.trainRouteID
        });

        // Cập nhật các compartment vào form
        this.compartmentsFormArray.clear();
        train.compartments.forEach(compartment => {
          this.compartmentsFormArray.push(this.createCompartmentFormGroup(compartment));
        });

        // Cập nhật các schedule vào form
        this.schedulesFormArray.clear();
        train.schedules.forEach(schedule => {
          this.schedulesFormArray.push(this.createScheduleFormGroup(schedule));
        });
      },
      error: (err) => console.error('Error fetching train details', err)
    });
  }
  // Lấy danh sách các train routes
  getTrainRoutes(): void {
    this.trainRouteService.getAllTrainRoutes().subscribe({
      next: (routes) => {
        this.trainRoutes = routes; // Lưu danh sách các route vào biến
      },
      error: (err) => console.error('Error fetching train routes', err)
    });
  }
  // Quay lại trang danh sách tàu
  goBack(): void {
    this.router.navigate(['/trains']);  
  }
  updateTrain(): void {
    if (this.trainForm.invalid) {
      return;
    }
    const updatedTrainData = {
      trainID: +this.trainID,
      trainName: this.trainForm.get('trainName')?.value,
      trainStatus: this.trainForm.get('trainStatus')?.value,
      trainRouteID: this.trainForm.get('trainRouteID')?.value,
      numberOfCompartments: this.trainForm.get('numberOfCompartments')?.value,
      trainRoute: this.trainDetail.trainRoute,  // Giữ nguyên trainRoute
      compartments: this.trainDetail.compartments,  // Giữ nguyên compartments
      schedules: this.trainDetail.schedules  // Giữ nguyên schedules
    };
  
    this.trainService.updateTrain(+this.trainID, updatedTrainData).subscribe({
      next: () => {
        console.log('Train updated successfully');
        this.snackBar.open('Train updated successfully!', 'Close', {
          duration: 5001
        });
        this.getTrainDetail(+this.trainID);
      },
      error: (err) => console.error('Error updating train:', err)
    });
  }
  
  updateSchedule(index: number, scheduleID: number): void {
    const updatedSchedule = {
      scheduleID: scheduleID,
      trainID: +this.trainID,
      departureTime: this.schedulesFormArray.at(index).get('departureTime')?.value,
      arrivalTime: this.schedulesFormArray.at(index).get('arrivalTime')?.value,
      dayOfWeek: this.schedulesFormArray.at(index).get('dayOfWeek')?.value,
      dateOfTravel: this.schedulesFormArray.at(index).get('dateOfTravel')?.value,
    };
  
    this.scheduleService.updateSchedule(scheduleID, updatedSchedule).subscribe({
      next: () => {
        console.log('Schedule updated successfully');
        this.snackBar.open('Schedule updated successfully!', 'Close', {
          duration: 5001
        });
        this.getTrainDetail(+this.trainID);
      },
      error: (err) => console.error('Error updating schedule:', err)
    });
  }
  
  updateCompartment(index: number, compartmentID: number): void {
    const updatedCompartment = {
      compartmentID: compartmentID,
      trainID: +this.trainID, // Giả định bạn có trainID từ route hoặc chi tiết tàu
      compartmentType: this.compartmentsFormArray.at(index).get('compartmentType')?.value,
      seatType: this.compartmentsFormArray.at(index).get('seatType')?.value,
      numberOfSeats: this.compartmentsFormArray.at(index).get('numberOfSeats')?.value
    };
  
    this.compartmentService.updateCompartment(compartmentID, updatedCompartment).subscribe({
      next: () => {
        console.log('Compartment updated successfully');
        this.snackBar.open('Compartment updated successfully!', 'Close', {
          duration: 5001
        });
        this.getTrainDetail(+this.trainID);
      },
      error: (err) => console.error('Error updating compartment:', err)
    });
  }
  // Mở form tạo khoang
  openCompartmentForm(): void {
    this.showCompartmentForm = true;
  }
  // Đóng form tạo khoang
  closeCompartmentForm(): void {
    this.showCompartmentForm = false;
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
        // Loại bỏ khoang đã tạo khỏi danh sách khoang mới (compartments)
        this.compartments = this.compartments.filter(c => c !== this.selectedCompartment);
        this.selectedCompartment = null;  // Reset lại lựa chọn
        this.compartmentForm.reset();  // Reset form sau khi tạo
        this.getTrainDetail(+this.trainID);      },
      error: (err) => console.error('Error creating compartment', err)
    });
  }
  // Xóa khoang ngẫu nhiên
  deleteCompartment(index: number): void {
    const compartmentID = this.trainDetail.compartments[index].compartmentID;

    this.compartmentService.deleteCompartment(compartmentID).subscribe({
      next: () => {
        console.log(`Compartment ${compartmentID} deleted successfully`);
        this.snackBar.open('Compartment deleted successfully!', 'Close', {
          duration: 5001,
        });

        // Cập nhật lại số lượng khoang sau khi xóa
        this.getTrainDetail(+this.trainID);
      },
      error: (err) => console.error('Error deleting compartment:', err),
    });
  }
  // Cập nhật thông tin tàu
  onSubmit(): void {
    if (this.trainForm.invalid) {
      return;
    }

    const updatedTrain: Train = {
      ...this.trainForm.value,
      trainID: +this.trainID  // Gán lại ID của tàu
    };

    this.trainService.updateTrain(+this.trainID, updatedTrain).subscribe({
      next: () => {
        console.log('Train updated successfully');
        this.router.navigate(['/trains']);  
      },
      error: (err) => console.error('Error updating train', err)
    });
  }
}
