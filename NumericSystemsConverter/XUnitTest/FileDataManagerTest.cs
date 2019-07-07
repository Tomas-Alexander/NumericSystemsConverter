using NSConverter;
using NSConverter.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTest
{
    public class FileDataManagerTest
    {

        [Fact]
        public void File_Data_NumericSystem_IsNotInvalid_Throws_ArgumentException()
        {
            //arrage
            var dataManager = new FileDataManager
            {
                EntryFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\files\dataTestIncorrect.txt",
                OutputFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\files\resultTest.txt"
            };

            //act
            Action actual = () => dataManager.GetData().FirstOrDefault();

            //assert
            Assert.Throws<ArgumentException>(actual);
        }

        [Fact]
        public void Correct_File_Data_Returns_Object()
        {
            //arrage
            var dataManager = new FileDataManager
            {
                EntryFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\files\dataTest.txt",
                OutputFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\files\resultTest.txt"
            };

            //act
            var actual = dataManager.GetData().FirstOrDefault();

            //assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void ProcessData_Create_New_File_With_Data()
        {
            //arrage
            var dataManager = new FileDataManager
            {
                OutputFile = AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\files\resultTest.txt"
            };

            //act
            dataManager.ProcessData(new DataStruct
            {
                From = NumericSystem.Decimal,
                To = NumericSystem.Hexadecimal,
                Value = "10",
                Result = "a"
            });

            var first = System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + @"..\..\..\files\resultTest.txt")[0];

            //assert
            Assert.Equal("10|10|16|a", first);
        }
    }
}
