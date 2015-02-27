using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Threading.Tasks; // Task
using System.Net.Http;        // HttpClient
using System.Net.Http.Headers;// MediaTypeWithQualityHeaderValue

namespace SimpleSupport.API
{

    /// <summary>
    /// http://www.asp.net/web-api/overview/advanced/calling-a-web-api-from-a-net-client 
    /// Run in NuGet Package Manager Console "Install-Package Microsoft.AspNet.WebApi.Client"
    /// </summary>
    public static class MCSF
    {
        private static async Task<decimal> RunAsync(string apiURL)
        {
            decimal content = 0m;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://mcsf.azurewebsites.net/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiURL);
                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsAsync<decimal>();
                }
            }

            return content;
        }

        // Api/ParentalTimeOffSet/Support?parentANights={parentANights}&parentASupport={parentASupport}&parentBSupport={parentBSupport}
        // Support(double parentANights, int parentASupport, int parentBSupport)
        internal static async Task<decimal> OffSetSupport(double parentANights, int parentASupport, int parentBSupport)
        {
            decimal multiplier = await RunAsync("ParentalTimeOffSet/Support?parentANights=" + parentANights +"&parentASupport=" + parentASupport + "&parentBSupport=" + parentBSupport);
            return multiplier;
        }

        // Api/HealthCarePremium/ThirdParty/{childCount}?parentAHealthCare={parentAHealthCare}&incomePercentA={incomePercentA}&parentBHealthCare={parentBHealthCare}&incomePercentB={incomePercentB}	
        // ThirdParty(decimal parentAHealthCare, decimal incomePercentA, decimal parentBHealthCare, decimal incomePercentB, int childCount)
        internal static async Task<decimal> AllocationHealthCare3rdParty(decimal parentAHealthCare, decimal incomePercentA, decimal parentBHealthCare, decimal incomePercentB, int childCount)
        {
            decimal multiplier = await RunAsync("HealthCarePremium/ThirdParty/" + childCount + "?parentAHealthCare=" + parentAHealthCare + 
                "&incomePercentA=" + incomePercentA + "&parentBHealthCare=" + parentBHealthCare + "&incomePercentB=" + incomePercentB);
            return multiplier;
        }

        // Api/HealthCarePremium/Allocation/{childCount}?payerHealthCareAmount={payerHealthCareAmount}&payerIncomePercent={payerIncomePercent}&payeeHealthCareAmount={payeeHealthCareAmount}&payeeIncomePercent={payeeIncomePercent}
        // Allocation(decimal payerHealthCareAmount, decimal payerIncomePercent, decimal payeeHealthCareAmount, decimal payeeIncomePercent, int childCount)
        internal static async Task<decimal> AllocationHealthCare(decimal payerHealthCareAmount, decimal payerIncomePercent, decimal payeeHealthCareAmount, decimal payeeIncomePercent, int childCount)
        {
            decimal multiplier = await RunAsync("HealthCarePremium/Allocation/" + childCount + "?payerHealthCareAmount=" + payerHealthCareAmount + 
                "&payerIncomePercent=" + payerIncomePercent + "&payeeHealthCareAmount=" + payeeHealthCareAmount + "&payeeIncomePercent=" + payeeIncomePercent);
            return multiplier;
        }

        // Api/AdditionalChildrenMultiplier/Get/{childCount}
        // Get(int childCount)
        internal static async Task<decimal> AdditionalChildrenMultiplier(int childCount)
        {
            decimal multiplier = await RunAsync("AdditionalChildrenMultiplier/Get/" + childCount);
            return multiplier;
        }

        // Api/ChildCare/Allocation?payerChildCareAmount={payerChildCareAmount}&payerIncomePercent={payerIncomePercent}&payeeChildCareAmount={payeeChildCareAmount}&payeeIncomePercent={payeeIncomePercent}
        // Allocation(decimal payerChildCareAmount, decimal payerIncomePercent, decimal payeeChildCareAmount, decimal payeeIncomePercent)
        internal static async Task<decimal> AllocationChildCare(decimal payerChildCareAmount, decimal payerIncomePercent, decimal payeeChildCareAmount, decimal payeeIncomePercent)
        {
            decimal multiplier = await RunAsync("ChildCare/Allocation?payerChildCareAmount=" + payerChildCareAmount + "&payerIncomePercent=" + 
                payerIncomePercent + "&payeeChildCareAmount=" + payeeChildCareAmount + "&payeeIncomePercent=" + payeeIncomePercent);
            return multiplier;
        }

        // Api/OrdinaryMedExp/Monthly/{childCount}
        // Monthly(int childCount)
        internal static async Task<decimal> OrdinaryMedExpMonthly(int childCount)
        {
            decimal multiplier = await RunAsync("OrdinaryMedExp/Monthly/" + childCount);
            return multiplier;
        }

        // Api/OrdinaryMedExp/Annual/{childCount}
        // Annual(int childCount)
        internal static async Task<decimal> OrdinaryMedExpAnnual(int childCount)
        {
            decimal multiplier = await RunAsync("OrdinaryMedExp/Annual/" + childCount);
            return multiplier;
        }

        // Api/BaseSupport/BaseSupport/{ChildCount}?NetIncomeA={NetIncomeA}&NetIncomeB={NetIncomeB}
        // BaseSupport(decimal NetIncomeA, decimal NetIncomeB, int ChildCount)
        internal static async Task<decimal> BaseSupport(decimal NetIncomeA, decimal NetIncomeB, int ChildCount)
        {
            decimal multiplier = await RunAsync("BaseSupport/BaseSupport/" + ChildCount + "?NetIncomeA=" + NetIncomeA + "&NetIncomeB=" + NetIncomeB);
            return multiplier;
        }

        // Api/BaseSupport/ThirdParty/{ChildCount}?NetIncome={NetIncome}
        // ThirdParty(decimal NetIncome, int ChildCount)
        internal static async Task<decimal> ObligationBaseSupport_3rdParty(decimal NetIncome, int ChildCount)
        {
            decimal multiplier = await RunAsync("BaseSupport/ThirdParty/" + ChildCount + "?NetIncome=" + NetIncome);
            return multiplier;
        }

        // Api/BaseSupport/GeneralCareEquation/{ChildCount}?CombinedNetIncome={CombinedNetIncome}&IncomePercent={IncomePercent}
        // GeneralCareEquation(decimal CombinedNetIncome, decimal IncomePercent, int ChildCount)
        internal static async Task<decimal> ObligationStandardSupport(decimal CombinedNetIncome, decimal IncomePercent, int ChildCount)
        {
            decimal multiplier = await RunAsync("BaseSupport/GeneralCareEquation/" + ChildCount + "?CombinedNetIncome=" + CombinedNetIncome + "&IncomePercent=" + IncomePercent);
            return multiplier;
        }

        // Api/BaseSupport/LowIncomeEquation?income={income}
        // LowIncomeEquation(decimal income)
        internal static async Task<decimal> LowIncomeObligation(decimal income)
        {
            decimal multiplier = await RunAsync("BaseSupport/LowIncomeEquation?income=" + income);
            return multiplier;
        }

        // Api/BaseSupport/LowIncomeTransitionEquation/{childCount}?income={income}
        // LowIncomeTransitionEquation(decimal income, int childCount)
        internal static async Task<decimal> LowIncomeTransitionObligation(decimal income, int childCount)
        {
            decimal multiplier = await RunAsync("BaseSupport/LowIncomeTransitionEquation/" + childCount + "?income=" + income);
            return multiplier;
        }

        // Api/LowIncome/Threshold
        // Threshold()
        internal static async Task<decimal> LowIncomeThreshold()
        {
            decimal multiplier = await RunAsync("LowIncome/Threshold/");
            return multiplier;
        }

        // Api/ReasonableCost/Get?parentMonthlyGrossIncome={parentMonthlyGrossIncome}
        // Get(int parentMonthlyGrossIncome)
        internal static async Task<decimal> HealthReasonableCost(int parentMonthlyGrossIncome)
        {
            decimal multiplier = await RunAsync("ReasonableCost/Get?parentMonthlyGrossIncome=" + parentMonthlyGrossIncome);
            return multiplier;
        }
    }
}