using Wallet;
using System.Text;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;

using (mainContext db = new mainContext())
{
  
    var wallets = db.WalletDbs.ToList();   // получаем объекты из бд и выводим на консоль
    Console.WriteLine("Список объектов:");
    foreach (WalletDb w in wallets)
    {
        Console.WriteLine($"{w.Id}.{w.Name} - Баланс {w.Ballance} руб.");
    }
    Console.WriteLine("Сохранить в json? y/n");

    if(Console.ReadKey().Key == ConsoleKey.Y)     //сохраняем в json
    {
        string fileName = "data.json";
        using FileStream createStream = File.Create("E:\\\\\\VSProjects\\Wallet\\"+fileName);
       
            var options = new JsonSerializerOptions //опции json
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true 
            };

            string jsonString = JsonSerializer.Serialize(wallets, options);
            File.WriteAllText(fileName, jsonString);

        Console.WriteLine("\n"+"Сохранено!");
    }
    else 
    {
        Console.ReadKey();
    }

}

