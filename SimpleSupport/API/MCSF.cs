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
        private static async Task<decimal> RunAsyncAsDecimal(string apiURL)
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

        private static async Task<string> RunAsyncAsString(string apiURL)
        {
            string content = "";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://mcsf.azurewebsites.net/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiURL);
                if (response.IsSuccessStatusCode)
                {
                    content = await response.Content.ReadAsStringAsync();
                }
            }

            return content;
        }


        // Api/ParentalTimeOffSet/Support?parentANights={parentANights}&parentASupport={parentASupport}&parentBSupport={parentBSupport}
        // Support(double parentANights, int parentASupport, int parentBSupport)
        public static async Task<decimal> OffSetSupport(double parentANights, int parentASupport, int parentBSupport)
        {
            decimal multiplier = await RunAsyncAsDecimal("ParentalTimeOffSet/Support?parentANights=" + parentANights +"&parentASupport=" + parentASupport + "&parentBSupport=" + parentBSupport);
            return multiplier;
        }

        // Api/HealthCarePremium/ThirdParty/{childCount}?parentAHealthCare={parentAHealthCare}&incomePercentA={incomePercentA}&parentBHealthCare={parentBHealthCare}&incomePercentB={incomePercentB}	
        // ThirdParty(decimal parentAHealthCare, decimal incomePercentA, decimal parentBHealthCare, decimal incomePercentB, int childCount)
        public static async Task<decimal> AllocationHealthCare3rdParty(decimal parentAHealthCare, decimal incomePercentA, decimal parentBHealthCare, decimal incomePercentB, int childCount)
        {
            decimal multiplier = await RunAsyncAsDecimal("HealthCarePremium/ThirdParty/" + childCount + "?parentAHealthCare=" + parentAHealthCare + 
                "&incomePercentA=" + incomePercentA + "&parentBHealthCare=" + parentBHealthCare + "&incomePercentB=" + incomePercentB);
            return multiplier;
        }

        // Api/HealthCarePremium/Allocation/{childCount}?payerHealthCareAmount={payerHealthCareAmount}&payerIncomePercent={payerIncomePercent}&payeeHealthCareAmount={payeeHealthCareAmount}&payeeIncomePercent={payeeIncomePercent}
        // Allocation(decimal payerHealthCareAmount, decimal payerIncomePercent, decimal payeeHealthCareAmount, decimal payeeIncomePercent, int childCount)
        public static async Task<decimal> AllocationHealthCare(decimal payerHealthCareAmount, decimal payerIncomePercent, decimal payeeHealthCareAmount, decimal payeeIncomePercent, int childCount)
        {
            decimal multiplier = await RunAsyncAsDecimal("HealthCarePremium/Allocation/" + childCount + "?payerHealthCareAmount=" + payerHealthCareAmount + 
                "&payerIncomePercent=" + payerIncomePercent + "&payeeHealthCareAmount=" + payeeHealthCareAmount + "&payeeIncomePercent=" + payeeIncomePercent);
            return multiplier;
        }

        // Api/AdditionalChildrenMultiplier/Get/{childCount}
        // Get(int childCount)
        public static async Task<decimal> AdditionalChildrenMultiplier(int childCount)
        {
            decimal multiplier = await RunAsyncAsDecimal("AdditionalChildrenMultiplier/Get/" + childCount);
            return multiplier;
        }

        // Api/ChildCare/Allocation?payerChildCareAmount={payerChildCareAmount}&payerIncomePercent={payerIncomePercent}&payeeChildCareAmount={payeeChildCareAmount}&payeeIncomePercent={payeeIncomePercent}
        // Allocation(decimal payerChildCareAmount, decimal payerIncomePercent, decimal payeeChildCareAmount, decimal payeeIncomePercent)
        public static async Task<decimal> AllocationChildCare(decimal payerChildCareAmount, decimal payerIncomePercent, decimal payeeChildCareAmount, decimal payeeIncomePercent)
        {
            decimal multiplier = await RunAsyncAsDecimal("ChildCare/Allocation?payerChildCareAmount=" + payerChildCareAmount + "&payerIncomePercent=" + 
                payerIncomePercent + "&payeeChildCareAmount=" + payeeChildCareAmount + "&payeeIncomePercent=" + payeeIncomePercent);
            return multiplier;
        }

        // Api/OrdinaryMedExp/Monthly/{childCount}
        // Monthly(int childCount)
        public static async Task<decimal> OrdinaryMedExpMonthly(int childCount)
        {
            decimal multiplier = await RunAsyncAsDecimal("OrdinaryMedExp/Monthly/" + childCount);
            return multiplier;
        }

        // Api/OrdinaryMedExp/Annual/{childCount}
        // Annual(int childCount)
        public static async Task<decimal> OrdinaryMedExpAnnual(int childCount)
        {
            decimal multiplier = await RunAsyncAsDecimal("OrdinaryMedExp/Annual/" + childCount);
            return multiplier;
        }

        // Api/BaseSupport/BaseSupport/{ChildCount}?NetIncomeA={NetIncomeA}&NetIncomeB={NetIncomeB}
        // BaseSupport(decimal NetIncomeA, decimal NetIncomeB, int ChildCount)
        public static async Task<decimal> BaseSupport(decimal NetIncomeA, decimal NetIncomeB, int ChildCount)
        {
            decimal multiplier = await RunAsyncAsDecimal("BaseSupport/BaseSupport/" + ChildCount + "?NetIncomeA=" + NetIncomeA + "&NetIncomeB=" + NetIncomeB);
            return multiplier;
        }

        // Api/BaseSupport/ThirdParty/{ChildCount}?NetIncome={NetIncome}
        // ThirdParty(decimal NetIncome, int ChildCount)
        public static async Task<string> ObligationBaseSupport_3rdParty(decimal NetIncome, int ChildCount)
        {
            string response = await RunAsyncAsString("BaseSupport/ThirdParty/" + ChildCount + "?NetIncome=" + NetIncome);
            return response;
        }

        // Api/BaseSupport/GeneralCareEquation/{ChildCount}?CombinedNetIncome={CombinedNetIncome}&IncomePercent={IncomePercent}
        // GeneralCareEquation(decimal CombinedNetIncome, decimal IncomePercent, int ChildCount)
        public static async Task<decimal> ObligationStandardSupport(decimal CombinedNetIncome, decimal IncomePercent, int ChildCount)
        {
            decimal multiplier = await RunAsyncAsDecimal("BaseSupport/GeneralCareEquation/" + ChildCount + "?CombinedNetIncome=" + CombinedNetIncome + "&IncomePercent=" + IncomePercent);
            return multiplier;
        }

        // Api/BaseSupport/LowIncomeEquation?income={income}
        // LowIncomeEquation(decimal income)
        public static async Task<decimal> LowIncomeObligation(decimal income)
        {
            decimal multiplier = await RunAsyncAsDecimal("BaseSupport/LowIncomeEquation?income=" + income);
            return multiplier;
        }

        // Api/BaseSupport/LowIncomeTransitionEquation/{childCount}?income={income}
        // LowIncomeTransitionEquation(decimal income, int childCount)
        public static async Task<decimal> LowIncomeTransitionObligation(decimal income, int childCount)
        {
            decimal multiplier = await RunAsyncAsDecimal("BaseSupport/LowIncomeTransitionEquation/" + childCount + "?income=" + income);
            return multiplier;
        }

        // Api/LowIncome/Threshold
        // Threshold()
        public static async Task<decimal> LowIncomeThreshold()
        {
            decimal multiplier = await RunAsyncAsDecimal("LowIncome/Threshold/");
            return multiplier;
        }

        // Api/ReasonableCost/Get?parentMonthlyGrossIncome={parentMonthlyGrossIncome}
        // Get(int parentMonthlyGrossIncome)
        public static async Task<decimal> HealthReasonableCost(int parentMonthlyGrossIncome)
        {
            decimal multiplier = await RunAsyncAsDecimal("ReasonableCost/Get?parentMonthlyGrossIncome=" + parentMonthlyGrossIncome);
            return multiplier;
        }
    }
}