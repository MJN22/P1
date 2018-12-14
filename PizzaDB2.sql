create database PizzaDB2
Go
Create schema PizzaDB2
Go

--drop table UserTBL
CREATE TABLE UserTBL
(
  UserID int identity Primary key NOT NULL,
  FirstName NVARCHAR(108) NOT NULL
,
  LastName NVARCHAR(108) NOT NULL
  ,
);
go
--drop table UserAddress 
CREATE TABLE UserAddress
(
  UserAddressID int identity Primary key NOT NULL,
  Address1 VARCHAR(120)NOT NULL,
  Address2 VARCHAR(120),
  City VARCHAR(100) NOT NULL,
  ProvidenceState NVARCHAR(108) NOT NULL,--SPELLING ERROR
  PostalCode VARCHAR(16) NOT NULL,
  CountryAbrev NVARCHAR(5) NOT NULL,


);
GO
CREATE TABLE Orders
(
  UserOrderAddressID int not null,
  StoreAddressID int not null,
  ID int identity Primary key NOT NULL,

);
GO

CREATE TABLE Store
(
  StoreAddress varchar(1000),
  StoreAddressID int identity Primary key NOT NULL,

  Address1 VARCHAR
(120)NOT NULL,
  Address2 VARCHAR
(120),
  City VARCHAR
(100) NOT NULL,
  ProvidenceState NVARCHAR
(108) NOT NULL,
  PostalCode VARCHAR
(16) NOT NULL,
  CountryAbrev NVARCHAR
(5) NOT NULL,

);

GO
--drop table StoreIngredients
CREATE TABLE StoreIngredients
(
  StoreIngredientsAddressID int Not Null,
  ID INT PRIMARY KEY IDENTITY NOT NULL,
  --IngredientsName NVARCHAR(300) NOT NULL,
  IngredientStock INT,
  --uncommented this for compiling issues need to fix db
);
GO

CREATE TABLE OrderedPizzas
(
  id INT PRIMARY KEY IDENTITY not null,
  OrderID int not null,
  PizzaID int not null,

)
GO

CREATE TABLE Pizza
(
  ID int PRIMARY KEY IDENTITY,
  PizzaName NVARCHAR(500) NOT NULL,
  Costs MONEY not null,
);
GO

CREATE TABLE PizzaIngredients
(
  ID INT IDENTITY PRIMARY KEY,
  PizzaID INT NOT NULL,
  IngredientName NVARCHAR(108) NOT NULL,
  IngredientCost INT NOT NULL,

); 
GO

------------ADDDING CONSTRAINTSSSSS -------------

ALTER TABLE PizzaIngredients
ADD CONSTRAINT FK_PizzaID
FOREIGN KEY (PizzaID) 
REFERENCES Pizza(ID);
GO

ALTER TABLE UserAddress
ADD CONSTRAINT FK_UserAddressID
FOREIGN KEY (UserAddressID) 
REFERENCES UserTBL(UserID);
GO

ALTER TABLE Orders
ADD CONSTRAINT FK_UserOrderAddressID
FOREIGN KEY (UserOrderAddressID) 
REFERENCES UserAddress(UserAddressID);
GO

Alter table Orders
ADD CONSTRAINT FK_StoreAddressID
FOREIGN KEY ( StoreAddressID )
REFERENCES Store(StoreAddressID);
GO

ALTER TABLE OrderedPizzas
ADD CONSTRAINT FK_OrderID
FOREIGN KEY ( OrderID )
REFERENCES Orders(ID);
GO

ALTER TABLE OrderedPizzas
ADD CONSTRAINT FK_OrderPizzaID
FOREIGN KEY ( PizzaID )
REFERENCES Pizza(ID);
GO

ALTER TABLE StoreIngredients
ADD CONSTRAINT FK_StoreIngredientsAddressID
FOREIGN KEY ( StoreIngredientsAddressID )
REFERENCES Store(StoreAddressID);
GO

------create info/insert --------------
INSERT INTO UserTBL
  (FirstName, LastName)
Values
  ('Tony', 'Stark'),
  ('Elon', 'Musk'),
  ('Greg', 'Savage');
--select * from UserTBL;

INSERT INTO UserAddress
  (Address1,Address2, City, ProvidenceState, PostalCode,CountryAbrev)
VALUES((SELECT UserID
    FROM UserTBL
    WHERE UserID =1), '181 11th street' , 'Charlotte', 'North Carolina', '28269', 'USA')
--select * from UserAddress;
INSERT INTO UserAddress
  (Address1,Address2, City, ProvidenceState, PostalCode,CountryAbrev)
VALUES((SELECT UserID
    FROM UserTBL
    WHERE UserID =2), '11th S 12th Street' , 'Pheonix', 'Arizona', '85001', 'USA')
INSERT INTO UserAddress
  (Address1,Address2, City, ProvidenceState, PostalCode,CountryAbrev)
VALUES((SELECT UserID
    FROM UserTBL
    WHERE UserID =3), '2121 Alexander Heigths' , 'Concord', 'North Carolina', '282027', 'USA')

INSERT INTO Store
  (StoreAddress, Address1, Address2, City, ProvidenceState, PostalCode, CountryAbrev)
VALUES( '11th Main street, Charlotte, North Carolina 28269 USA' , '11th Main street', 'Null', 'Charlotte', 'North Carolina', '28269', 'USA')
Select *
from Store;

--INSERT Pizza-----
--drop table pizza
INSERT INTO Pizza
  ( PizzaName, Costs)
VALUES
  ('Cheese', 8.00)
INSERT INTO Pizza
  ( PizzaName, Costs)
VALUES
  ('ExtraCheesy', 12.00)
 INSERT INTO Pizza
  ( PizzaName, Costs)
VALUES
  ('Meats', 15.00)

SELECT *
FROM Pizza
---into pizzaIngredients
INSERT INTO PizzaIngredients
  (PizzaID, IngredientName, IngredientCost)
VALUES
  ( (select ID FROM Pizza Where ID =1), 'Cheese', 1)

INSERT INTO PizzaIngredients
(PizzaID, IngredientName, IngredientCost)
VALUES ( (select ID FROM Pizza Where ID =2),(select PizzaName FROM Pizza Where ID =2) , 2)

INSERT INTO PizzaIngredients
(PizzaID, IngredientName, IngredientCost)
VALUES ( (select ID FROM Pizza Where ID =3),(select PizzaName FROM Pizza Where ID =3) , 3)



--SELECT *FROM PizzaIngredients 
--SELECT * FROM UserAddress
--select * From Pizza
--SELECT * From Store
--select * from StoreIngredients
--select * from Orders
--select * from OrderedPizzas
------insert into store ignreds---
INSERT INTO StoreIngredients( StoreIngredientsAddressID, IngredientStock)
Values((Select StoreAddressID from Store),250)
GO
--insert into order and order  pizzaa--------
INSERT INTO Orders(UserOrderAddressID, StoreAddressID) VALUES
(1,1),(2,1),(3,1)
--isseus storing into order pizza may have key wrong, also reference fields wrong 
--will get back to this if i can

--select * from Orders
--select * from OrderedPizzas

