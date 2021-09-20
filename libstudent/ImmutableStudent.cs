using System;

namespace libstudent
{
    public record ImmutableStudent(int id, string givenName, string surName, DateTime startDate, DateTime endDate, DateTime graduationDate);
}