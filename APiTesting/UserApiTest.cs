namespace APiTesting {
    [TestClass]
    public class UserApiTest {

        private RestClient client;
        [TestInitialize]
        public void TestInit() {
            client = new RestClient(ConfigurationHelper.GetConfig<String>("url"));
        }
        [TestMethod("TC05: Get List User")]
        public void VerifyGetListUser() {


            int randomePage = new Random().Next(1, 11);
            var request = new RestRequest($"/api/users?page={randomePage}", Method.Get);

            RestResponse response = client.Execute(request);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            GetUserModel getUserModel = JsonConvert.DeserializeObject<GetUserModel>(response.Content);
            getUserModel.page.Should().Be(randomePage);
            /*
             int randomePage = new Random().Next(1, 11);
            var request = new RestRequest($"/api/users?page={randomePage}", Method.Get);
            /*
             int randomePage = new Random().Next(1, 11);
            var request = new RestRequest($"/api/users?page={randomePage}", Method.Get);
            /*
             int randomePage = new Random().Next(1, 11);
            var request = new RestRequest($"/api/users?page={randomePage}", Method.Get);
      
            RestResponse response = client.Execute(request);
            /*
             int randomePage = new Random().Next(1, 11);
            var request = new RestRequest($"/api/users?page={randomePage}", Method.Get);
      
            RestResponse response = client.Execute(request);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            GetUserModel getUserModel = JsonConvert.DeserializeObject<GetUserModel>(response.Content);
            getUserModel.page.Should().Be(randomePage);
            
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            GetUserModel getUserModel = JsonConvert.DeserializeObject<GetUserModel>(response.Content);
            getUserModel.page.Should().Be(randomePage);
          
            RestResponse response = client.Execute(request);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            GetUserModel getUserModel = JsonConvert.DeserializeObject<GetUserModel>(response.Content);
            getUserModel.page.Should().Be(randomePage);
        
            RestResponse response = client.Execute(request);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            GetUserModel getUserModel = JsonConvert.DeserializeObject<GetUserModel>(response.Content);
            getUserModel.page.Should().Be(randomePage);
            */

        }
        [TestMethod("TC06: Create a new user")]
        public void VerifyCreateNewUser() {


            var request = new RestRequest("/api/users", Method.Post);
            var requestModel = new CreateUserRequestModel {
                Name = "Tham" + DateTime.Now.ToFileTimeUtc(),
                Job = "Automation Test",
            };

            request.AddJsonBody(requestModel);

            RestResponse response = client.Execute(request);
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            //

            var createUserResponseModel = JsonConvert.DeserializeObject<CreateUserResponseModel>(response.Content);
            createUserResponseModel.name.Should().Be(requestModel.Name);
            createUserResponseModel.job.Should().Be(requestModel.Job);

        }
    }
}
