using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using UserProfile_DeveloperExam.DBContext;
using UserProfile_DeveloperExam.Interface;
using UserProfile_DeveloperExam.Models;
using static UserProfile_DeveloperExam.Models.UserModelRequest;
using static UserProfile_DeveloperExam.Models.UserModel;
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace UserProfile_DeveloperExam.Repositories
{
    public class UserProfileRepository : IUserProfileRepositoryInterface , IDisposable
    {
        private readonly UserProfileDBContext _contextOptions;

        public UserProfileRepository(UserProfileDBContext _contextOptions)
        {
            this._contextOptions = _contextOptions; 
        }
        public List<User_Profile> saveUserProfile(User_Profile_Req data)
        {
            User_Profile userProfile = new User_Profile();
            userProfile.Name = data.Name;
            userProfile.Weight = data.Weight;
            userProfile.Height = data.Height;  
            userProfile.Birth_date = data.Birth_date;
            userProfile.Age = DateTime.Now.Year - data.Birth_date.Year;
            userProfile.BMI = data.Weight / Math.Pow(data.Height / 100, 2);

            foreach (var act_ in data.RunningActivities)
            {
                _contextOptions.Entry(new Running_Activities
                {
                    Location = act_.Location,
                    Started = act_.Started,
                    Ended = act_.Ended,
                    Distance = act_.Distance,
                    Duration = DateTime.Now,
                    Average_Pace = (act_.Ended - act_.Started).TotalMinutes / act_.Distance
                }).State = (EntityState)System.Data.Entity.EntityState.Added;
            }
            _contextOptions.Entry(userProfile).State = (EntityState)System.Data.Entity.EntityState.Added;
            //_contextOptions.AddRange(userProfile);
            _contextOptions.SaveChanges();
            return _contextOptions.UserProfiles.ToList();
        }

        public void Dispose()
        {
            _contextOptions.Dispose();
        }

    }
}
