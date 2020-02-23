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

            dueDate = CheckWeekEnd(dueDate);

            if(service.isHoliday(dueDate))
            {
                dueDate = CheckWeekEnd(dueDate.AddDays(1));
            }
                

            return dueDate;
        }

        public DateTime CheckWeekEnd(DateTime dueDate)
        {
            if (service.IsWeekEnd(dueDate))
            {
                switch (dueDate.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                        dueDate = dueDate.AddDays(2);
                        break;
                    case DayOfWeek.Sunday:
                        dueDate = dueDate.AddDays(1);
                        break;
                }
                
            }
            return dueDate;
        }
    }
}
