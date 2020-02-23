using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDDueDate
{
    public interface IHolidayService
    {
        bool isHoliday(DateTime duedate);
        bool IsWeekEnd(DateTime dueDate);
    }
}
