using System;
using Xunit;
using libstudent;

namespace libstudent.Tests
{
    public class StudentTest
    {
        [Fact]
        public void StudentIsNew()
        {
            // Arrange.
            Student student = new Student(1234, "Bob", "Smith", DateTime.Now.AddMonths(-6), DateTime.MaxValue, DateTime.Now.AddYears(3));

            // Act.
            var actual = student.Status;
            var expected = Status.New;

            // Asset.
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StudentIsActive()
        {
            // Arrange.
            Student student = new Student(1234, "Bob", "Smith", DateTime.Now.AddYears(-2), DateTime.MaxValue, DateTime.Now.AddYears(1));

            // Act.
            var actual = student.Status;
            var expected = Status.Active;

            // Asset.
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StudentIsDropout()
        {
            // Arrange.
            Student student = new Student(1234, "Bob", "Smith", DateTime.Now.AddMonths(-6), DateTime.Now.AddYears(2), DateTime.Now.AddYears(3));

            // Act.
            var actual = student.Status;
            var expected = Status.Dropout;

            // Asset.
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void StudentIsGraduated()
        {
            // Arrange.
            Student student = new Student(1234, "Bob", "Smith", DateTime.Now.AddYears(-1), DateTime.MaxValue, DateTime.Now.AddMonths(-6));

            // Act.
            var actual = student.Status;
            var expected = Status.Graduated;

            // Asset.
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToStringTest()
        {
            // Arrange.
            Student student = new Student(1234, "Bob", "Smith", DateTime.Now.AddYears(-1), DateTime.MaxValue, DateTime.Now.AddMonths(-6));

            // Act.
            var actual = student.ToString();
            var expected = String.Format(
                "Id: 1234\nName: Bob Smith\nStatus: Graduated\nStartdate: {0}\nEnddate: {1}\nGraduationdate: {1}",
                DateTime.Now.AddYears(-1).ToString(),
                DateTime.Now.AddMonths(-6).ToString()
            );

            // Asset.
            Assert.Equal(expected, actual);
        }
    }
}
