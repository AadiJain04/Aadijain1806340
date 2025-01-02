use Railways

CREATE TABLE Admin (
    AdminID INT PRIMARY KEY IDENTITY(1,1)
);
 

CREATE TABLE Train (
    TrainID INT PRIMARY KEY IDENTITY,
    TrainName VARCHAR(100),
    Source VARCHAR(100),
    Destination VARCHAR(100),
    TotalBerths INT,
    AvailableBerths INT,
    IsActive BIT,
    TrainClass VARCHAR(50) 
);

 
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1)
);
 
CREATE TABLE Booking (
    BookingID INT PRIMARY KEY IDENTITY,
	UserId INT,
    TrainID INT,     
    SeatsBooked INT,
    BookingDate DATETIME DEFAULT GETDATE(),
    Status VARCHAR(20) DEFAULT 'Booked', 
    FOREIGN KEY (TrainID) REFERENCES Train(TrainID) 
);

ALTER TABLE Booking ADD TrainClass VARCHAR(50);

 

 -------------------------------------------Procedures for admin------------------------------------------

-- Procedure for adding the train
CREATE OR ALTER PROCEDURE AddTrain
    @TrainName NVARCHAR(50),
    @Source NVARCHAR(50),
    @Destination NVARCHAR(50),
    @TotalBerths INT,
    @TrainClass VARCHAR(50) = 'AC'
AS
BEGIN
    INSERT INTO Train (TrainName, Source, Destination, TotalBerths, AvailableBerths, IsActive, TrainClass)
    VALUES (@TrainName, @Source, @Destination, @TotalBerths, @TotalBerths, 1, @TrainClass);
END

 
 --Procedure for modifying the train
CREATE OR ALTER PROCEDURE ModifyTrain
    @TrainID INT, 
    @TrainName NVARCHAR(50),
    @Source NVARCHAR(50),
    @Destination NVARCHAR(50)
AS
BEGIN
    UPDATE Train 
    SET TrainName = @TrainName, Source = @Source, Destination = @Destination
    WHERE TrainID = @TrainID;
END
 
--Procedure for deleting the train
CREATE OR ALTER PROCEDURE DeleteTrain
@TrainID INT
AS
BEGIN
    UPDATE Train
    SET IsActive = 0
    WHERE TrainID = @TrainID;
END
 
 --------------------------------------procedures for user-----------------------------------------------

 --Procedure for booking the ticket
CREATE OR ALTER PROCEDURE BookTicket
    @TrainID INT,
    @SeatsBooked INT,
    @TrainClass VARCHAR(50)
AS
BEGIN
    IF EXISTS (
        SELECT *
        FROM Train
        WHERE TrainID = @TrainID
        AND AvailableBerths >= @SeatsBooked
    )
    BEGIN
        UPDATE Train
        SET AvailableBerths = AvailableBerths - @SeatsBooked
        WHERE TrainID = @TrainID;

        INSERT INTO Booking (TrainID, SeatsBooked, BookingDate, TrainClass) -- Include TrainClass
        VALUES (@TrainID, @SeatsBooked, GETDATE(), @TrainClass);

        PRINT 'Ticket booked';
    END
    ELSE
    BEGIN
        PRINT 'Not enough available seats for this booking';
    END
END;


 --Procedure for cancelling the ticket
CREATE OR ALTER PROCEDURE CancelTicket
@BookingID INT
AS
BEGIN
    DECLARE @Seats INT, @TrainID INT;

    SELECT @Seats = SeatsBooked, @TrainID = TrainID
    FROM Booking
    WHERE BookingID = @BookingID;
 
    DELETE FROM Booking WHERE BookingID = @BookingID;
 
    UPDATE Train
    SET AvailableBerths = AvailableBerths + @Seats
    WHERE TrainID = @TrainID;
END
 

  --Procedure for showing all trains 
CREATE OR ALTER PROCEDURE ShowTrains
AS
BEGIN
    SELECT TrainID, TrainName, Source, Destination, TotalBerths, AvailableBerths, IsActive, TrainClass
    FROM Train
    WHERE IsActive = 1;
END

 select * from Train
 select * from booking