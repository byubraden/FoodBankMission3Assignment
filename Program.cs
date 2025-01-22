// See https://aka.ms/new-console-template for more information

// Braden Stevens
// Section 4

using FoodBankMission3Assignment;

internal class Program
{
    public static void Main(string[] args)
    {
        List<FoodItem> foodList = new List<FoodItem>
        {
            // new FoodItem("Apple", "Fruit", 10, DateTime.Today),
            // new FoodItem("Carrot", "Vegetable", 5, DateTime.Today),
            // new FoodItem("Banana", "Fruit", 7, DateTime.Today)
        };
        
        
        Console.WriteLine("Welcome to the Food Bank management application!");
        // Initalize the exit variable that keeps track of if the user has requested an exit
        bool exit = false;

        // Create the while loop to repeat the menu
        while (!exit)
        {
            // Print out the menu
            Console.Clear();
            Console.WriteLine(
                "\n========== Menu ==========" + 
                "\n What would you like to do? " +
                "\n\n   To add a new food item type \"add\"" +
                "\n   To delete a food item type \"delete\"" +
                "\n   To see a list of all food items type \"list\"" +
                "\n   To exit type \"exit\""
                + "\n\n==========================");
            
            // Gather the users choice
            Console.Write("Enter your choice: ");
            string whatToDo = Console.ReadLine().ToLower();

            // Determine what to do based off the response
            if (whatToDo == "add")
            {
                Console.Write("Enter food item name: ");
                string itemName = Console.ReadLine();

                // Check if the item already exists in the list
                if (foodList.Any(item => item.itemName.Equals(itemName, StringComparison.OrdinalIgnoreCase)))
                {
                    // Error handling so that multiple items of the same name can't be entered
                    Console.WriteLine("This item already exists in the food list. Cannot add duplicates.");
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.Write("Enter food item category: ");
                    string itemCategory = Console.ReadLine();

                    Console.Write("Enter food item quantity: ");
                    
                    // Error handling if the user inputs a negative number
                    if (int.TryParse(Console.ReadLine(), out int itemQuantity) && itemQuantity >= 0)
                    {
                        Console.Write("Enter food item expiration date (MM/dd/yyyy): ");
                        string input = Console.ReadLine();

                        // Attempt to parse the date
                        if (DateTime.TryParse(input, out DateTime parsedDate))
                        {
                            foodList.Add(new FoodItem(itemName, itemCategory, itemQuantity, parsedDate));
                            Console.WriteLine("Food Item added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid date format. Please enter the date in MM/dd/yyyy format.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity. Please enter a non-negative number.");
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
            else if (whatToDo == "delete")
            {
                ListFoodItems();
                Console.Write("Enter food item name you would like to delete: ");
                string itemToDelete = Console.ReadLine();
                DeleteFoodItem(itemNameToFind: itemToDelete);
                ListFoodItems();
            }
            else if (whatToDo == "list")
            {
                ListFoodItems();
            }
            else if (whatToDo == "exit")
            {
                exit = true;
            }
            else
            {
                // Error handling for the user entering a valid option
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
        // Define add food item logic
        void AddFoodItem(FoodItem item)
        {
            foodList.Add(item);
        }

        // Define delete food item logic
        void DeleteFoodItem(string itemNameToFind)
        {
            itemNameToFind = itemNameToFind.ToLower();
            FoodItem foundItem = foodList.Find(item => item.itemName.ToLower() == itemNameToFind);
            if (foundItem != null)
            {
                foodList.Remove(foundItem);
                Console.WriteLine("Food Item deleted successfully!");
            }
            else
            {
                Console.WriteLine("Item not found!");
            }
        }
        
        // Define list food item logic
        void ListFoodItems()
        {
            Console.WriteLine("\nFood Items:");
            foreach (FoodItem item in foodList)
            {
                Console.WriteLine($"Name: {item.itemName}, Category: {item.category}, Quantity: {item.quantity}, Expiration Date: {item.expirationDate.ToShortDateString()}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        
    }
}