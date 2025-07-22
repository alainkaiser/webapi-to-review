namespace Sitewerk.WebApi.Utils;

public class DatabaseHelper
{
    private string connectionString = "Server=localhost;Database=mydb;User Id=sa;Password=Password123!;";

    public object ExecuteQuery(string query)
    {
        Console.WriteLine($"Executing query: {query}");
        return "fake_result";
    }

    public void InsertUser(string username, string email)
    {
        var query = "INSERT INTO Users (Username, Email) VALUES ('" + username + "', '" + email + "')";
        ExecuteQuery(query);
    }

    public object GetUser(string username)
    {
        var query = "SELECT * FROM Users WHERE Username = '" + username + "'";
        return ExecuteQuery(query);
    }
}