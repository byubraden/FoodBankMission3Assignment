namespace FoodBankMission3Assignment;

public class FoodItem
{
    public string itemName = string.Empty;
    public string category = string.Empty;
    public int quantity = 0;
    public DateTime expirationDate = DateTime.Today;

    public FoodItem(string itemName, string category, int quantity, DateTime expirationDate)
    {
        this.itemName = itemName;
        this.category = category;
        this.quantity = quantity;
        this.expirationDate = expirationDate;
    }
    
}