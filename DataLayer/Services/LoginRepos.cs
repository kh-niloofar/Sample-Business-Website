using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LoginRepos : ILoginRepos
    {
        private Connect db;
        public LoginRepos(Connect connect)
        {
            this.db = connect;
        }
        public bool IsExistUser(string username, string pass)
        {
            return db.Logins.Any(c => c.UserName == username && c.UserPass == pass);
        }
    }
}
