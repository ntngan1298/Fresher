USE [master]
GO
/****** Object:  Database [CustomerDemo]    Script Date: 05/03/2018 4:04:16 SA ******/
CREATE DATABASE [CustomerDemo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CustomerDemo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\CustomerDemo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CustomerDemo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\CustomerDemo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CustomerDemo] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CustomerDemo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CustomerDemo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CustomerDemo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CustomerDemo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CustomerDemo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CustomerDemo] SET ARITHABORT OFF 
GO
ALTER DATABASE [CustomerDemo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CustomerDemo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CustomerDemo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CustomerDemo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CustomerDemo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CustomerDemo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CustomerDemo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CustomerDemo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CustomerDemo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CustomerDemo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CustomerDemo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CustomerDemo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CustomerDemo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CustomerDemo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CustomerDemo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CustomerDemo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CustomerDemo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CustomerDemo] SET RECOVERY FULL 
GO
ALTER DATABASE [CustomerDemo] SET  MULTI_USER 
GO
ALTER DATABASE [CustomerDemo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CustomerDemo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CustomerDemo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CustomerDemo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CustomerDemo] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CustomerDemo', N'ON'
GO
ALTER DATABASE [CustomerDemo] SET QUERY_STORE = OFF
GO
USE [CustomerDemo]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [CustomerDemo]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 05/03/2018 4:04:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](155) NULL,
	[FullName] [nvarchar](255) NULL,
	[CompanyName] [nvarchar](255) NULL,
	[CompanyCodeTax] [nvarchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[City] [nvarchar](100) NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Email] [nvarchar](100) NULL,
	[MemberCardCode] [nvarchar](50) NULL,
	[RankCard] [int] NULL,
	[DebitAmount] [decimal](18, 0) NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Proc_DeleteCustomer]    Script Date: 05/03/2018 4:04:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[Proc_DeleteCustomer]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   ManhNV using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[Proc_DeleteCustomer]
-- Date Generated: 05 Tha´ng Ba 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[Proc_DeleteCustomer]
	@CustomerID uniqueidentifier
AS

SET NOCOUNT ON

DELETE FROM [dbo].[Customer]
WHERE
	[CustomerID] = @CustomerID

--endregion

GO
/****** Object:  StoredProcedure [dbo].[Proc_DeleteCustomersDynamic]    Script Date: 05/03/2018 4:04:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[Proc_DeleteCustomersDynamic]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   ManhNV using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[Proc_DeleteCustomersDynamic]
-- Date Generated: 05 Tha´ng Ba 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[Proc_DeleteCustomersDynamic]
	@WhereCondition nvarchar(500)
AS

SET NOCOUNT ON

DECLARE @SQL nvarchar(3250)

SET @SQL = '
DELETE FROM
	[dbo].[Customer]
WHERE
	' + @WhereCondition

EXEC sp_executesql @SQL

--endregion

GO
/****** Object:  StoredProcedure [dbo].[Proc_GetListCustomer]    Script Date: 05/03/2018 4:04:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Proc_GetListCustomer]
	
AS
BEGIN
	
	SET NOCOUNT ON;
	SELECT * FROM dbo.Customer
END
GO
/****** Object:  StoredProcedure [dbo].[Proc_InsertCustomer]    Script Date: 05/03/2018 4:04:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[Proc_InsertCustomer]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   ManhNV using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[Proc_InsertCustomer]
-- Date Generated: 05 Tha´ng Ba 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[Proc_InsertCustomer]
	@FirstName nvarchar(100),
	@LastName nvarchar(155),
	@FullName nvarchar(255),
	@CompanyName nvarchar(255),
	@CompanyCodeTax nvarchar(50),
	@Address nvarchar(500),
	@City nvarchar(100),
	@PhoneNumber nvarchar(20),
	@Email nvarchar(100),
	@MemberCardCode nvarchar(50),
	@RankCard int,
	@DebitAmount decimal(18, 0),
	@Note nvarchar(max),
	@CustomerID uniqueidentifier OUTPUT
AS

SET NOCOUNT ON

SET @CustomerID = NEWID()

INSERT INTO [dbo].[Customer] (
	[CustomerID],
	[FirstName],
	[LastName],
	[FullName],
	[CompanyName],
	[CompanyCodeTax],
	[Address],
	[City],
	[PhoneNumber],
	[Email],
	[MemberCardCode],
	[RankCard],
	[DebitAmount],
	[Note]
) VALUES (
	@CustomerID,
	@FirstName,
	@LastName,
	@FullName,
	@CompanyName,
	@CompanyCodeTax,
	@Address,
	@City,
	@PhoneNumber,
	@Email,
	@MemberCardCode,
	@RankCard,
	@DebitAmount,
	@Note
)

--endregion

GO
/****** Object:  StoredProcedure [dbo].[Proc_InsertUpdateCustomer]    Script Date: 05/03/2018 4:04:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[Proc_InsertUpdateCustomer]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   ManhNV using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[Proc_InsertUpdateCustomer]
-- Date Generated: 05 Tha´ng Ba 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[Proc_InsertUpdateCustomer]
	@CustomerID uniqueidentifier,
	@FirstName nvarchar(100),
	@LastName nvarchar(155),
	@FullName nvarchar(255),
	@CompanyName nvarchar(255),
	@CompanyCodeTax nvarchar(50),
	@Address nvarchar(500),
	@City nvarchar(100),
	@PhoneNumber nvarchar(20),
	@Email nvarchar(100),
	@MemberCardCode nvarchar(50),
	@RankCard int,
	@DebitAmount decimal(18, 0),
	@Note nvarchar(max)
AS

SET NOCOUNT ON

IF EXISTS(SELECT [CustomerID] FROM [dbo].[Customer] WHERE [CustomerID] = @CustomerID)
BEGIN
	UPDATE [dbo].[Customer] SET
		[FirstName] = @FirstName,
		[LastName] = @LastName,
		[FullName] = @FullName,
		[CompanyName] = @CompanyName,
		[CompanyCodeTax] = @CompanyCodeTax,
		[Address] = @Address,
		[City] = @City,
		[PhoneNumber] = @PhoneNumber,
		[Email] = @Email,
		[MemberCardCode] = @MemberCardCode,
		[RankCard] = @RankCard,
		[DebitAmount] = @DebitAmount,
		[Note] = @Note
	WHERE
		[CustomerID] = @CustomerID
END
ELSE
BEGIN
	INSERT INTO [dbo].[Customer] (
		[CustomerID],
		[FirstName],
		[LastName],
		[FullName],
		[CompanyName],
		[CompanyCodeTax],
		[Address],
		[City],
		[PhoneNumber],
		[Email],
		[MemberCardCode],
		[RankCard],
		[DebitAmount],
		[Note]
	) VALUES (
		@CustomerID,
		@FirstName,
		@LastName,
		@FullName,
		@CompanyName,
		@CompanyCodeTax,
		@Address,
		@City,
		@PhoneNumber,
		@Email,
		@MemberCardCode,
		@RankCard,
		@DebitAmount,
		@Note
	)
END

--endregion

GO
/****** Object:  StoredProcedure [dbo].[Proc_SelectCustomer]    Script Date: 05/03/2018 4:04:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[Proc_SelectCustomer]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   ManhNV using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[Proc_SelectCustomer]
-- Date Generated: 05 Tha´ng Ba 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[Proc_SelectCustomer]
	@CustomerID uniqueidentifier
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[CustomerID],
	[FirstName],
	[LastName],
	[FullName],
	[CompanyName],
	[CompanyCodeTax],
	[Address],
	[City],
	[PhoneNumber],
	[Email],
	[MemberCardCode],
	[RankCard],
	[DebitAmount],
	[Note]
FROM
	[dbo].[Customer]
WHERE
	[CustomerID] = @CustomerID

--endregion

GO
/****** Object:  StoredProcedure [dbo].[Proc_SelectCustomersAll]    Script Date: 05/03/2018 4:04:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[Proc_SelectCustomersAll]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   ManhNV using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[Proc_SelectCustomersAll]
-- Date Generated: 05 Tha´ng Ba 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[Proc_SelectCustomersAll]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[CustomerID],
	[FirstName],
	[LastName],
	[FullName],
	[CompanyName],
	[CompanyCodeTax],
	[Address],
	[City],
	[PhoneNumber],
	[Email],
	[MemberCardCode],
	[RankCard],
	[DebitAmount],
	[Note]
FROM
	[dbo].[Customer]

--endregion

GO
/****** Object:  StoredProcedure [dbo].[Proc_SelectCustomersDynamic]    Script Date: 05/03/2018 4:04:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[Proc_SelectCustomersDynamic]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   ManhNV using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[Proc_SelectCustomersDynamic]
-- Date Generated: 05 Tha´ng Ba 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[Proc_SelectCustomersDynamic]
	@WhereCondition nvarchar(500),
	@OrderByExpression nvarchar(250) = NULL
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

DECLARE @SQL nvarchar(3250)

SET @SQL = '
SELECT
	[CustomerID],
	[FirstName],
	[LastName],
	[FullName],
	[CompanyName],
	[CompanyCodeTax],
	[Address],
	[City],
	[PhoneNumber],
	[Email],
	[MemberCardCode],
	[RankCard],
	[DebitAmount],
	[Note]
FROM
	[dbo].[Customer]
WHERE
	' + @WhereCondition

IF @OrderByExpression IS NOT NULL AND LEN(@OrderByExpression) > 0
BEGIN
	SET @SQL = @SQL + '
ORDER BY
	' + @OrderByExpression
END

EXEC sp_executesql @SQL

--endregion

GO
/****** Object:  StoredProcedure [dbo].[Proc_SelectCustomersPaged]    Script Date: 05/03/2018 4:04:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[Proc_SelectCustomersPaged]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   ManhNV using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[Proc_SelectCustomersPaged]
-- Date Generated: 05 Tha´ng Ba 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[Proc_SelectCustomersPaged]
AS

SET NOCOUNT ON
SET TRANSACTION ISOLATION LEVEL READ COMMITTED

SELECT
	[CustomerID],
	[FirstName],
	[LastName],
	[FullName],
	[CompanyName],
	[CompanyCodeTax],
	[Address],
	[City],
	[PhoneNumber],
	[Email],
	[MemberCardCode],
	[RankCard],
	[DebitAmount],
	[Note]
FROM
	[dbo].[Customer]

--endregion

GO
/****** Object:  StoredProcedure [dbo].[Proc_UpdateCustomer]    Script Date: 05/03/2018 4:04:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--region [dbo].[Proc_UpdateCustomer]

------------------------------------------------------------------------------------------------------------------------
-- Generated By:   ManhNV using CodeSmith 6.0.0.0
-- Template:       StoredProcedures.cst
-- Procedure Name: [dbo].[Proc_UpdateCustomer]
-- Date Generated: 05 Tha´ng Ba 2018
------------------------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[Proc_UpdateCustomer]
	@CustomerID uniqueidentifier,
	@FirstName nvarchar(100),
	@LastName nvarchar(155),
	@FullName nvarchar(255),
	@CompanyName nvarchar(255),
	@CompanyCodeTax nvarchar(50),
	@Address nvarchar(500),
	@City nvarchar(100),
	@PhoneNumber nvarchar(20),
	@Email nvarchar(100),
	@MemberCardCode nvarchar(50),
	@RankCard int,
	@DebitAmount decimal(18, 0),
	@Note nvarchar(max)
AS

SET NOCOUNT ON

UPDATE [dbo].[Customer] SET
	[FirstName] = @FirstName,
	[LastName] = @LastName,
	[FullName] = @FullName,
	[CompanyName] = @CompanyName,
	[CompanyCodeTax] = @CompanyCodeTax,
	[Address] = @Address,
	[City] = @City,
	[PhoneNumber] = @PhoneNumber,
	[Email] = @Email,
	[MemberCardCode] = @MemberCardCode,
	[RankCard] = @RankCard,
	[DebitAmount] = @DebitAmount,
	[Note] = @Note
WHERE
	[CustomerID] = @CustomerID

--endregion

GO
USE [master]
GO
ALTER DATABASE [CustomerDemo] SET  READ_WRITE 
GO
