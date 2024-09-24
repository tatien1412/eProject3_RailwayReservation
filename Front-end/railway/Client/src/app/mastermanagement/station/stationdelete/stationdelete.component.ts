import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { StationService } from '../../../services/station.service';
import { Station } from '../../../interfaces/station';

@Component({
  selector: 'app-stationdelete',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './stationdelete.component.html',
  styleUrls: ['./stationdelete.component.css']
})
export class StationdeleteComponent {
  stationService = inject(StationService);
  router = inject(Router);
  route = inject(ActivatedRoute);

  stationDetail$!: Observable<Station>;

  ngOnInit(): void {
    const stationID = this.route.snapshot.paramMap.get('stationID')!;
    this.stationDetail$ = this.stationService.getDetail(+stationID);
  }

  confirmDelete(stationID: number): void {
    const confirmation = confirm('Are you sure you want to delete this station?');
    if(confirmation) {
      this.stationService.deleteStation(+stationID).subscribe({
        next: () => {
          console.log('Station deleted successfully');
          this.router.navigate(['/stations']);
        },
        error: (err) => console.error('Error deleting station:', err)
      });
    }
  }

  goBack(): void {
    this.router.navigate(['/stations']);  // Trở lại trang danh sách trạm
  }
}
