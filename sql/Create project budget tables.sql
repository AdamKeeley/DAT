CREATE TABLE [dbo].[tblProjectDatAllocation](
	[ProjectDatAllocationId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectNumber] [varchar](5) NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL
	, Duration			decimal(4,1)
	, DurationComputed	as case when FromDate is null or ToDate is null then [Duration] else cast(ROUND(datediff(d, [FromDate], [ToDate]) / (365.25/12), 1) as decimal(4,1))  end
	,[FTE] [decimal](4, 1) NULL,
	[ValidFrom] [datetime] NULL,
	[ValidTo] [datetime] NULL,
	[CreatedBy] [varchar](12) NULL,
 CONSTRAINT [PK_ProjectDatAllocation] PRIMARY KEY CLUSTERED 
(
	[ProjectDatAllocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblProjectDatAllocation] ADD  DEFAULT (getdate()) FOR [ValidFrom]
GO

ALTER TABLE [dbo].[tblProjectDatAllocation] ADD  DEFAULT (suser_sname()) FOR [CreatedBy]
GO



create table dbo.tlkCostingType (
	CostingTypeId int identity(1,1)
	, CostingTypeDescription varchar(25)

	, ValidFrom datetime default getdate()
	, ValidTo datetime
	, CreatedBy varchar(12) default suser_sname()
	constraint PK_tlkCostingType primary key clustered (CostingTypeId)
	)

insert into dbo.tlkCostingType (CostingTypeDescription) values
('Full VRE')
, ('Archive')
, ('Additional resource')
, ('Extension')

create table dbo.tblProjectCostings (
	ProjectCostingsId integer identity(1,1)
	, ProjectNumber		varchar(5)
	, CostingTypeId		int
	, DateCosted		datetime
	, FromDate			datetime
	, ToDate			datetime
	, Duration			decimal(4,1)
	, DurationComputed	as case when FromDate is null or ToDate is null then [Duration] else cast(ROUND(datediff(d, [FromDate], [ToDate]) / (365.25/12), 1) as decimal(4,1))  end
	, LaserCompute		decimal(19,2)
	, ItsSupport		decimal(19,2)
	, FixedInfra		decimal(19,2)

	, ValidFrom datetime default getdate()
	, ValidTo datetime
	, CreatedBy varchar(12) default suser_sname()
	constraint PK_Projectcostings primary key clustered (ProjectCostingsId)
	)
