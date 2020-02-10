create database DST_CMS
go

use [DST_CMS]
go

create table dbo.tblProject (
	pID int identity(1,1) primary key
	, pNumber varchar(5)
	, pName varchar(100)
	, pStage varchar(20)
	, pPI varchar(60)
	, ValidFrom datetime DEFAULT getdate()
	, ValidUntil datetime 
	, CreatedBy varchar(50) DEFAULT suser_sname()
	)
