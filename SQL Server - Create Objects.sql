create database DAT_CMS
go

use [DAT_CMS]
go


/************************************************************
*	Project stuff 
************************************************************/
CREATE TABLE [dbo].[tblProject](
	[pID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectNumber] [varchar](5) NULL,
	[ProjectName] [varchar](100) NULL,
	[Stage] [int] NULL,
	[Classification] [int] NULL,
	[DATRAG] [int] NULL,
	[ProjectedStartDate] [datetime] NULL,
	[ProjectedEndDate] [datetime] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[PI] [int] NULL,
	[LeadApplicant] [int] NULL,
	[Faculty] [int] NULL,
	[LIDA] [bit] NULL,
	[DSPT] [bit] NULL,
	[ISO27001] [bit] NULL,
	[Azure] [bit] NULL,
	[IRC] [bit] NULL,
	[SEED] [bit] NULL,
	[ValidFrom] [datetime] NULL,
	[ValidTo] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY NONCLUSTERED 
(
	[pID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblProject] ADD  DEFAULT ((0)) FOR [LIDA]
GO

ALTER TABLE [dbo].[tblProject] ADD  DEFAULT ((0)) FOR [DSPT]
GO

ALTER TABLE [dbo].[tblProject] ADD  DEFAULT ((0)) FOR [ISO27001]
GO

ALTER TABLE [dbo].[tblProject] ADD  DEFAULT ((0)) FOR [Azure]
GO

ALTER TABLE [dbo].[tblProject] ADD  DEFAULT ((0)) FOR [IRC]
GO

ALTER TABLE [dbo].[tblProject] ADD  DEFAULT ((0)) FOR [SEED]
GO

ALTER TABLE [dbo].[tblProject] ADD  DEFAULT (getdate()) FOR [ValidFrom]
GO

ALTER TABLE [dbo].[tblProject] ADD  DEFAULT (suser_sname()) FOR [CreatedBy]
GO

CREATE TABLE [dbo].[tblProjectNotes](
	[pnID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectNumber] [varchar](5) NULL,
	[pNote] [varchar](max) NULL,
	[Created] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
 CONSTRAINT [PK_ProjectNotes] PRIMARY KEY NONCLUSTERED 
(
	[pnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblProjectNotes] ADD  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[tblProjectNotes] ADD  DEFAULT (suser_sname()) FOR [CreatedBy]
GO

CREATE TABLE [dbo].[tlkClassification](
	[classificationID] [int] IDENTITY(1,1) NOT NULL,
	[classificationDescription] [varchar](25) NULL,
	[ValidFrom] [datetime] NULL,
	[ValidTo] [datetime] NULL,
 CONSTRAINT [PK_Classification] PRIMARY KEY NONCLUSTERED 
(
	[classificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tlkClassification] ADD  DEFAULT (getdate()) FOR [ValidFrom]
GO

CREATE TABLE [dbo].[tlkFaculty](
	[facultyID] [int] IDENTITY(1,1) NOT NULL,
	[facultyDescription] [varchar](100) NULL,
	[ValidFrom] [datetime] NULL,
	[ValidTo] [datetime] NULL,
 CONSTRAINT [PK_Faculty] PRIMARY KEY NONCLUSTERED 
(
	[facultyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tlkFaculty] ADD  DEFAULT (getdate()) FOR [ValidFrom]
GO

CREATE TABLE [dbo].[tlkRAG](
	[ragID] [int] IDENTITY(1,1) NOT NULL,
	[ragDescription] [varchar](25) NULL,
	[ValidFrom] [datetime] NULL,
	[ValidTo] [datetime] NULL,
 CONSTRAINT [PK_RAG] PRIMARY KEY NONCLUSTERED 
(
	[ragID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tlkRAG] ADD  DEFAULT (getdate()) FOR [ValidFrom]
GO

CREATE TABLE [dbo].[tlkStage](
	[StageID] [int] IDENTITY(1,1) NOT NULL,
	[pStageDescription] [varchar](25) NULL,
	[ValidFrom] [datetime] NULL,
	[ValidTo] [datetime] NULL,
 CONSTRAINT [PK_Stage] PRIMARY KEY NONCLUSTERED 
(
	[StageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tlkStage] ADD  DEFAULT (getdate()) FOR [ValidFrom]
GO


ALTER TABLE [dbo].[tblProject]  WITH CHECK ADD  CONSTRAINT [FK_Project_Classification] FOREIGN KEY([Classification])
REFERENCES [dbo].[tlkClassification] ([classificationID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tblProject] CHECK CONSTRAINT [FK_Project_Classification]
GO

ALTER TABLE [dbo].[tblProject]  WITH CHECK ADD  CONSTRAINT [FK_Project_DATRAG] FOREIGN KEY([DATRAG])
REFERENCES [dbo].[tlkRAG] ([ragID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tblProject] CHECK CONSTRAINT [FK_Project_DATRAG]
GO

ALTER TABLE [dbo].[tblProject]  WITH CHECK ADD  CONSTRAINT [FK_Project_Faculty] FOREIGN KEY([Faculty])
REFERENCES [dbo].[tlkFaculty] ([facultyID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tblProject] CHECK CONSTRAINT [FK_Project_Faculty]
GO

ALTER TABLE [dbo].[tblProject]  WITH CHECK ADD  CONSTRAINT [FK_Project_Stage] FOREIGN KEY([Stage])
REFERENCES [dbo].[tlkStage] ([StageID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tblProject] CHECK CONSTRAINT [FK_Project_Stage]
GO

INSERT INTO [dbo].[tlkStage]
           ([pStageDescription])
     VALUES
           ('Setup'), ('Active'), ('Closed')

/************************************************************
*	User stuff 
************************************************************/

create table dbo.tblUser (
	 [UserID] int identity(1,1)
	, UserNumber int
	, [Status] int
	, [Title] int
	, [FirstName] varchar(50)
	, [LastName] varchar(50)
	, [Email] varchar(255)
	, [Phone] varchar(15)
	, [UserName] varchar(12)
	, [Organisation] varchar(255)
	, [StartDate] datetime
	, [EndDate] datetime
	, [Priviledged] bit default 0
	, [IRCAgreement] datetime
	, [ISET] datetime
	, [ISAT] datetime
	, [SAFE] datetime
	, [TokenSerial] bigint
	, [TokenIssued] datetime
	, [TokenReturned] datetime
	, [ValidFrom] datetime default getdate()
	, [ValidTo] datetime 
	, [CreatedBy] varchar(50) default suser_sname()
	constraint PK_User primary key nonclustered (UserID)
	)

create table dbo.tblUserNotes (
	unID int identity(1,1)
	, UserID int
	, uNote varchar(max)
	, Created datetime default getdate()
	, CreatedBy varchar(50) default suser_name()
	constraint PK_UserNotes primary key nonclustered (unID)
	)

create table dbo.tblUserProject (
	UserNumber int
	, ProjectNumber varchar(5)
	, [ValidFrom] datetime default getdate()
	, [ValidTo] datetime 
	, [CreatedBy] varchar(50) default suser_sname()
	constraint PK_UserProject primary key nonclustered (UserNumber, ProjectNumber)
	)


create table dbo.tlkUserStatus (
	StatusID int identity(1,1)
	, StatusDescription varchar(25)
	, [ValidFrom] datetime default getdate()
	, [ValidTo] datetime 
	constraint PK_UserStatus primary key nonclustered (StatusID)
	)
alter table dbo.tblUser
add constraint FK_User_UserStatus foreign key ([Status])
	references dbo.tlkUserStatus(StatusID)
	on update cascade
	on delete cascade

create table dbo.tlkTitle (
	TitleID int identity(1,1)
	, TitleDescription varchar(25)
	, [ValidFrom] datetime default getdate()
	, [ValidTo] datetime 
	constraint PK_Title primary key nonclustered (TitleID)
	)
alter table dbo.tblUser
add constraint FK_User_Title foreign key ([Title])
	references dbo.tlkTitle(TitleID)
	on update cascade
	on delete cascade

insert into dbo.tlkTitle (TitleDescription) values 
	('Mr'), ('Mrs'), ('Ms'), ('Miss'), ('Dr'), ('Prof'), ('Sir')

 insert into dbo.tlkUserStatus (StatusDescription) values
	('Enabled'), ('Disabled')


