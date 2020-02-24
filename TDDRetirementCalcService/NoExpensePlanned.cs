using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDRetirementCalcService
{
    class NoExpensePlanned : IExpense
    {
        public int amount { get; set; } = 0;
        public int numberofYears { get; set; } = 0;
        public int totalExpense()
        {
            return amount * numberofYears;
        }
    }
}
