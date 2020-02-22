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
            if(!service.isHoliday(dueDate))
                return dueDate;

            return new DateTime();
        }
    }
}
