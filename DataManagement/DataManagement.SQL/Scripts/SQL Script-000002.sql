--Script to create table
USE [DataManagement]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 12/24/2016 8:26:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserMobile] [varchar](50) NULL,
	[UserEmail] [varchar](50) NULL,
	[FaceBookUrl] [varchar](50) NULL,
	[LinkedInUrl] [varchar](50) NULL,
	[TwitterUrl] [varchar](50) NULL,
	[PersonalWebUrl] [varchar](50) NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_User_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO


