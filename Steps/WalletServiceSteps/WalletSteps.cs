using Task9.Clients;
using Task9.Models.Requests;
using TechTalk.SpecFlow;

namespace Task9.Steps.WalletServiceSteps
{
    [Binding]
    public sealed class WalletSteps
    {

        private readonly UserServiceClient _userService;
        private readonly UserServiceRegisterUserRequest _requestBody;
        private readonly DataContext _context;
        private readonly WalletServiceClient _walletService;
        WalletServiceChargeRequest _requestChargeBody;



        public WalletSteps(DataContext context,
                UserServiceRegisterUserRequest requestBody,
                UserServiceClient userService, 
                WalletServiceClient walletService,
                WalletServiceChargeRequest requestChargeBody)
        {

            _context = context;
            _requestBody = requestBody;
            _userService = userService;
            _walletService = walletService;
            _requestChargeBody = requestChargeBody;
        }

        [Given(@"Set user status active")]
        public async Task SetStatusActive()
        {
            await _userService.SetUserStatus(_context.Id1, true);
        }

        [Given(@"Charge user negative value: (.*)")]
        public async Task GivenChargeUser(bool negativeBalance)
        {

            await (negativeBalance ? _requestChargeBody.SetNegativeBalance() : _walletService.Charge(_requestChargeBody));

        }

       
        [Given(@"add to default balance: '([^']*)'")]
        public async Task GivenAddToDefaultBalance(string boolean)
        {
            var addToDefaultBalance = Convert.ToBoolean(boolean);
            if (addToDefaultBalance)
            {
                _requestChargeBody.SetBody(_context.Id1, Math.Round(new Random().NextDouble() * (10000000 - 0.01) + 0.01, 2));
                await _walletService.Charge(_requestChargeBody);

            }
        }

        [Given(@"Set charge body with (.*)")]
        public void GivenSetChargeBodyWithAmount(double amount)
        {
            _requestChargeBody.SetBody(_context.Id1, amount);
        }

        [When(@"Get Charge Status Code")]
        public async Task WhenGetChargeStatusCode()
        {
             var response = await _walletService.Charge(_requestChargeBody);
             _context.GetChargeStatusCode = response.StatusCode;
        }


        [When(@"Get Balance status code")]
        public async Task WhenGetBalanceStatusCode()
        {
            HttpResponseMessage response = await _walletService.GetBalance(_context.Id1);
            _context.GetBalanceStatusCode = response.StatusCode;

        }



    }
}