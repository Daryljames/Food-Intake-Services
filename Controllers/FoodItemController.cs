using System.Net;
namespace FoodIntakeServices.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using FoodIntakeServices.Commands;
using FoodIntakeServices.Models;
using FoodIntakeServices.Interfaces;


[ApiController]
[Route("food_items")]
public class FoodItemController : ControllerBase
{
    private readonly IFoodItemsService _foodItemsService;

    private readonly IUsersService _usersService;

    public FoodItemController(IFoodItemsService foodItemsService, IUsersService usersService)
    {
        _foodItemsService = foodItemsService;
        _usersService = usersService;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<FoodItem> foodItem = _foodItemsService.GetAll();
        return Ok(foodItem);
    }

    // [HttpGet("{date}")]
    // public IActionResult IndexDate(DateTime date)
    // {
    //     List<FoodItem> foodItem = _foodItemsService.GetByDate(date);
    //     return Ok(foodItem);
    // }

    [HttpGet("{id}")]
    public IActionResult Show(int id)
    {
        FoodItem food = _foodItemsService.GetById(id);
        if (food == null)
        {
            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "No food found with id " + id);
            return UnprocessableEntity(message);
        }
        else
        {
            return Ok(food);
        }

    }

    [HttpGet("{id}/{userId}")]
    public IActionResult Show(int id, int userId)
    {
        FoodItem food = _foodItemsService.GetByIdAndUserId(id, userId);
        if (food == null)
        {
            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "No food found with id " + id + " and userId " + userId);
            return UnprocessableEntity(message);
        }
        else
        {
            return Ok(food);
        }

    }

    [HttpPost("")]
    public IActionResult Save([FromBody] object payload)
    {
        Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

        ValidateSaveFoodItem validator = new ValidateSaveFoodItem(hash);
        validator.Execute();

        if (validator.HasErrors())
        {
            return UnprocessableEntity(validator.Errors);
        }
        else
        {
            BuildFoodItemFromDictionary cmd = new BuildFoodItemFromDictionary(hash, _usersService);

            FoodItem foodItem = cmd.Execute();
            _foodItemsService.Save(foodItem);

            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "Ok");
            return Ok(message);
        }
    }
    [HttpPut("{id}")]
    public IActionResult Edit([FromBody] object payload, int id)
    {

        FoodItem food = _foodItemsService.GetById(id);
        if (food == null)
        {
            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "No food found with id " + id);
            return UnprocessableEntity(message);
        }
        else
        {
            Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

            ValidateSaveFoodItem validator = new ValidateSaveFoodItem(hash);
            validator.Execute();

            if (validator.HasErrors())
            {
                return UnprocessableEntity(validator.Errors);
            }
            else
            {
                BuildFoodItemFromDictionary cmd = new BuildFoodItemFromDictionary(hash, _usersService);

                FoodItem foodItem = cmd.Execute();
                _foodItemsService.Save(foodItem);

                Dictionary<string, object> message = new Dictionary<string, object>();
                message.Add("message", "Ok");
                return Ok(message);
            }
        }

    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        FoodItem food = _foodItemsService.Delete(id);
        if (food == null)
        {
            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "No food found with id " + id);
            return UnprocessableEntity(message);
        }
        else
        {
            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "Deleted");
            return Ok(message);
        }
    }
}