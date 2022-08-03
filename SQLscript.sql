USE [master]
GO

IF(EXISTS(SELECT * FROM sysdatabases WHERE name = 'OnlineBookDB'))
	DROP DATABASE OnlineBookDB
CREATE DATABASE OnlineBookDB
GO

USE OnlineBookDB
GO
--================================================================================================================
IF OBJECT_ID('User') IS NOT NULL
	DROP TABLE [User]
GO

CREATE TABLE [User](
[FirstName] VARCHAR(30) NOT NULL,
[LastName] VARCHAR(30) NOT NULL,
[EmailID] VARCHAR(50) CONSTRAINT User_pk_EmailID PRIMARY KEY,
[UserPassword] VARCHAR(15) NOT NULL,
[DOB] DATE CONSTRAINT User_chk_DOB CHECK(DOB<GETDATE()) NOT NULL,
[Gender] CHAR(1) CONSTRAINT User_chk_Gender CHECK(Gender='F' OR Gender='M') NOT NULL,
[ContactNo] BIGINT CONSTRAINT User_chk_ContactNo CHECK(LEN(ContactNo)=10) CONSTRAINT User_uq_ContactNo UNIQUE NOT NULL,
[Address] VARCHAR(100) NOT NULL
)
GO

INSERT INTO [User] values('Divya','Lingam','lingamdivya13@gmail.com','Divya13','1999-06-13','F',7288040547,'flatno:501,vidya1 flats,Tirupati')

--==================================================================================================================

IF OBJECT_ID('Genre') IS NOT NULL
	DROP TABLE Genre
GO

CREATE TABLE [Genre]
(
[GenreID] TINYINT CONSTRAINT Genre_pk_GenreID PRIMARY KEY IDENTITY(1,1),
[GenreName] VARCHAR(30) CONSTRAINT Genre_uq_GenreName UNIQUE NOT NULL
)
GO

INSERT INTO Genre VALUES('Thriller')
INSERT INTO Genre VALUES('Romance')
INSERT INTO Genre VALUES('Fantasy')
GO

--=====================================================================================================================

IF OBJECT_ID('Book') IS NOT NULL
	DROP TABLE Book
GO

CREATE TABLE [Book]
(
[BookID] TINYINT CONSTRAINT Book_pk_BookID PRIMARY KEY IDENTITY(1,1),
[BookName] VARCHAR(30) CONSTRAINT Book_uq_BookName UNIQUE NOT NULL,
[AuthorName] VARCHAR(30) NOT NULL,
[GenreID] TINYINT CONSTRAINT Book_fk_GenreID FOREIGN KEY REFERENCES Genre(GenreID) NOT NULL,
[MaxQuantity] INT CONSTRAINT Book_chk_Quantity CHECK(MaxQuantity>=0) NOT NULL,
[Cost] DECIMAL(5,2) CONSTRAINT Book_chk_Cost CHECK(Cost>0) NOT NULL,
[Description] VARCHAR(500) NOT NULL
)
GO

INSERT INTO Book VALUES('It Ends With Us','Colleen Hoover',2,5,250.00,'Come witness the story of Lily,Atlas and Ryle..')
INSERT INTO Book VALUES('And Then There Were None','Agatha Christie',1,3,220.00,'Come witness this gripping tale of murders and who commits them..')
INSERT INTO Book VALUES('An Ember In The Ashes','Sabaa Tahir',3,2,300.00,'Get into this magical world created by Sabaa with a fearless female lead..')
INSERT INTO Book VALUES('The Love Hypothesis','Ali Hazelwood',2,4,250.00,'This lovely tale of Adam and Olive is surely going to make you fall in love..')
INSERT INTO Book VALUES('Good Girl,Bad Blood','Holly Jackson',1,6,349.00,'Read this second part of popular thriller trilogy..')
INSERT INTO Book VALUES('Truly Devious','Maureen Johnson',1,3,399.00,'Witness this gripping tale of series of murders in boarding school and our young Stevie Bell who solves it..')
INSERT INTO Book VALUES('November 9','Colleen Hoover',1,2,200.00,'Witness Fallon and ben fall in love..')
INSERT INTO Book VALUES('Harry Potter Vol.1','J.K.Rowling',3,6,350.00,'Witness the magic in Hogwarts..')
INSERT INTO Book VALUES('The Dating Plan','Sara Desai',2,2,200.00,'Witness this new age love story..')
GO
--=======================================================================================================================
IF OBJECT_ID('CardDetails') IS NOT NULL
		DROP TABLE [CardDetails]
GO

CREATE TABLE CardDetails
(
[CardNumber] VARCHAR(16) CONSTRAINT card_pk_cardnumber PRIMARY KEY CONSTRAINT CardDetails_chk_CardNumber CHECK(LEN(CardNumber)=16),
[Balance] INT CONSTRAINT card_chk_balance CHECK(Balance>0) NOT NULL
)
GO

INSERT INTO CardDetails VALUES('3456234512578970',500000)
INSERT INTO CardDetails VALUES('3579053718392849',200000)
INSERT INTO CardDetails VALUES('4521986237485736',300000)

GO
--==========================================================================================================================
IF OBJECT_ID('Order') IS NOT NULL
		DROP TABLE [Order]
GO

CREATE TABLE [Order]
(
[OrderID] INT CONSTRAINT Order_pk_OrderID PRIMARY KEY IDENTITY(1000,1),
[EmailID] VARCHAR(50) CONSTRAINT Order_fk_EmailID FOREIGN KEY REFERENCES [User](EmailID) NOT NULL,
[BookID] TINYINT CONSTRAINT Order_fk_BookID FOREIGN KEY REFERENCES Book(BookID) NOT NULL,
[OrderQuantity] INT NOT NULL,
[OrderStatus] VARCHAR(50) CONSTRAINT Order_chk_OrderStatus CHECK([OrderStatus] IN ('Ordered','Delivered')) NOT NULL,
[OrderDate] DATE CONSTRAINT Order_chk_OrderDate CHECK([OrderDate]>=GETDATE()-1) NOT NULL,
[EstimatedDelivery] DATE NOT NULL,
CONSTRAINT Order_chk_EstimatedDelivery CHECK([EstimatedDelivery]>[OrderDate])
)
GO

INSERT INTO [Order] VALUES('lingamdivya13@gmail.com',1,1,'Ordered','2022-07-28','2022-07-29')
GO
--===========================================================================================================================
IF OBJECT_ID('Wishlist') IS NOT NULL
		DROP TABLE Wishlist
GO

CREATE TABLE [Wishlist]
(
[WishlistID] INT CONSTRAINT Wishlist_pk_WishlistID PRIMARY KEY IDENTITY(1,1),
[BookID] TINYINT CONSTRAINT Wishlist_fk_BookID FOREIGN KEY REFERENCES Book(BookID) NOT NULL,
[EmailID] VARCHAR(50) CONSTRAINT Wishlist_fk_EmailID FOREIGN KEY REFERENCES [User](EmailID) NOT NULL
)
GO
INSERT INTO Wishlist VALUES(3,'lingamdivya13@gmail.com')
GO

--===========================================================================================================================
IF OBJECT_ID('Cart') IS NOT NULL
		DROP TABLE Cart
GO

CREATE TABLE [Cart]
(
[CartID] INT CONSTRAINT Cart_pk_CartID PRIMARY KEY IDENTITY(1,1),
[BookID] TINYINT CONSTRAINT Cart_fk_BookID FOREIGN KEY REFERENCES Book(BookID) NOT NULL,
[EmailID] VARCHAR(50) CONSTRAINT Cart_fk_EmailID FOREIGN KEY REFERENCES [User](EmailID) NOT NULL,
[CartQuantity] INT NOT NULL
)
GO
INSERT INTO Cart VALUES(3,'lingamdivya13@gmail.com',1)
GO
--==================================================================================================================================
IF OBJECT_ID('Ratings') IS NOT NULL
		DROP TABLE Ratings
GO

CREATE TABLE [Ratings]
(
[RatingID] INT CONSTRAINT Ratings_pk_RatingID PRIMARY KEY IDENTITY(1,1),
[BookID] TINYINT CONSTRAINT Ratings_fk_BookID FOREIGN KEY REFERENCES Book(BookID) NOT NULL,
[EmailID] VARCHAR(50) CONSTRAINT Ratings_fk_EmailID FOREIGN KEY REFERENCES [User](EmailID) NOT NULL,
[OrderID] INT CONSTRAINT Ratings_fk_OrderID FOREIGN KEY REFERENCES [Order](OrderID) NOT NULL,
Rating TINYINT CONSTRAINT Ratings_chk_Rating CHECK(Rating<=5 AND Rating>=1) NOT NULL,
Comments VARCHAR(50) NOT NULL
)
GO
INSERT INTO Ratings VALUES(1,'lingamdivya13@gmail.com',1000,5,'loved it')
GO

SELECT * FROM Ratings
--=====================================================================================================================================

IF OBJECT_ID('usp_RegisterUser') IS NOT NULL
		DROP PROC usp_RegisterUser

GO

CREATE PROCEDURE usp_RegisterUser
(
@FirstName VARCHAR(30),
@LastName VARCHAR(30), 
@EmailID VARCHAR(50),
@UserPassword VARCHAR(15),
@DOB DATE,
@Gender CHAR(1),
@ContactNo BIGINT,
@Address VARCHAR(100)
)
AS
BEGIN
DECLARE @retval INT 
	BEGIN TRY
		IF (LEN(@EmailID)<4 OR LEN(@EmailID)>50 OR (@EmailID IS NULL))
			RETURN -1 
		ELSE IF (LEN(@UserPassword)<8 OR LEN(@UserPassword)>15 OR (@UserPassword IS NULL))
			RETURN -2
		ELSE IF (@Gender<>'F' AND @Gender<>'M' OR (@Gender IS NULL))
			RETURN -3
		ELSE IF (@DOB>=CAST(GETDATE() AS DATE) OR (@DOB IS NULL))
			RETURN -4
		ELSE IF (@Address IS NULL OR @Address='')
			RETURN -5
		ELSE IF (@FirstName IS NULL OR @FirstName='')
			RETURN -6
		ELSE IF (@LastName IS NULL OR @LastName='')
			RETURN -7
		ELSE IF (@ContactNo IS NULL OR LEN(@ContactNo)<10)
			RETURN -8
		ELSE
			BEGIN
				INSERT INTO [User] VALUES(@FirstName,@LastName,@EmailId,@UserPassword,@DOB,@Gender,@ContactNo,@Address)
				SET @retval=1
			END
		RETURN @retval
	END TRY
	BEGIN CATCH
		SET @retval=-99
		RETURN @retval
	END CATCH
END
GO

declare @retval INT
EXEC @retval=dbo.usp_RegisterUser @FirstName='Aishu',@LastName='Lingam',@EmailID='aishu@gmail.com',@UserPassword='aishu0609',@DOB='2006-09-06',@ContactNo=9346176355,@Gender='F',@Address='18-3-55/e,k.t.road.tirupati'
select @retval
--============================================================================================================================
IF OBJECT_ID('ufn_ValidateUserCredentials') IS NOT NULL
		DROP FUNCTION [ufn_ValidateUserCredentials]
GO

CREATE FUNCTION ufn_ValidateUserCredentials
(
@EmailID VARCHAR(50),
@UserPassword VARCHAR(50)
)
RETURNS INT
AS
BEGIN
	DECLARE @Status INT = -1
	IF(EXISTS(SELECT * FROM [User] WHERE EmailID=@EmailID AND UserPassword=@UserPassword))
	SET @Status=200
	RETURN @Status
END
GO

declare @status int
select dbo.ufn_ValidateUserCredentials('lingamdivya13@gmail.com','Divya13')
--===========================================================================================================================
IF OBJECT_ID('usp_AddGenre') IS NOT NULL
		DROP PROC usp_AddGenre

GO

CREATE PROCEDURE usp_AddGenre
(
@GenreName VARCHAR(30)
)
AS
BEGIN
DECLARE @retval INT 
	BEGIN TRY
		IF (@GenreName IS NULL OR @GenreName='')
			RETURN -1
		ELSE
			BEGIN
				INSERT INTO Genre VALUES(@GenreName)
				SET @retval=1
			END
		RETURN @retval
	END TRY
	BEGIN CATCH
		SET @retval=-99
		RETURN @retval
	END CATCH
END
GO

declare @retval INT
EXEC @retval=dbo.usp_AddGenre @GenreName='Non-Fiction'
select @retval
--=======================================================================================================================
IF OBJECT_ID('ufn_GetGenres') IS NOT NULL
		DROP FUNCTION [ufn_GetGenres]
GO

CREATE FUNCTION [dbo].[ufn_GetGenres]()
RETURNS TABLE
AS
	RETURN (SELECT * FROM Genre)
GO

select * from dbo.ufn_GetGenres()
--======================================================================================================================
IF OBJECT_ID('usp_AddBook') IS NOT NULL
		DROP PROC usp_AddBook

GO

CREATE PROCEDURE usp_AddBook
(
@BookName VARCHAR(30),
@AuthorName VARCHAR(30), 
@GenreID TINYINT,
@MaxQuantity INT,
@Cost DECIMAL(5,2),
@Description VARCHAR(500)
)
AS
BEGIN
DECLARE @retval INT 
	BEGIN TRY
		IF (@BookName IS NULL OR @BookName='')
			RETURN -1 
		ELSE IF (@AuthorName IS NULL OR @AuthorName='')
			RETURN -2
		ELSE IF NOT EXISTS(SELECT @GenreID FROM Genre WHERE @GenreID=GenreID)
			RETURN -3
		ELSE IF (@MaxQuantity<0 OR @MaxQuantity IS NULL)
			RETURN -4
		ELSE IF (@Cost<0 OR @Cost IS NULL)
			RETURN -5
		ELSE IF (@Description IS NULL OR @Description='')
			RETURN -6
		ELSE
			BEGIN
				INSERT INTO Book VALUES(@BookName,@AuthorName,@GenreID,@MaxQuantity,@Cost,@Description)
				SET @retval=@@IDENTITY
			END
		RETURN @retval
	END TRY
	BEGIN CATCH
		SET @retval=-99
		RETURN @retval
	END CATCH
END
GO

declare @retval INT
EXEC @retval=dbo.usp_AddBook @BookName='November 9',@AuthorName='Colleen Hoover',@GenreID=1,@MaxQuantity=3,@Cost=200.00,@Description='Witness Fallon and Ben fall in love..'
select @retval
--=========================================================================================================================
IF OBJECT_ID('ufn_GetAllBooks') IS NOT NULL
		DROP FUNCTION [ufn_GetAllBooks]
GO

CREATE FUNCTION [dbo].[ufn_GetAllBooks]()
RETURNS TABLE
AS
	RETURN (SELECT * FROM Book)
GO

select * from dbo.ufn_GetAllBooks()
--==============================================================================================================================
IF OBJECT_ID('usp_AddOrder') IS NOT NULL
		DROP PROC usp_AddOrder

GO

CREATE PROCEDURE usp_AddOrder
(
@EmailID VARCHAR(50),
@BookID TINYINT,
@OrderQuantity INT,
@OrderStatus VARCHAR(50),
@OrderDate DATE,
@EstimatedDelivery DATE
)
AS
BEGIN
DECLARE @retval INT 
	BEGIN TRY
		IF NOT EXISTS(SELECT @EmailID FROM [User] WHERE @EmailID=EmailID)
			RETURN -1 
		ELSE IF NOT EXISTS(SELECT @BookID FROM [Book] WHERE @BookID=BookID)
			RETURN -2
		ELSE IF(@OrderQuantity<0 OR @OrderQuantity IS NULL)
			RETURN -3
		ELSE IF (@OrderStatus='' OR @OrderStatus IS NULL)
			RETURN -4
		ELSE IF (@OrderDate<GETDATE()-1 OR @OrderDate IS NULL)
			RETURN -5
		ELSE IF (@EstimatedDelivery IS NULL OR @EstimatedDelivery<@OrderDate)
			RETURN -6
		ELSE
			BEGIN
				INSERT INTO [Order] VALUES(@EmailID,@BookID,@OrderQuantity,@OrderStatus,@OrderDate,@EstimatedDelivery)
				SET @retval=@@IDENTITY
			END
		RETURN @retval
	END TRY
	BEGIN CATCH
		SET @retval=-99
		RETURN @retval
	END CATCH
END
GO

declare @retval INT
EXEC @retval=dbo.usp_AddOrder @EmailID='aishu@gmail.com',@BookID=4,@OrderQuantity=1,@OrderStatus='Ordered',@OrderDate='2022-07-23',@EstimatedDelivery='2022-07-25'
select @retval
--================================================================================================================
IF OBJECT_ID('ufn_GetOrdersByEmail') IS NOT NULL
		DROP FUNCTION [ufn_GetOrdersByEmail]
GO

CREATE FUNCTION [dbo].[ufn_GetOrdersByEmail]
(
@EmailID VARCHAR(50)
)
RETURNS TABLE
AS
	RETURN (SELECT * FROM dbo.[Order] WHERE @EmailID=EmailID)
GO

select * from ufn_GetOrdersByEmail('lingamdivya13@gmail.com')
--=========================================================================================================
IF OBJECT_ID('usp_AddorUpdateWishlist') IS NOT NULL
		DROP PROC usp_AddorUpdateWishlist

GO

CREATE PROCEDURE usp_AddorUpdateWishlist
(
@EmailID VARCHAR(50),
@BookID TINYINT
)
AS
BEGIN
DECLARE @retval INT 
	BEGIN TRY
		IF NOT EXISTS(SELECT @EmailID FROM [User] WHERE @EmailID=EmailID)
			RETURN -1 
		ELSE IF NOT EXISTS(SELECT @BookID FROM [Book] WHERE @BookID=BookID)
			RETURN -2
		ELSE IF EXISTS(SELECT WishlistID FROM Wishlist WHERE @EmailID=EmailID AND @BookID=BookID)
			BEGIN
				UPDATE Wishlist SET @BookID=BookID WHERE @EmailID=EmailID AND @BookID=BookID
				SET @retval=@@IDENTITY
			END
		ELSE
			BEGIN
				INSERT INTO [Wishlist] VALUES(@BookID,@EmailID)
				SET @retval=@@IDENTITY
			END
		RETURN @retval
	END TRY
	BEGIN CATCH
		SET @retval=-99
		RETURN @retval
	END CATCH
END
GO

declare @retval INT
EXEC @retval=dbo.usp_AddorUpdateWishlist @EmailID='aishu@gmail.com',@BookID=4
select @retval
--====================================================================================================================
IF OBJECT_ID('ufn_GetWishlistByEmail') IS NOT NULL
		DROP FUNCTION [ufn_GetWishlistByEmail]
GO

CREATE FUNCTION [dbo].[ufn_GetWishlistByEmail]
(
@EmailID VARCHAR(50)
)
RETURNS TABLE
AS
	RETURN (SELECT * FROM dbo.[Wishlist] WHERE @EmailID=EmailID)
GO

select * from ufn_GetWishlistByEmail('lingamdivya13@gmail.com')
--======================================================================================================================
IF OBJECT_ID('usp_AddorUpdateCart') IS NOT NULL
		DROP PROC usp_AddorUpdateCart

GO

CREATE PROCEDURE usp_AddorUpdateCart
(
@EmailID VARCHAR(50),
@BookID TINYINT,
@CartQuantity INT
)
AS
BEGIN
DECLARE @retval INT 
	BEGIN TRY
		IF NOT EXISTS(SELECT @EmailID FROM [User] WHERE @EmailID=EmailID)
			RETURN -1 
		ELSE IF NOT EXISTS(SELECT @BookID FROM [Book] WHERE @BookID=BookID)
			RETURN -2
		ELSE IF(@CartQuantity IS NULL OR @CartQuantity<0)
			RETURN -3
		ELSE IF EXISTS(SELECT CartID FROM Cart WHERE @EmailID=EmailID AND @BookID=BookID)
			BEGIN
				UPDATE Cart SET CartQuantity=@CartQuantity WHERE @EmailID=EmailID AND @BookID=BookID
				SET @retval=@@IDENTITY
			END
		ELSE
			BEGIN
				INSERT INTO [Cart] VALUES(@BookID,@EmailID,@CartQuantity)
				SET @retval=@@IDENTITY
			END
		RETURN @retval
	END TRY
	BEGIN CATCH
		SET @retval=-99
		RETURN @retval
	END CATCH
END
GO

declare @retval INT
EXEC @retval=dbo.usp_AddorUpdateCart @EmailID='aishu@gmail.com',@BookID=5,@CartQuantity=1
select @retval
--=============================================================================================================
IF OBJECT_ID('ufn_GetCartByEmail') IS NOT NULL
		DROP FUNCTION [ufn_GetCartByEmail]
GO

CREATE FUNCTION [dbo].[ufn_GetCartByEmail]
(
@EmailID VARCHAR(50)
)
RETURNS TABLE
AS
	RETURN (SELECT * FROM dbo.[Cart] WHERE @EmailID=EmailID)
GO

select * from ufn_GetCartByEmail('lingamdivya13@gmail.com')
--=========================================================================================================
IF OBJECT_ID('usp_AddRatings') IS NOT NULL
		DROP PROC usp_AddRatings

GO
CREATE PROCEDURE usp_AddRatings
(
@EmailID VARCHAR(50),
@BookID TINYINT,
@OrderID INT,
@Rating TINYINT,
@Comments VARCHAR(50)
)
AS
BEGIN
DECLARE @retval INT 
	BEGIN TRY
		IF NOT EXISTS(SELECT @EmailID FROM [User] WHERE @EmailID=EmailID)
			RETURN -1 
		ELSE IF NOT EXISTS(SELECT @BookID FROM [Book] WHERE @BookID=BookID)
			RETURN -2
		ELSE IF NOT EXISTS(SELECT @OrderID FROM [Order] WHERE @OrderID=OrderID)
			RETURN -3
		ELSE IF(@Rating<1 OR @Rating>5)
			RETURN -4
		ELSE IF(@Comments IS NULL OR @Comments='')
			RETURN -5
		ELSE
			BEGIN
				INSERT INTO [Ratings] VALUES(@BookID,@EmailID,@OrderID,@Rating,@Comments)
				SET @retval=@@IDENTITY
			END
		RETURN @retval
	END TRY
	BEGIN CATCH
		SET @retval=-99
		RETURN @retval
	END CATCH
END
GO

declare @retval INT
EXEC @retval=dbo.usp_AddRatings @EmailID='aishu@gmail.com',@BookID=4,@OrderID=1001,@Rating=4,@Comments='very good'
select @retval
--=============================================================================================================
IF OBJECT_ID('ufn_GetRatingsByEmail') IS NOT NULL
		DROP FUNCTION [ufn_GetRatingsByEmail]
GO

CREATE FUNCTION [dbo].[ufn_GetRatingsByEmail]
(
@EmailID VARCHAR(50)
)
RETURNS TABLE
AS
	RETURN (SELECT * FROM dbo.[Ratings] WHERE @EmailID=EmailID)
GO

select * from ufn_GetRatingsByEmail('lingamdivya13@gmail.com')
--========================================================================================================================
IF OBJECT_ID('usp_RemoveFromCart') IS NOT NULL
		DROP PROC usp_RemoveFromCart

GO

CREATE PROCEDURE usp_RemoveFromCart
(
@EmailID VARCHAR(50),
@BookID TINYINT
)
AS
BEGIN
DECLARE @retval INT 
	BEGIN TRY
		IF NOT EXISTS(SELECT @EmailID FROM [User] WHERE @EmailID=EmailID)
			RETURN -1 
		ELSE IF NOT EXISTS(SELECT @BookID FROM [Book] WHERE @BookID=BookID)
			RETURN -2
		ELSE
			BEGIN
				DELETE FROM Cart WHERE @EmailID=EmailID AND @BookID=BookID
				SET @retval=1
			END
		RETURN @retval
	END TRY
	BEGIN CATCH
		SET @retval=-99
		RETURN @retval
	END CATCH
END
GO

declare @retval INT
EXEC @retval=dbo.usp_RemoveFromCart @EmailID='aishu@gmail.com',@BookID=5
select @retval
select * from Cart
--============================================================================================================
IF OBJECT_ID('usp_RemoveFromWishlist') IS NOT NULL
		DROP PROC usp_RemoveFromWishlist

GO

CREATE PROCEDURE usp_RemoveFromWishlist
(
@EmailID VARCHAR(50),
@BookID TINYINT
)
AS
BEGIN
DECLARE @retval INT 
	BEGIN TRY
		IF NOT EXISTS(SELECT @EmailID FROM [User] WHERE @EmailID=EmailID)
			RETURN -1 
		ELSE IF NOT EXISTS(SELECT @BookID FROM [Book] WHERE @BookID=BookID)
			RETURN -2
		ELSE
			BEGIN
				DELETE FROM Wishlist WHERE @EmailID=EmailID AND @BookID=BookID
				SET @retval=1
			END
		RETURN @retval
	END TRY
	BEGIN CATCH
		SET @retval=-99
		RETURN @retval
	END CATCH
END
GO

declare @retval INT
EXEC @retval=dbo.usp_RemoveFromWishlist @EmailID='aishu@gmail.com',@BookID=4
select @retval
SELECT * FROM Wishlist
--===================================================================================================================
IF OBJECT_ID('ufn_TotalAmountInCart') IS NOT NULL
		DROP FUNCTION ufn_TotalAmountInCart

GO

CREATE FUNCTION ufn_TotalAmountInCart
(
@EmailID VARCHAR(50)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
DECLARE @TotalAmount INT=0
SELECT @TotalAmount = SUM(B.Cost*C.CartQuantity) FROM BOOK B INNER JOIN CART C ON B.BookID=C.BookID WHERE EmailID=@EmailID
RETURN @TotalAmount
END
GO

declare @retval INT
SELECT @RETVAL=dbo.ufn_TotalAmountInCart('aishu@gmail.com')
select @retval
--=========================================================================================================================
IF OBJECT_ID('usp_UpdateOrderStatus') IS NOT NULL
		DROP PROC usp_UpdateOrderStatus

GO

CREATE PROCEDURE usp_UpdateOrderStatus
(
@EmailID VARCHAR(50)
)
AS
BEGIN
DECLARE @retval INT
	BEGIN TRY
		UPDATE [Order] SET OrderStatus='Delivered' WHERE EstimatedDelivery<GETDATE()
		SET @retval=1
		RETURN @retval
	END TRY
	BEGIN CATCH
		SET @retval=-99
		RETURN @retval
	END CATCH
END
GO

declare @retval INT
EXEC @retval=dbo.usp_UpdateOrderStatus @EmailID='aishu@gmail.com'
select @retval
select * from [Order]
--============================================================================================================================
IF OBJECT_ID('ufn_GetAllBooksInCartWithMaxQuantityAndCost') IS NOT NULL
		DROP FUNCTION ufn_GetAllBooksInCartWithMaxQuantityAndCost

GO

CREATE FUNCTION ufn_GetAllBooksInCartWithMaxQuantityAndCost
(
@EmailID VARCHAR(50)
)
RETURNS TABLE
AS
	RETURN (SELECT B.BookID,B.BookName,B.AuthorName,B.GenreID,B.Cost,B.MaxQuantity,B.[Description],C.CartID,C.EmailID,C.CartQuantity FROM BOOK B INNER JOIN CART C ON B.BookID=C.BookID WHERE C.EmailID=@EmailID)
GO

SELECT * FROM ufn_GetAllBooksInCartWithMaxQuantityAndCost('lingamdivya13@gmail.com')
--==========================================================================================================================
IF OBJECT_ID('usp_UpdateCartQuantity') IS NOT NULL
		DROP PROC usp_UpdateCartQuantity

GO

CREATE PROCEDURE usp_UpdateCartQuantity
(
@EmailID VARCHAR(50),
@BookID TINYINT,
@NewQuantity INT
)
AS
BEGIN
DECLARE @retval INT 
	BEGIN TRY
		IF (@NewQuantity IS NULL OR @NewQuantity<0)
			RETURN -1 
		ELSE
			BEGIN
				UPDATE Cart SET CartQuantity=@NewQuantity WHERE @EmailID=EmailID AND @BookID=BookID
				SET @retval=1
			END
		RETURN @retval
	END TRY
	BEGIN CATCH
		SET @retval=-99
		RETURN @retval
	END CATCH
END
GO

declare @retval INT
EXEC @retval=dbo.usp_UpdateCartQuantity @EmailID='aishu@gmail.com',@BookID=5,@NewQuantity=1
select @retval

SELECT * FROM CART
--========================================================================================================================
IF OBJECT_ID('ufn_GetBooksAndGenre') IS NOT NULL
		DROP FUNCTION ufn_GetBooksAndGenre

GO

CREATE FUNCTION ufn_GetBooksAndGenre()
RETURNS TABLE
AS
	RETURN (SELECT B.BookID,B.BookName,B.AuthorName,B.GenreID,B.MaxQuantity,B.Cost,B.Description,G.GenreName FROM BOOK B INNER JOIN GENRE G ON B.GenreID=G.GenreID)
GO

SELECT * FROM dbo.ufn_GetBooksAndGenre()
--==========================================================================================================================
--Scaffold-DbContext -Connection "Data Source =(localdb)\MSSQLLocalDB;Initial Catalog=OnlineBookDB;Integrated Security=true" -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
