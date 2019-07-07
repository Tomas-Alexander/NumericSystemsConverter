using System;
using NSConverter;
using NSConverter.DataManager;

namespace NSConverterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var file = new FileDataManager();
                Console.WriteLine("File path (read data):");
                file.EntryFile = Console.ReadLine();

                Console.WriteLine("File path (write data result):");
                file.OutputFile = Console.ReadLine();

                NumericSystems.Convert(file);
                Console.Write("The process has finished");
            }
            catch (Exception ex)
            {
                Console.Write($"An error has occurred: {ex}");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
