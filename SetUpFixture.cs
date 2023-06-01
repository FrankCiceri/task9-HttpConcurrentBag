using Newtonsoft.Json;
using System.Collections.Concurrent;
using Task9.Clients;
using Task9.Models.Responses;

namespace Task9
{
    [SetUpFixture]
    public class SetUpFixture
    {
        //[OneTimeSetUp]
        //public void OneTimeSetUp()
        //{ 

        //}

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
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
    }

    public static class TestDataStorage
    { 
    
    private static readonly ConcurrentBag<int> _addedUsers = new ConcurrentBag<int>();
    private static readonly ConcurrentBag<int> _deletedUsers = new ConcurrentBag<int>();
        public static void AddUser(int id)
        {
            _addedUsers.Add(id);
        
        }

        public static void RemoveUser(int id)
        {
            _deletedUsers.Add(id);

        }

        public static IEnumerable<int> GetUsers()        {

            var finalUsers = _addedUsers.Except(_deletedUsers);
            return finalUsers.ToArray();
        
        }
    
    }

}
