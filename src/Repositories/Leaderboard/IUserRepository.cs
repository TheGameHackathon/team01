using System;
using System.Collections.Generic;

namespace thegame.Leaderboard
{
    public interface IUserRepository
    {
        Guid AddUser(string username, string password);
        
        void UpdateUserScore(Guid userId, int score);
        IEnumerable<User> GetAllUsers();
    }
}