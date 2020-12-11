-- First drop the constraint that defaults [LIDA] to 0
alter table [dbo].[tblProject] drop constraint [DF__tblProject__LIDA__2A164134]
-- then add new constraint that defaults [LIDA] to 1 
ALTER TABLE [dbo].[tblProject] ADD  DEFAULT ((1)) FOR [LIDA]
GO
