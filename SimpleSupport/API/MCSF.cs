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

        private static async Task<string> GetResponse(string apiURL)
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
            string response = await GetResponse("ParentalTimeOffSet/Support?parentANights=" + parentANights +"&parentASupport=" + parentASupport + "&parentBSupport=" + parentBSupport);
            return Convert.ToDecimal(response);
        }

        // Api/HealthCarePremium/ThirdParty/{childCount}?parentAHealthCare={parentAHealthCare}&incomePercentA={incomePercentA}&parentBHealthCare={parentBHealthCare}&incomePercentB={incomePercentB}	
        // ThirdParty(decimal parentAHealthCare, decimal incomePercentA, decimal parentBHealthCare, decimal incomePercentB, int childCount)
        public static async Task<decimal> AllocationHealthCare3rdParty(decimal parentAHealthCare, decimal incomePercentA, decimal parentBHealthCare, decimal incomePercentB, int childCount)
        {
            string response = await GetResponse("HealthCarePremium/ThirdParty/" + childCount + "?parentAHealthCare=" + parentAHealthCare + 
                "&incomePercentA=" + incomePercentA + "&parentBHealthCare=" + parentBHealthCare + "&incomePercentB=" + incomePercentB);
            return Convert.ToDecimal(response);
        }

        // Api/HealthCarePremium/Allocation/{childCount}?payerHealthCareAmount={payerHealthCareAmount}&payerIncomePercent={payerIncomePercent}&payeeHealthCareAmount={payeeHealthCareAmount}&payeeIncomePercent={payeeIncomePercent}
        // Allocation(decimal payerHealthCareAmount, decimal payerIncomePercent, decimal payeeHealthCareAmount, decimal payeeIncomePercent, int childCount)
        public static async Task<decimal> AllocationHealthCare(decimal payerHealthCareAmount, decimal payerIncomePercent, decimal payeeHealthCareAmount, decimal payeeIncomePercent, int childCount)
        {
            string response = await GetResponse("HealthCarePremium/Allocation/" + childCount + "?payerHealthCareAmount=" + payerHealthCareAmount + 
                "&payerIncomePercent=" + payerIncomePercent + "&payeeHealthCareAmount=" + payeeHealthCareAmount + "&payeeIncomePercent=" + payeeIncomePercent);
            return Convert.ToDecimal(response);
        }

        // Api/AdditionalChildrenMultiplier/Get/{childCount}
        // Get(int childCount)
        public static async Task<decimal> AdditionalChildrenMultiplier(int childCount)
        {
            string response = await GetResponse("AdditionalChildrenMultiplier/Get/" + childCount);
            return Convert.ToDecimal(response);
        }

        // Api/ChildCare/Allocation?payerChildCareAmount={payerChildCareAmount}&payerIncomePercent={payerIncomePercent}&payeeChildCareAmount={payeeChildCareAmount}&payeeIncomePercent={payeeIncomePercent}
        // Allocation(decimal payerChildCareAmount, decimal payerIncomePercent, decimal payeeChildCareAmount, decimal payeeIncomePercent)
        public static async Task<decimal> AllocationChildCare(decimal payerChildCareAmount, decimal payerIncomePercent, decimal payeeChildCareAmount, decimal payeeIncomePercent)
        {
            string response = await GetResponse("ChildCare/Allocation?payerChildCareAmount=" + payerChildCareAmount + "&payerIncomePercent=" + 
                payerIncomePercent + "&payeeChildCareAmount=" + payeeChildCareAmount + "&payeeIncomePercent=" + payeeIncomePercent);
            return Convert.ToDecimal(response);
        }

        // Api/OrdinaryMedExp/Monthly/{childCount}
        // Monthly(int childCount)
        public static async Task<decimal> OrdinaryMedExpMonthly(int childCount)
        {
            string response = await GetResponse("OrdinaryMedExp/Monthly/" + childCount);
            return Convert.ToDecimal(response);
        }

        // Api/OrdinaryMedExp/Annual/{childCount}
        // Annual(int childCount)
        public static async Task<decimal> OrdinaryMedExpAnnual(int childCount)
        {
            string response = await GetResponse("OrdinaryMedExp/Annual/" + childCount);
            return Convert.ToDecimal(response);
        }

        // Api/BaseSupport/BaseSupport/{ChildCount}?NetIncomeA={NetIncomeA}&NetIncomeB={NetIncomeB}
        // BaseSupport(decimal NetIncomeA, decimal NetIncomeB, int ChildCount)
        public static async Task<decimal> BaseSupport(decimal NetIncomeA, decimal NetIncomeB, int ChildCount)
        {
            string response = await GetResponse("BaseSupport/BaseSupport/" + ChildCount + "?NetIncomeA=" + NetIncomeA + "&NetIncomeB=" + NetIncomeB);
            return Convert.ToDecimal(response);
        }

        // Api/BaseSupport/ThirdParty/{ChildCount}?NetIncome={NetIncome}
        // ThirdParty(decimal NetIncome, int ChildCount)
        public static async Task<string> ObligationBaseSupport_3rdParty(decimal NetIncome, int ChildCount)
        {
            string response = await GetResponse("BaseSupport/ThirdParty/" + ChildCount + "?NetIncome=" + NetIncome);
            return response;
        }

        // Api/BaseSupport/GeneralCareEquation/{ChildCount}?CombinedNetIncome={CombinedNetIncome}&IncomePercent={IncomePercent}
        // GeneralCareEquation(decimal CombinedNetIncome, decimal IncomePercent, int ChildCount)
        public static async Task<decimal> ObligationStandardSupport(decimal CombinedNetIncome, decimal IncomePercent, int ChildCount)
        {
            string response = await GetResponse("BaseSupport/GeneralCareEquation/" + ChildCount + "?CombinedNetIncome=" + CombinedNetIncome + "&IncomePercent=" + IncomePercent);
            return Convert.ToDecimal(response);
        }

        // Api/BaseSupport/LowIncomeEquation?income={income}
        // LowIncomeEquation(decimal income)
        public static async Task<decimal> LowIncomeObligation(decimal income)
        {
            string response = await GetResponse("BaseSupport/LowIncomeEquation?income=" + income);
            return Convert.ToDecimal(response);
        }

        // Api/BaseSupport/LowIncomeTransitionEquation/{childCount}?income={income}
        // LowIncomeTransitionEquation(decimal income, int childCount)
        public static async Task<decimal> LowIncomeTransitionObligation(decimal income, int childCount)
        {
            string response = await GetResponse("BaseSupport/LowIncomeTransitionEquation/" + childCount + "?income=" + income);
            return Convert.ToDecimal(response);
        }

        // Api/LowIncome/Threshold
        // Threshold()
        public static async Task<decimal> LowIncomeThreshold()
        {
            string response = await GetResponse("LowIncome/Threshold/");
            return Convert.ToDecimal(response);
        }

        // Api/ReasonableCost/Get?parentMonthlyGrossIncome={parentMonthlyGrossIncome}
        // Get(int parentMonthlyGrossIncome)
        public static async Task<decimal> HealthReasonableCost(int parentMonthlyGrossIncome)
        {
            string response = await GetResponse("ReasonableCost/Get?parentMonthlyGrossIncome=" + parentMonthlyGrossIncome);
            return Convert.ToDecimal(response);
        }
    }
}