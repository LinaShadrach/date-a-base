Create DATABASE date_a_base
go
USE [date_a_base]
GO
/****** Object:  Table [dbo].[matches]    Script Date: 12/21/2016 2:18:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[matches](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user1_id] [int] NULL,
	[user2_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[messages]    Script Date: 12/21/2016 2:18:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[messages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sender_id] [int] NULL,
	[receiver_id] [int] NULL,
	[body] [varchar](max) NULL,
	[viewed] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[photos]    Script Date: 12/21/2016 2:18:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[photos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[url] [varchar](max) NULL,
	[profile] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[state]    Script Date: 12/21/2016 2:18:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[state](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tags]    Script Date: 12/21/2016 2:18:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tags](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tags_users]    Script Date: 12/21/2016 2:18:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tags_users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[tag_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 12/21/2016 2:18:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](255) NULL,
	[last_name] [varchar](255) NULL,
	[zip_code] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[phone_number] [varchar](255) NULL,
	[about_me] [varchar](255) NULL,
	[tag_line] [varchar](255) NULL,
	[user_name] [varchar](255) NULL,
	[password] [varchar](255) NULL,
	[gender_identity] [int] NULL,
	[seeking_gender] [int] NULL
) ON [PRIMARY]
GO
