update [dbo].[tlkStage]
set ValidTo = getdate()
where StageID in (4, 5)

insert into [dbo].[tlkStage] (pStageDescription) values 
	  ('Proposal')
	, ('Pre-grant')
	, ('Store')
	, ('Destroy')

alter table [dbo].[tlkStage]
add [StageNumber] decimal(3,1)

update [dbo].[tlkStage]
set [StageNumber] = 1 where StageID = 6
update [dbo].[tlkStage]
set [StageNumber] = 2 where StageID = 7
update [dbo].[tlkStage]
set [StageNumber] = 3 where StageID = 1
update [dbo].[tlkStage]
set [StageNumber] = 4 where StageID = 2
update [dbo].[tlkStage]
set [StageNumber] = 5 where StageID = 3
update [dbo].[tlkStage]
set [StageNumber] = 6.1 where StageID = 8
update [dbo].[tlkStage]
set [StageNumber] = 6.2 where StageID = 9

SELECT *
into #t
FROM [dbo].[tlkStage]

ALTER TABLE [dbo].[tblProject] DROP CONSTRAINT [FK_Project_Stage]

drop table [dbo].[tlkStage]

create table [dbo].[tlkStage](
	  [StageID] int IDENTITY(1,1) NOT NULL
	, [pStageDescription] varchar(25) NULL
	, [StageNumber] decimal(3, 1) NULL
	, [ValidFrom] datetime NULL DEFAULT (getdate())
	, [ValidTo] datetime NULL
	CONSTRAINT [PK_Stage] PRIMARY KEY NONCLUSTERED ([StageID])
	)

insert into [dbo].[tlkStage] (pStageDescription
	, StageNumber
	, ValidFrom
	, ValidTo)
select pStageDescription
	, StageNumber
	, ValidFrom
	, ValidTo
from #t

ALTER TABLE [dbo].[tblProject]  WITH CHECK ADD  CONSTRAINT [FK_Project_Stage] FOREIGN KEY([Stage])
REFERENCES [dbo].[tlkStage] ([StageID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

drop table #t


