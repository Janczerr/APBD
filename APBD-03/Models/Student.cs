namespace APBD_03.Models
{
    public class Student
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string studiesName { get; set; }
        public string studiesMode { get; set; }
        public string indexNumber { get; set; }
        public string birthdate { get; set; }
        public string email { get; set; }
        public string mothersName { get; set; }
        public string fathersName { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Student student &&
                   indexNumber == student.indexNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(indexNumber);
        }
    }
}