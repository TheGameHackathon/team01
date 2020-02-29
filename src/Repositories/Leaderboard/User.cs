using System;

namespace thegame.Leaderboard
{
    public class User
    {
        public int Score { get; private set; } = 0;

        public string Name { get; }
        private string _password;

        public void SetIfMaxScore(int newScore) => 
            Score = Math.Max(newScore, Score);
        

        public User(string name, string password)
        {
            Name = name;
            _password = password;
        }

        public bool IsSameUser(string username, string password)
        {
            return string.Equals(username, Name) 
                   && string.Equals(password, _password);
        }
    }
}