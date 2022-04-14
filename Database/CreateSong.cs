using PA3.Interfaces;
using PA3.Models;
using MySql.Data.MySqlClient;

namespace PA3.Database
{
    public class CreateSong
    {
        public static void CreateSongTable()
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"CREATE TABLE songs(id INTEGER PRIMARY KEY AUTO_INCREMENT, title TEXT, date_added DATE, deleted TEXT)";
            // string stm = @"DROP TABLE IF EXISTS songs";
            using var cmd = new MySqlCommand(stm, con);
            cmd.ExecuteNonQuery();
        }
        public static void AddSong(Song song)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;
            using var con = new MySqlConnection(cs);
            con.Open();

            string stm = @"INSERT INTO songs(title, date_added, deleted) VALUES(@title, @date_added, @deleted)";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@title", song.SongTitle);
            cmd.Parameters.AddWithValue("@date_added", song.SongTimestamp);
            cmd.Parameters.AddWithValue("@deleted", song.Deleted);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}