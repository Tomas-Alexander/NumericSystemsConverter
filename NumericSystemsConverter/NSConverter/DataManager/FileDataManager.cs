using System;
using System.Collections.Generic;

namespace NSConverter.DataManager
{
    public class FileDataManager: IDataManager
    {
        public string EntryFile { get; set; }
        public string OutputFile { get; set; }
        public string Separator { get; set; } = "|";

        public IEnumerable<DataStruct> GetData()
        {
           
            int lineNumber= 1;
            System.IO.File.Delete(OutputFile);
            foreach (var line in System.IO.File.ReadAllLines(EntryFile))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var columns = line.Split(Separator);
                    var item = new DataStruct
                    {
                        Value = columns[0].Trim(),
                        From = Enum.Parse<NumericSystem>(columns[1].Trim()),
                        To = Enum.Parse<NumericSystem>(columns[2].Trim())
                    };

                    if (!Enum.IsDefined(typeof(NumericSystem), item.From))
                        throw new ArgumentException($"From (Invalid type): {columns[1]}. at line: {lineNumber}");

                    if (!Enum.IsDefined(typeof(NumericSystem), item.To))
                        throw new ArgumentException($"To (Invalid type): {columns[2]}. at line: {lineNumber}");

                    yield return item;
                }
                lineNumber++;
            }
        }

        public void ProcessData(DataStruct data)
        {
            System.IO.File.AppendAllText(OutputFile, $"{data.Value}{Separator}{(int)data.From}{Separator}{(int)data.To}{Separator}{data.Result}\n");
        }

    }
}
