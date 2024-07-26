using System;
using System.Collections.Generic;
using System.Linq;

// Поставяме допълнителните / помощните класове
public class Item
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Item(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}

public class Box
{
    public string SerialNumber { get; set; }
    public Item Item { get; set; }
    public int ItemQuantity { get; set; }
    public decimal PriceForBox 
    { 
        get
        {
            return ItemQuantity * Item.Price;
        }
    }

    public Box(string serialNumber, Item item, int itemQuantity)
    {
        SerialNumber = serialNumber;
        Item = item;
        ItemQuantity = itemQuantity;
    }
}

// Поставяме логиката за изпълнение на задачата
public class Program
{
    public static void Main(string[] args)
    {
        // Ето тук поставяме логиката на изпълнение на задачата
        List<Box> boxes = new List<Box>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "end")
            {
                break;
            }

            string[] boxData = input.Split(' ');
            string serialNumber = boxData[0];
            string itemName = boxData[1];
            int itemQuantity = int.Parse(boxData[2]);
            decimal itemPrice = decimal.Parse(boxData[3]);

            Item item = new Item(itemName, itemPrice);
            Box box = new Box(serialNumber, item, itemQuantity);
            boxes.Add(box);
        }

        // Сортираме кутиите по цена на кутията в низходящ ред
        var sortedBoxes = boxes.OrderByDescending(b => b.PriceForBox).ToList();

        foreach (Box box in sortedBoxes)
        {
            Console.WriteLine($"{box.SerialNumber}");
            Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}");
            Console.WriteLine($"-- ${box.PriceForBox:F2}");
        }
    }
}
