using System;
using System.Text.RegularExpressions;

namespace FoodIntakeServices.Commands;

public class ValidateSaveFoodItem
{
    Regex rxCalorie = new Regex(@"\b^([0-9]+|([0-9]*\.[0-9][0-9]))$\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    Regex rxQuantity = new Regex(@"\b^([1-9]+|([1-9]*\.[0-9][0-9]))$\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);

    Regex rxMeasure = new Regex(@"\b^(\p{L}+)$\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private Dictionary<string, object> payload;

    public Dictionary<string, List<string>> Errors { get; private set; }

    public ValidateSaveFoodItem(Dictionary<string, object> payload)
    {
        this.payload = payload;

        this.Errors = new Dictionary<string, List<string>>();

        Errors.Add("name", new List<string>());
        Errors.Add("calorie", new List<string>());
        Errors.Add("quantity", new List<string>());
        Errors.Add("measure", new List<string>());
        Errors.Add("dateEaten", new List<string>());
        Errors.Add("meal", new List<string>());
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
        if (Errors["quantity"].Count > 0)
        {
            ans = true;
        }
        if (Errors["measure"].Count > 0)
        {
            ans = true;
        }
        if (Errors["dateEaten"].Count > 0)
        {
            ans = true;
        }
        if (Errors["meal"].Count > 0)
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
        // int id = int.Parse(payload["id"].ToString());
        string quantity = payload["quantity"].ToString();
        string calorie = payload["calorie"].ToString();
        string dateEaten = payload["dateEaten"].ToString();
        string measure = payload["measure"].ToString();
        string meal = payload["meal"].ToString();

        if (!payload.ContainsKey("name"))
        {
            Errors["name"].Add("name is required");
        }
        else
        {
            string name = payload["name"].ToString();

            if (name == "")
            {
                Errors["name"].Add("Name should not be empty");
            }

            if (name.Length > 255)
            {
                Errors["name"].Add("Name should only be less than 255 characters");
            }
        }

        if (!payload.ContainsKey("calorie"))
        {
            Errors["calorie"].Add("calorie is required");
        }
        else if (calorie == "0")
        {
            Errors["calorie"].Add("Calorie should not be empty");
        }
        else
        {
            try
            {

                bool matches = rxCalorie.IsMatch((calorie));
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

        if (!payload.ContainsKey("quantity"))
        {
            Errors["quantity"].Add("quantity is required");
        }
        else if (quantity == "0")
        {
            // string quantity = payload["quantity"].ToString();
            Errors["quantity"].Add("Quantity should not be empty");
        }
        else
        {
            try
            {
                bool matches = rxQuantity.IsMatch((payload["quantity"].ToString()));
                if (!matches)
                {
                    Errors["quantity"].Add("Quantity should be greater than zero and only up to 2 decimal places");
                }
            }
            catch (FormatException e)
            {
                Errors["quantity"].Add("Invalid format for quantity " + payload["quantity"].ToString());
            }
        }

        if (!payload.ContainsKey("measure"))
        {
            Errors["measure"].Add("measure is required");
        }
        else if (measure == "")
        {
            Errors["measure"].Add("Measure should not be empty");
        }
        else
        {
            try
            {
                bool matches = rxMeasure.IsMatch((payload["measure"].ToString()));
                if (!matches)
                {
                    Errors["measure"].Add("Measure must only be one word");
                }
            }
            catch (FormatException e)
            {
                Errors["measure"].Add("Invalid format for measure " + payload["measure"].ToString());
            }
        }

        if (!payload.ContainsKey("meal"))
        {
            Errors["meal"].Add("meal is required");
        }
        else if (meal == "")
        {
            Errors["meal"].Add("Meal should not be empty");
        }
        else
        {
            try
            {
                bool matches = rxMeasure.IsMatch((payload["meal"].ToString()));
                if (!matches)
                {
                    Errors["meal"].Add("Meal must only be one word");
                }
            }
            catch (FormatException e)
            {
                Errors["meal"].Add("Invalid format for meal " + payload["meal"].ToString());
            }
        }


        if (!payload.ContainsKey("dateEaten"))
        {
            Errors["dateEaten"].Add("dateEaten is required");
        }
        else if (DateTime.Parse(dateEaten).Hour == DateTime.Now.Hour && DateTime.Parse(dateEaten).Minute == DateTime.Now.Minute)
        {
            Errors["dateEaten"].Add("Date Eaten should not be empty");
            System.Console.WriteLine(dateEaten);
        }
    }
}