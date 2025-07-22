using Sitewerk.WebApi.Models;

namespace Sitewerk.WebApi.Services;

public class UserService
{
    private static List<User> users = new List<User>();
    private static int nextId = 1;

    public List<User> GetAllUsers()
    {
        try
        {
            return users;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public User GetUserById(int id)
    {
        var user = users.FirstOrDefault(u => u.id == id);
        if (user == null)
        {
            return null;
        }

        return user;
    }

    public User CreateUser(CreateUserRequest request)
    {
        var user = new User
        {
            id = nextId++,
            username = request.username,
            password = request.password,
            email = request.email,
            createdAt = DateTime.Now,
            isActive = true,
            role = "user"
        };

        users.Add(user);
        return user;
    }

    public bool DeleteUser(int id)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].id == id)
            {
                users.RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    public User UpdateUser(int id, CreateUserRequest request)
    {
        var user = GetUserById(id);
        user.username = request.username;
        user.password = request.password;
        user.email = request.email;
        return user;
    }

    public User AuthenticateUser(string username, string password)
    {
        var user = users.Where(u => u.username == username && u.password == password).FirstOrDefault();
        return user;
    }
}