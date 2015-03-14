-- --------------------------------------------------
-- When a Case record is deleted...
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CaseChild]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Children] DROP CONSTRAINT [FK_CaseChild];
GO

-- Creating foreign key on [CaseId] in table 'Children'
ALTER TABLE [dbo].[Children]
ADD CONSTRAINT [FK_CaseChild]
    FOREIGN KEY ([Case_CaseId])
    REFERENCES [dbo].[Cases]
        ([CaseId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

--IF OBJECT_ID(N'[dbo].[FK_CaseParentingTime]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[ParentingTimes] DROP CONSTRAINT [FK_CaseParentingTime];
--GO

---- Creating foreign key on [CaseId] in table 'ParentingTimes'
--ALTER TABLE [dbo].[ParentingTimes]
--ADD CONSTRAINT [FK_CaseParentingTime]
--    FOREIGN KEY ([Case_CaseId])
--    REFERENCES [dbo].[Cases]
--        ([CaseId])
--    ON DELETE CASCADE ON UPDATE NO ACTION;

IF OBJECT_ID(N'[dbo].[FK_CaseParty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Parties] DROP CONSTRAINT [FK_CaseParty];
GO

-- Creating foreign key on [CaseId] in table 'Parties'
ALTER TABLE [dbo].[Parties]
ADD CONSTRAINT [FK_CaseParty]
    FOREIGN KEY ([Case_CaseId])
    REFERENCES [dbo].[Cases]
        ([CaseId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- --------------------------------------------------
-- When a Party record is deleted...
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PartyIncome]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Incomes] DROP CONSTRAINT [FK_PartyIncome];
GO

-- The Income records will be deleted
-- Creating foreign key on [PartyId] in table 'Incomes'
ALTER TABLE [dbo].[Incomes]
ADD CONSTRAINT [FK_PartyIncome]
    FOREIGN KEY ([Party_PartyId])
    REFERENCES [dbo].[Parties]
        ([PartyId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

IF OBJECT_ID(N'[dbo].[FK_PartyDeduction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Deductions] DROP CONSTRAINT [FK_PartyDeduction];
GO

-- Creating foreign key on [PartyId] in table 'Deductions'
ALTER TABLE [dbo].[Deductions]
ADD CONSTRAINT [FK_PartyDeduction]
    FOREIGN KEY ([Party_PartyId])
    REFERENCES [dbo].[Parties]
        ([PartyId])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
