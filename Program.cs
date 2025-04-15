class Program
{
    static void Main(string[] args)
    {
        BankTransfer_Config config = new BankTransfer_Config();
        if (config.lang == "en")
        {
            Console.WriteLine("Please enter the amount to transfer:");
        }
        else if (config.lang == "id")
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
        }
        string input = Console.ReadLine();

        if (config.lang == "en")
        {
            if (int.TryParse(input, out int amount))
            {
                if (amount < config.threshold)
                {
                    Console.WriteLine($"The fee is: {config.low_fee} with Total of " + (amount + config.low_fee));
                }
                else
                {
                    Console.WriteLine($"The fee is: {config.high_fee} With Total of " + (amount + config.high_fee));
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            Console.WriteLine("Select transfer method:");
            for (int i = 0; i < config.methods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {config.methods[i]}");
            }
            string methodInput = Console.ReadLine();
            Console.WriteLine($"You selected: {config.methods[int.Parse(methodInput) - 1]}");
            Console.WriteLine($"Please type {config.en} to confirm the transaction ");
            string confirm = Console.ReadLine();
            if (confirm == config.en)
            {
                Console.WriteLine("The transfer is completed");
            }
            else
            {
                Console.WriteLine("Transfer is cancelled");
            }
        } else if (config.lang == "id")
        {
            if (int.TryParse(input, out int amount))
            {
                if (amount < config.threshold)
                {
                    Console.WriteLine($"Biaya transfer adalah {config.low_fee} Dengan Total " + (amount + config.low_fee));
                }
                else
                {
                    Console.WriteLine($"Biaya transfer adalah {config.high_fee} Dengan Total " + (amount + config.high_fee));
                }
            }
            else
            {
                Console.WriteLine("Input tidak valid. Silakan masukkan angka yang valid.");
            }
            Console.WriteLine("Pilih metode transfer:");
            for (int i = 0; i < config.methods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {config.methods[i]}");
            }
            string methodInput = Console.ReadLine();
            Console.WriteLine($"Anda memilih: {config.methods[int.Parse(methodInput) - 1]}");
            Console.WriteLine($"Ketik {config.id} untuk mengkonfirmasi transaksi ");
            string confirm = Console.ReadLine();
            if (confirm == config.id)
            {
                Console.WriteLine("Proses transfer berhasil");
            }
            else
            {
                Console.WriteLine("Transfer dibatalkan");
            }
        }
    }
}