create table dbo.tlkCostingType (
	CostingTypeId int identity(1,1)
	, CostingTypeDescription varchar(25)

	, ValidFrom datetime default getdate()
	, ValidTo datetime
	, CreatedBy varchar(12) default suser_sname()
	constraint PK_tlkCostingType primary key clustered (CostingTypeId)
	)

insert into dbo.tlkCostingType (CostingTypeDescription) values
	('Full VRE - Tier 3')
	, ('Full VRE - Tier 4')
	, ('Enhancment')
	, ('Full VRE - Extension')

create table dbo.tblProjectcostings (
	ProjectCostingsId integer identity(1,1)
	, ProjectNumber		varchar(5)
	, CostingTypeId		int
	, DateCosted		datetime
	, FromDate			datetime
	, ToDate			datetime
	, LaserCompute		decimal(19,4)
	, ItsSupport		decimal(19,4)
	, FixedInfra		decimal(19,4)

	, ValidFrom datetime default getdate()
	, ValidTo datetime
	, CreatedBy varchar(12) default suser_sname()
	constraint PK_Projectcostings primary key clustered (ProjectCostingsId)
	)
