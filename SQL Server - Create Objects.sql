--create database DAT_CMS
--go

use DAT_CMS
go

CREATE TABLE dbo.tblProject(
	  pID					int IDENTITY(1,1) NOT NULL
	, ProjectNumber			varchar(5) NULL
	, ProjectName			varchar(100) NULL
	, Stage					int NULL
	, Classification		int
	, DATRAG				int
	, ProjectedStartDate	datetime null
	, ProjectedEndDate		datetime null
	, StartDate				datetime NULL
	, EndDate				datetime NULL
	, [PI]					varchar(60) NULL
	, LeadApplicant			varchar(60)
	, Faculty				int
	, LIDA					bit default 0
	, DSPT					bit default 0
	, ISO27001				bit default 0
	, Azure					bit default 0
	, IRC					bit default 0
	, SEED					bit default 0
	, ValidFrom				datetime NULL DEFAULT (getdate())
	, ValidTo				datetime NULL
	, CreatedBy				varchar(50) NULL DEFAULT (suser_sname())
	, constraint PK_Project primary key nonclustered (pID)
	)

CREATE TABLE dbo.tblProjectNotes(
	pnID int IDENTITY(1,1) NOT NULL
	, ProjectNumber varchar(5) NULL
	, pNote varchar(max) NULL
	, Created datetime NULL DEFAULT (getdate())
	, CreatedBy varchar(50) NULL DEFAULT (suser_sname())
	, constraint PK_ProjectNotes primary key nonclustered (pnID)
	)

CREATE TABLE dbo.tlkStage(
	StageID int IDENTITY(1,1) NOT NULL
	, pStageDescription varchar(25) NULL
	, ValidFrom datetime NULL DEFAULT (getdate())
	, ValidTo datetime NULL
	, constraint PK_Stage primary key nonclustered (StageID)
	)
alter table dbo.tblProject
	add constraint FK_Project_Stage foreign key (Stage)
		references dbo.tlkStage (StageID)
		on delete cascade
		on update cascade

CREATE TABLE dbo.tlkClassification (
	classificationID int IDENTITY(1,1) NOT NULL
	, classificationDescription varchar(25) NULL
	, ValidFrom datetime NULL DEFAULT (getdate())
	, ValidTo datetime NULL
	, constraint PK_Classification primary key nonclustered (classificationID)
	)
alter table dbo.tblProject
	add constraint FK_Project_Classification foreign key (Classification)
		references dbo.tlkClassification (classificationID)
		on delete cascade
		on update cascade

CREATE TABLE dbo.tlkRAG (
	ragID int IDENTITY(1,1) NOT NULL
	, ragDescription varchar(25) NULL
	, ValidFrom datetime NULL DEFAULT (getdate())
	, ValidTo datetime NULL
	, constraint PK_RAG primary key nonclustered (ragID)
	)
alter table dbo.tblProject
	add constraint FK_Project_DATRAG foreign key (DATRAG)
		references dbo.tlkRAG (ragID)
		on delete cascade
		on update cascade 

CREATE TABLE dbo.tlkFaculty (
	facultyID int IDENTITY(1,1) NOT NULL
	, facultyDescription varchar(100) NULL
	, ValidFrom datetime NULL DEFAULT (getdate())
	, ValidTo datetime NULL
	, constraint PK_Faculty primary key nonclustered (facultyID)
	)
alter table dbo.tblProject
	add constraint FK_Project_Faculty foreign key (Faculty)
		references dbo.tlkFaculty (facultyID)
		on delete cascade
		on update cascade 


--INSERT INTO dbo.tblProject
--           (ProjectNumber, ProjectName)
--     VALUES
--           ('P0001', 'Seeder project')

INSERT INTO dbo.tlkStage
           (pStageDescription)
     VALUES
           (''), ('Pre-Approval'), ('Setup'), ('Active'), ('Frozen'), ('Closed')

INSERT INTO dbo.tlkClassification
           (classificationDescription)
     VALUES
           (''), ('IRC_Unclassified'), ('IRC_Protect'), ('IRC_Confidential'), ('IRC_Secure')

INSERT INTO dbo.tlkRAG
           (ragDescription)
     VALUES
           (''), ('Green'), ('Orange'), ('Red')

INSERT INTO dbo.tlkFaculty
           (facultyDescription)
     VALUES
           (''), ('Arts Humanities and Cultures'), ('Biological Sciences'), ('Business'), ('Social Sciences'), ('Engineering and Physical Sciences'), ('Environment'), ('Medicine and Health'), ('Interdisciplinary')


-- Data tracking tables schema

CREATE TABLE dbo.tblImportRequests(
	ImportID			INT IDENTITY(1,1) NOT NULL,
	Project				INT NOT NULL,
	-- Include VRE ID foreign key?
	DateImported		DATETIME NULL DEFAULT (getdate()),
	ImportedBy			VARCHAR(50) NULL DEFAULT (suser_sname()),
	RequestedBy			VARCHAR(50) NULL, -- Needs to reference user ID once Users table has been created
	RequestersNotes		VARCHAR(MAX) NULL, -- Researchers communication explaining data/etc. Or a link to same text elsewhere?
	ImportersResponse	VARCHAR(MAX) NULL, -- Response communication from DAT to confirm import status?
	CONSTRAINT PK_ImportRequests PRIMARY KEY (ImportID),
	CONSTRAINT FK_ImportsRefsProjects FOREIGN KEY (Project) REFERENCES dbo.tblProject (pID)
);

CREATE TABLE dbo.tblImportedAssets(
	AssetID			INT IDENTITY(1,1) NOT NULL, -- Might be better if this was a sha2 checksum?
	Import			INT NOT NULL,
	AssetName		VARCHAR(100) NOT NULL,
	AssetSha256sum	CHAR(64) NULL, -- This could become the primary key instead?
	-- Include data provider id column? Would need to reference a separate DataProviders tbl ... do we need one?
	VreFilePath		VARCHAR(200) NULL, -- Path to file in VRE
	FileAccepted	BIT NULL DEFAULT 1, -- 0 = File transfer was rejected by importer
	RejectionNotes	VARCHAR(MAX) NULL, -- Importer's reasons for rejecting the file (e.g. not meeting requirements)
	-- Add column showing if file is still in VRE? Default=exists, but create Destructions tbl and cascade on update its new status?
	CONSTRAINT PK_ImportedAssets PRIMARY KEY (AssetID),
	CONSTRAINT FK_InAssetsRefsInRequests FOREIGN KEY (Import) REFERENCES dbo.tblImportRequests (ImportID)
);

CREATE TABLE dbo.tblExportRequests(
	ExportID			INT IDENTITY(1,1) NOT NULL,
	Project				INT NOT NULL,
	-- Include VRE ID foreign key?
	DateExported		DATETIME NULL DEFAULT (getdate()),
	ExportedBy			VARCHAR(50) NULL DEFAULT (suser_sname()),
	RequestedBy			VARCHAR(50) NULL, -- Needs to reference user ID once Users table has been created
	RequestersNotes		VARCHAR(MAX) NULL, -- Researchers communication explaining data/etc. Or a link to same text elsewhere?
	ExportersResponse	VARCHAR(MAX) NULL, -- Response communication from DAT to confirm export status?
	CONSTRAINT PK_ExportRequests PRIMARY KEY (ExportID),
	CONSTRAINT FK_ExportsRefsProjects FOREIGN KEY (Project) REFERENCES dbo.tblProject (pID)
);

CREATE TABLE dbo.tblExportedAssets(
	AssetID			INT IDENTITY(1,1) NOT NULL, -- Might be better if this was a sha2 checksum?
	Export			INT NOT NULL,
	AssetName		VARCHAR(100) NOT NULL,
	AssetSha256sum	CHAR(64) NULL, -- This could become the primary key instead?
	-- Include data provider id column? Would need to reference a separate DataProviders tbl ... do we need one?
	VreFilePath		VARCHAR(200) NULL, -- Path to file in VRE
	FileAccepted	BIT NULL DEFAULT 1, -- 0 = File transfer was rejected by exporter
	RejectionNotes	VARCHAR(MAX) NULL, -- Exporter's reasons for rejecting the file (e.g. not meeting requirements)
	-- Add column showing if file is still in VRE? Default=exists, but create Destructions tbl and cascade on update its new status?
	CONSTRAINT PK_ExportedAssets PRIMARY KEY (AssetID),
	CONSTRAINT FK_OutAssetsRefsOutRequests FOREIGN KEY (Export) REFERENCES dbo.tblExportRequests (ExportID)
);

/*
Do we need to log data destructions?

If so, we'd want to have a way to keeping a log of current assets
and updated that log when an asset gets destroyed.

A data destructions table could include any communications
and signed confirmations regarding the permanent destruction.
*/