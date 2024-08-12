using static UserProfile_DeveloperExam.Models.UserModel;
using static UserProfile_DeveloperExam.Models.UserModelRequest;

namespace UserProfile_DeveloperExam.Interface
{
    public interface IUserProfileServiceInterface : IDisposable
    {
        List<User_Profile> saveUserProfile(User_Profile_Req data);
    }
}
