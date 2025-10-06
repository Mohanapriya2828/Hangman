using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace hangman.model
{
    public class userrepository
    {
        private readonly string filepath;

        public userrepository(string filepath)
        {
            this.filepath = filepath;
        }

        public List<user> getallusers()
        {
            var users = new List<user>();
            if (!File.Exists(filepath)) return users;
            foreach (var line in File.ReadAllLines(filepath))
            {
                var parts = line.Split(',');
                if (parts.Length == 3)
                    users.Add(new user(parts[0], parts[1], parts[2]));
            }
            return users;
        }

        public user getuserbyusername(string username)
        {
            return getallusers().FirstOrDefault(u => u.username == username);
        }

        public void adduser(user user)
        {
            File.AppendAllText(filepath, $"{user.username},{user.password},{user.role}{System.Environment.NewLine}");
        }
    }
}
