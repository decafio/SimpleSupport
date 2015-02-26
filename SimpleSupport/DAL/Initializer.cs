using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SimpleSupport.Models;

// Used for ApplicationDbContext Seed
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

using System.Data.Entity.Validation;
using System.Text;
using System;

namespace SimpleSupport.DAL
{
    public class Initializer
    {
        // It is referenced in the "contexts" section in the web.config
        public void SeedTables(SupportContext context)
        {
            SeedIncomeTypes(context);
            SeedDeductionTypes(context);
            SeedCityTaxes(context);
            SeedFilingStatuses(context);
            SeedPartyTypes(context);
        }

        public void SeedTestCases(SupportContext context, string userId)
        {
            // Get some Income Type objects
            IncomeType it1 = context.IncomeTypes.Where(c => c.Code == "wages").First();
            IncomeType it2 = context.IncomeTypes.Where(c => c.Code == "bonuses").First();
            IncomeType it3 = context.IncomeTypes.Where(c => c.Code == "winnings").First();
            IncomeType it4 = context.IncomeTypes.Where(c => c.Code == "milretire").First();

            // Get some Deduction Type objects
            // ~TODO~ Add the Deduction Types to the SeedCodeTables.sql
            DeductionType dt1 = context.DeductionTypes.Where(c => c.Code == "Alimony").First();
            DeductionType dt2 = context.DeductionTypes.Where(c => c.Code == "Trad401").First();
            DeductionType dt3 = context.DeductionTypes.Where(c => c.Code == "TradIRA").First();
            DeductionType dt4 = context.DeductionTypes.Where(c => c.Code == "LifeIns").First();

            // Get some CityTax objects
            CityTax ct1 = context.CityTaxes.Where(c => c.Name == "No City Tax").First();
            CityTax ct2 = context.CityTaxes.Where(c => c.Name == "Hudson (Resident)").First();
            CityTax ct3 = context.CityTaxes.Where(c => c.Name == "Lansing (Non-Resident)").First();
            CityTax ct4 = context.CityTaxes.Where(c => c.Name == "Portland (Non-Resident)").First();
            CityTax ct5 = context.CityTaxes.Where(c => c.Name == "Saginaw (Resident)").First();

            // Get some FilingStatus objects
            FilingStatus fs1 = context.FilingStatus.Where(c => c.Code == "Single").First();
            FilingStatus fs2 = context.FilingStatus.Where(c => c.Code == "Head").First();
            FilingStatus fs3 = context.FilingStatus.Where(c => c.Code == "Jointly").First();
            FilingStatus fs4 = context.FilingStatus.Where(c => c.Code == "Seperately").First();
            FilingStatus fs5 = context.FilingStatus.Where(c => c.Code == "Widow").First();

            // Get some PartyType objects
            PartyType ptA = context.PartyTypes.Where(c => c.Code == "A").First();
            PartyType ptB = context.PartyTypes.Where(c => c.Code == "B").First();
            PartyType pt3 = context.PartyTypes.Where(c => c.Code == "3").First();

            // Create some cases
            var case1 = new Case() { AspNetUserId = userId, CaseNumber = "14-42566-DM" };
            var case2 = new Case() { AspNetUserId = userId, CaseNumber = "12-23434-DM" };

            context.Cases.Add(case1);
            context.Cases.Add(case2);
            SaveChanges(context);

            // Create some ParentingTime objects
            ParentingTime pt1 = new ParentingTime()
            {
                SchoolAMonday = true,
                SchoolATuesday = true,
                SchoolAWednesday = true,
                SchoolAThursday = true,
                SchoolAFriday = true,
                SchoolASaturday = true,
                SchoolASunday = true,
                SchoolBMonday = false,
                SchoolBTuesday = false,
                SchoolBWednesday = false,
                SchoolBThursday = false,
                SchoolBFriday = false,
                SchoolBSaturday = true,
                SchoolBSunday = true,
                SummerAMonday = true,
                SummerATuesday = true,
                SummerAWednesday = true,
                SummerAThursday = false,
                SummerAFriday = false,
                SummerASaturday = true,
                SummerASunday = true,
                SummerBMonday = false,
                SummerBTuesday = true,
                SummerBWednesday = false,
                SummerBThursday = true,
                SummerBFriday = true,
                SummerBSaturday = true,
                SummerBSunday = false
            };

            // Create some ParentingTime objects
            ParentingTime pt2 = new ParentingTime()
            {
                SchoolAMonday = false,
                SchoolATuesday = true,
                SchoolAWednesday = true,
                SchoolAThursday = true,
                SchoolAFriday = false,
                SchoolASaturday = true,
                SchoolASunday = true,
                SchoolBMonday = false,
                SchoolBTuesday = false,
                SchoolBWednesday = false,
                SchoolBThursday = false,
                SchoolBFriday = false,
                SchoolBSaturday = true,
                SchoolBSunday = true,
                SummerAMonday = true,
                SummerATuesday = true,
                SummerAWednesday = false,
                SummerAThursday = false,
                SummerAFriday = false,
                SummerASaturday = true,
                SummerASunday = true,
                SummerBMonday = false,
                SummerBTuesday = false,
                SummerBWednesday = false,
                SummerBThursday = false,
                SummerBFriday = true,
                SummerBSaturday = true,
                SummerBSunday = false
            };

            context.ParentingTimes.Add(pt1);
            context.ParentingTimes.Add(pt2);
            SaveChanges(context);

            // Create some Child objects
            Child ch1 = new Child() { Case = case1, FirstName = "John", LastName = "Benix", ParentingTime = pt1 };
            Child ch2 = new Child() { Case = case1, FirstName = "Alex", LastName = "Benix", ParentingTime = pt1 };
            Child ch3 = new Child() { Case = case1, FirstName = "Amber", LastName = "Benix", ParentingTime = pt1 };
            Child ch4 = new Child() { Case = case2, FirstName = "Aaron", LastName = "Marly", ParentingTime = pt2 };
            Child ch5 = new Child() { Case = case2, FirstName = "Lisa", LastName = "Marly", ParentingTime = pt2 };

            context.Children.Add(ch1);
            context.Children.Add(ch2);
            context.Children.Add(ch3);
            context.Children.Add(ch4);
            context.Children.Add(ch5);
            SaveChanges(context);

            // Create some Party objects
            Party p1 = new Party() { Case = case1, Name = "Brad Benix", AdditionalChildren = 0, ChildCareAmount = 0, Exemptions = 5, ExemptionsUnder17 = 3, HealthCareAmount = 0, PartyType = ptA, CityTax = ct1, FilingStatus = fs1 };
            Party p2 = new Party() { Case = case1, Name = "Alison Benix", AdditionalChildren = 0, ChildCareAmount = 0, Exemptions = 5, ExemptionsUnder17 = 3, HealthCareAmount = 0, PartyType = ptB, CityTax = ct2, FilingStatus = fs2 };
            Party p3 = new Party() { Case = case2, Name = "Harry Marly", AdditionalChildren = 0, ChildCareAmount = 0, Exemptions = 5, ExemptionsUnder17 = 3, HealthCareAmount = 0, PartyType = ptA, CityTax = ct3, FilingStatus = fs3 };
            Party p4 = new Party() { Case = case2, Name = "Mary Marly", AdditionalChildren = 0, ChildCareAmount = 0, Exemptions = 5, ExemptionsUnder17 = 3, HealthCareAmount = 0, PartyType = ptB, CityTax = ct4, FilingStatus = fs4 };

            context.Parties.Add(p1);
            context.Parties.Add(p2);
            context.Parties.Add(p3);
            context.Parties.Add(p4);
            SaveChanges(context);

            // Create some Deduction objects
            Deduction d1 = new Deduction() { DeductionType = dt1, Party = p1, Amount = 1000m };
            Deduction d2 = new Deduction() { DeductionType = dt2, Party = p2, Amount = 1200m };
            Deduction d3 = new Deduction() { DeductionType = dt3, Party = p3, Amount = 1300m };
            Deduction d4 = new Deduction() { DeductionType = dt4, Party = p4, Amount = 2000m };

            context.Deductions.Add(d1);
            context.Deductions.Add(d2);
            context.Deductions.Add(d3);
            context.Deductions.Add(d4);
            SaveChanges(context);

            // Create some Income objects
            Income i1 = new Income() { IncomeType = it1, Party = p1, Amount = 54000m };
            Income i2 = new Income() { IncomeType = it2, Party = p2, Amount = 43000m };
            Income i3 = new Income() { IncomeType = it3, Party = p3, Amount = 62000m };
            Income i4 = new Income() { IncomeType = it4, Party = p4, Amount = 38000m };

            context.Incomes.Add(i1);
            context.Incomes.Add(i2);
            context.Incomes.Add(i3);
            context.Incomes.Add(i4);
            SaveChanges(context);

        }

        /// <summary>
        /// Wrapper for SaveChanges adding the Validation Messages to the generated exception
        /// </summary>
        /// <param name="context">The context.</param>
        private void SaveChanges(SupportContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex);
            }
            catch (DbUnexpectedValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                throw new DbEntityValidationException("DbUnexpectedValidation Exception Failed - errors follow:\n" + ex.InnerException.ToString(), ex);
            }
            catch (Exception ex)
            {
                throw new DbEntityValidationException("Exception - errors follow:\n" + ex.ToString(), ex);
            }
        }

        private static void SeedPartyTypes(SupportContext context)
        {
            // Add PartyType
            var partyTypes = new List<PartyType>
            {
                new PartyType() { Code="A", Name="Parent A", Description="Plaintiff. The biological/legal parent of the child(ren)." },
                new PartyType() { Code="B", Name="Parent B", Description="efendant. The biological/legal parent of the child(ren)." },
                new PartyType() { Code="3", Name="Third Party", Description="A legal gaurdian. Anyone except one of the biological parents of the child(ren)." }
            };
            partyTypes.ForEach(s => context.PartyTypes.Add(s));
            context.SaveChanges();
        }

        private static void SeedFilingStatuses(SupportContext context)
        {
            // Add FilingStatus
            var filingStatuses = new List<FilingStatus>
            {
                new FilingStatus() { Code="Single", Name="Single" },
                new FilingStatus() { Code="Head", Name="Head of Household" },
                new FilingStatus() { Code="Jointly", Name="Married Filing Jointly" },
                new FilingStatus() { Code="Seperately", Name="Married Filing Seperatly" },
                new FilingStatus() { Code="Widow", Name="Qualified Widow" }
            };
            filingStatuses.ForEach(s => context.FilingStatus.Add(s));
            context.SaveChanges();
        }

        private static void SeedCityTaxes(SupportContext context)
        {
            // Add CityTax Table
            var cityTaxes = new List<CityTax>
            {
                new CityTax() { Name="No City Tax", TaxRate=0.000m },
                new CityTax() { Name="Albion (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Albion (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Battle Creek (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Battle Creek (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Big Rapids (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Big Rapids (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Flint (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Flint (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Grayling (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Grayling (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Hamtramck (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Hamtramck (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Hudson (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Hudson (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Ionia (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Ionia (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Jackson (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Jackson (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Lansing (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Lansing (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Lapeer (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Lapeer (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Muskegon (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Muskegon (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Muskegon Heights (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Muskegon Heights (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Pontiac (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Pontiac (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Port Huron (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Port Huron (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Portland (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Portland (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Springfield (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Springfield (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Walker (Resident)", TaxRate=0.010m },
                new CityTax() { Name="Walker (Non-Resident)", TaxRate=0.005m },
                new CityTax() { Name="Detroit (Resident)", TaxRate=0.024m },
                new CityTax() { Name="Detroit (Non-Resident)", TaxRate=0.014m },
                new CityTax() { Name="Grand Rapids (Resident)", TaxRate=0.015m },
                new CityTax() { Name="Grand Rapids (Non-Resident)", TaxRate=0.075m },
                new CityTax() { Name="Highland Park (Resident)", TaxRate=0.020m },
                new CityTax() { Name="Highland Park (Non-Resident)", TaxRate=0.010m },
                new CityTax() { Name="Saginaw (Resident)", TaxRate=0.015m },
                new CityTax() { Name="Saginaw (Non-Resident)", TaxRate=0.075m }
            };
            cityTaxes.ForEach(s => context.CityTaxes.Add(s));
            context.SaveChanges();
        }

        private static void SeedDeductionTypes(SupportContext context)
        {
            // Add Deduction Types
            var deductionTypes = new List<DeductionType>
            {
                new DeductionType() { Name="Alimony / Spousal Support", Description="Deduct alimony/spousal support paid to someone other than the other parent in the case under consideration from its payer’s gross income before calculating and deducting its payer’s federal, state, and local income taxes, and after deducting other mandatory federal taxes (e.g., FICA).", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=true, FICA=true, CityTax=true, Code="Alimony" },
                new DeductionType() { Name="Employer Mandated Payments", Description="2.07(C) Deduct any mandatory payments withheld as a condition of employment (e.g., most union dues and some retirement plans).", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=true, FICA=false, CityTax=true, Code="Mandated" },
                new DeductionType() { Name="Life Insurance Policy Premiums", Description="2.07(D) Deduct life insurance policy premiums when children-in-common with the other parent are the beneficiaries. (ordered by the court)", FederalTax=false, AMTTax=false, NIITax=true, SETax=false, StateTax=true, FICA=true, CityTax=false, Code="LifeIns" },
                new DeductionType() { Name="Roth IRA (After-Tax)", Description="Deduct contributions to pensions, retirement plans, or private qualified pension plans, but only up to 5.5 percent of the employee’s parent’s gross income. After-Tax include include Roth IRA and Roth 401(k) contributions.", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=false, FICA=true, CityTax=false, Code="RothIRA" },
                new DeductionType() { Name="Traditional IRA (Pre-Tax)", Description="Deduct contributions to pensions, retirement plans, or private qualified pension plans, but only up to 5.5 percent of the employee’s parent’s gross income. Pre-Tax would include Traditional IRA and Traditional 401(k) contributions.", FederalTax=true, AMTTax=false, NIITax=true, SETax=false, StateTax=true, CityTax=true, FICA=false, Code="TradIRA" },
                new DeductionType() { Name="Roth 401(k) (After-Tax)", Description="Deduct contributions to pensions, retirement plans, or private qualified pension plans, but only up to 5.5 percent of the employee’s parent’s gross income. After-Tax include include Roth IRA and Roth 401(k) contributions.", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=false, FICA=true, CityTax=false, Code="Roth401" },
                new DeductionType() { Name="Traditional 401(k) (Pre-Tax)", Description="Deduct contributions to pensions, retirement plans, or private qualified pension plans, but only up to 5.5 percent of the employee’s parent’s gross income. Pre-Tax would include Traditional IRA and Traditional 401(k) contributions.", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=true, CityTax=true, FICA=false, Code="Trad401" },
                new DeductionType() { Name="457 (Pre-Tax)", Description="Deduct contributions to pensions, retirement plans, or private qualified pension plans, but only up to 5.5 percent of the employee’s parent’s gross income. Pre-Tax would include Traditional IRA and Traditional 401(k) contributions.", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=false, FICA=true, CityTax=false, Code="457" },
                new DeductionType() { Name="403(b) (Pre-Tax)", Description="Deduct contributions to pensions, retirement plans, or private qualified pension plans, but only up to 5.5 percent of the employee’s parent’s gross income. Pre-Tax would include Traditional IRA and Traditional 401(k) contributions.", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=false, FICA=true, CityTax=false, Code="403" }
            };
            deductionTypes.ForEach(s => context.DeductionTypes.Add(s));
            context.SaveChanges();
        }

        private static void SeedIncomeTypes(SupportContext context)
        {
            // Add Income Types
            var incomeTypes = new List<IncomeType>
            {
                new IncomeType() { Name="Annual Wages & Overtime", Description="(1) Wages, overtime pay, commissions, bonuses, or other monies from all employers or as a result of any employment (usually, as reported in the Medicare, wages, and tips section of the parent’s W-2).", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=true, FICA=true, CityTax=true, Code="wages" },
                new IncomeType() { Name="Commissions, Bonuses & Tips", Description="(1) Wages, overtime pay, commissions, bonuses, or other monies from all employers or as a result of any employment (usually, as reported in the Medicare, wages, and tips section of the parent’s W-2).", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=true, FICA=true, CityTax=true, Code="bonuses" },
                new IncomeType() { Name="Gambing & Lottery Winnings", Description="(5) Tips, gratuities, royalties, interest, dividends, fees, or gambling or lottery winnings to the extent that they represent regular income or may be used to generate regular income.", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=true, FICA=false, CityTax=true, Code="winnings" },
                new IncomeType() { Name="Military Retirement", Description="(4) Military specialty pay, allowance for quarters and rations, BAH-II, veterans’ administration benefits, G.I. benefits (other than education allotment), or drill pay.", FederalTax=false, NIITax=false, AMTTax=false, SETax=false, StateTax=false, FICA=false, CityTax=false, Code="milretire" },
                new IncomeType() { Name="Military Basic, Special, Bonus & Incentive Pay", Description="(4) Military specialty pay, allowance for quarters and rations, BAH-II, veterans’ administration benefits, G.I. benefits (other than education allotment), or drill pay.", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=true, FICA=true, CityTax=true, Code="" },
                new IncomeType() { Name="Post 9-11 GI BAH-II Payments", Description="(4) Military specialty pay, allowance for quarters and rations, BAH-II, veterans’ administration benefits, G.I. benefits (other than education allotment), or drill pay.", FederalTax=false, NIITax=false, AMTTax=false, SETax=false, StateTax=false, FICA=false, CityTax=false, Code="" },
                new IncomeType() { Name="Military Combat, Travel, Moving, Living, Dealth & Other Pay", Description="(4) Military specialty pay, allowance for quarters and rations, BAH-II, veterans’ administration benefits, G.I. benefits (other than education allotment), or drill pay.", FederalTax=false, NIITax=false, AMTTax=false, SETax=false, StateTax=false, FICA=false, CityTax=false, Code="" },
                new IncomeType() { Name="VA Penision & Compensation", Description="(4) Military specialty pay, allowance for quarters and rations, BAH-II, veterans’ administration benefits, G.I. benefits (other than education allotment), or drill pay.", FederalTax=false, NIITax=false, AMTTax=false, SETax=false, StateTax=false, FICA=false, CityTax=false, Code="" },
                new IncomeType() { Name="VA Vocational Rehabilitation", Description="(4) Military specialty pay, allowance for quarters and rations, BAH-II, veterans’ administration benefits, G.I. benefits (other than education allotment), or drill pay.", FederalTax=false, NIITax=false, AMTTax=false, SETax=false, StateTax=false, FICA=false, CityTax=false, Code="" },
                new IncomeType() { Name="Royalites, Rental Property, Bank Account Interest", Description="(2) Earnings generated from a business, partnership, contract, self-employment, or other similar arrangement, or from rentals. §2.01(E). (5) Tips, gratuities, royalties, interest, dividends, fees, or gambling or lottery winnings to the extent that they represent regular income or may be used to generate regular income.", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=true, FICA=true, CityTax=true, Code="" },
                new IncomeType() { Name="Annuities, Interest Payments, & Short Term Gains", Description="Needs Description", FederalTax=true, NIITax=true, AMTTax=true, SETax=false, StateTax=true, FICA=false, CityTax=false, Code="" },
                new IncomeType() { Name="Contract Income & Self-Employment", Description="(3) Distributed profits or payments from profit-sharing, a pension or retirement, an insurance contract, an annuity, trust fund, deferred compensation, retirement account, social security, unemployment compensation, supplemental unemployment benefits, disability insurance or benefits, or worker’s compensation.", FederalTax=true, NIITax=false, AMTTax=true, SETax=true, StateTax=true, FICA=true, CityTax=true, Code="" },
                new IncomeType() { Name="Social Security - Parents", Description="(3) Distributed profits or payments from profit-sharing, a pension or retirement, an insurance contract, an annuity, trust fund, deferred compensation, retirement account, social security, unemployment compensation, supplemental unemployment benefits, disability insurance or benefits, or worker’s compensation.", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=false, FICA=false, CityTax=false, Code="" },
                new IncomeType() { Name="Social Security - Children", Description="(3) Distributed profits or payments from profit-sharing, a pension or retirement, an insurance contract, an annuity, trust fund, deferred compensation, retirement account, social security, unemployment compensation, supplemental unemployment benefits, disability insurance or benefits, or worker’s compensation.", FederalTax=false, NIITax=false, AMTTax=false, SETax=false, StateTax=false, FICA=false, CityTax=false, Code="" },
                new IncomeType() { Name="Business Income, Partnership, & Profit-Sharing", Description="(3) Distributed profits or payments from profit-sharing, a pension or retirement, an insurance contract, an annuity, trust fund, deferred compensation, retirement account, social security, unemployment compensation, supplemental unemployment benefits, disability insurance or benefits, or worker’s compensation.", FederalTax=true, NIITax=false, AMTTax=true, SETax=true, StateTax=true, FICA=true, CityTax=true, Code="" },
                new IncomeType() { Name="Insurance Contract", Description="Needs Description", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=true, FICA=true, CityTax=true, Code="" },
                new IncomeType() { Name="Qualified Retirement & Pension Accounts", Description="Needs Description", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=true, FICA=false, CityTax=true, Code="" },
                new IncomeType() { Name="Unemployment Compensation & Supplemental Unemployment Benefits", Description="Needs Description", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=true, FICA=false, CityTax=true, Code="" },
                new IncomeType() { Name="Trust Fund Income", Description="Needs Description", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=true, FICA=true, CityTax=true, Code="" },
                new IncomeType() { Name="Workers Compensation and Disablity Insurance", Description="Needs Description", FederalTax=false, NIITax=false, AMTTax=false, SETax=false, StateTax=false, FICA=false, CityTax=false, Code="" },
                new IncomeType() { Name="Qualified Retirement & Pension Accounts-Born before 1946", Description="Needs Description", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=true, FICA=false, CityTax=true, Code="" },
                new IncomeType() { Name="Employer provided expense account (Meals, Room & Board, & Business Vehicle)", Description="Needs Description", FederalTax=true, NIITax=false, AMTTax=true, SETax=false, StateTax=true, FICA=true, CityTax=true, Code="" }
            };
            incomeTypes.ForEach(s => context.IncomeTypes.Add(s));
            context.SaveChanges();
        }

        private static void ClearCodeTables(SupportContext context)
        {
            // context.ExecuteCommand("TRUNCATE TABLE EntityName");
            // context.Entities.DeleteAllOnSubmit(dc.Entities);
        }

        private static void ClearTeatCases(SupportContext context)
        {

        }


        public void SeedRoles(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole
                {
                    Name = "Admin"
                };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Individual"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole
                {
                    Name = "Individual"
                };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Attorney"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole
                {
                    Name = "Attorney"
                };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Government"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole
                {
                    Name = "Government"
                };

                manager.Create(role);
            }
        }

    }
}