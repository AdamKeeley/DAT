/****** Object:  Table [dbo].[tlkGrantStage]    Script Date: 23/11/2021 15:22:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tlkGrantStage](
	[GrantStageID] [int] IDENTITY(1,1) NOT NULL,
	[StageNumber] [decimal](3, 1) NULL,
	[GrantStageDescription] [varchar](25) NULL,
	[ValidFrom] [datetime] NULL,
	[ValidTo] [datetime] NULL,
 CONSTRAINT [PK_GrantStage] PRIMARY KEY NONCLUSTERED 
(
	[GrantStageID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tlkGrantStage] ADD  DEFAULT (getdate()) FOR [ValidFrom]
GO

insert into [dbo].[tlkGrantStage] ([StageNumber] ,[GrantStageDescription])
values 
 (1.0,	'Application')
, (2.0,	'Submitted')
, (3.0,	'Live')
, (4.0,	'Closed')
, (5.0,	'Unsuccessful')


/****** Object:  Table [dbo].[tblKristal]    Script Date: 23/11/2021 15:21:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblKristal](
	[KristalID] [int] IDENTITY(1,1) NOT NULL,
	[KristalRef] [decimal](6, 0) NULL,
	[GrantStageID] [int] NULL,
	[ValidFrom] [datetime] NULL,
	[ValidTo] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
 CONSTRAINT [PK_Kristal] PRIMARY KEY NONCLUSTERED 
(
	[KristalID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblKristal] ADD  DEFAULT (getdate()) FOR [ValidFrom]
GO

ALTER TABLE [dbo].[tblKristal] ADD  DEFAULT (suser_sname()) FOR [CreatedBy]
GO

ALTER TABLE [dbo].[tblKristal]  WITH CHECK ADD  CONSTRAINT [FK_Kristal_GrantStage] FOREIGN KEY([GrantStageID])
REFERENCES [dbo].[tlkGrantStage] ([GrantStageID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tblKristal] CHECK CONSTRAINT [FK_Kristal_GrantStage]
GO

/****** Object:  Table [dbo].[tblProjectKristal]    Script Date: 23/11/2021 15:21:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblProjectKristal](
	[ProjectKristalID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectNumber] [varchar](5) NULL,
	[KristalRef] [decimal](6, 0) NULL,
	[ValidFrom] [datetime] NULL,
	[ValidTo] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
 CONSTRAINT [PK_ProjectKristal] PRIMARY KEY NONCLUSTERED 
(
	[ProjectKristalID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblProjectKristal] ADD  DEFAULT (getdate()) FOR [ValidFrom]
GO

ALTER TABLE [dbo].[tblProjectKristal] ADD  DEFAULT (suser_sname()) FOR [CreatedBy]
GO
