create database DAT_CMS
go

use [DAT_CMS]
go

CREATE TABLE [dbo].[tblProject](
	[pID] [int] IDENTITY(1,1) NOT NULL,
	[pNumber] [varchar](5) NULL,
	[pName] [varchar](100) NULL,
	[pStage] [int] NULL,
	[pPI] [varchar](60) NULL,
	[pStartDate] [datetime] NULL,
	[pEndDate] [datetime] NULL,
	[ValidFrom] [datetime] NULL DEFAULT (getdate()),
	[ValidTo] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL DEFAULT (suser_sname()),
PRIMARY KEY CLUSTERED 
(
	[pID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[tblProjectNotes](
	[pnID] [int] IDENTITY(1,1) NOT NULL,
	[pNumber] [varchar](5) NULL,
	[pNote] [varchar](max) NULL,
	[Created] [datetime] NULL DEFAULT (getdate()),
	[CreatedBy] [varchar](50) NULL DEFAULT (suser_sname()),
PRIMARY KEY CLUSTERED 
(
	[pnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

CREATE TABLE [dbo].[tlkStage](
	[StageID] [int] IDENTITY(1,1) NOT NULL,
	[pStageDescription] [varchar](25) NULL,
	[ValidFrom] [datetime] NULL DEFAULT (getdate()),
	[ValidTo] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

INSERT INTO [dbo].[tlkStage]
           ([pStageDescription])
     VALUES
           ('Setup'), ('Active'), ('Closed')

