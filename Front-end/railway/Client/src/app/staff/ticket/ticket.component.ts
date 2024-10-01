import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TicketService } from '../../services/ticket.service';
import { Observable } from 'rxjs';
import { Ticket } from '../../interfaces/ticket';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-ticket',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './ticket.component.html',
  styleUrl: './ticket.component.css'
})
export class TicketComponent implements OnInit{
  PnrNo : number =0;
  ticketService = inject(TicketService);
  router = inject(Router);
  route = inject(ActivatedRoute);
  ticket$! : Observable<Ticket>;
  ngOnInit(): void {
    
  }
  searchTicket(PnrNo : number)
  {
      this.ticket$=this.ticketService.getDetail(PnrNo);
  }
  deleteticket(PnrNo : number)
  {
    const confirmation = confirm('Are you sure you want to delete this ticket?');
    if(confirmation) {
      this.ticketService.deleteTicket(+PnrNo).subscribe({
        next: () => {
          console.log('Ticket deleted successfully');
          this.router.navigate(['/ticket']);
        },
        error: (err) => console.error('Error deleting delete:', err)
      });
    }
  }
}
