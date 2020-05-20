use DAT_CMS
go

CREATE TABLE dbo.tblDsas(
	DsaID		INT IDENTITY(1,1) NOT NULL,
	DataOwner	INT NOT NULL,
	AmendmentOf	INT NULL, -- References primary key to link amendments with original agreement
	DsaName		VARCHAR(100) NULL,
	DsaFileLoc	VARCHAR(200) NULL,
	StartDate	DATETIME NULL,
	ExpiryDate	DATETIME NULL,
	DSPT		BIT NOT NULL,
	ISO270001	BIT NOT NULL,
	DateAdded	DATETIME NULL DEFAULT (getdate()),
	LastUpdated	DATETIME NULL,
	CONSTRAINT PK_Dsas PRIMARY KEY (DsaID),
	CONSTRAINT FK_AmendmentOf_DsaID FOREIGN KEY (AmendmentOf) REFERENCES dbo.tblDsas (DsaID)
)

CREATE TABLE dbo.tblDsaNotes(
	dnID		INT IDENTITY(1,1) NOT NULL,
	Dsa			INT NOT NULL,
	Note		VARCHAR(MAX) NULL,
	Created		DATETIME NULL DEFAULT (getdate()),
	CreatedBy	VARCHAR(50) NULL DEFAULT (suser_sname()),
	CONSTRAINT PK_DsaNotes PRIMARY KEY (dnID)
)

CREATE TABLE dbo.tblDsasProjects(
	dpID		INT IDENTITY(1,1) NOT NULL,
	DsaID		INT NOT NULL,
	Project		VARCHAR(5) NULL,
	DateAdded	DATETIME NULL DEFAULT (getdate()),
	CONSTRAINT PK_DsasProjects PRIMARY KEY (dpID),
	CONSTRAINT FK_DsasProjects_Dsas FOREIGN KEY (DsaID) REFERENCES dbo.tblDsas (DsaID)
)

CREATE TABLE dbo.tblDsaDataOwners(
	doID			INT IDENTITY(1,1) NOT NULL,
	RebrandOf		INT NULL, -- References primary key to link brands when they change their name
	DataOwnerName	VARCHAR(50) NOT NULL UNIQUE,
	CONSTRAINT PK_DataOwners PRIMARY KEY (doID),
	CONSTRAINT FK_RebrandOf_doID FOREIGN KEY (RebrandOf) REFERENCES dbo.tblDsaDataOwners (doID)
)
ALTER TABLE dbo.tblDsas
	ADD CONSTRAINT FK_Dsas_DataOwners FOREIGN KEY (DataOwner) REFERENCES dbo.tblDsaDataOwners (doID)