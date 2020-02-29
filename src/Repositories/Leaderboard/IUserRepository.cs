using System;
using System.Collections.Generic;

namespace thegame.Leaderboard
{
    public interface IUserRepository
    {
        Guid AddUser(string username, string password);
        User GetUser(Guid userId);
        Guid GetUserId(User user);
        void UpdateUserScore(Guid userId, int score);
        IEnumerable<User> GetAllUsers();
    }
}