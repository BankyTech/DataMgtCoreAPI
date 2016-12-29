--Script to update user
USE [DataManagement]
GO

/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 12/24/2016 8:57:40 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[UpdateUser]
	@UserId int,	
	@UserName varchar(50),
	@UserMobile varchar(50),
	@UserEmail varchar(50),
	@FaceBookUrl varchar(50),
	@LinkedInUrl varchar(50),
	@TwitterUrl varchar(50),
	@PersonalWebUrl varchar(50)	
AS
BEGIN

	SET NOCOUNT ON;

	update Users set 
	UserName=@UserName,
	UserMobile=@UserMobile,
	UserEmail=@UserEmail,
	FaceBookUrl=@FaceBookUrl,
	LinkedInUrl=@LinkedInUrl,
	TwitterUrl=@TwitterUrl,
	PersonalWebUrl=@PersonalWebUrl	

  where UserId=@UserId

END


GO


