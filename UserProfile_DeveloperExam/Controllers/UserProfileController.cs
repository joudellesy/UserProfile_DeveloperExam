using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.OleDb;
using System.Text.Json.Serialization;
using UserProfile_DeveloperExam.DBContext;
using UserProfile_DeveloperExam.Interface;
using UserProfile_DeveloperExam.Models;
using UserProfile_DeveloperExam.Services;
using static UserProfile_DeveloperExam.Models.UserModelRequest;
using static UserProfile_DeveloperExam.Models.UserModel;

namespace UserProfile_DeveloperExam.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly ILogger<UserProfileController> _logger;
        //private readonly IUserProfileServiceInterface _serviceinterface;
        private readonly UserProfileDBContext _contextOptions;

        public UserProfileController(ILogger<UserProfileController> logger
            ,UserProfileDBContext _contextOptions
            )
        {
            _logger = logger;
            this._contextOptions = _contextOptions;
        }

        [HttpPost]
        public string Get(User_Profile_Req data)
        {
            try
            {
                _logger.LogInformation("Getting Request: {data}", JsonConvert.SerializeObject(data));
                var asd = new UserProfileService(_contextOptions);
                var result = JsonConvert.SerializeObject(asd.saveUserProfile(data));
                return result;

            }catch(Exception ex)
            {

                _logger.LogError("ERROR: ", ex.Message);
                throw new NotImplementedException();
            }
        }


    }
}