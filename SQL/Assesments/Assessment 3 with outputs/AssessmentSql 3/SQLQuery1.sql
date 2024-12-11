use Assessment

CREATE TABLE Coursedetails(
    C_id VARCHAR(10) PRIMARY KEY,
    C_Name VARCHAR(50),
    Start_date DATE,
    End_date DATE,
    Fee INT
);

INSERT INTO Coursedetails(C_id, C_Name, Start_date, End_date, Fee) VALUES
('DN003', 'DotNet', '2018-02-01', '2018-02-28', 15000),
('DV004', 'DataVisualization', '2018-03-01', '2018-04-15', 15000),
('JA002', 'AdvancedJava', '2018-01-02', '2018-01-20', 10000),
('JC001', 'CoreJava', '2018-01-02', '2018-01-12', 3000);
SELECT * FROM Coursedetails


-----------SOLUTION 1---------------
CREATE OR ALTER FUNCTION Duration(
    @SDate DATE,
    @EDate DATE
)
RETURNS INT
AS
BEGIN
    RETURN DATEDIFF(DAY, @SDate, @EDate)
END;
SELECT C_id,C_Name,Start_date,End_date,Fee,dbo.Duration(Start_date, End_date) AS DurationInDays FROM Coursedetails;


---------------SOLUTION 2-----------------------
CREATE TABLE CourseInfo(
    C_Name VARCHAR(50),
    Start_date DATE
);
CREATE OR ALTER TRIGGER InsertingInfo
ON Coursedetails
AFTER INSERT
AS
BEGIN
    INSERT INTO CourseInfo (C_Name, Start_date)
    SELECT C_Name, Start_date
    FROM Coursedetails;
END;

INSERT INTO Coursedetails (C_id, C_Name, Start_date, End_date, Fee) VALUES 
('CPP005', 'C++', '2024-01-01', '2024-01-15', 11000);
SELECT * FROM CourseInfo;


-------------------SOLUTION 3--------------------
CREATE TABLE ProductsDetails (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName VARCHAR(100),
    Price FLOAT,
    DiscountedPrice FLOAT
);

CREATE OR ALTER PROCEDURE InsertingPDetails
    @ProductName VARCHAR(30),
    @Price FLOAT,
    @GeneratedProductId INT OUTPUT,
    @DiscountedPrice FLOAT OUTPUT
AS
BEGIN
    SET @DiscountedPrice = @Price - (@Price * 0.1);
    
    INSERT INTO ProductsDetails (ProductName, Price, DiscountedPrice) VALUES (@ProductName, @Price, @DiscountedPrice);
    SET @GeneratedProductId = SCOPE_IDENTITY();
END;
