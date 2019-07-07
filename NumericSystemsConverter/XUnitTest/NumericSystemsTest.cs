using Moq;
using NSConverter;
using NSConverter.DataManager;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTest
{
    public class NumericSystemsTest
    {
        //IDataManager
        //FileManager
        //Enum -> NumericSystem

        /* TODO: Investigar Radix
         Pruebas ->
            Metodo -> Valor, Unidad de entrada, Unidad de salida
         Una prueba para cada tipo de conversion
         Prueba para tipos invalidos -> El tipo de excepcion que generara
         
         */

        [Fact]
        public void NotFound_Data_Throws_ArgumentNullException()
        {
            //arrage
            var dataManager = new Mock<IDataManager>();
            dataManager.Setup(x => x.GetData()).Returns<IEnumerable<DataStruct>>(null);

            //act
            Action actual = () => NumericSystems.Convert(dataManager.Object);

            //assert
            Assert.Throws<ArgumentNullException>(actual);
        }


        [Theory]
        [InlineData("10", NumericSystem.Decimal, NumericSystem.Hexadecimal, "a")]
        [InlineData("a", NumericSystem.Hexadecimal, NumericSystem.Decimal, "10")]
        [InlineData("10", NumericSystem.Octal, NumericSystem.Binary, "1000")]
        public void NumericSystem_Converts_To_Another(string value, NumericSystem from, NumericSystem to, string expected)
        {
            //arrage
            DataStruct data = null;

            IEnumerable<DataStruct> dataList = new List<DataStruct>
            {
                new DataStruct
                {
                    Value = value,
                    From = from,
                    To = to
                }
            };

            var dataManager = new Mock<IDataManager>();
            dataManager.Setup(x => x.GetData()).Returns(dataList);
            dataManager.Setup(x => x.ProcessData(It.IsAny<DataStruct>())).Callback<DataStruct>(x => data = x);

            //act
            NumericSystems.Convert(dataManager.Object);

            //assert
            Assert.Equal(expected, data.Result);
        }

    }
}
