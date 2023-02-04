using System;
using System.Text.RegularExpressions;

namespace FoodIntakeServices.Commands;

public class ValidateSaveFoodItem
{
    Regex rxCalorie = new Regex(@"\b^([0-9]+|([0-9]*\.[0-9][0-9]))$\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private Dictionary<string, object> payload;

    public Dictionary<string, List<string>> Errors { get; private set; }

    public ValidateSaveFoodItem(Dictionary<string, object> payload)
    {
        this.payload = payload;

        this.Errors = new Dictionary<string, List<string>>();

        Errors.Add("name", new List<string>());
        Errors.Add("calorie", new List<string>());
    }

    public bool HasErrors()
    {
        bool ans = false;

        if (Errors["name"].Count > 0)
        {
            ans = true;
        }

        if (Errors["calorie"].Count > 0)
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
        int id = int.Parse(payload["id"].ToString());

        if (!payload.ContainsKey("name"))
        {
            Errors["name"].Add("name is required");
        }
        else
        {
            string name = payload["name"].ToString();

            if (name.Length > 255)
            {
                Errors["name"].Add("Name should only be less than 255 characters");
            }
        }

        if (!payload.ContainsKey("calorie"))
        {
            Errors["calorie"].Add("calorie is required");
        }
        else if (payload.ContainsKey("calorie"))
        {

            try
            {
                bool matches = rxCalorie.IsMatch((payload["calorie"].ToString()));

                if (!matches)
                {
                    Errors["calorie"].Add("Calorie should only have 2 decimal places");
                }
            }
            catch (FormatException e)
            {
                Errors["calorie"].Add("Invalid format for calorie " + payload["calorie"].ToString());
            }

        }
        else
        {
            try
            {
                float calorie = float.Parse(payload["calorie"].ToString());

                if (calorie < 0)
                {
                    Errors["calorie"].Add("calorie should be positive");
                }
            }
            catch (FormatException e)
            {
                Errors["calorie"].Add("Invalid format for calorie " + payload["calorie"].ToString());
            }
        }
    }
}