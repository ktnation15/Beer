using Microsoft.VisualStudio.TestTools.UnitTesting;
using Beer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer.Tests
{
    [TestClass()]
    public class BeerTests
    {
        [TestMethod()]
        public void ToStringTest()
        {

        }
        [TestMethod()]
        public void ValidateNameTest()
        {
            Beer beer = new()
            {
                Id = 1,
                Name = "Carlsberg",
                Abv = 65
            };
            beer.ValidateName();

            Beer beerNullName = new()
            {
                Id = 1,
                Name = "",
                Abv = 65
            };
            Assert.ThrowsException<ArgumentException>(
                () => beerNullName.ValidateName());
        }
        [TestMethod()]
        public void ValidateAbvTest()
        {
            Beer BeerAbvLow = new()
            {
                Id = 1,
                Name = "Carlsberg",
                Abv = -1
            };
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () =>  BeerAbvLow.ValidateAbv());

            Beer beerInRange = new()
            {
                Id = 1,
                Name = "Carlsberg",
                Abv = 36
            };
            beerInRange.ValidateAbv();
        }
    }
}