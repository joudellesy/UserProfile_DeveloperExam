using System.ComponentModel.DataAnnotations.Schema;

namespace UserProfile_DeveloperExam.Models
{
    public class UserModel
    {
        public class User_Profile
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Weight { get; set; }
            public double Height { get; set; }
            public DateTime Birth_date { get; set; }
            public int Age { get; set; }
            public double BMI { get; set; }
            //public List<Running_Activities> RunningActivities { get;set; }

        }
        public class Running_Activities
        {
            public int Id { get; set; }
            public string Location { get; set; }
            public DateTime Started { get; set; }
            public DateTime Ended { get; set; }
            public double Distance { get; set; }
            public DateTime Duration { get; set; }
            public double Average_Pace { get; set; }
            //add virtual
        }
    }
}
