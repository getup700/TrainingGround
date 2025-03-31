using MySql.Data.MySqlClient;

namespace DbConnection.Bases;

internal class MySqlConnHelper
{
    private const string _connString = "Server=39.106.54.114;Database=sakila;Port=3306;Uid=root;Pwd=260963hzw.;";
    public void Run()
    {
        using var conn = new MySqlConnection(_connString);
        conn.Open();
        var transaction = conn.BeginTransaction();

    }
}
