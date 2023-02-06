namespace FoodIntakeServices.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using FoodIntakeServices.Commands;
using FoodIntakeServices.Models;
using FoodIntakeServices.Interfaces;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    public readonly IUsersService _usersService;

    public UserController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        Dictionary<string, object> data = new Dictionary<string, object>();
        data.Add("users", _usersService.GetAll());
        return Ok(data);
    }

    [HttpGet("{id}")]
    public IActionResult Show(int id)
    {
        User user = _usersService.GetById(id);
        if (user == null)
        {
            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "No food found with id " + id);
            return UnprocessableEntity(message);
        }
        else
        {
            return Ok(user);
        }
    }

    [HttpPost("")]
    public IActionResult Save([FromBody] object payload)
    {
        Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

        ValidateSaveUser validator = new ValidateSaveUser(hash);
        validator.Execute();

        if (validator.HasErrors())
        {
            return UnprocessableEntity(validator.Errors);
        }
        else
        {
            BuildUserFromHash cmd = new BuildUserFromHash(hash);

            User user = cmd.Execute();
            _usersService.Save(user);

            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "Ok");
            return Ok(message);
        }
    }
}