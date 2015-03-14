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

-- Open Package Manager Console

-- Enable-Migrations -ContextTypeName SimpleSupport.DAL.SupportContext
-- Add-Migration Init
-- Update-Database -Verbose

-- Run Seeding SQL --SeedCalculationTables.sql
-- Run Cascade CSL --AddConstraints.sql