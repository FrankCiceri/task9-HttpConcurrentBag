using Newtonsoft.Json;
using Task9.Clients;
using Task9.Models.Responses;
using TechTalk.SpecFlow;

namespace Task9.DI
{
    [Binding]
    public class SetUpFixture
    {
        //[OneTimeSetUp]
        //public void OneTimeSetUp()
        //{ 

        //}

        [AfterTestRun]
        public static async Task OneTimeTearDown()
        {
            var userClient = new UserServiceClient();
            var walletClient = new WalletServiceClient();

            var usersTasks = TestDataStorage.GetUsers()
                .Select(async user =>
                new { Key = user, Value = await (await walletClient.GetTransactions(user)).Content.ReadAsStringAsync() });

            var selectedData = await Task.WhenAll(usersTasks);

            var deleteTasks = selectedData.ToDictionary(element => element.Key, element => element.Value)
                .Where(element => JsonConvert.DeserializeObject<List<TransactionsResponse>>(element.Value).Count() == 0)
                .Select(element => userClient.DeleteUser(element.Key));

            await Task.WhenAll(deleteTasks);
        }

        //[ScenarioDependencies]
        //public static ContainerBuilder ScenarioDependencies()
        //{


        //    var builder = new ContainerBuilder();

        //    builder.RegisterModule<TestDependencyModule>();

        //    return builder;

        //}

        //[BeforeTestRun]
        //public static void BeforeTestRun()
        //{
        //    var container = ScenarioDependencies().Build();


        //}


    }

}


