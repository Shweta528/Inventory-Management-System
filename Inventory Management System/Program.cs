// See https://aka.ms/new-console-template for more information
using System;

public class InventoryItems
{
    // Properties to store the details of an inventory item
    public string itemName { get; set; }
    public int itemID { get; set; }
    public double itemPrice { get; set; }
    public int itemQuantity { get; set; }

    // Constructor to initialize the properties of the inventory item
    public InventoryItems(string name, int id, double price, int quantity)
    {
        itemName = name;
        itemID = id;
        itemPrice = price;
        itemQuantity = quantity;
    }

    // Methods to update the price of the items
    public void UpdatePrice(double newPrice)
    {
        itemPrice = newPrice;
    }

    // Method to restock the item by adding to its quantity
    public void RestockItem(int additionalQuantity)
    {
        itemQuantity += additionalQuantity;
    }

    // Method to sell a specified quantity of the item
    public void SellItem(int quantitySold)
    {
        if (itemQuantity >= quantitySold)
        {
            itemQuantity -= quantitySold;     // Decrease the quantity if enough stock is available
        }
        else
        {
            Console.WriteLine("Not enough stock to sell.");    // Print the message if stock is insufficient
        }
    }

    // Method to check if the item is currently in stock
    public bool IsInStock()
    {
        return itemQuantity > 0; // Return true if quantity is greater than 0
    }

    // Method to print the details of the item
    public void PrintDetails()
    {
        Console.WriteLine($"Name: {itemName}, ID: {itemID}, Price: {itemPrice}, Quantity: {itemQuantity}");
    }
}

public class Shweta_Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Prompt the user to enter details of the item
            Console.Write("Enter item name: ");
            string itemName = Console.ReadLine();

            Console.Write("Enter item ID: ");
            int itemID = int.Parse(Console.ReadLine());

            Console.Write("Enter item price: ");
            double itemPrice = double.Parse(Console.ReadLine());

            Console.Write("Enter item quantity: ");
            int itemQuantity = int.Parse(Console.ReadLine());

            // Create an instance of InventoryItem with the user-provided details
            InventoryItems item = new InventoryItems(itemName, itemID, itemPrice, itemQuantity);

            // Loop to display a menu of options until the user chooses to exit
            while (true)
            {
                try
                {
                    // Display the menu of options
                    Console.WriteLine("\nChoose an option:");
                    Console.WriteLine("1. Print item details");
                    Console.WriteLine("2. Update item price");
                    Console.WriteLine("3. Restock item");
                    Console.WriteLine("4. Sell item");
                    Console.WriteLine("5. Check if item is in stock");
                    Console.WriteLine("6. Exit");
                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    // Execute the chosen option
                    switch (choice)
                    {
                        case 1:
                            // Print the details of the item
                            item.PrintDetails();
                            break;

                        case 2:
                            // Update the price of the item
                            Console.Write("Enter new price: ");
                            double newPrice = double.Parse(Console.ReadLine());
                            item.UpdatePrice(newPrice);
                            break;

                        case 3:
                            // Restock the item by adding to its quantity
                            Console.Write("Enter quantity to restock: ");
                            int additionalQuantity = int.Parse(Console.ReadLine());
                            item.RestockItem(additionalQuantity);
                            break;

                        case 4:
                            // Sell a specified quantity of the item
                            Console.Write("Enter quantity to sell: ");
                            int quantitySold = int.Parse(Console.ReadLine());
                            item.SellItem(quantitySold);
                            break;

                        case 5:
                            // Check if the item is in stock and display the result
                            Console.WriteLine($"Is item in stock? {item.IsInStock()}");
                            break;

                        case 6:
                            // Exit the program
                            return;

                        default:
                            // Handles the invalid choices
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An error occurred: {e.Message}");
                }
            }
        }
        catch (FormatException e)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
    }
}
