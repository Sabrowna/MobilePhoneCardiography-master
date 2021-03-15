using MobilePhoneCardiography.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneCardiography.Services
{
    public class MockDataStoreUser : IDataStore<User>
    {
        readonly List<User> users;

        public MockDataStoreUser()
        {
            users = new List<User>()
            {
                new User { Id = Guid.NewGuid().ToString(), Username = "First item", Password="This is an item description." },
                new User { Id = Guid.NewGuid().ToString(), Username = "Second item", Password="This is an item description." },
                new User { Id = Guid.NewGuid().ToString(), Username = "Third item", Password="This is an item description." },
                new User { Id = Guid.NewGuid().ToString(), Username = "Fourth item", Password="This is an item description." },
                new User { Id = Guid.NewGuid().ToString(), Username = "Fifth item", Password="This is an item description." },
                new User { Id = Guid.NewGuid().ToString(), Username = "Sixth item", Password="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(User measurement)
        {
            users.Add(measurement);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(User user)
        {
            var oldUser = users.Where((User arg) => arg.Id == user.Id).FirstOrDefault();
            users.Remove(oldUser);
            users.Add(user);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(long id)
        {
            var oldUser = users.Where((User arg) => Convert.ToInt16(arg.Id) == id).FirstOrDefault();
            users.Remove(oldUser);

            return await Task.FromResult(true);
        }

        public async Task<User> GetItemAsync(long id)
        {
            return await Task.FromResult(users.FirstOrDefault(s => Convert.ToInt16(s.Id) == id));
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(users);
        }
    }
}