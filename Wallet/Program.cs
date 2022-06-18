using Wallet;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;

using (mainContext db = new mainContext())
{
  
    var wallets = db.WalletDbs.ToList();
    var operations = db.Operations.ToList(); // получаем объекты из бд и выводим на консоль
    Console.WriteLine("Нажмите Enter чтобы продолжить");
    if (Console.ReadKey().Key == ConsoleKey.Enter)
    { 
        Main(); 
    }
    
    void Main()
    {
        Console.WriteLine("Список объектов:");
        foreach (WalletDb w in wallets)
        {
            Console.WriteLine($"{w.Id}.{w.Name} - Баланс {w.Ballance} руб.");
        }
        Console.WriteLine("Сохранить в json или показать историю? y/J. Для выхода нажмите N");
        if (Console.ReadKey().Key == ConsoleKey.Y)     //сохраняем в json
        {
            SaveMain();
        }
        if (Console.ReadKey().Key == ConsoleKey.N)     //сохраняем в json
        {
            Environment.Exit(0);
        }
        if (Console.ReadKey().Key == ConsoleKey.J)
        {
            Console.Clear();
            Operations();
        }
    }
    
    void SaveMain() 
    {
        string fileName = "data.json";
        using FileStream createStream = File.Create("E:\\\\\\VSProjects\\Wallet\\" + fileName);

        var options = new JsonSerializerOptions //опции json
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };

        string jsonString = JsonSerializer.Serialize(wallets, options);
        File.WriteAllText(fileName, jsonString);

        Console.WriteLine("\n" + "Сохранено!");
    }

    void Operations()
    {
        foreach (WalletDb w in wallets)
        {
            Console.WriteLine($"Список операций {w.Name}:");
            foreach (Operation o in operations)
            {
                if (o.UserId == w.Id)
                {
                    Console.WriteLine($"   - Дата: {o.Data}  Тип операций: {o.Type}  Сумма: {o.Summ}.");
                }
                
            }
        }
        Console.WriteLine("Сохранить в json? y/n");
        if (Console.ReadKey().Key == ConsoleKey.Y)     //сохраняем в json
        {
            SaveOperations();
        }
        if (Console.ReadKey().Key == ConsoleKey.N)
        {
            Environment.Exit(0);
        }
    }

    void SaveOperations()
    {
        string fileName = "dataOperations.json";
        using FileStream createStream = File.Create("E:\\\\\\VSProjects\\Wallet\\" + fileName);

        var options = new JsonSerializerOptions //опции json
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };

        string jsonString = JsonSerializer.Serialize(operations, options);
        File.WriteAllText(fileName, jsonString);

        Console.WriteLine("\n" + "Сохранено!");
    }

}

