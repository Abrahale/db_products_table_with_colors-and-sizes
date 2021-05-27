using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        public void Noise()
        {
            Console.WriteLine("All Vehicles Create noise !!");
        }
        static void Main(string[] args)
        {
            //Uncomment the funcion call below if db is empty and  you want to seed it
            seedDb();
            makeATransaction();
            //int[] arr = new int[] { 5, -4, 11, 0, 18, 22, 67, 51, 6 };
            //int n;

            //n = arr.Length;
            //Console.WriteLine("Original Array Elements :");
            //show_array_elements(arr);
            //shellSort(arr, n);
            //Console.WriteLine("\nSorted Array Elements :");
            //show_array_elements(arr);
            //Console.Read();
        }
        public static void makeATransaction()
        {
            Console.WriteLine("Please scan barcode to ring a sale");
            string barcode = Console.ReadLine();
            using(var context = new AppDbContext())
            {
                var product = context.Products.Where(x => x.Barcode == Convert.ToInt32(barcode)).ToList();
                
                Console.WriteLine(JsonConvert.DeserializeObject(product[0].ColorsAndSizes));
            }
        }
        public static void seedDb()
        {
            using (var dbContext = new AppDbContext())
            {
                Random rand = new Random();
                int randomNum = rand.Next(3);
                Console.WriteLine(randomNum);
                string[] productName = { "Golf shirt", "Nike Air Jordans", "Gucci Jackets" };
                int[] barcodes = { 111111, 222222, 333333 };
                string[] colors = { "White", "Black", "Orange", "Green", "Blue", "Red", "Maroon", "Gold", "Cream White", "Sky Blue", "Yellow" };
                string[] sizes = { "XS", "S", "M", "L", "XL", "XXL" };

                for (int i = 0; i < productName.Length; i++)
                {
                    List<ColorsAndSizes> colorsAndSizes = new List<ColorsAndSizes>();
                    int qty = 0;
                    int colorNum = rand.Next(colors.Length);
                    for (var c=0;c<colorNum;c++)
                    {
                        ColorsAndSizes cas = new ColorsAndSizes();
                        cas.ColorName = colors[c];
                        cas.ColorProperty = colors[c];
                        List<Sizes> sizesL = new List<Sizes>();
                        foreach (var size in sizes)
                        {
                            Sizes siz = new Sizes();
                            siz.Size = size;
                            siz.qty = rand.Next(50);
                            qty += siz.qty;
                            sizesL.Add(siz);
                        }

                        cas.Sizes = sizesL;
                        colorsAndSizes.Add(cas);
                    }
                    Product pro = new Product
                    {
                        AddedDate = DateTime.Now,
                        Barcode = barcodes[i],
                        ProductName = productName[i],
                        Qty = qty,
                        SellingPrice = 1250.00,
                        StockPrice = 1000,
                        ColorsAndSizes = JsonConvert.SerializeObject(colorsAndSizes)
                    };
                    dbContext.Products.Add(pro);

                }
                dbContext.SaveChanges();
            }
        }
        static void shellSort(int[] arr, int array_size)
        {
            int i, j, inc, temp;
            inc = 3;
            while (inc > 0)
            {
                for (i = 0; i < array_size; i++)
                {
                    j = i;
                    temp = arr[i];
                    while ((j >= inc) && (arr[j - inc] > temp))
                    {
                        Console.WriteLine($"This are the values of J and Temp {j} <fi-> {temp}");
                        arr[j] = arr[j - inc];
                        j = j - inc;
                    }
                    arr[j] = temp;
                    Console.WriteLine($"The iteration {j}");
                    show_array_elements(arr);
                }
                if (inc / 2 != 0)
                    inc = inc / 2;
                else if (inc == 1)
                    inc = 0;
                else
                    inc = 1;
            }
        }

        static void show_array_elements(int[] arr)
        {
            foreach (var element in arr)
            {
                Console.Write(element + " ");
            }
            Console.Write("\n");

        }
    }
}
