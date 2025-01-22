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
            new FoodItem("Apple", "Fruit", 10, DateTime.Today),
            new FoodItem("Carrot", "Vegetable", 5, DateTime.Today),
            new FoodItem("Banana", "Fruit", 7, DateTime.Today)
        };
        
        
        Console.WriteLine("Welcome to the Food Bank management application!");
        // Initalize the exit variable that keeps track of if the user has requested an exit
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine(
                "\n========== Menu ==========" + 
                "\n What would you like to do? " +
                "\n\n   To add a new food item type \"add\"" +
                "\n   To delete a food item type \"delete\"" +
                "\n   To see a list of all food items type \"list\"" +
                "\n   To exit type \"exit\""
                + "\n==========================");
            Console.Write("Enter your choice: ");
            string whatToDo = Console.ReadLine().ToLower();

            if (whatToDo == "add")
            {
                Console.Write("Enter food item name: ");
                string itemName = Console.ReadLine();
                Console.Write("Enter food item category: ");
                string itemCategory = Console.ReadLine();
                Console.Write("Enter food item quantity: ");
                int itemQuantity = int.Parse(Console.ReadLine());
                Console.Write("Enter food item experation date (MM/dd/yyyy): ");
                string input = Console.ReadLine();

                // Attempt to parse the date
                if (DateTime.TryParse(input, out DateTime parsedDate))
                {
                    AddFoodItem(new FoodItem(itemName, itemCategory, itemQuantity, parsedDate));
                    Console.WriteLine("Food Item added successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter the date in MM/dd/yyyy format.");
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
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }

        void AddFoodItem(FoodItem item)
        {
            foodList.Add(item);
        }

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

        void ListFoodItems()
        {
            Console.WriteLine("\nFood Items:");
            foreach (FoodItem item in foodList)
            {
                Console.WriteLine($"Name: {item.itemName}, Category: {item.category}, Quantity: {item.quantity}, Expiration Date: {item.expirationDate}");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        
        
        
    }
}