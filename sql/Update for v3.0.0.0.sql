/****** Object:  Table [dbo].[tblProjectNotes]    Script Date: 01/12/2021 15:41:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblKristalNotes](
	[knID] [int] IDENTITY(1,1) NOT NULL,
	[KristalRef] int NULL,
	[KristalNote] [varchar](max) NULL,
	[Created] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
 CONSTRAINT [PK_KristalNotes] PRIMARY KEY NONCLUSTERED 
(
	[knID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblKristalNotes] ADD  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[tblKristalNotes] ADD  DEFAULT (suser_sname()) FOR [CreatedBy]
GO


alter view [dbo].[vw_AllProjects]
as

SELECT [ProjectNumber]
	,isnull([ProjectName], '') as [ProjectName]
	,isnull([PortfolioNumber], '') as [PortfolioNumber]
	,s.pStageDescription as [Stage]
	,c.classificationDescription as [Classification]
	,r.ragDescription as [DATRAG]
	,[ProjectedStartDate]
	,[ProjectedEndDate]
	,p.[StartDate]
	,p.[EndDate]
	,isnull(userPI.LastName + ', ' + userPI.FirstName, '') as [PI]
	,isnull(userLA.LastName + ', ' + userLA.FirstName, '') as [LeadApplicant]
	,isnull(f.facultyDescription, '') as [Faculty]
	,[LIDA]
	,[DSPT]
	,[ISO27001]
	,[LASER]
	,[IRC]
	,[SEED]
FROM [dbo].[tblProject] p
	left join [dbo].[tlkClassification] c
		on p.[Classification] = c.classificationID
	left join [dbo].[tlkRAG] r
		on p.DATRAG = r.ragID
	left join [dbo].[tlkFaculty] f
		on p.Faculty = f.facultyID
	left join [dbo].[tlkStage] s
		on p.Stage = s.StageID
	left join [dbo].[tblUser] userPI
		on p.[PI] = userPI.UserNumber
	left join [dbo].[tblUser] userLA
		on p.[LeadApplicant] = userLA.UserNumber
where p.ValidTo is null
	and userPI.ValidTo is null
	and userLA.ValidTo is null
GO

