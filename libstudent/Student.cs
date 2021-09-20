using System;

namespace libstudent
{
    public enum Status
    {
        New,
        Active,
        Dropout,
        Graduated
    }

    public class Student
    {
        private int _id;
        private string _givenName;
        private string _surName;
        private Status _status;
        private DateTime _startDate;
        private DateTime _endDate;
        private DateTime _graduationDate;

        public DateTime StartDate
        {
            get => _startDate;
            set {
                _startDate = value;
                _status = _startDate.AddYears(1) > DateTime.Now ? Status.New : Status.Active;
            }
        }

        public DateTime GraduationDate
        {
            get => _graduationDate;
            set {
                _graduationDate = value;
                _status = _graduationDate < DateTime.Now ? Status.Graduated : _status;
            }
        }

        public Status Status
        {
            get {
                ValidateStatus();
                return _status;
            }
        }

        public Student(int id, string givenName, string surName, DateTime startDate, DateTime endDate, DateTime graduationDate)
        {
            _id = id;
            _givenName = givenName;
            _surName = surName;
            _startDate = startDate;
            _endDate = endDate;
            _graduationDate = graduationDate;

            ValidateStatus();
        }

        private void ValidateStatus()
        {
            if (DateTime.Now > _graduationDate && (_endDate == DateTime.MaxValue || _endDate == _graduationDate))
            {
                _endDate = _graduationDate;
                _status = Status.Graduated;
            }
            else if (_endDate < _graduationDate)
            {
                _status = Status.Dropout;
            }
            else if (_startDate < DateTime.Now.AddYears(-1) && _endDate > DateTime.Now)
            {
                _status = Status.Active;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        
        public override string ToString()
        {
            return String.Format(
                "Id: {0}\nName: {1} {2}\nStatus: {3}\nStartdate: {4}\nEnddate: {5}\nGraduationdate: {6}",
                _id,
                _givenName,
                _surName,
                _status,
                _startDate,
                _endDate,
                _graduationDate
            );
        }
    }
}
