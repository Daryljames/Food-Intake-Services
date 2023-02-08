namespace FoodIntakeServices.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using FoodIntakeServices.Commands;
using FoodIntakeServices.Models;
using FoodIntakeServices.Interfaces;

[ApiController]
[Route("meals")]
public class MealController : ControllerBase
{
    public readonly IMealsService _mealsService;

    public MealController(IMealsService mealsService)
    {
        _mealsService = mealsService;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Meal> meal = _mealsService.GetAll();
        return Ok(meal);
    }

    [HttpGet("{id}")]
    public IActionResult Show(int id)
    {
        Meal meal = _mealsService.GetById(id);
        if (meal == null)
        {
            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "No meal found with id " + id);
            return UnprocessableEntity(message);
        }
        else
        {
            return Ok(meal);
        }
    }

    [HttpPost("")]
    public IActionResult Save([FromBody] object payload)
    {
        Dictionary<string, object> hash = JsonSerializer.Deserialize<Dictionary<string, object>>(payload.ToString());

        ValidateSaveMeal validator = new ValidateSaveMeal(hash);
        validator.Execute();

        if (validator.HasErrors())
        {
            return UnprocessableEntity(validator.Errors);
        }
        else
        {
            BuildMealFromHash cmd = new BuildMealFromHash(hash);

            Meal meal = cmd.Execute();
            _mealsService.Save(meal);

            Dictionary<string, object> message = new Dictionary<string, object>();
            message.Add("message", "Ok");
            return Ok(message);
        }
    }
}