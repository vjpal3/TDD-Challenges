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

        [Test]
        public void ifSaturday_ReturnMonday()
        {
            var input = new DateTime(2020, 2, 22);

            var mockHolidayService = new HolidayService<IHolidayService>();
            var _bill = new Bill(mockHolidayService);
            var expected = new DateTime(2020, 2, 24);

            var output = _bill.CheckDate(input);

            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        public void ifSunday_ReturnMonday()
        {
            var input = new DateTime(2020, 2, 23);

            var mockHolidayService = new HolidayService<IHolidayService>();
            var _bill = new Bill(mockHolidayService);
            var expected = new DateTime(2020, 2, 24);

            var output = _bill.CheckDate(input);

            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        public void ifHoliday_ReturnNonHoliday()
        {
            var input = new DateTime(2020, 5, 25);

            var mockHolidayService = new HolidayService<IHolidayService>();
            var _bill = new Bill(mockHolidayService);

            var output = _bill.CheckDate(input);
            var expected = input.AddDays(1);

            Assert.That(output, Is.EqualTo(expected));
        }

    }
}
