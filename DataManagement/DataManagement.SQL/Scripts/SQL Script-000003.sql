--Script to add user
USE [DataManagement]
GO

/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 12/24/2016 8:57:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create PROCEDURE [dbo].[AddUser] 
	@UserName varchar(50),
	@UserMobile varchar(50),
	@UserEmail varchar(50),
	@FaceBookUrl varchar(50),
	@LinkedInUrl varchar(50),
	@TwitterUrl varchar(50),
	@PersonalWebUrl varchar(50)	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   insert into Users (UserName, UserMobile, UserEmail, FaceBookUrl, LinkedInUrl, TwitterUrl, PersonalWebUrl) 
   values (@UserName,@UserMobile,@UserEmail,@FaceBookUrl,@LinkedInUrl,@TwitterUrl,@PersonalWebUrl)

END

GO


