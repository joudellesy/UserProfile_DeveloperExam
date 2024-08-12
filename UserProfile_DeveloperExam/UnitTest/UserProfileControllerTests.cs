using Microsoft.EntityFrameworkCore;
using Moq;
using UserProfile_DeveloperExam.Controllers;
using UserProfile_DeveloperExam.DBContext;
using Xunit;
using static UserProfile_DeveloperExam.Models.UserModel;
using static UserProfile_DeveloperExam.Models.UserModelRequest;

namespace UserProfile_DeveloperExam.UnitTest
{
    public class UserProfileControllerTests 
    {
        private readonly UserProfileController _controller;
        private readonly UserProfileDBContext _context;

        public UserProfileControllerTests()
        {
            var options = new DbContextOptionsBuilder<UserProfileDBContext>()
                .UseInMemoryDatabase(databaseName: "User_Prfile")
                .UseInMemoryDatabase(databaseName: "Running_Activities")
                .Options;
            var mock = new Mock<ILogger<UserProfileController>>();
            ILogger<UserProfileController> logger = mock.Object;
            _context = new UserProfileDBContext(options);
            _controller = new UserProfileController(logger, _context);
        }

        [Fact]
        public void PostUserProfile_CalculatesAgeAndBMI_Correctly()
        {
            // Arrange
            var userProfile = new User_Profile_Req
            {
                Name = "Jane Doe",
                Weight = 60,
                Height = 165,
                Birth_date = new DateTime(1995, 5, 5),
                Age = (DateTime.Now.Year - new DateTime(2022, 5, 5).Year),
                BMI = 60 / Math.Pow(165 / 100, 2),
                RunningActivities = new List<Running_Activities_Req> { new Running_Activities_Req { Average_Pace = 500 , Distance = 100 , Duration = new DateTime(2024, 08, 15), Ended = new DateTime(2024, 08, 10), Started = new DateTime(2024,08,08) , Location = "pampanga" } } 
            };

            // Act
            var result = _controller.Get(userProfile);
            var createdUserProfile = _context.UserProfiles.FirstOrDefaultAsync(u => u.Name == "Jane Doe");

            // Assert
            Assert.Equal(29, createdUserProfile.Result.Age); // Assuming the current year is 2024
            Assert.Equal(22.04, createdUserProfile.Result.BMI, 2);
        }

        [Fact]
        public void PostUserProfile_AddsUserProfileToDatabase()
        {
            // Arrange
            var userProfile = new User_Profile_Req
            {
                Name = "jdsyy",
                Weight = 80,
                Height = 180,
                Birth_date = new DateTime(1985, 10, 10),
                Age = (DateTime.Now.Year - new DateTime(1995, 5, 5).Year),
                BMI = 80 / Math.Pow(180 / 100, 2),
                RunningActivities = new List<Running_Activities_Req> { new Running_Activities_Req { Average_Pace = 500, Distance = 100, Duration = new DateTime(2024, 08, 15), Ended = new DateTime(2024, 08, 10), Started = new DateTime(2024, 08, 08), Location = "pampanga" } }

            };

            // Act
             _controller.Get(userProfile);
            var createdUserProfile = _context.UserProfiles.FirstOrDefaultAsync(u => u.Name == "jdsyy");

            // Assert
            Assert.NotNull(createdUserProfile);
            Assert.Equal("jdsyy", createdUserProfile.Result.Name);
        }
    }
}
