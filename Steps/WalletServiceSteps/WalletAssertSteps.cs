using System.Net;
using Task9.Clients;
using Task9.Models.Requests;
using TechTalk.SpecFlow;

namespace Task9.Steps.WalletServiceSteps
{
    [Binding]
    public sealed class WalletAssertSteps
    {

        private readonly UserServiceClient _userService;
        private readonly UserServiceRegisterUserRequest _requestBody;
        private readonly DataContext _context;
        private static readonly object _contextLock = new object();



        public WalletAssertSteps(DataContext context)
        {
            _context = context;    
        }

        



        [Then(@"Get Balance Status code is '([^']*)'")]
        public void ThenGetBalanceStatusCodeIs(string expected)
        {
            var expectedStatus = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), expected);

            var actualStatus = _context.GetBalanceStatusCode;

            Assert.That(_context.GetBalanceStatusCode, Is.EqualTo(expectedStatus));

        }

        [Then(@"Get Charge Status Code is '([^']*)'")]
        public void ThenGetChargeStatusCodeIs(string expected)
        {
            var expectedStatus = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), expected);

            var actualStatus = _context.GetBalanceStatusCode;

            Assert.That(_context.GetChargeStatusCode, Is.EqualTo(expectedStatus));
        }



    }
}