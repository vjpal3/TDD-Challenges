using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDRetirementCalcService
{
    public class Calculator
    {
        public int RetirementYears(Client client)
        {
            int years = (int)Math.Floor(client.netWorth / (client.desiredMonthlySpending * 12));
            return years;
        }
    }
}
