import { TrainRoute } from './train-route';
import { Compartment } from './compartment';
import { Schedule } from './schedule';

export interface Train {
  trainID: number;
  trainName: string;
  trainRouteDetails: string;
  numberOfCompartments: number;
  trainRouteID: number;
  trainRoute: TrainRoute;  // Khóa ngoại TrainRoute
  compartments: Compartment[];  // Danh sách các khoang
  schedules: Schedule[];  // Danh sách các lịch trình
}
