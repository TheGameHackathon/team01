using System;
using System.Collections.Generic;
using System.Linq;

namespace thegame.Leaderboard
{
    public class UserRepository : IUserRepository
    {
        private Dictionary<Guid, User> _board = new Dictionary<Guid, User>();

        public Guid AddUser(string username, string password)
        {
            var newUser = new User(username, password);
            if (!GetUserId(newUser).Equals(Guid.Empty)) 
                return Guid.Empty;

            var id = Guid.NewGuid();
            
            _board.Add(id, new User(username, password));
            return id;
        }

        public bool IsUserAuthorized(string username, string password)
        {
            var user = new User(username, password);
            return _board.ContainsValue(user);
        }

        public User GetUser(Guid userId)
        {
            return _board.TryGetValue(userId, out var user) 
                ? user : null;
        }

        public Guid GetUserId(User user)
        {
            return _board
                .FirstOrDefault(x => x.Value.Equals(user))
                .Key;
        }

        public void UpdateUserScore(Guid userId, int score)
        {
            GetUser(userId)?.SetIfMaxScore(score);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _board.Values.OrderByDescending(x => x.Score);
        }
    }
}