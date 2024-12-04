use Assessment


------------------SOLUTION 1----------------------------
SELECT DATENAME(WEEKDAY,'2002-03-02') AS DAY_OF_WEEK


------------------SOLUTION 2---------------------------- 
SELECT DATEDIFF(DAY, '2002-03-02', GETDATE()) AS AGE_IN_DAYS


------------------SOLUTION 3----------------------------
USE TESTS
SELECT * FROM EMPLOYEES WHERE DATEDIFF(YEAR, HIREDATE, GETDATE()) >= 5 AND MONTH(HIREDATE) = MONTH(GETDATE());


------------------SOLUTION 4----------------------------
USE Assessment
CREATE TABLE Employee (empno INT PRIMARY KEY,ename VARCHAR(50),sal DECIMAL(10, 2),doj DATE);

--Insert 3 rows
BEGIN TRANSACTION
INSERT INTO Employee (empno, ename, sal, doj) VALUES (101, 'Aadi', 60000, '2024-06-01');
INSERT INTO Employee (empno, ename, sal, doj) VALUES (102, 'Ramneet', 65000, '2023-05-15');
INSERT INTO Employee (empno, ename, sal, doj) VALUES (103, 'Kishor', 45000, '2023-03-20');
SAVE TRANSACTION INSERTROW;
SELECT * FROM Employee

--Update the second row's salary with a 15% increment
UPDATE Employee SET sal = sal *1.15 WHERE empno = 102;
SAVE TRANSACTION UPDATEROW;
SELECT * FROM Employee

--Delete the first row
DELETE FROM Employee WHERE empno = 101;
SAVE TRANSACTION DELETEROW

ROLLBACK TRANSACTION INSERTROWS;
COMMIT TRANSACTION
SELECT * FROM Employee


------------------SOLUTION 5----------------------------
use Tests
GO
CREATE OR ALTER FUNCTION CALCULATEBONUS(@deptno INT, @sal FLOAT)
RETURNS FLOAT
AS
BEGIN
   DECLARE @bonus FLOAT;
   IF @deptno = 10
       SET @bonus = @sal * 0.15;
   ELSE IF @deptno = 20
       SET @bonus = @sal * 0.20;
   ELSE
       SET @bonus = @sal * 0.05;
   RETURN @bonus;
END;
GO
select empNo, eName, sal,deptno,  dbo.CALCULATEBONUS(deptNo) as Bonus from Employee


----------------SOLUTION 6------------------------
USE Tests
CREATE OR ALTER PROCEDURE UpdateSalaryForSales
AS
BEGIN
   UPDATE Emp
   SET sal = sal + 500
   WHERE deptno = (SELECT deptno FROM DEPT WHERE dname = 'SALES')
     AND sal < 1500;
END;
GO
 
EXEC UpdateSalaryForSales;