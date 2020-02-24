using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDRetirementCalcService
{
    public class Client
    {
        public int currentAge { get; set; }
        public int targetRetirementAge { get; set; }
        public double netWorth { get; set; }
        public double desiredMonthlySpending { get; set; }
        public double yearlySavingContribution { get; set; }
        public double yearlyExpenses { get; set; }
    }
}
