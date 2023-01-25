using System;
using System.Security.Cryptography;
using System.Text;

namespace КурсоваяОП
{
    public class User
    {        
            private string login;
            private string confirm;
            private string password;

            public User(string login, string password, string confirm = null)
            {
                this.login = login;
                this.password = password;
                this.confirm = confirm;
            }

            public string Login { get => login; }
            public string Password { get => password; }
            public string Confirm { get => confirm; }

        public bool IsCorrect()
            {
                Database database = new Database("Data Source=dataBase.db;Version=3;");

                if (database.CheckUser(this, false))
                    return true;

                return false;
        }
        public bool CorrectUser()
        {
            if (String.IsNullOrEmpty(login))
                throw new Exception("Поле для имени пользователя пусто.");
            if (String.IsNullOrEmpty(password))
                throw new Exception("Поле для пароля пусто.");
            if (login.Length < 8)
                throw new Exception("Длина логина пользователя меньше 8 символов.");
            if (password.Length < 8)
                throw new Exception("Длина пароля меньше 8 символов.");
            if (confirm != null && password != confirm)
                throw new Exception("Пароль и подтверждение пароля не совпадают.");
            return true;
        }
        public string getHash()
        {
            using (var hmac = new HMACSHA1(Encoding.UTF8.GetBytes("new key")))
            {
                return
               Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            } 
        }
        public void CreateUser()
        {
            Database database = new Database("Data Source=dataBase.db;Version=3;");
            database.createUser(this);

        }
        public bool Exist()
        {
            Database database = new Database("Data Source=dataBase.db;Version=3;");
            if (database.CheckUser(this,true))
                return true;
            else
                return false;
        }     
    }
}
