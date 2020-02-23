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
        private Bill bill;
        private HolidayService<IHolidayService> mockHolidayService;

        [OneTimeSetUp]      
        public void Init()
        {
            mockHolidayService = new HolidayService<IHolidayService>();
            bill = new Bill(mockHolidayService);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            mockHolidayService = null;
            bill = null;
        }

        [Test]
        public void ifBussinessDay_ReturnDueDate()
        {
            var input = new DateTime(2020, 8, 6);
            var expected = input;

            var output = bill.CheckDate(input);

            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        public void ifSaturday_ReturnMonday()
        {
            var input = new DateTime(2020, 2, 22);
            var expected = new DateTime(2020, 2, 24);

            var output = bill.CheckDate(input);

            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        public void ifSunday_ReturnMonday()
        {
            var input = new DateTime(2020, 2, 23);
            var expected = new DateTime(2020, 2, 24);

            var output = bill.CheckDate(input);

            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        public void ifHoliday_ReturnNonHoliday()
        {
            var input = new DateTime(2020, 5, 25);
            var expected = input.AddDays(1); 

            var output = bill.CheckDate(input);

            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        public void ifHoliday_ReturnWeekday()
        {
            var input = new DateTime(2020, 12, 25);
            var output = bill.CheckDate(input);

            var expected = input.AddDays(3);

            Assert.That(output, Is.EqualTo(expected));
        }

    }
}
