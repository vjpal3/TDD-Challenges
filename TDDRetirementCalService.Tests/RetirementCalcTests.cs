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
    }
}
