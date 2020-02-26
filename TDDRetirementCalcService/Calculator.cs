using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDRetirementCalcService
{
    public class Calculator
    {
        public int RetirementYears(Client client, IExpense expense = null)
        {
            int years;
            double netWorthAtRetirement;
            if (client.currentAge >= client.targetRetirementAge)
            {
                netWorthAtRetirement = client.netWorth;
            }
            else
            {
                int yearsToRetirement = client.targetRetirementAge - client.currentAge; 
                netWorthAtRetirement = client.netWorth + (client.yearlySavingContribution * yearsToRetirement); 
            }

            if(expense != null)
            {
                netWorthAtRetirement -= expense.totalExpense();
            }

            years = (int)(netWorthAtRetirement / (client.desiredMonthlySpending * 12)); 

            return years;
        }
    }
}
