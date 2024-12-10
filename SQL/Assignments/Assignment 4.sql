use Tests

--SOLUTION 1
DECLARE @Number INT = 5; 
DECLARE @Factorial INT = 1;
DECLARE @Counter INT = 1;

WHILE @Counter <= @Number
BEGIN
    SET @Factorial = @Factorial * @Counter;
    SET @Counter = @Counter + 1;
END
SELECT @Factorial AS Factorial;

--SOLUTION 2
CREATE OR ALTER PROCEDURE MultiplicationTable
    @Number INT, 
    @Range INT
AS
BEGIN
    IF @Range <= 0
    BEGIN
        PRINT 'The range must be positive';
        RETURN;
    END
    DECLARE @Counter INT = 1;
    WHILE @Counter <= @Range
    BEGIN
        PRINT @Number * @Counter; 
        SET @Counter = @Counter + 1;
    END
END;
EXEC MultiplicationTable @Number = 5, @Range = 10;


--SOLUTION 3

CREATE TABLE Student (
    Sid INT PRIMARY KEY,
    Sname VARCHAR(50)
);
CREATE TABLE Marks (
    Mid INT PRIMARY KEY,
    Sid INT,
    Score INT,
    CONSTRAINT FK_Sid FOREIGN KEY (Sid) REFERENCES Student(Sid)
);
INSERT INTO Student (Sid, Sname) 
VALUES 
    (1, 'Jack'),
    (2, 'Rithvik'),
    (3, 'Jaspreeth'),
    (4, 'Praveen'),
    (5, 'Bisa'),
    (6, 'Suraj');
INSERT INTO Marks (Mid, Sid, Score) 
VALUES 
    (1, 1, 23),
    (2, 6, 95),
    (3, 4, 98),
    (4, 2, 17),
    (5, 3, 53),
    (6, 5, 13);

CREATE OR ALTER FUNCTION dbo.StudentStatus (@Sid INT)
RETURNS VARCHAR(10)
AS
BEGIN
DECLARE @Status VARCHAR(10);
 
DECLARE @Score INT;
SELECT @Score = Score
FROM Marks
WHERE Sid = @Sid;

IF @Score >= 50
SET @Status = 'Pass';
ELSE
SET @Status = 'Fail';
RETURN @Status;
END;

SELECT S.Sid,S.Sname,M.Score,dbo.StudentStatus(S.Sid) AS FinalStatus FROM Student S JOIN Marks M ON S.Sid = M.Sid ORDER BY S.Sid;


