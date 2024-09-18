export interface Schedule {
    scheduleID: number;
    trainID: number;
    trainRouteID: number;
    departureTime: string;  // Kiểu dữ liệu TimeSpan có thể chuyển thành chuỗi ở Angular
    arrivalTime: string;
    dayOfWeek: string;
}
  