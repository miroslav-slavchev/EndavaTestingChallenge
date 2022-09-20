using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework.Internal;
using Reqres.Library.Entities.Dtos;
using Reqres.Library.Entities.Dtos.User;
using System.Net;

namespace Reqres.Tests
{
    [TestFixture]
    public class UserTests : Tests
    {
        [Test]
        [Description("List available users")]
        public void ListAvailableUsers()
        {
            //GET /api/users?page=1
            var allUsers = APIClient.Users.GetAll(page: 1);
            allUsers.RestResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            //Execute one or many JSON Response Assertions
            ReqresMultipleDto<UserDataDto> content = allUsers.DeserializedContent.Single();
            content.Support.Text.Should().Be(@"To keep ReqRes free, contributions towards server costs are appreciated!");
            content.Support.Url.Should().Be(@"https://reqres.in/#support-heading");
            content.Data.Should().NotBeEmpty();
            content.Data.Should().HaveCountLessThanOrEqualTo(content.PerPage);
            content.Page.Should().Be(1);
            content.TotalPages.Should().BeGreaterThanOrEqualTo(content.Total / content.PerPage);

            //Extract single user details (Id, Email)
            var user1ActualData = content.Data.First();
            TestContext.WriteLine(user1ActualData.Id);
            TestContext.WriteLine(user1ActualData.Email);

            var user1ExpectedData = JsonFileReader.GetJObjectFromFile("TestData\\User1.json").ToObject<ReqresSingleDto<UserDataDto>>();
            user1ExpectedData.Data.Should().BeEquivalentTo(user1ActualData);

            //(Optional) Extract all users, sort them by First Name alphabetically. Print sorted collection.
            var allUsersOnCurrentPage = content.Data.OrderBy(user => user.FirstName).ToList();
            allUsersOnCurrentPage.ForEach(user => TestContext.WriteLine(user.FirstName));
        }

        [Test]
        [Description("Get extracted user details")]
        public void GetExtractedUserDetails()
        {
            //GET /api/users/{USER_ID}
            var user1ActualData = APIClient.Users.GetSingle(id: 1).DeserializedContent.Single();

            //Execute one or many JSON Response Assertions
            var user1ExpectedData = JsonFileReader.GetJObjectFromFile("TestData\\User1.json").ToObject<ReqresSingleDto<UserDataDto>>();
            user1ExpectedData.Should().BeEquivalentTo(user1ActualData);
        }

        [Test]
        [Description("Try to get details of user that doesn't exist")]
        public void TryToGetDetailsOfUserThatDoesntExist()
        {
            //GET /api/users/{USER_ID}
            var user1ActualData = APIClient.Users.GetSingle(id: 23);

            //Execute one or many Assertions
            user1ActualData.DeserializedContent.Should().BeEmpty();
            user1ActualData.RestResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Test]
        [Description("Create UNIQUE new user")]
        public void CreateUNIQUENewUser()
        {
            //Preconditions
            var dateTimeOffsetBeforeTheRequest = DateTimeOffset.Now;
            List<int> allUserIdsBeforeTheRequest = GetAllUserIds();

            //POST /api/users
            var createUserDto = JsonFileReader.GetJObjectFromFile("TestData\\CreateUser.json").ToObject<CreateUserDto>();
            var cratedUserResponse = APIClient.Users.Add(createUserDto);

            //Execute one or many JSON Response Assertions
            cratedUserResponse.RestResponse.StatusCode.Should().Be(HttpStatusCode.Created);

            cratedUserResponse.DeserializedContent.Single().Name.Should().Be(createUserDto.Name);
            cratedUserResponse.DeserializedContent.Single().Job.Should().Be(createUserDto.Job);

            allUserIdsBeforeTheRequest.Should().NotContain(int.Parse(cratedUserResponse.DeserializedContent.Single().Id));

            cratedUserResponse.DeserializedContent.Single()
                .CreatedAt.AddHours(Configuration.TimezoneDifference)
                .Should()
                .BeAfter(dateTimeOffsetBeforeTheRequest);
        }

        [Test]
        [Description("Delete newly created user")]
        public void DeleteNewlyCreatedUser()
        {
            //DELETE /api/users/{USER_ID}
            var deletedUserResponse = APIClient.Users.Remove(id: 2);

            //Execute one or many Assertions
            deletedUserResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

            //var getUser = APIClient.Users.GetSingle(id: 2);
            //getUser.RestResponse.Should().Be(HttpStatusCode.NotFound);
            //getUser.DeserializedContent.Should().BeEmpty();

        }

        private List<int> GetAllUserIds()
        {
            var allUsers = APIClient.Users.GetAll();
            var totalPages = allUsers.DeserializedContent.Single().TotalPages;

            List<int> ids = new();
            for (int i = 1; i < totalPages; i++)
            {
                var idsOnPageI = APIClient.Users.GetAll(page: i)
                    .DeserializedContent.Single()
                    .Data.Select(user => user.Id)
                    .ToList();

                ids.AddRange(idsOnPageI);
            }

            return ids;
        }
    }
}
