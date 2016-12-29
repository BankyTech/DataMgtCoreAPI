----Script to delete user
USE [DataManagement]
GO

/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 12/24/2016 8:57:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteUser] 
	@UserId int
AS
BEGIN	
	SET NOCOUNT ON;   

  update Users set IsDeleted=1 where UserId=@UserId
END



GO


