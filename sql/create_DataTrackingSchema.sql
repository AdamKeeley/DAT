USE lida_dat_cms_test
GO

CREATE TABLE dbo.tblDataIORequests(
	RequestID			INT IDENTITY(1,1) NOT NULL,
	Project				VARCHAR(5) NULL,
	-- Include VRE ID foreign key?
	RequestType			INT NOT NULL,
	RequestedBy			VARCHAR(50) NULL, -- Needs to reference user ID once Users table has been created
	RequesterNotes		VARCHAR(MAX) NULL, -- Researchers communication explaining data/etc. Or a link to same text elsewhere?
	ReviewedBy			VARCHAR(50) NULL DEFAULT (suser_sname()),
	ReviewDate			DATETIME NULL DEFAULT (getdate()),
	ReviewNotes			VARCHAR(MAX) NULL, -- Response communication from DAT to confirm import status?
	-- In future, we could include here a ConversationID, linking to DAT-user interactions and remove RequesterNotes and ChangerResponse here
	CONSTRAINT PK_DataIORequests PRIMARY KEY (RequestID)
);

CREATE TABLE dbo.tlkAssetRequestTypes (
	RequestTypeID		INT IDENTITY(1,1) NOT NULL,
	RequestTypeLabel		VARCHAR(25) NULL,
	CONSTRAINT PK_AssetRequestTypes PRIMARY KEY (RequestTypeID)
);
ALTER TABLE dbo.tblDataIORequests
	ADD CONSTRAINT FK_DataIORequests_RequestTypes FOREIGN KEY (RequestType) REFERENCES dbo.tlkAssetRequestTypes (RequestTypeID)
		ON DELETE CASCADE
		ON UPDATE CASCADE;
INSERT INTO dbo.tlkAssetRequestTypes (RequestTypeLabel)
     VALUES (''), ('Import'), ('Export'), ('Delete');

CREATE TABLE dbo.tblAssetsRegister(
	AssetID			INT IDENTITY(1,1) NOT NULL, -- Might be better if this was a sha2 checksum?
	Project			VARCHAR(5) NULL,
	AssetName		VARCHAR(100) NOT NULL,
	AssetSha256sum	CHAR(64) NULL, -- This could become the primary key instead?
	VreFilePath		VARCHAR(200) NULL, -- Path to file in VRE
	CONSTRAINT PK_AssetsRegister PRIMARY KEY (AssetID)
);

-- Intermediary table between dbo.tblDataIORequest
CREATE TABLE dbo.tblAssetsChangeLog(
	ChangeID		INT IDENTITY(1,1) NOT NULL,
	RequestID		INT NOT NULL,
	AssetID			INT NOT NULL,
	TransferMethod	INT NOT NULL,
	DsaReviewed		INT NOT NULL,
	ChangeAccepted	BIT NULL DEFAULT 1, -- 0 = File transfer was rejected
	RejectionNotes	VARCHAR(MAX) NULL, -- Reasons for rejecting change (e.g. not meeting import requirements)
	CONSTRAINT PK_AssetsChangeLog PRIMARY KEY (ChangeID),
	CONSTRAINT FK_AssetsChangeLog_DataIORequests FOREIGN KEY (RequestID) REFERENCES dbo.tblDataIORequests (RequestID),
	CONSTRAINT FK_AssetsChangeLog_AssetsRegister FOREIGN KEY (AssetID) REFERENCES dbo.tblAssetsRegister (AssetID),
	CONSTRAINT FK_AssetsDsas_Dsas FOREIGN KEY (DsaReviewed) REFERENCES dbo.tblDsas (DsaID)
);

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