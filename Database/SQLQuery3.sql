--Users
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'100a50ec-945e-454b-b39b-09912603f822', N'Transaction Staff', N'TRANSACTION STAFF', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c7bb04c0-891f-4bfd-b296-6966a7cff24c', N'Admin', N'ADMIN', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'fb22492b-8ef8-41bd-90a0-f8812e8ba33d', N'Master Manager', N'MASTER MANAGER', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'93cd748d-5819-4602-a2e5-05a2eee58351', N'100a50ec-945e-454b-b39b-09912603f822')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6557ee48-ccd4-4868-9cef-6bf6a071a3b2', N'c7bb04c0-891f-4bfd-b296-6966a7cff24c')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a5766493-4e4e-443c-b4ab-48525ab81973', N'fb22492b-8ef8-41bd-90a0-f8812e8ba33d')
GO
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6557ee48-ccd4-4868-9cef-6bf6a071a3b2', N'ADMIN', N'admin123@gmail.com', N'ADMIN123@GMAIL.COM', N'admin123@gmail.com', N'ADMIN123@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAELcfA+Bnp1Y0UnzbImAzZ3eJ6mHwE9gDB/eLNwhwUquhwLe1Gw1+SglVG3alYlE/aA==', N'FNYADZVWCL3CMMUBQVCAXBKOKOZGVELR', N'0251cba6-6ff2-47cf-81fe-eb43865d6edf', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'93cd748d-5819-4602-a2e5-05a2eee58351', N'STAFF', N'staff123@gmail.com', N'STAFF123@GMAIL.COM', N'staff123@gmail.com', N'STAFF123@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAED036b+bNMwwDhlgzauzug98TwhLs1bM8oPUaCZGQT0z4ngKAdZXbLXH9mkx9szwAg==', N'UFRASO7LSPU6ZH2LF7TQWNCGD75NLEQI', N'90eabeee-0293-4545-9711-78b7b36f390c', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a5766493-4e4e-443c-b4ab-48525ab81973', N'MASTER', N'master123@gmail.com', N'MASTER123@GMAIL.COM', N'master123@gmail.com', N'MASTER123@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEFQs6TRcLdm9Zepta4Wb9f5FqbYRy8i4kMPOP8prWi+l1EAd7cBDSR8XoIi8mDJ7AA==', N'SBNZVPZCSRM32NDE35E24L6BX2MCDN6M', N'1c32f90c-2236-44b0-9e6d-69e25f2b8b73', NULL, 0, 0, NULL, 1, 0)
GO
-- Bảng TrainRoutes
INSERT INTO TrainRoutes (TrainRouteName) VALUES
(N'Tuyến Hà Nội - Sài Gòn'),
(N'Tuyến Hà Nội - Đà Nẵng'),
(N'Tuyến Hà Nội - Hải Phòng'),
(N'Tuyến Hà Nội - Cần Thơ'),
(N'Tuyến Sài Gòn - Đà Nẵng');

-- Bảng Stations
INSERT INTO Stations (StationCode, StationName, RailwayDivisionName) VALUES
(N'HN', N'Hà Nội', N'Miền Bắc'),
(N'HP', N'Hải Phòng', N'Miền Bắc'),
(N'DN', N'Đà Nẵng', N'Miền Trung'),
(N'SG', N'Sài Gòn', N'Miền Nam'),
(N'CT', N'Cần Thơ', N'Miền Nam');
-- Bảng Trains
INSERT INTO Trains (TrainName, TrainStatus, NumberOfCompartments, TrainRouteID) VALUES
(N'SE1', N'Dừng', 5, 1),
(N'SE2', N'Khởi hành', 4, 2),
(N'SE3', N'Khởi hành', 5, 3),
(N'SE4', N'Dừng', 3, 4),
(N'SE5', N'Đang đi', 6, 5);

-- Giả định rằng bảng Compartment có các cột: TrainID, CompartmentType, NumberOfSeats, SeatType
-- Dựa trên NumberOfCompartments của bảng Trains để thêm dữ liệu

-- Chèn dữ liệu vào bảng Compartment dựa trên số lượng khoang của từng tàu
-- Chèn dữ liệu vào bảng Compartment dựa trên số lượng khoang của từng tàu
INSERT INTO Compartments (TrainID, CompartmentType, SeatType, NumberOfSeats)
SELECT 
    TrainID,
    CASE
        WHEN CompartmentIndex % 2 = 0 THEN N'Cao cấp' -- Các khoang chẵn là Cao cấp
        ELSE N'Thường'                               -- Các khoang lẻ là Thường
    END AS CompartmentType,
    CASE
        WHEN CompartmentIndex % 2 = 0 THEN N'Ghế giường nằm' -- Ghế giường nằm cho khoang Cao cấp
        ELSE N'Ghế thường'                                   -- Ghế thường cho khoang Thường
    END AS SeatType,
    CASE
        WHEN CompartmentIndex % 2 = 0 THEN 30    -- Khoang Cao cấp có 30 ghế
        ELSE 50                                  -- Khoang Thường có 50 ghế
    END AS NumberOfSeats
FROM (
    SELECT 
        T.TrainID,
        ROW_NUMBER() OVER (PARTITION BY T.TrainID ORDER BY T.TrainID) AS CompartmentIndex
    FROM Trains T
    CROSS APPLY (SELECT TOP (T.NumberOfCompartments) 1 AS Dummy FROM master.dbo.spt_values) AS X -- Tạo từng khoang dựa trên NumberOfCompartments
) AS Temp;

-- Bảng Schedules
INSERT INTO Schedules (TrainID, TrainRouteID, DepartureTime, ArrivalTime, DayOfWeek) VALUES
(1, 1, '08:00:00', '20:00:00', N'Monday'),
(2, 2, '09:00:00', '21:00:00', N'Tuesday'),
(3, 3, '10:00:00', '22:00:00', N'Wednesday'),
(4, 4, '11:00:00', '23:00:00', N'Thursday'),
(5, 5, '12:00:00', '00:00:00', N'Friday');

-- Bảng RouteStations
INSERT INTO RouteStations (TrainRouteID, StationID, OrderInRoute) VALUES
(1, 1, 1),
(1, 2, 2),
(2, 3, 3),
(3, 4, 4),
(4, 5, 5);