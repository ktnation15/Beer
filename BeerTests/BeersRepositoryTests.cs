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
    public class BeersRepositoryTests
    {
        [TestMethod()]
        public void GetBeersTest()
        {            
                // Arrange
                var repo = new BeersRepository();

                // Act
                var result = repo.GetBeers();

                // Assert
                Assert.AreEqual(5, result.Count); // Antager at der oprindeligt er 5 øl
        }

        [TestMethod()]
        public void GetByIdTest()
        {
                // Arrange
                var repo = new BeersRepository();
                var expectedBeerId = 1;

                // Act
                var result = repo.GetById(expectedBeerId);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(expectedBeerId, result.Id);
        }

        [TestMethod()]
        public void AddBeerTest()
        {
                // Arrange
                var repo = new BeersRepository();
                var newBeer = new Beer { Name = "New Test Beer", Abv = 5.5 };

                // Act
                var result = repo.AddBeer(newBeer);
                var allBeers = repo.GetBeers();

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(6, allBeers.Count); // Antager at der oprindeligt var 5 øl
                Assert.IsTrue(allBeers.Any(b => b.Name == "New Test Beer"));
        }

        [TestMethod()]
        public void DeleteBeerTest()
        {
                // Arrange
                var repo = new BeersRepository();
                var beerIdToDelete = 1;

                // Act
                var result = repo.DeleteBeer(beerIdToDelete);
                var allBeers = repo.GetBeers();

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(4, allBeers.Count); // Antager at der oprindeligt var 5 øl
                Assert.IsFalse(allBeers.Any(b => b.Id == beerIdToDelete));
        }

        [TestMethod()]
        public void UpdateBeersTest()
        {
                // Arrange
                var repo = new BeersRepository();
                var beerIdToUpdate = 1;
                var updatedData = new Beer { Name = "Updated Name", Abv = 6.5 };

                // Act
                var result = repo.UpdateBeers(beerIdToUpdate, updatedData);
                var updatedBeer = repo.GetById(beerIdToUpdate);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual("Updated Name", updatedBeer.Name);
                Assert.AreEqual(6.5, updatedBeer.Abv);
        }
    }
}