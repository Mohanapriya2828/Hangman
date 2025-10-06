using hangman.model;
using hangman.view;

namespace hangman.controller
{
    public class logincontroller
    {
        private readonly loginview view;
        private readonly userrepository repo;

        public logincontroller(loginview view, userrepository repo)
        {
            this.view = view;
            this.repo = repo;
        }

        public user loginwithrole()
        {
            while (true)
            {
                var (username, password) = view.getlogincredentials();
                user existinguser = repo.getuserbyusername(username);

                if (existinguser != null)
                {
                    if (existinguser.password == password)
                    {
                        view.showmessage($"Welcome back, {username}!");
                        return existinguser;
                    }
                    else
                    {
                        view.showmessage("Incorrect password. Try again.");
                        continue;
                    }
                }
                else
                {
                    bool register = view.askforregistration();
                    if (!register)
                    {
                        view.showmessage("Login cancelled.");
                        return null;
                    }

                    var (newusername, newpassword) = view.getnewregistration();
                    user newuser = new user(newusername, newpassword, "user");
                    repo.adduser(newuser);
                    view.showmessage("Registration successful! Please login now.");
                }
            }
        }
    }
}
