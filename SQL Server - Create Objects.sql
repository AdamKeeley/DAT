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

/*
Data tracking tables schema
*/

CREATE TABLE dbo.tblDataIORequests(
	RequestID			INT IDENTITY(1,1) NOT NULL,
	Project				INT NOT NULL,
	-- Include VRE ID foreign key?
	ChangeType			INT NOT NULL,
	ChangeDate			DATETIME NULL DEFAULT (getdate()),
	ChangedBy			VARCHAR(50) NULL DEFAULT (suser_sname()),
	RequestedBy			VARCHAR(50) NULL, -- Needs to reference user ID once Users table has been created
	RequesterNotes		VARCHAR(MAX) NULL, -- Researchers communication explaining data/etc. Or a link to same text elsewhere?
	ChangerResponse		VARCHAR(MAX) NULL, -- Response communication from DAT to confirm import status?
	-- In future, we could include here a ConversationID, linking to DAT-user interactions and remove RequesterNotes and ChangerResponse here
	CONSTRAINT PK_DataIORequests PRIMARY KEY (RequestID),
	CONSTRAINT FK_DataIORequests_Projects FOREIGN KEY (Project) REFERENCES dbo.tblProject (pID)
);

CREATE TABLE dbo.tlkAssetChangeTypes (
	ChangeTypeID		INT IDENTITY(1,1) NOT NULL,
	ChangeTypeLabel		VARCHAR(25) NULL,
	CONSTRAINT PK_AssetChangeTypes PRIMARY KEY (ChangeTypeID)
);
ALTER TABLE dbo.tblDataIORequests
	ADD CONSTRAINT FK_DataIORequests_ChangeType FOREIGN KEY (ChangeType) REFERENCES dbo.tlkAssetChangeTypes (ChangeTypeID)
		ON DELETE CASCADE
		ON UPDATE CASCADE;
INSERT INTO dbo.tlkAssetChangeTypes (ChangeTypeLabel)
     VALUES (''), ('Import'), ('Export'), ('Delete');

CREATE TABLE dbo.tblAssetsRegister(
	AssetID			INT IDENTITY(1,1) NOT NULL, -- Might be better if this was a sha2 checksum?
	Project			INT NOT NULL,
	AssetName		VARCHAR(100) NOT NULL,
	AssetSha256sum	CHAR(64) NULL, -- This could become the primary key instead?
	-- Asset-DSA will be many-to-many so will probably need intermediary table
	VreFilePath		VARCHAR(200) NULL, -- Path to file in VRE
	CONSTRAINT PK_AssetsRegister PRIMARY KEY (AssetID),
	CONSTRAINT FK_AssetsRegister_Projects FOREIGN KEY (Project) REFERENCES dbo.tblProject (pID)
);

-- Intermediary table between dbo.tblDataIORequest
CREATE TABLE dbo.tblAssetsChangeLog(
	ChangeID		INT IDENTITY(1,1) NOT NULL,
	RequestID		INT NOT NULL,
	AssetID			INT NOT NULL,
	ChangeAccepted	BIT NULL DEFAULT 1, -- 0 = File transfer was rejected
	RejectionNotes	VARCHAR(MAX) NULL, -- Reasons for rejecting change (e.g. not meeting import requirements)
	CONSTRAINT PK_AssetsChangeLog PRIMARY KEY (ChangeID),
	CONSTRAINT FK_AssetsChangeLog_DataIORequests FOREIGN KEY (RequestID) REFERENCES dbo.tblDataIORequests (RequestID),
	CONSTRAINT FK_AssetsChangeLog_AssetsRegister FOREIGN KEY (AssetID) REFERENCES dbo.tblAssetsRegister (AssetID)
);



/*
TO DO NEXT:
Add DSA table and AssetRegister_DSA intermediary table.

*/