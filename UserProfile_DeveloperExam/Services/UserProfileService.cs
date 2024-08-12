using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using UserProfile_DeveloperExam.DBContext;
using UserProfile_DeveloperExam.Interface;
using UserProfile_DeveloperExam.Repositories;
using static UserProfile_DeveloperExam.Models.UserModelRequest;
using static UserProfile_DeveloperExam.Models.UserModel;
using UserProfile_DeveloperExam.Models;

namespace UserProfile_DeveloperExam.Services
{
    public class UserProfileService : IUserProfileServiceInterface
    {
        private readonly UserProfileDBContext _contextOptions;

        public UserProfileService (
            UserProfileDBContext _contextOptions
            )
        {
            this._contextOptions = _contextOptions;
        }
        public List<User_Profile> saveUserProfile(User_Profile_Req data)
        {
            UserProfileRepository user_repo = new UserProfileRepository(_contextOptions);
            return user_repo.saveUserProfile(data);
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
