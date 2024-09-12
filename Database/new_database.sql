USE eProject_RailwayReservation;

-- Bảng TrainRoutes
INSERT INTO TrainRoutes (TrainRouteName) VALUES
('Tuyến Hà Nội - Sài Gòn'),
('Tuyến Hà Nội - Đà Nẵng'),
('Tuyến Hà Nội - Hải Phòng'),
('Tuyến Hà Nội - Cần Thơ'),
('Tuyến Sài Gòn - Đà Nẵng');

-- Bảng Stations
INSERT INTO Stations (StationCode, StationName, RailwayDivisionName) VALUES
('HN', 'Hà Nội', 'Miền Bắc'),
('HP', 'Hải Phòng', 'Miền Bắc'),
('DN', 'Đà Nẵng', 'Miền Trung'),
('SG', 'Sài Gòn', 'Miền Nam'),
('CT', 'Cần Thơ', 'Miền Nam');

-- Bảng Trains
INSERT INTO Trains (TrainName, TrainRouteDetails, NumberOfCompartments, TrainRouteID) VALUES
('SE1', 'Hà Nội - Sài Gòn', 12, 1),
('SE2', 'Hà Nội - Đà Nẵng', 10, 2),
('SE3', 'Hà Nội - Hải Phòng', 8, 3),
('SE4', 'Hà Nội - Cần Thơ', 15, 4),
('SE5', 'Sài Gòn - Đà Nẵng', 10, 5);

-- Bảng Compartments
INSERT INTO Compartments (TrainID, CompartmentType, NumberOfSeats) VALUES
(1, 'Thường', 50),
(1, 'Cao cấp', 30),
(2, 'Thường', 60),
(3, 'Cao cấp', 40),
(4, 'Thường', 55);

-- Bảng Schedules
INSERT INTO Schedules (TrainID, TrainRouteID, DepartureTime, ArrivalTime, DayOfWeek) VALUES
(1, 1, '08:00:00', '20:00:00', 'Monday'),
(2, 2, '09:00:00', '21:00:00', 'Tuesday'),
(3, 3, '10:00:00', '22:00:00', 'Wednesday'),
(4, 4, '11:00:00', '23:00:00', 'Thursday'),
(5, 5, '12:00:00', '00:00:00', 'Friday');

-- Bảng RouteStations
INSERT INTO RouteStations (TrainRouteID, StationID, OrderInRoute) VALUES
(1, 1, 1),
(1, 2, 2),
(2, 3, 3),
(3, 4, 4),
(4, 5, 5);

-- Bảng Tickets
INSERT INTO Tickets (Name, Age, Gender, TotalPassengers) VALUES
('Nguyễn Văn A', 25, 'M', 1),
('Trần Thị B', 30, 'F', 2),
('Lê Văn C', 22, 'M', 1),
('Phạm Thị D', 40, 'F', 1),
('Đinh Văn E', 35, 'M', 3);

-- Bảng Reservations 
INSERT INTO Reservations (PnrNo, DateOfJourney, TotalFare) VALUES
( 1, '2024-09-10', 500000),
( 2, '2024-09-11', 300000),
( 3, '2024-09-12', 600000),
( 4, '2024-09-13', 800000),
( 5, '2024-09-14', 1000000);

-- Bảng Trips
INSERT INTO Trips ( ReservationID, ScheduleID, StartStationID, EndStationID, DepartureTime, ArrivalTime, TravelTime) VALUES
(1, 1, 1, 2, '08:00:00', '20:00:00', '12:00:00'),
(2, 2, 3, 4, '09:00:00', '21:00:00', '12:00:00'),
(3, 3, 2, 3, '10:00:00', '22:00:00', '12:00:00'),
(4, 4, 1, 4, '11:00:00', '23:00:00', '12:00:00'),
(5, 5, 1, 5, '12:00:00', '00:00:00', '12:00:00');

-- Bảng Seats 
INSERT INTO Seats (CompartmentID, SeatNumber, SeatStatus, SeatType, Fare, ReservationID) VALUES
(1, '01A', 'Available', 'Ghế mềm', 500000, 1),
(1, '02A', 'Booked', 'Ghế mềm', 500000, 1),
(2, '03B', 'Available', 'Ghế cứng', 300000, 2),
(3, '04A', 'Booked', 'Ghế cứng', 300000, 2),
(4, '05B', 'Available', 'Ghế mềm', 500000, 3);

