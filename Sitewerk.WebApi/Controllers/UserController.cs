using Microsoft.AspNetCore.Mvc;
using Sitewerk.WebApi.Models;
using Sitewerk.WebApi.Services;

namespace Sitewerk.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private UserService userService;

    public UserController(UserService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        try
        {
            var users = userService.GetAllUsers();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest("Error occurred");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        var user = userService.CreateUser(request);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, CreateUserRequest request)
    {
        var user = userService.UpdateUser(id, request);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var result = userService.DeleteUser(id);
        if (result)
        {
            return Ok();
        }

        return NotFound();
    }

    [HttpPost("login")]
    public IActionResult Login(string username, string password)
    {
        var user = userService.AuthenticateUser(username, password);
        if (user != null)
        {
            return Ok(new { message = "Login successful", user = user, token = "fake-jwt-token" });
        }

        return Unauthorized();
    }

    [HttpGet("admin")]
    public IActionResult AdminEndpoint()
    {
        return Ok("Admin data");
    }
}