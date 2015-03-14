using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleSupport.API;
using Newtonsoft.Json.Linq;
using SimpleSupport.Classes;
using SimpleSupport.Models;

namespace SimpleSupport.Tests.API
{
    [TestClass]
    public class MSCFTest
    {
        [TestMethod]
        public async Task AdditionalChildrenMultiplier_2()
        {
            // Arrange
            decimal multiplier = 0m;

            // Act
            multiplier = await MCSF.AdditionalChildrenMultiplier(2);

            // Assert
            Assert.AreEqual(.77m, multiplier);
        }

        [TestMethod]
        public async Task AdditionalChildrenMultiplier_4()
        {
            // Arrange
            decimal multiplier = 0m;

            // Act
            multiplier = await MCSF.AdditionalChildrenMultiplier(4);

            // Assert
            Assert.AreEqual(.69m, multiplier);
        }

        [TestMethod]
        public async Task AdditionalChildrenMultiplier_5Plus()
        {
            // Arrange
            decimal multiplier5 = 0m;
            decimal multiplier7 = 0m;

            // Act
            multiplier5 = await MCSF.AdditionalChildrenMultiplier(5);
            multiplier7 = await MCSF.AdditionalChildrenMultiplier(7);

            // Assert
            Assert.AreEqual(multiplier5, multiplier7);
        }

        [TestMethod]
        public async Task OrdinaryMedExpMonthly_1()
        {
            // Arrange
            decimal expense = 0m;

            // Act
            expense = await MCSF.OrdinaryMedExpMonthly(1);

            // Assert
            Assert.AreEqual(29.75m, expense);
        }

        [TestMethod]
        public async Task OrdinaryMedExpMonthly_3()
        {
            // Arrange
            decimal expense = 0m;

            // Act
            expense = await MCSF.OrdinaryMedExpMonthly(3);

            // Assert
            Assert.AreEqual(89.33m, expense);
        }

        [TestMethod]
        public async Task OrdinaryMedExpMonthly_5Plus()
        {
            // Arrange
            decimal expense5 = 0m;
            decimal expense7 = 0m;

            // Act
            expense5 = await MCSF.OrdinaryMedExpMonthly(5);
            expense7 = await MCSF.OrdinaryMedExpMonthly(7);

            // Assert
            Assert.AreEqual(expense5, expense7);
        }

        [TestMethod]
        public async Task OrdinaryMedExpAnnual_1()
        {
            // Arrange
            decimal expense = 0m;

            // Act
            expense = await MCSF.OrdinaryMedExpAnnual(1);

            // Assert
            Assert.AreEqual(357m, expense);
        }

        [TestMethod]
        public async Task OrdinaryMedExpAnnual_3()
        {
            // Arrange
            decimal expense = 0m;

            // Act
            expense = await MCSF.OrdinaryMedExpAnnual(3);

            // Assert
            Assert.AreEqual(1072m, expense);
        }

        [TestMethod]
        public async Task OrdinaryMedExpAnnual_5Plus()
        {
            // Arrange
            decimal expense5 = 0m;
            decimal expense7 = 0m;

            // Act
            expense5 = await MCSF.OrdinaryMedExpAnnual(5);
            expense7 = await MCSF.OrdinaryMedExpAnnual(7);

            // Assert
            Assert.AreEqual(expense5, expense7);
        }

        [TestMethod]
        public async Task HealthReasonableCost_2000()
        {
            // Arrange
            decimal cost = 0m;

            // Act
            cost = await MCSF.HealthReasonableCost(2000);

            // Assert
            Assert.AreEqual(100m, cost);
        }
        // HealthReasonableCost(int parentMonthlyGrossIncome)

        [TestMethod]
        public async Task LowIncomeThreshold()
        {
            // Arrange
            decimal amount = 0m;

            // Act
            amount = await MCSF.LowIncomeThreshold();

            // Assert
            Assert.AreEqual(932m, amount);
        }
        // LowIncomeThreshold()

        [TestMethod]
        public async Task LowIncomeObligation_1000()
        {
            // Arrange
            decimal amount = 0m;

            // Act
            amount = await MCSF.LowIncomeObligation(1000);

            // Assert
            Assert.AreEqual(100m, amount);
        }
        // LowIncomeObligation(decimal income)

        [TestMethod]
        public async Task LowIncomeTransitionObligation_Answer()
        {
            // Arrange
            decimal amount = 0m;

            // Act
            amount = await MCSF.LowIncomeTransitionObligation(1000, 3);

            // Assert
            Assert.AreNotEqual(0m, amount);
        }
        // LowIncomeTransitionObligation(decimal income, int childCount)

        [TestMethod]
        public async Task LowIncomeTransitionObligation_5Plus()
        {
            // Arrange
            decimal amount5 = 0m;
            decimal amount7 = 0m;

            // Act
            amount5 = await MCSF.LowIncomeTransitionObligation(1000, 5);
            amount7 = await MCSF.LowIncomeTransitionObligation(1000, 7);

            // Assert
            Assert.AreEqual(amount5, amount7);
        }
        // LowIncomeTransitionObligation(decimal income, int childCount)

        [TestMethod]
        public async Task Obligation_StandardSupport_3Children()
        {
            // Arrange
            decimal support = 0;

            // Act
            support = await MCSF.ObligationStandardSupport(4372m, .30m, 3);

            // Assert
            Assert.AreEqual(507, support);
        }
        // ObligationStandardSupport(decimal CombinedNetIncome, decimal IncomePercent, int ChildCount)

        [TestMethod]
        public async Task Obligation_StandardSupport_Over5Children()
        {
            // Arrange
            
            // Act
            decimal result = await MCSF.ObligationStandardSupport(4372m, .30m, 5);
            decimal result2 = await MCSF.ObligationStandardSupport(4372m, .30m, 7);

            // Assert
            Assert.AreEqual(result, result2);
        }
        // ObligationStandardSupport(decimal CombinedNetIncome, decimal IncomePercent, int ChildCount)

        [TestMethod]
        public async Task ObligationBaseSupport_3rdParty_3Children()
        {
            // Arrange
            string responseString = "";
            BaseSupport baseSupport = new BaseSupport();

            // Act
            responseString = await MCSF.ObligationBaseSupport_3rdParty(2200m, 3);
            baseSupport = JsonToObject.ParseJsonObject<BaseSupport>(responseString);

            // Assert
            Assert.AreEqual(854, baseSupport.BaseObligation);
            Assert.AreEqual("Low Income Transition", baseSupport.FormulaUsed);
        }
        // ObligationBaseSupport_3rdParty(decimal NetIncome, int ChildCount)




        // BaseSupport(decimal NetIncomeA, decimal NetIncomeB, int ChildCount)

        // AllocationChildCare(decimal payerChildCareAmount, decimal payerIncomePercent, decimal payeeChildCareAmount, decimal payeeIncomePercent)

        // AllocationHealthCare(decimal payerHealthCareAmount, decimal payerIncomePercent, decimal payeeHealthCareAmount, decimal payeeIncomePercent, int childCount)

        // AllocationHealthCare3rdParty(decimal parentAHealthCare, decimal incomePercentA, decimal parentBHealthCare, decimal incomePercentB, int childCount)

        // OffSetSupport(double parentANights, int parentASupport, int parentBSupport)



    }
}
