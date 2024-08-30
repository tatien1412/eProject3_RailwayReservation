create database eProject_RailwayReservation

use eProject_RailwayReservation
-- Users
SET IDENTITY_INSERT Users ON;
INSERT INTO Users (UserID, UserName, Password, Role)
VALUES 
(1, 'john_doe', 'password123', 'Admin'),
(2, 'jane_smith', 'password456', 'Master Management'),
(3, 'michael_clark', 'password789', 'Master Management'),
(4, 'susan_lee', 'password321', 'Transaction Staff'),
(5, 'robert_brown', 'password654', 'Transaction Staff');

SET IDENTITY_INSERT Users OFF;

-- Stations
SET IDENTITY_INSERT Stations ON;
INSERT INTO Stations (StationID, StationCode, StationName, RailwayDivisionName)
VALUES 
(1, 'HCM', 'Ho Chi Minh City', 'South'),
(2, 'HN', 'Hanoi', 'North'),
(3, 'DN', 'Da Nang', 'Central'),
(4, 'NT', 'Nha Trang', 'Central'),
(5, 'CT', 'Can Tho', 'South');
SET IDENTITY_INSERT Stations OFF;

-- Trains
SET IDENTITY_INSERT Trains ON;
INSERT INTO Trains (TrainID, TrainName, Route, NumberOfCompartments)
VALUES 
(1, 'Express 01', 'HCM-HN', 10),
(2, 'Express 02', 'HN-HCM', 8),
(3, 'Coastal 03', 'HCM-DN', 7),
(4, 'Mountain 04', 'HN-NT', 6),
(5, 'Southern 05', 'HCM-CT', 9);
SET IDENTITY_INSERT Trains OFF;

-- Schedules
SET IDENTITY_INSERT Schedules ON;
INSERT INTO Schedules (ScheduleID, TrainNo, StartStationID, EndStationID, DepartureTime, ArrivalTime, DayOfWeek)
VALUES 
(1, 1, 1, 2, '06:00', '18:00', 'Monday'),
(2, 2, 2, 1, '06:00', '18:00', 'Tuesday'),
(3, 3, 1, 3, '07:00', '15:00', 'Wednesday'),
(4, 4, 2, 4, '08:00', '16:00', 'Thursday'),
(5, 5, 1, 5, '09:00', '17:00', 'Friday');
SET IDENTITY_INSERT Schedules OFF;

-- Reservations
SET IDENTITY_INSERT Reservations ON;
INSERT INTO Reservations (ReservationID, PnrNo, UserID, TrainNo, ScheduleID, FromStationID, ToStationID, SeatNo, DateOfJourney, CoachNo, Fare, CancellationStatus)
VALUES 
(1, 1001, 1, 1, 1, 1, 2, 'A1', '2024-09-01', 'C1', 150.00, 'None'),
(2, 1002, 2, 2, 2, 2, 1, 'B2', '2024-09-02', 'C2', 120.00, 'None'),
(3, 1003, 3, 3, 3, 1, 3, 'C3', '2024-09-03', 'C3', 110.00, 'None'),
(4, 1004, 4, 4, 4, 2, 4, 'D4', '2024-09-04', 'C4', 130.00, 'Cancelled'),
(5, 1005, 5, 5, 5, 1, 5, 'E5', '2024-09-05', 'C5', 140.00, 'None');
SET IDENTITY_INSERT Reservations OFF;

-- Tickets
SET IDENTITY_INSERT Tickets ON;
INSERT INTO Tickets (PnrNo, Name, Age, Gender, TotalPassengers, ReservationID)
VALUES 
(1001, 'John Doe', 35, 'M', 1, 1),
(1002, 'Jane Smith', 30, 'F', 2, 2),
(1003, 'Michael Clark', 40, 'M', 1, 3),
(1004, 'Susan Lee', 28, 'F', 1, 4),
(1005, 'Robert Brown', 45, 'M', 3, 5);

SET IDENTITY_INSERT Tickets OFF;


-- Fares
SET IDENTITY_INSERT Fares ON;
INSERT INTO Fares (FareID, ReservationID, Distance, CompartmentType, TrainType, Amount)
VALUES 
(1, 1, 1700, 'First Class', 'Express', 150.00),
(2, 2, 1700, 'Second Class', 'Express', 120.00),
(3, 3, 1000, 'Second Class', 'Coastal', 110.00),
(4, 4, 1200, 'First Class', 'Mountain', 130.00),
(5, 5, 1500, 'Second Class', 'Southern', 140.00);
SET IDENTITY_INSERT Fares OFF;
