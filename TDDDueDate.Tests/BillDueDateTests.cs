using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TDDDueDate.Tests
{
    [TestFixture]
    public class BillDueDateTests
    {
        [Test]
        public void ifBussinessDay_ReturnDueDate()
        {
            var input = new DateTime(2020, 8, 6);

            var mockHolidayService = new HolidayService<IHolidayService>();
            var _bill = new Bill(mockHolidayService);

            var output = _bill.CheckDate(input);
            var expected = input;

            Assert.That(expected, Is.EqualTo(output));
        }
    }
}
