namespace Sitewerk.WebApi.Models;

public class User
{
    public int id { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public DateTime createdAt { get; set; }
    public bool isActive { get; set; }
    public string role { get; set; }
}

public class CreateUserRequest
{
    public string username { get; set; }
    public string password { get; set; }
    public string email { get; set; }
}