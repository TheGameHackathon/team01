using System;
using System.Collections.Generic;
using System.Linq;

namespace thegame.Leaderboard
{
    public class UserRepository : IUserRepository
    {
        //private Dictionary<User, Guid> _board;
        //
        //public void AddUser(string username, string password)
        //{
        //    if(FindUser(username) == null)
        //        _board.Add(new User(username, password), new Guid());
        //}
//
        //public User FindUser(Guid userId)
        //{
        //    return _board.Keys.FirstOrDefault(x => x.Name.Equals(username));
        //}
//
        //public Guid GetUserId(string username)
        //{
        //    throw new NotImplementedException();
        //}
//
        //public User FindUser(Guid userId)
        //{
        //    return _board.Keys.FirstOrDefault(x => x.Name.Equals(username));
        //}
//
        //public void UpdateUserScore(Guid userId, int score)
        //{
        //    FindUser(username)?.SetIfMaxScore(score);
        //}
//
        //public IEnumerable<User> GetAllUsers()
        //{
        //    return _board.Keys.OrderByDescending(x => x.Score);
        //}
        public Guid AddUser(string username, string password)
        {
                throw new NotImplementedException();
        }

        public void UpdateUserScore(Guid userId, int score)
        {
                throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
                throw new NotImplementedException();
        }
    }
}