using System;
using System.Text.RegularExpressions;

namespace FoodIntakeServices.Commands;

public class ValidateSaveUser
{
    private Dictionary<string, object> payload;

    public Dictionary<string, List<string>> Errors { get; private set; }

    public ValidateSaveUser(Dictionary<string, object> payload)
    {
        this.payload = payload;

        this.Errors = new Dictionary<string, List<string>>();

        Errors.Add("firstName", new List<string>());
        Errors.Add("middleName", new List<string>());
        Errors.Add("lastName", new List<string>());
        Errors.Add("age", new List<string>());
        Errors.Add("weight", new List<string>());
        Errors.Add("weightType", new List<string>());
        Errors.Add("height", new List<string>());
        Errors.Add("heightType", new List<string>());
        Errors.Add("userType", new List<string>());
        Errors.Add("calorieGoal", new List<string>());
        Errors.Add("email", new List<string>());
        Errors.Add("password", new List<string>());
    }

    public bool HasErrors()
    {
        bool ans = false;

        if (Errors["firstName"].Count > 0)
        {
            ans = true;
        }
        if (Errors["middleName"].Count > 0)
        {
            ans = true;
        }
        if (Errors["lastName"].Count > 0)
        {
            ans = true;
        }
        if (Errors["age"].Count > 0)
        {
            ans = true;
        }
        if (Errors["weight"].Count > 0)
        {
            ans = true;
        }
        if (Errors["weightType"].Count > 0)
        {
            ans = true;
        }
        if (Errors["height"].Count > 0)
        {
            ans = true;
        }
        if (Errors["heightType"].Count > 0)
        {
            ans = true;
        }
        if (Errors["userType"].Count > 0)
        {
            ans = true;
        }
        if (Errors["calorieGoal"].Count > 0)
        {
            ans = true;
        }
        if (Errors["email"].Count > 0)
        {
            ans = true;
        }
        if (Errors["password"].Count > 0)
        {
            ans = true;
        }

        return ans;
    }

    public bool HasNoErrors()
    {
        return !HasErrors();
    }

    public void Execute()
    {
        if (!payload.ContainsKey("firstName"))
        {
            Errors["firstName"].Add("First name is required");
        }
        if (!payload.ContainsKey("lastName"))
        {
            Errors["lastName"].Add("Last name is required");
        }
        if (!payload.ContainsKey("age"))
        {
            Errors["age"].Add("Age is required");
        }
        if (!payload.ContainsKey("weight"))
        {
            Errors["weight"].Add("Weight is required");
        }
        if (!payload.ContainsKey("weightType"))
        {
            Errors["weightType"].Add("Weight Type is required");
        }
        if (!payload.ContainsKey("height"))
        {
            Errors["height"].Add("height is required");
        }
        if (!payload.ContainsKey("heightType"))
        {
            Errors["heightType"].Add("Height Type is required");
        }
        if (!payload.ContainsKey("userType"))
        {
            Errors["userType"].Add("User Type is required");
        }
        if (!payload.ContainsKey("calorieGoal"))
        {
            Errors["calorieGoal"].Add("Calorie Goal is required");
        }
        if (!payload.ContainsKey("email"))
        {
            Errors["email"].Add("Email is required");
        }
        if (!payload.ContainsKey("password"))
        {
            Errors["password"].Add("Password is required");
        }
    }
}