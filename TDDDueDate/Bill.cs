using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDDueDate
{
    public class Bill
    {
        private readonly IHolidayService service;

        //bring in holiday service to check for holidays
        //use dependency injection

        public Bill(IHolidayService service)
        {
            this.service = service;
        }
        public DateTime CheckDate(DateTime dueDate)
        {
            while(service.isHoliday(dueDate) || dueDate.DayOfWeek == DayOfWeek.Saturday || dueDate.DayOfWeek == DayOfWeek.Sunday)
            {
                dueDate = dueDate.AddDays(1);
            }
            return dueDate;
        }
    }
}
