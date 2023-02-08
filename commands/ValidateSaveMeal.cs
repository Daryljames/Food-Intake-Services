using System;
using System.Text.RegularExpressions;

namespace FoodIntakeServices.Commands;

public class ValidateSaveMeal
{
    private Dictionary<string, object> payload;

    public Dictionary<string, List<string>> Errors { get; set; }

    public ValidateSaveMeal(Dictionary<string, object> payload)
    {
        this.payload = payload;

        this.Errors = new Dictionary<string, List<string>>();

        Errors.Add("name", new List<string>());
        Errors.Add("isACtive", new List<string>());
    }

    public bool HasErrors()
    {
        bool ans = false;

        if (Errors["name"].Count > 0)
        {
            ans = true;
        }
        if (Errors["isACtive"].Count > 0)
        {
            ans = true;
        }
        return ans;
    }

    public void Execute()
    {
        if (!payload.ContainsKey("name"))
        {
            Errors["name"].Add("name is required");
        }
        if (!payload.ContainsKey("isActive"))
        {
            Errors["isActive"].Add("isActive is required");
        }
    }
}