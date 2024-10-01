import { Seat } from "./seat";
import { Train } from "./train";
import { Trainall } from "./traingetall";


export interface Compartmentdetail {
    compartmentID: number;
    trainID: number;
    compartmentType: string;
    seatType: string;
    numberOfSeats: number;
    train :Trainall[];
    seat:Seat[];
}
  