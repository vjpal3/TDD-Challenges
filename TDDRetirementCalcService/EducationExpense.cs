using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDRetirementCalcService
{
    public class EducationExpense : IExpense
    {
        public int amount { get; set; }
        public int numberofYears { get; set; }
        public int totalExpense()
        {
            return amount * numberofYears;
        }
    }
}
