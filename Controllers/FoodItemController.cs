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

    public FoodItemController(IFoodItemsService foodItemsService)
    {
        _foodItemsService = foodItemsService;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        Dictionary<string, object> data = new Dictionary<string, object>();
        data.Add("food_items", _foodItemsService.GetAll());
        return Ok(data);
    }

    [HttpGet("{id}")]
    public IActionResult Show(int id)
    {
        FoodItem food = _foodItemsService.GetById(id);
        if (food == null)
        {
            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "No food found");
            return Ok(message);
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
            BuildFoodItemFromDictionary cmd = new BuildFoodItemFromDictionary(hash);

            FoodItem foodItem = cmd.Execute();
            _foodItemsService.Save(foodItem);

            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "Ok");
            return Ok(message);
        }



    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        FoodItem food = _foodItemsService.Delete(id);
        if (food == null)
        {
            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "No food found");
            return Ok(message);
        }
        else
        {
            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "Deleted");
            return Ok(message);
        }
    }
}