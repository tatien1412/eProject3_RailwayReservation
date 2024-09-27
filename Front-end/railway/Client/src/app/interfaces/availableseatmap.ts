export interface AvailableSeatMap{
    TotalAvailableSeatType1:number;
    TotalAvailableSeatType2:number;
    TotalAvailableSeatType3:number;
    FareAC1 : number;
    FareAC2 : number;
    FareAC3 : number;
    scheduleID: number;
    trainID: number;
    trainRouteID: number;
    departureTime: string;  
    arrivalTime: string;
    dayOfWeek: string;
    dateOfTravel:string;
}