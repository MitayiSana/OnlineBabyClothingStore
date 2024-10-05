using System;
using System.Collections.Generic;

public class BabyDress
{
    public int Size { get; set; }
    public string Color { get; set; }
    public string Brand { get; set; }
    public double Price { get; set; }
}

public class BabyDressUtility
{
    public static void AddDressToCart(BabyDress dress)
    {
       Program.DressesCart.Add(dress);
    }

    public static bool RemoveDressFromCart(string brand)
    {
        return Program.DressesCart.RemoveAll(dress => dress.Brand == brand) > 0;
    }

    public static double CalculateTotalPrice()
    {
        return Program.DressesCart.Sum(dress => dress.Price);
    }
}

public class Program
{
    public static List<BabyDress> DressesCart { get; set; } = new List<BabyDress>();

    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Add dress to cart");
            Console.WriteLine("2. Remove dress from cart");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the dress size: ");
                    int size = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter the dress color: ");
                    string color = Console.ReadLine();
                    Console.Write("Enter the dress brand: ");
                    string brand = Console.ReadLine();
                    Console.Write("Enter the dress price: ");
                    double price = Convert.ToDouble(Console.ReadLine());

                    BabyDress dress = new BabyDress
                    {
                        Size = size,
                        Color = color,
                        Brand = brand,
                        Price = price
                    };

                    BabyDressUtility.AddDressToCart(dress);
                    Console.WriteLine("Successfully added to the dress cart");
                    break;
                case 2:
                    Console.Write("Enter the dress brand to remove from cart: ");
                    string removeBrand = Console.ReadLine();

                    if (BabyDressUtility.RemoveDressFromCart(removeBrand))
                    {
                        Console.WriteLine("Successfully removed from the cart");
                    }
                    else
                    {
                        Console.WriteLine("Dress not found in the cart");
                    }
                    break;
                case 3:
                    Console.WriteLine("Thank you!");
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

        }
    }
}