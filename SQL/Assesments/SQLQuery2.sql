use Assessment

CREATE TABLE books (
   id INT IDENTITY(1,1) PRIMARY KEY,
   title VARCHAR(100) NOT NULL,
   author VARCHAR(50) NOT NULL,
   isbn CHAR(13) UNIQUE NOT NULL,
   published_date DATETIME
)
 
INSERT INTO books (title, author, isbn, published_date)
VALUES
('My First SQL book', 'Mary Parker', '981483029127', '2012-02-22 12:08:17'),
('My Second SQL book', 'John Mayer', '857300923713', '1972-07-03 09:22:45'),
('My Third SQL book', 'Cary Flint', '523120967812', '2015-10-18 14:05:44');
SELECT * FROM books

CREATE TABLE reviews (
   id INT IDENTITY(1,1) PRIMARY KEY,
   book_id INT FOREIGN KEY REFERENCES books(id),
   reviewer_name VARCHAR(50),
   content TEXT,
   rating INT,
   published_date DATETIME
);
 
INSERT INTO reviews (book_id, reviewer_name, content, rating, published_date)
VALUES
   (1 ,'John Smith', 'My first review', 4, '2017-12-10 05:50:11'),
   (2,'John Smith', 'My second review', 5, '2017-10-13 15:05:12.6'),
   (3 ,'Alice Walker', 'Another review', 1, '2017-10-22 23:47:10');
   SELECT * FROM reviews

   CREATE TABLE customer_table(
   id INT IDENTITY(1,1),
   name varchar(30),
   age int,
   address varchar(50),
   salary DECIMAL(10, 2)
   )

INSERT INTO customer_table( name, age, address, salary)
VALUES
   ('Ramesh', 32, 'Ahmedabad', 2000.00),
   ('Khilan', 25, 'Delhi', 1500.00),
   ('Kaushik', 23, 'Kota', 2000.00),
   ('Chaitali', 25, 'Mumbai', 6500.00),
   ('Hardik', 27, 'Bhopal', 8500.00),
   ('Komal', 22, 'MP', 4500.00),
   ('Muffy', 24, 'Indore', 10000.00);
   SELECT * FROM customer_table

   CREATE TABLE orders(
   OID int PRIMARY KEY,
   DATE DATETIME,
   CUSTOMER_ID int,
   AMOUNT int
   )

INSERT INTO orders(OID, DATE, CUSTOMER_ID, AMOUNT)
VALUES
   (102, '2009-10-08 00:00:00', 3, 3000),
   (100, '2009-10-08 00:00:00', 3, 1500),
   (101, '2009-11-20 00:00:00', 2, 1560),
   (103, '2008-05-20 00:00:00', 4, 2060);

CREATE TABLE Employees(
   id INT IDENTITY(1,1)Primary key,
   name varchar(30),
   age int,
   address varchar(50),
   salary DECIMAL(10, 2)
   )

INSERT INTO Employees( name, age, address, salary)
VALUES
   ('Ramesh', 32, 'Ahmedabad', 2000.00),
   ('Khilan', 25, 'Delhi', 1500.00),
   ('Kaushik', 23, 'Kota', 2000.00),
   ('Chaitali', 25, 'Mumbai', 6500.00),
   ('Hardik', 27, 'Bhopal', 8500.00),
   ('Komal', 22, 'MP', null),
   ('Muffy', 24, 'Indore', null);
   SELECT * FROM Employees


   CREATE TABLE StudentDetails (
   Register_No INT PRIMARY KEY,
   Name VARCHAR(50),
   Age INT,
   Qualification VARCHAR(50),
   MobileNo VARCHAR(10),
   Mail_Id VARCHAR(50),
   Location VARCHAR(50),
   Gender CHAR(1)
);
INSERT INTO StudentDetails (Register_No, Name, Age, Qualification, MobileNo, Mail_Id, Location, Gender)
VALUES
   (2, 'Sai', 22, 'B.E', '9952836777', 'Sai@gmail.com', 'Chennai', 'M'),
   (3, 'Kumar', 20, 'BSc', '7890125648', 'Kumar@gmail.com', 'Madurai', 'M'),
   (4, 'Selvi', 22, 'B.Tech', '8904567342', 'selvi@gmail.com', 'Selam', 'F'),
   (5, 'Nisha', 25, 'M.E', '7834672310', 'Nisha@gmail.com', 'Theni', 'F'),
   (6, 'SaiSaran', 21, 'B.A', '7890345678', 'saran@gmail.com', 'Madurai', 'F'),
   (7, 'Tom', 23, 'BCA', '8901234675', 'Tom@gmail.com', 'Pune', 'M');

----------------------------------------SOLUTIONS----------------------------------------------
--SOLUTION 1 Write a query to fetch the details of the books written by author whose name ends with er.
SELECT title,author FROM books WHERE author like '%er'

--SOLUTION 2 Display the Title ,Author and ReviewerName for all the books from the above table 
SELECT title , author , reviewer_name FROM books b right join reviews r on b.id = r.id;

--SOLUTION 3 Display the reviewer name who reviewed more than one book. 
SELECT reviewer_name FROM reviews GROUP BY reviewer_name HAVING count(*) > 1;

--SOLUTION 4 Display the Name for the customer from above customer table  who live in same address which has character o anywhere in address 
SELECT name FROM customer_table WHERE address like '%o%';

--SOLUTION 5 Write a query to display the   Date,Total no of customer  placed order on same Date  
SELECT DATE, count(CUSTOMER_ID) AS Final_Customers FROM orders GROUP BY DATE;

--SOLUTION 6 Display the Names of the Employee in lower case, whose salary is null  
SELECT lower(name) from Employees WHERE salary is NULL;

--SOLUTION 7 Write a sql server query to display the Gender,Total no of male and female from the above 
SELECT Gender, count(*) AS TotalNoOfCount FROM StudentDetails GROUP BY Gender;
