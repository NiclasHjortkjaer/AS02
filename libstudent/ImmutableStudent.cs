using System;

namespace libstudent
{
    public record ImmutableStudent(int id, string givenName, string surName, DateTime startDate, DateTime endDate, DateTime graduationDate)
    {
        public override string ToString()
        {
            return String.Format(
                "{{ id = {0}, givenName = {1}, surName = {2}, startDate = {3}, endDate = {4}, graduationDate = {5} }}",
                id,
                givenName,
                surName,
                startDate.ToString("MM/dd/yyyy hh:mm tt"),
                endDate.ToString("MM/dd/yyyy hh:mm tt"),
                graduationDate.ToString("MM/dd/yyyy hh:mm tt")
            );
        }
    }
}