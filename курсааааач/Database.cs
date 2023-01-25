using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace КурсоваяОП
{
    public class Database
    {
        private readonly string dataSource;
        //Проверка существования файла БД
        public Database()
        {
            if (!File.Exists(dataSource))
            {
                InitializeDatabase();
            }
        }

        public Database(string dataSource)
        {
            this.dataSource = dataSource;
        }
        public bool InitializeDatabase()
        {
            SQLiteConnection conn = new SQLiteConnection(dataSource);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    SQLiteCommand cmd = conn.CreateCommand();
                    string sql_command = "DROP TABLE IF EXISTS users;"
                    + "CREATE TABLE users("
                    + "id INTEGER PRIMARY KEY AUTOINCREMENT, "
                    + "login TEXT, "
                    + "password TEXT, "
                    + "role TEXT);"
                    + "DROP TABLE IF EXISTS distanse;"
                    + "CREATE TABLE distanse(id INTEGER PRIMARY KEY AUTOINCREMENT,"
                    + "login TEXT, firstWord TEXT, secondWord TEXT, distanse TEXT);";

                    cmd.CommandText = sql_command;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                conn.Dispose();
            }
            return true;
        }
        public bool createDisnanse(string Login, LevenshteinDistance levenshteinDistance)
        {
            SQLiteConnection conn = new SQLiteConnection(dataSource);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("INSERT INTO distanse (login, firstWord, secondWord, distanse)"
                + "VALUES ('{0}', '{1}', '{2}','{3}')", Login, levenshteinDistance.FirstWord,
                levenshteinDistance.SecondWord, levenshteinDistance.Levenshtein());
                cmd.ExecuteNonQuery();
                return true;
            }
            return true;
        }
        public bool createUser(User user)
        {
            SQLiteConnection conn = new SQLiteConnection(dataSource);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("INSERT INTO users (login, password)"
                + "VALUES ('{0}', '{1}')", user.Login, user.getHash());
                cmd.ExecuteNonQuery();
                return true;
            }
            return true;
        }


        public bool CheckUser(User user, bool exist)
        {
            SQLiteConnection conn = new SQLiteConnection(dataSource);
            try
            {
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();
                if (conn.State == ConnectionState.Open)
                {
                    if (exist)
                    {
                        cmd.CommandText = string.Format("SELECT *"
                            + "FROM users where login = '{0}'",user.Login);
               
                    }
                    else
                    {
                        cmd.CommandText = string.Format("SELECT COUNT(login)"
                        + "FROM users "
                        + "where login = '{0}' AND "
                        + "password = '{1}'",
                        user.Login, user.getHash());

                        
                    }
                }var usersCount = Convert.ToInt32(cmd.ExecuteScalar());
                        return usersCount > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                conn.Dispose();
            }         
        }     
    }
}

  
