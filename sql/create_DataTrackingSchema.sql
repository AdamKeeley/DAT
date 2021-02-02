USE lida_dat_cms_test
GO

CREATE TABLE dbo.tblTransferRequests(
	RequestID			INT IDENTITY(1,1) NOT NULL,
	Project				VARCHAR(5) NULL,
	-- Include VRE ID foreign key?
	RequestType			INT NOT NULL,
	RequestedBy			VARCHAR(50) NULL,	-- Needs to reference user ID once Users table has been created
	RequesterNotes		VARCHAR(MAX) NULL,	-- Researchers communication explaining data/etc. Or a link to same text elsewhere?
	ReviewedBy			VARCHAR(50) NULL DEFAULT (suser_sname()),
	ReviewDate			DATETIME NULL DEFAULT (getdate()),
	ReviewNotes			VARCHAR(MAX) NULL,	-- Response communication from DAT to confirm import status?
	-- In future, we could include here a ConversationID, linking to DAT-user interactions and remove RequesterNotes and ChangerResponse here
	CONSTRAINT PK_TransferRequests PRIMARY KEY (RequestID)
);

CREATE TABLE dbo.tlkTransferRequestTypes (
	RequestTypeID		INT IDENTITY(1,1) NOT NULL,
	RequestTypeLabel	VARCHAR(25) NULL,
	CONSTRAINT PK_TransferRequestTypes PRIMARY KEY (RequestTypeID)
);
ALTER TABLE dbo.tblTransferRequests
	ADD CONSTRAINT FK_TransferRequests_RequestTypes FOREIGN KEY (RequestType) REFERENCES dbo.tlkTransferRequestTypes (RequestTypeID)
		ON DELETE CASCADE
		ON UPDATE CASCADE;
INSERT INTO dbo.tlkTransferRequestTypes (RequestTypeLabel)
     VALUES (''), ('Import'), ('Export');

CREATE TABLE dbo.tblAssetsRegister(
	FileID				INT IDENTITY(1,1) NOT NULL,
	Project				VARCHAR(5) NULL,
	DataFileName		VARCHAR(100) NOT NULL,
	Sha256sum			CHAR(64) NULL,
	VreFilePath			VARCHAR(200) NULL,	-- Path to file in VRE
	DataRepoFilePath	VARCHAR(200) NULL,	-- Path to file in DAT Repo \\datstagingdata.file.core.windows.net
	AssetID				INT NULL,			-- ID of asset to which each file belongs
	CONSTRAINT PK_AssetsRegister PRIMARY KEY (FileID)
);

-- Intermediary table between dbo.tblTransferRequests and dbo.tblAssetsRegister
CREATE TABLE dbo.tblAssetsChangeLog(
	ChangeID		INT IDENTITY(1,1) NOT NULL,
	RequestID		INT NOT NULL,
	FileID			INT NOT NULL,
	TransferMethod	INT NOT NULL,
	TransferFrom	VARCHAR(50) NOT NULL,
	TransferTo		VARCHAR(50) NOT NULL,
	DsaReviewed		INT NOT NULL,
	ChangeAccepted	BIT NULL DEFAULT 1, -- 0 = File transfer was rejected
	RejectionNotes	VARCHAR(MAX) NULL,	-- Reasons for rejecting change (e.g. not meeting import requirements)
	CONSTRAINT PK_AssetsChangeLog PRIMARY KEY (ChangeID),
	CONSTRAINT FK_AssetsChangeLog_TransferRequests FOREIGN KEY (RequestID) REFERENCES dbo.tblTransferRequests (RequestID),
	CONSTRAINT FK_AssetsChangeLog_AssetsRegister FOREIGN KEY (FileID) REFERENCES dbo.tblAssetsRegister (FileID),
	CONSTRAINT FK_AssetsDsas_Dsas FOREIGN KEY (DsaReviewed) REFERENCES dbo.tblDsas (DsaID)
);

CREATE TABLE dbo.tblAssetGroups(
	AssetID		INT IDENTITY(1,1) NOT NULL,
	Project		VARCHAR(5) NULL,
	AssetName	VARCHAR(100) NULL,
	CONSTRAINT PK_AssetGroups PRIMARY KEY (AssetID)
);
ALTER TABLE dbo.tblAssetsRegister
	ADD CONSTRAINT FK_AssetsRegister_AssetGroups FOREIGN KEY (AssetID) REFERENCES dbo.tblAssetGroups (AssetID)
		ON DELETE CASCADE
		ON UPDATE CASCADE;

CREATE TABLE dbo.tlkFileTransferMethods(
	MethodID INT IDENTITY(1,1) NOT NULL,
	MethodLabel VARCHAR(25) NULL,
	CONSTRAINT PK_FileTransferMethods PRIMARY KEY (MethodID)
);
ALTER TABLE dbo.tblAssetsChangeLog
	ADD CONSTRAINT FK_AssetsChangeLog_FileTransferMethods FOREIGN KEY (TransferMethod) REFERENCES dbo.tlkFileTransferMethods (MethodID)
		ON DELETE CASCADE
		ON UPDATE CASCADE;
INSERT INTO dbo.tlkFileTransferMethods (MethodLabel)
     VALUES (''), ('Email'), ('SCP'), ('SFT Biscom'), ('SFT SEFT'), ('CPRD'), ('GPG');

--/*
--TO DO NEXT:
--Add DSA table and AssetRegister_DSA intermediary table.
--*/