import { AsyncPipe, CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { TrainService } from '../../../services/train.service';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { Train } from '../../../interfaces/train';
import { Observable } from 'rxjs';
import { MatButtonModule } from '@angular/material/button';
import { ScheduleService } from '../../../services/schedule.service';
import { CompartmentService } from '../../../services/compartment.service';

@Component({
  selector: 'app-traindelete',
  standalone: true,
  imports: [CommonModule, AsyncPipe, RouterModule, MatButtonModule],
  templateUrl: './traindelete.component.html',
  styleUrls: ['./traindelete.component.css']
})
export class TraindeleteComponent {
  trainService = inject(TrainService);
  scheduleService = inject(ScheduleService);
  compartmentService = inject(CompartmentService);
  router = inject(Router);
  route = inject(ActivatedRoute);

  trainDetail$!: Observable<Train>;

  ngOnInit(): void {
    const trainID = this.route.snapshot.paramMap.get('trainID')!;
    this.trainDetail$ = this.trainService.getDetail(+trainID);
  }

  confirmDelete(trainID: number): void {
    const confirmation = confirm('Are you sure you want to delete this train?');
    if(confirmation) {
      this.trainService.deleteTrain(+trainID).subscribe({
        next: () => {
          console.log('Train deleted successfully');
          this.router.navigate(['/trains']);
        },
        error: (err) => console.error('Error deleting train:', err)
      });
    }
  }

  goBack(): void {
    this.router.navigate(['/trains']);  
  }
  // Phương thức xóa lịch trình
  deleteSchedule(scheduleID: number): void {
    const confirmation = confirm('Are you sure you want to delete this schedule?');
    if (confirmation) {
      this.scheduleService.deleteSchedule(scheduleID).subscribe({
        next: () => {
          console.log('Schedule deleted successfully');
          // Sau khi xóa thành công, cập nhật lại thông tin tàu
          this.trainDetail$ = this.trainService.getDetail(+this.route.snapshot.paramMap.get('trainID')!);
        },
        error: (err) => console.error('Error deleting schedule:', err)
      });
    }
  }

  // Phương thức xóa khoang
  deleteCompartment(compartmentID: number): void {
    const confirmation = confirm('Are you sure you want to delete this compartment?');
    if (confirmation) {
      this.compartmentService.deleteCompartment(compartmentID).subscribe({
        next: () => {
          console.log('Compartment deleted successfully');
          // Sau khi xóa thành công, cập nhật lại thông tin tàu
          this.trainDetail$ = this.trainService.getDetail(+this.route.snapshot.paramMap.get('trainID')!);
        },
        error: (err) => console.error('Error deleting compartment:', err)
      });
    }
  }
}
