Create Database AracKiralama;

Use AracKiralama;

Create Table Users(
UserID int primary key identity(1,1) not null,
UserName varchar(50) not null,
Password varchar(50) not null,
usertype int not null,
);

Create Table Customers(
CustID int primary key identity(1,1) not null,
UserID int Foreign Key References Users(UserID) not null,
Cust_TC varchar(50) not null,
CustName varchar(50) not null,
CustSurName varchar(50) not null,
Adress varchar(50) not null,
Phone varchar(50) not null,
);

Create Table Cars(
CarsID int primary key identity(1,1) not null,
ReqNo varchar(50) not null,
Brand varchar(50) not null,
Model varchar(50) not null,
Available varchar(50) not null,
Price varchar(50) not null,
);

Create Table Rent(
RentID int primary key identity(1,1) not null,
CarsID int Foreign Key References Cars(CarsID) not null,
CustName varchar(50) not null,
ReqNo varchar(50) not null,
Rent_Date date not null,
Return_Date date not null,
Fee varchar(50) not null,
);

Create Table [Return](
ReturnID int primary key identity(1,1) not null,
ReqNo varchar(50) not null,
CustName varchar(50) not null,
Return_Date date not null,
Delay int not null,
Fine int not null,
);
INSERT INTO Users (UserName,Password,usertype) VALUES ('Kemalinho','123',1);
INSERT INTO Customers (UserID,Cust_TC,CustName,CustSurName,Adress,Phone) VALUES (1,'123','Kemal','Ýþkembe','Çorbacý','444');

INSERT INTO Users (UserName,Password,usertype) VALUES ('Kursat','123',1);
INSERT INTO Customers (UserID,Cust_TC,CustName,CustSurName,Adress,Phone) VALUES (2,'732','Kemal','Ýþkembe','Çorbacý','444');

INSERT INTO Cars(ReqNo,Brand,Model,Available,Price) VALUES ('34YG1907','BMW','218i','Boþ','229 TL');
INSERT INTO Rent(CarsID,CustName,ReqNo,Rent_Date,Return_Date,Fee) VALUES (1,'Kemal','34SKE1842','03.05.2021','04.05.2021','179 TL');

SELECT * From Rent WHERE CarsID=1;

SELECT Customers.CustName, Customers.CustSurName, Customers.Adress, Customers.Cust_TC, Customers.Phone, Cars.Model FROM Customers INNER JOIN Cars on Customers.CustID = Cars.CarsID;
