
using System.Text;


namespace MoneyApp5
{
    class Program
    {
        // завдання 1 
        static void ConvertCurrency(double hryvnias, double dollarRate, double euroRate,
        out double dollars, out double euros)
        {
            dollars = hryvnias / dollarRate;
            euros = hryvnias / euroRate;
        }

        // завдання 2 
        static void CheckNumber(int number,
          out bool isEven,
          out bool isPositive,
          out bool isPrime)
        {
            isEven = number % 2 == 0;
            isPositive = number > 0;
            isPrime = true;

            if (number < 2)
            {
                isPrime = false;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }
        }

        // завдання 3
        static void BuyProduct(double price, int quantity, double money,
          out double totalCost,
          out double change,
          out bool enoughMoney)
        {
            totalCost = price * quantity;
            enoughMoney = money >= totalCost;

            if (enoughMoney)
            {
                change = money - totalCost;
            }
            else
            {
                change = 0;
            }
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Обмін валют");
                Console.WriteLine("2. Обробка числа");
                Console.WriteLine("3. Магазин");
                Console.WriteLine("0. Вихід");
                Console.Write("Оберіть завдання: ");

                string choice = Console.ReadLine();

                Console.Clear();

                switch (choice)
                {
                    // завдання 1
                    case "1":
                        Console.WriteLine("Обмін валют");
                        Console.WriteLine();

                        Console.Write("Введіть суму в гривнях: ");
                        double hryvnias = double.Parse(Console.ReadLine());

                        Console.Write("Введіть курс долара: ");
                        double dollarRate = double.Parse(Console.ReadLine());

                        Console.Write("Введіть курс євро: ");
                        double euroRate = double.Parse(Console.ReadLine());

                        ConvertCurrency(
                            hryvnias,
                            dollarRate,
                            euroRate,
                            out double dollars,
                            out double euros
                        );

                        Console.WriteLine();
                        Console.WriteLine($"Сума в доларах: {dollars:F2} $");
                        Console.WriteLine($"Сума в євро: {euros:F2} €");

                        break;
                    //завданння  2
                    case "2":
                        Console.WriteLine("Обробка числа ");
                        Console.WriteLine();

                        Console.Write("Введіть ціле число: ");
                        int number = int.Parse(Console.ReadLine());

                        CheckNumber(
                            number,
                            out bool isEven,
                            out bool isPositive,
                            out bool isPrime
                        );

                        Console.WriteLine();
                        Console.WriteLine($"Число парне: {isEven}");
                        Console.WriteLine($"Число додатне: {isPositive}");
                        Console.WriteLine($"Число просте: {isPrime}");

                        break;
                    // завданння  3
                    case "3":
                        Console.WriteLine("Магазин");
                        Console.WriteLine();

                        Console.Write("Введіть ціну товару: ");
                        double price = double.Parse(Console.ReadLine());

                        Console.Write("Введіть кількість товару: ");
                        int quantity = int.Parse(Console.ReadLine());

                        Console.Write("Введіть суму грошей: ");
                        double money = double.Parse(Console.ReadLine());

                        BuyProduct(
                            price,
                            quantity,
                            money,
                            out double totalCost,
                            out double change,
                            out bool enoughMoney
                        );
                        Console.WriteLine();
                        Console.WriteLine($"Загальна вартість: {totalCost:F2} грн");
                        Console.WriteLine($"Грошей достатньо: {enoughMoney}");
                        if (enoughMoney)
                        {
                            Console.WriteLine($"Решта: {change:F2} грн");
                        }
                        else
                        {
                            Console.WriteLine("Грошей недостатньо для покупки.");
                            Console.WriteLine($"Не вистачає: {totalCost - money:F2} грн");
                        }

                        break;
                    // 
                    case "0":
                        Console.WriteLine("Програму завершено.");
                        return;

                    default:
                        Console.WriteLine("Неправильний вибір!");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Натисніть Enter, щоб повернутися до меню...");
                Console.ReadLine();
            }
        }
    }
}
