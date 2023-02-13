# Expense Items API Demo C# ASP Backend

This is the back end application of Food Intake Bank using ASP.NET MVC.

## Initialize

1. As of this moment, when the user clones or pulls this repository, the user should edit the connection strings in the appsettings.json file.
2. Run dotnet ef database udpate
3. Run and change the payload for meal.json since it is still not integrated in the UI. There should only be four:
   - breakfast
   - lunch
   - dinner
   - snack
     Use this command for meal.json:

```
curl -X POST -H "Content-Type: application/json" -d @payloads/meal.json http://localhost:5128/meals | jq
```

4. Run dotnet run

## Commands for Testing (via curl)

### Fetching all Food Item

```
curl http://localhost:5128/food_items | jq
```

### Saving a New Expense Item from file `payloads/expenseItem.json`

```
curl -X POST -H "Content-Type: application/json" -d @payloads/foodItem.json http://localhost:5128/food_items | jq
```

### Deleting an item

```
curl -X DELETE -H "Accept: application/json" http://localhost:5128/food_items/3 | jq
```
