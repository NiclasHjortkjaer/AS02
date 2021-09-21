using System;
using Xunit;
using libstudent;

namespace libstudent.Tests
{
    public class ImmutableStudentTest
    {
        [Fact]
        public void TwoRecordsAreEqual()
        {
            // Arrange.
            ImmutableStudent is1 = new(1234, "Bob", "Smith", new DateTime(2021, 2, 1), DateTime.MaxValue, new DateTime(2024, 2, 1));
            ImmutableStudent is2 = new(1234, "Bob", "Smith", new DateTime(2021, 2, 1), DateTime.MaxValue, new DateTime(2024, 2, 1));

            // Assert.
            Assert.Equal(is1, is2);
        }

        [Fact]
        public void TwoRecordsAreNotEqual()
        {
            // Arrange.
            ImmutableStudent is1 = new(4321, "Bob", "Smith", new DateTime(2021, 2, 1), DateTime.MaxValue, new DateTime(2024, 2, 1));
            ImmutableStudent is2 = new(1234, "Bob", "Smith", new DateTime(2021, 2, 1), DateTime.MaxValue, new DateTime(2024, 2, 1));

            // Assert.
            Assert.NotEqual(is1, is2);
        }

        [Fact]
        public void TwoRecordsToStringAreEqual()
        {
            // Arrange.
            ImmutableStudent actual = new(1234, "Bob", "Smith", new DateTime(2021, 2, 1), DateTime.MaxValue, new DateTime(2024, 2, 1));
            string expected = "{ id = 1234, givenName = Bob, surName = Smith, startDate = 02/01/2021 12:00 AM, endDate = 12/31/9999 11:59 PM, graduationDate = 02/01/2024 12:00 AM }";

            // Assert.
            Assert.Equal(expected, actual.ToString());
        }
    }
}