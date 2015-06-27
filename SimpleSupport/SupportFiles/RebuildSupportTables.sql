-- Drop all tables (DropTables.sql) 
DROP Table Cases;
DROP Table Children;
DROP Table Deductions;
DROP Table Incomes;
DROP Table ParentingTimes;
DROP Table Parties;

DROP Table CityTaxes;
DROP Table DeductionTypes;
DROP Table FilingStatus;
DROP Table PartyTypes;
DROP Table IncomeTypes;

DROP Table __MigrationHistory;

-- Open Package Manager Console (Under Tools)

-- Enable-Migrations -ContextTypeName SimpleSupport.DAL.SupportContext
-- Add-Migration Init
-- Update-Database -Verbose

-- Run Seeding SQL --SeedCodeTables.sql (Be sure to change Database in dropdown)
-- Run Cascade SQL --AddConstraints.sql (Be sure to change Database in dropdown)