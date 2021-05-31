Create Database RentACar;

Use RentACar;

Create Table Users(
UserID int primary key identity(1,1) not null,
UserName varchar(50) not null,
Password varchar(50) not null,
usertype int not null,
);

Create Table Cars(
CarsID int primary key identity(1,1) not null,
ReqNo varchar(50) not null,
Brand varchar(50) not null,
Model varchar(50) not null,
Available varchar(50) not null,
Price varchar(50) not null,
);

Create Table Customers(
CustID int primary key identity(1,1) not null,
Cust_TC varchar(50) not null,
CustName varchar(50) not null,
CustSurName varchar(50) not null,
Adress varchar(50) not null,
Phone varchar(50) not null,
);

Create Table Rent(
RentID int primary key identity(1,1) not null,
ReqNo varchar(50) not null,
CustName varchar(50) not null,
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

INSERT INTO Customers(Cust_TC,CustName,CustSurName,Adress,Phone) VALUES ('11460466593','Kürþat','Yeðin','Ýstanbul','5464831457');
INSERT INTO Customers(Cust_TC,CustName,CustSurName,Adress,Phone) VALUES ('11460466593','Emir','Þen','Bursa','5056321749');
INSERT INTO Customers(Cust_TC,CustName,CustSurName,Adress,Phone) VALUES ('11460466593','Enes','Çetinkaya','Sinop','5358462048');
INSERT INTO Customers(Cust_TC,CustName,CustSurName,Adress,Phone) VALUES ('11460466593','Harun','Dede','Sinop','5056328452');
INSERT INTO Customers(Cust_TC,CustName,CustSurName,Adress,Phone) VALUES ('11460466593','Buðrahan','Yaman','Hatay','5358463748');

INSERT INTO Cars(ReqNo,Brand,Model,Available,Price) VALUES ('34YG1907','BMW','218i','Boþ','229 TL');
INSERT INTO Cars(ReqNo,Brand,Model,Available,Price) VALUES ('34ZY1060','Mercedes','G','Dolu','299 TL');
INSERT INTO Cars(ReqNo,Brand,Model,Available,Price) VALUES ('15DH412','Renault','Clio','Boþ','159 TL');
INSERT INTO Cars(ReqNo,Brand,Model,Available,Price) VALUES ('57DD8314','Opel','Astra','Boþ','159 TL');
INSERT INTO Cars(ReqNo,Brand,Model,Available,Price) VALUES ('34SKE1842','Seat','Lion','Dolu','179 TL');

INSERT INTO Users(UserName,Password,usertype) VALUES ('KursatYG','5757','0');
INSERT INTO Users(UserName,Password,usertype) VALUES ('Emirsen16','1234','1');
INSERT INTO Users(UserName,Password,usertype) VALUES ('enesctnky','5775','1');
INSERT INTO Users(UserName,Password,usertype) VALUES ('yamanbugra','1907bugra','1');
INSERT INTO Users(UserName,Password,usertype) VALUES ('rdharun','harun5757','1');

INSERT INTO Rent(ReqNo,CustName,Rent_Date,Return_Date,Fee) VALUES ('34SKE1842','Enes','03.05.2021','04.05.2021','179 TL');
