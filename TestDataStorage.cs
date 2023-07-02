using System.Collections.Concurrent;

namespace Task9
{
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
