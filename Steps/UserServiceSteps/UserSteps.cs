using Task9.Clients;
using Task9.Models.Requests;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Task9.Steps.UserServiceSteps
{
    [Binding]
    public sealed class UserSteps
    {
        private readonly UserServiceClient _userService;
        private readonly UserServiceRegisterUserRequest _requestBody;
        private readonly DataContext _context;
        private static readonly object _contextLock = new object();



    public UserSteps(DataContext context, 
            UserServiceRegisterUserRequest requestBody, UserServiceClient userService)
        {

            _context = context;
            _requestBody = requestBody;
            _userService = userService;

        }

        [Given(@"New user Id")]
        public async Task GivenNewUserId()
        {
            _context.Id1 = await _requestBody.GenerateUserId();
        }



        [Given(@"New user response body with '([^']*)' '([^']*)'")]
        public void GivenNewUserResponseBodyWith(string fName, string lName)
        {
            var firstName = fName == "null" ? null: fName;
            var lastName   = lName == "null" ? null : lName;

            _requestBody.SetBody(firstName, lastName);
            
        }


        [Given(@"New user response body with '([^']*)'")]
        public void GivenNewUserResponseBodyWith(string length)
        {
            _requestBody.SetBody(int.Parse(length));
        }





        [Given(@"Get Status from new user")]
        public async Task GivenGetStatusFromNewUser()
        {
            _context.GetUserStatus = await _userService.GetUserStatus(_context.Id1);
        }

        [Given(@"Delete first user Id when based on '([^']*)'")]
        public async Task GivenDeleteFirstUserIdWhenBasedOn(string boolean)
        {
            var enableDelete = Convert.ToBoolean(boolean);
            if (enableDelete)
            {
                await _userService.DeleteUser(_context.Id1);
            }
        }


        [When(@"Get Id for second user")]
        public async Task WhenGetIdForSecondUser()
        {
             _context.Id2 = await _requestBody.GenerateUserId();
        }



        [When(@"Get response from register user")]
        public async Task WhenGetResponseFromRegisterUser()
        {
            HttpResponseMessage response;
            response = await _userService.RegisterUser(_requestBody);

            lock (_contextLock)
            {
                _context.GetResponse = response;
            };           
                    
        }

        [When(@"Get StatusCode from deleting user")]
        public async Task WhenGetStatusCodeFromDeletingUser()
        {
            _context.DeleteUserStatusCode = await _userService.DeleteUser(_context.Id1);
        }

        [Given(@"Get StatusCode from set status")]
        [When(@"Get StatusCode from set status")]
        public async Task WhenGetStatusCodeFromSetStatus()
        {
           _context.SetStatusResponseCode = await _userService.SetUserStatus(_context.Id1, true);
        }

        [When(@"Get StatusCode from Get status")]
        public async Task WhenGetStatusCodeFromGetStatus()
        {
            _context.GetUserStatus = await _userService.GetUserStatus(_context.Id1);
        }











    }
}