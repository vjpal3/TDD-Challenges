using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TDDRetirementCalcService;

namespace TDDRetirementCalService.Tests
{
     [TestFixture] 
    public class RetirementCalcTests
    {
        [Test]
        public void RetirementCalculatorReturns_TypeInt()
        {
            var client = new Client
            {
                currentAge = 47,
                targetRetirementAge = 65,
                netWorth = 500000,
                desiredMonthlySpending = 2500,
                yearlySavingContribution = 22000,
                yearlyExpenses = 55000
            };

            var calculator = new Calculator();
            var output = calculator.RetirementYears(client);
            Assert.That(output, Is.TypeOf<int>());
        }

        [Test]
        public void SimpleClientReturns_CorrectYears()
        {
            var client = new Client
            {
                currentAge = 70,
                targetRetirementAge = 65,
                netWorth = 500000,
                desiredMonthlySpending = 2500
            };
            double expected = 16;

            var calculator = new Calculator();

            var output = calculator.RetirementYears(client);
            Assert.That(output, Is.EqualTo(expected));

        }

        [Test]
        public void ComplicatedClientReturns_CorrectYears()
        {
            var client = new Client
            {
                currentAge = 47,
                targetRetirementAge = 65,
                netWorth = 500000,
                desiredMonthlySpending = 2500,
                yearlySavingContribution = 22000,
                yearlyExpenses = 55000
            };

            int yearsToRetirement = client.targetRetirementAge - client.currentAge; //18
            
            double netWorthAtRetirement = client.netWorth + (client.yearlySavingContribution * yearsToRetirement); // 896,000

            int expected = (int)(netWorthAtRetirement / (client.desiredMonthlySpending * 12)); //29

            var calculator = new Calculator();
            var output = calculator.RetirementYears(client);

            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        public void NotEnoughForRetirementReturns_Zero()
        {
            var client = new Client
            {
                currentAge = 47,
                targetRetirementAge = 65,
                netWorth = 10000,
                desiredMonthlySpending = 2500,
                yearlySavingContribution = 1000,
                yearlyExpenses = 55000
            };

            int yearsToRetirement = client.targetRetirementAge - client.currentAge; 

            double netWorthAtRetirement = client.netWorth + (client.yearlySavingContribution * yearsToRetirement); 

            int expected = (int)(netWorthAtRetirement / (client.desiredMonthlySpending * 12)); 

            var calculator = new Calculator();
            var output = calculator.RetirementYears(client);

            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        public void AddExpenseReturns_CorrectYears()
        {
            var client = new Client
            {
                currentAge = 47,
                targetRetirementAge = 65,
                netWorth = 500000,
                desiredMonthlySpending = 2500,
                yearlySavingContribution = 22000,
                yearlyExpenses = 55000
            };

            var educationExpense = new EducationExpense
            {
                numberofYears = 5,
                amount = 10000
            };

            int yearsToRetirement = client.targetRetirementAge - client.currentAge; 

            double netWorthAtRetirement = client.netWorth + (client.yearlySavingContribution * yearsToRetirement) - educationExpense.totalExpense(); 

            int expected = (int)(netWorthAtRetirement / (client.desiredMonthlySpending * 12)); 

            var calculator = new Calculator();
            var output = calculator.RetirementYears(client, educationExpense);

            Assert.That(output, Is.EqualTo(expected));
        }

    }
}
