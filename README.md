# Expense Items API Demo C# ASP Backend

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
