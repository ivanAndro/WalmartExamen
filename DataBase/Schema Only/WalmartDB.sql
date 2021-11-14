USE [WalmartDB]
GO
/****** Object:  Table [dbo].[Personas]    Script Date: 13/11/2021 10:38:37 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personas](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Phone] [bigint] NOT NULL,
	[CodeCountry] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Personas] ADD  CONSTRAINT [DF_Personas_Id]  DEFAULT (newid()) FOR [Id]
GO
/****** Object:  StoredProcedure [dbo].[SP_Personas_Insert]    Script Date: 13/11/2021 10:38:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Personas_Insert]
	@Name varchar(50),
	@City varchar(50),
	@Phone bigint,
	@CodeCountry varchar(40),
	@Email varchar(100)
AS
BEGIN
	INSERT INTO Personas (Name, City, Phone, CodeCountry, Email) 
	OUTPUT INSERTED.* 
	VALUES(@Name,@City, @Phone, @CodeCountry, @Email)

END
GO
/****** Object:  StoredProcedure [dbo].[SP_Personas_Search]    Script Date: 13/11/2021 10:38:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Personas_Search]
	@City varchar(50),
	@CodeCountry varchar(40)
AS
BEGIN

	SELECT * FROM Personas 
	WHERE 
		City = CASE WHEN @City is not null THEN @City ELSE City END AND
		CodeCountry = CASE WHEN @CodeCountry is not null THEN @CodeCountry ELSE CodeCountry END

END
GO
/****** Object:  StoredProcedure [dbo].[SP_Personas_Update]    Script Date: 13/11/2021 10:38:38 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Personas_Update]
	@Id  uniqueidentifier,
	@Name varchar(50),
	@City varchar(50),
	@Phone bigint,
	@CodeCountry varchar(40),
	@Email varchar(100)
AS
BEGIN
	update Personas 
	SET Name = @Name, City = @City, Phone = @Phone, CodeCountry = @CodeCountry, Email = @Email
	WHERE Id = @Id
	SELECT * FROM Personas WHERE Id = @Id
END
GO
