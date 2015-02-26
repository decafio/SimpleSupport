-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--	Populate FilingStatus
-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

If not exists(SELECT * FROM FilingStatus WHERE [Code] = 'Single')
INSERT INTO FilingStatus([Name],[Code]) VALUES
('Single','Single')

If not exists(SELECT * FROM FilingStatus WHERE [Code] = 'Head')
INSERT INTO FilingStatus([Name],[Code]) VALUES
('Head of Household','Head')

If not exists(SELECT * FROM FilingStatus WHERE [Code] = 'Jointly')
INSERT INTO FilingStatus([Name],[Code]) VALUES
('Married Filing Jointly','Jointly')

If not exists(SELECT * FROM FilingStatus WHERE [Code] = 'Seperately')
INSERT INTO FilingStatus([Name],[Code]) VALUES
('Married Filing Seperatly','Seperately')

If not exists(SELECT * FROM FilingStatus WHERE [Code] = 'Widow')
INSERT INTO FilingStatus([Name],[Code]) VALUES
('Qualified Widow','Widow')

-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
--	Populate CityFilingStatus
-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'No City Tax')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('No City Tax', 0.000)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Albion (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Albion (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Albion (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Albion (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Battle Creek (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Battle Creek (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Battle Creek (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Battle Creek (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Big Rapids (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Big Rapids (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Big Rapids (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Big Rapids (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Flint (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Flint (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Flint (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Flint (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Grayling (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Grayling (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Grayling (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Grayling (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Hamtramck (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Hamtramck (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Hamtramck (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Hamtramck (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Hudson (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Hudson (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Hudson (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Hudson (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Ionia (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Ionia (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Ionia (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Ionia (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Jackson (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Jackson (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Jackson (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Jackson (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Lansing (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Lansing (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Lansing (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Lansing (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Lapeer (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Lapeer (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Lapeer (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Lapeer (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Muskegon (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Muskegon (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Muskegon (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Muskegon (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Muskegon Heights (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Muskegon Heights (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Muskegon Heights (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Muskegon Heights (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Pontiac (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Pontiac (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Pontiac (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Pontiac (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Port Huron (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Port Huron (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Port Huron (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Port Huron (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Portland (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Portland (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Portland (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Portland (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Springfield (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Springfield (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Springfield (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Springfield (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Walker (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Walker (Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Walker (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Walker (Non-Resident)',0.005)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Detroit (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Detroit (Resident)',0.024)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Detroit (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Detroit (Non-Resident)', 0.014)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Grand Rapids (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Grand Rapids (Resident)',0.015)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Grand Rapids (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Grand Rapids (Non-Resident)',0.075)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Highland Park (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Highland Park (Resident)', 0.020)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Highland Park (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Highland Park (Non-Resident)',0.010)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Saginaw (Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Saginaw (Resident)',0.015)

If not exists(SELECT * FROM CityTaxes WHERE [Name] = 'Saginaw (Non-Resident)')
INSERT INTO CityTaxes([Name],[TaxRate]) VALUES
('Saginaw (Non-Resident)',0.075)


-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Populate DeductionTypes Table
-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
If not exists(SELECT * FROM DeductionTypes WHERE [Code] = 'Alimony')
INSERT INTO DeductionTypes([Name], [Description], [FederalTax], [NIITax], [AMTTax], [SETax], [StateTax], [FICA], [CityTax], [Code]) VALUES
('Alimony / Spousal Support'
,'Deduct alimony/spousal support paid to someone other than the other parent in the case under consideration from its payer’s gross income before calculating and deducting its payer’s federal, state, and local income taxes, and after deducting other mandatory federal taxes (e.g., FICA).'
,1,0,1,0,1,1,1,'Alimony')

If not exists(SELECT * FROM DeductionTypes WHERE [Code] = 'Mandated')
INSERT INTO DeductionTypes([Name], [Description], [FederalTax], [NIITax], [AMTTax], [SETax], [StateTax], [FICA], [CityTax], [Code]) VALUES
('Employer Mandated Payments'
,'2.07(C) Deduct any mandatory payments withheld as a condition of employment (e.g., most union dues and some retirement plans).'
,1,0,1,0,1,0,1,'Mandated')

If not exists(SELECT * FROM DeductionTypes WHERE [Code] = 'LifeIns')
INSERT INTO DeductionTypes([Name], [Description], [FederalTax], [NIITax], [AMTTax], [SETax], [StateTax], [FICA], [CityTax], [Code]) VALUES
('Life Insurance Policy Premiums'
,'2.07(D) Deduct life insurance policy premiums when children-in-common with the other parent are the beneficiaries. (ordered by the court)'
,0,0,1,0,1,1,0,'LifeIns')

If not exists(SELECT * FROM DeductionTypes WHERE [Code] = 'RothIRA')
INSERT INTO DeductionTypes([Name], [Description], [FederalTax], [NIITax], [AMTTax], [SETax], [StateTax], [FICA], [CityTax], [Code]) VALUES
('Roth IRA (After-Tax)'
,'Deduct contributions to pensions, retirement plans, or private qualified pension plans, but only up to 5.5 percent of the employee’s parent’s gross income. After-Tax include include Roth IRA and Roth 401(k) contributions.'
,1,0,1,0,0,1,0,'RothIRA')

If not exists(SELECT * FROM DeductionTypes WHERE [Code] = 'TradIRA')
INSERT INTO DeductionTypes([Name], [Description], [FederalTax], [NIITax], [AMTTax], [SETax], [StateTax], [FICA], [CityTax], [Code]) VALUES
('Traditional IRA (Pre-Tax)'
,'Deduct contributions to pensions, retirement plans, or private qualified pension plans, but only up to 5.5 percent of the employee’s parent’s gross income. Pre-Tax would include Traditional IRA and Traditional 401(k) contributions.'
,1,0,1,0,1,1,0,'TradIRA')

If not exists(SELECT * FROM DeductionTypes WHERE [Code] = 'Roth401')
INSERT INTO DeductionTypes([Name], [Description], [FederalTax], [NIITax], [AMTTax], [SETax], [StateTax], [FICA], [CityTax], [Code]) VALUES
('Roth 401(k) (After-Tax)'
,'Deduct contributions to pensions, retirement plans, or private qualified pension plans, but only up to 5.5 percent of the employee’s parent’s gross income. After-Tax include include Roth IRA and Roth 401(k) contributions.'
,1,0,1,0,0,1,0,'Roth401')

If not exists(SELECT * FROM DeductionTypes WHERE [Code] = 'Trad401')
INSERT INTO DeductionTypes([Name], [Description], [FederalTax], [NIITax], [AMTTax], [SETax], [StateTax], [FICA], [CityTax], [Code]) VALUES
('Traditional 401(k) (Pre-Tax)'
,'Deduct contributions to pensions, retirement plans, or private qualified pension plans, but only up to 5.5 percent of the employee’s parent’s gross income. Pre-Tax would include Traditional IRA and Traditional 401(k) contributions.'
,1,0,1,0,1,1,0,'Trad401')

If not exists(SELECT * FROM DeductionTypes WHERE [Code] = '457')
INSERT INTO DeductionTypes([Name], [Description], [FederalTax], [NIITax], [AMTTax], [SETax], [StateTax], [FICA], [CityTax], [Code]) VALUES
('457 (Pre-Tax)'
,'Deduct contributions to pensions, retirement plans, or private qualified pension plans, but only up to 5.5 percent of the employee’s parent’s gross income. Pre-Tax would include Traditional IRA and Traditional 401(k) contributions.'
,1,0,1,0,0,1,0,'457')

If not exists(SELECT * FROM DeductionTypes WHERE [Code] = '403')
INSERT INTO DeductionTypes([Name], [Description], [FederalTax], [NIITax], [AMTTax], [SETax], [StateTax], [FICA], [CityTax], [Code]) VALUES
('403(b) (Pre-Tax)'
,'Deduct contributions to pensions, retirement plans, or private qualified pension plans, but only up to 5.5 percent of the employee’s parent’s gross income. Pre-Tax would include Traditional IRA and Traditional 401(k) contributions.'
,1,0,1,0,0,1,0,'403')


-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Populate IncomeTypes
-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Annual Wages & Overtime')
INSERT INTO IncomeTypes ([Name], [Description], [FederalTax], [NIITax], [AMTTax], [SETax], [StateTax], [FICA], [CityTax], [Code]) VALUES
('Annual Wages & Overtime','(1) Wages, overtime pay, commissions, bonuses, or other monies from all employers or as a result of any employment (usually, as reported in the Medicare, wages, and tips section of the parent’s W-2).'
,1,0,1,0,1,1,1,'wages')

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Commissions, Bonuses & Tips')
INSERT INTO IncomeTypes ([Name], [Description], [FederalTax], [NIITax], [AMTTax], [SETax], [StateTax],[FICA],[CityTax], [Code]) VALUES
('Commissions, Bonuses & Tips', '(1) Wages, overtime pay, commissions, bonuses, or other monies from all employers or as a result of any employment (usually, as reported in the Medicare, wages, and tips section of the parent’s W-2).'
,1,0,1,0,1,1,1,'bonuses')

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Gambing & Lottery Winnings')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax], [AMTTax], [SETax], [StateTax],[FICA],[CityTax], [Code]) VALUES
('Gambing & Lottery Winnings', '(5) Tips, gratuities, royalties, interest, dividends, fees, or gambling or lottery winnings to the extent that they represent regular income or may be used to generate regular income.',
1,0,1,0,1,0,1,'winnings')

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Military Retirement')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax], [Code]) VALUES
('Military Retirement', '(4) Military specialty pay, allowance for quarters and rations, BAH-II, veterans’ administration benefits, G.I. benefits (other than education allotment), or drill pay.',
0,0,0,0,0,0,0,'milretire')

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Military Basic, Special, Bonus & Incentive Pay')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('Military Basic, Special, Bonus & Incentive Pay', '(4) Military specialty pay, allowance for quarters and rations, BAH-II, veterans’ administration benefits, G.I. benefits (other than education allotment), or drill pay.',
1,0,1,0,1,1,1)

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Post 9-11 GI BAH-II Payments')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('Post 9-11 GI BAH-II Payments', '(4) Military specialty pay, allowance for quarters and rations, BAH-II, veterans’ administration benefits, G.I. benefits (other than education allotment), or drill pay.',
0,0,0,0,0,0,0)

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Military Combat, Travel, Moving, Living, Dealth & Other Pay')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('Military Combat, Travel, Moving, Living, Dealth & Other Pay', '(4) Military specialty pay, allowance for quarters and rations, BAH-II, veterans’ administration benefits, G.I. benefits (other than education allotment), or drill pay.',
0,0,0,0,0,0,0)

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='VA Penision & Compensation')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('VA Penision & Compensation', '(4) Military specialty pay, allowance for quarters and rations, BAH-II, veterans’ administration benefits, G.I. benefits (other than education allotment), or drill pay.',
0,0,0,0,0,0,0)

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='VA Vocational Rehabilitation')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('VA Vocational Rehabilitation', '(4) Military specialty pay, allowance for quarters and rations, BAH-II, veterans’ administration benefits, G.I. benefits (other than education allotment), or drill pay.',
0,0,0,0,0,0,0)

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Bank Account Interest, Rental Property, & Royalites')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('Royalites, Rental Property, Bank Account Interest', '(2) Earnings generated from a business, partnership, contract, self-employment, or other similar arrangement, or from rentals. §2.01(E). (5) Tips, gratuities, royalties, interest, dividends, fees, or gambling or lottery winnings to the extent that they represent regular income or may be used to generate regular income.',
1,0,1,0,1,1,1)

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Annuities, Interest Payments, & Short Term Gains')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('Annuities, Interest Payments, & Short Term Gains', 'Needs Description',1,1,1,0,1,0,0)

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Contract Income & Self-Employment')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('Contract Income & Self-Employment', '(3) Distributed profits or payments from profit-sharing, a pension or retirement, an insurance contract, an annuity, trust fund, deferred compensation, retirement account, social security, unemployment compensation, supplemental unemployment benefits, disability insurance or benefits, or worker’s compensation.',
1,0,1,1,1,1,1)

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Social Security - Parents')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('Social Security - Parents', '(3) Distributed profits or payments from profit-sharing, a pension or retirement, an insurance contract, an annuity, trust fund, deferred compensation, retirement account, social security, unemployment compensation, supplemental unemployment benefits, disability insurance or benefits, or worker’s compensation.',
1,0,1,0,0,0,0)

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Social Security - Children')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('Social Security - Children', '(3) Distributed profits or payments from profit-sharing, a pension or retirement, an insurance contract, an annuity, trust fund, deferred compensation, retirement account, social security, unemployment compensation, supplemental unemployment benefits, disability insurance or benefits, or worker’s compensation.',
0,0,0,0,0,0,0)

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Business Income, Partnership, & Profit-Sharing')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('Business Income, Partnership, & Profit-Sharing', '(3) Distributed profits or payments from profit-sharing, a pension or retirement, an insurance contract, an annuity, trust fund, deferred compensation, retirement account, social security, unemployment compensation, supplemental unemployment benefits, disability insurance or benefits, or worker’s compensation.',
1,0,1,1,1,1,1)

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Insurance Contract')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('Insurance Contract', 'Needs Description',1,0,1,0,1,1,1)

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Qualified Retirement & Pension Accounts')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('Qualified Retirement & Pension Accounts', 'Needs Description',1,0,1,0,1,0,1)

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Unemployment Compensation & Supplemental Unemployment Benefits')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('Unemployment Compensation & Supplemental Unemployment Benefits', 'Needs Description',1,0,1,0,1,0,1)

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Trust Fund Income')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('Trust Fund Income', 'Needs Description',1,0,1,0,1,1,1)

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Workers Compensation and Disablity Insurance')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('Workers Compensation and Disablity Insurance', 'Needs Description',0,0,0,0,0,0,0)

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Qualified Retirement & Pension Accounts-Born before 1946')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('Qualified Retirement & Pension Accounts-Born before 1946', 'Needs Description',1,0,1,0,1,0,1)

If not exists(SELECT * FROM IncomeTypes WHERE [Name] ='Employer provided expense account (Meals, Room & Board, & Business Vehicle)')
INSERT INTO IncomeTypes ([Name],[Description],[FederalTax],[NIITax],[AMTTax], [SETax], [StateTax],[FICA],[CityTax]) VALUES
('Employer provided expense account (Meals, Room & Board, & Business Vehicle)', 'Needs Description',1,0,1,0,1,1,1)

-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- Populate PartyTypes Table
-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
-- --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
If not exists(SELECT * FROM PartyTypes WHERE [Name] = 'Parent A')
INSERT INTO PartyTypes ([Name],[Description],[Code]) VALUES
	('Parent A','Plaintiff. The biological/legal parent of the child(ren).','A')

If not exists(SELECT * FROM PartyTypes WHERE [Name] = 'Parent B')
INSERT INTO PartyTypes ([Name],[Description],[Code]) VALUES
	('Parent B','Defendant. The biological/legal parent of the child(ren).','B')

If not exists(SELECT * FROM PartyTypes WHERE [Name] = 'Third Party')
INSERT INTO PartyTypes ([Name],[Description],[Code]) VALUES
	('Third Party','A legal gaurdian. Anyone except one of the biological parents of the child(ren).','3')
