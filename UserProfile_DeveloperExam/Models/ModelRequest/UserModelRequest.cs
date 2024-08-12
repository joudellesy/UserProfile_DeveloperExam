namespace UserProfile_DeveloperExam.Models
{
    public class UserModelRequest
    {
        public class User_Profile_Req
        {
            public string Name { get; set; }
            public double Weight { get; set; }
            public double Height { get; set; }
            public DateTime Birth_date { get; set; }
            public int Age { get; set; }
            public double BMI { get; set; }
            public List<Running_Activities_Req> RunningActivities { get;set; }

        }
        public class Running_Activities_Req
        {
            public string Location { get; set; }
            public DateTime Started { get; set; }
            public DateTime Ended { get; set; }
            public double Distance { get; set; }
            public DateTime Duration { get; set; }
            public double Average_Pace { get; set; }

        }
    }
}
