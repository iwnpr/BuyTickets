using System;
using BuyTickets.Domains;
using BuyTickets.Storages;
using BuyTickets.StoragesInMemory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuyTicketsTests
{
    [TestClass]
    public class BuyerStorageTests
    {
        //arange
        //act
        //assert

        private BuyerInMemoryStorage _buyerStorage;

        [TestInitialize]
        public void BuyerStorageTestsInitialize()
        {
            _buyerStorage = new BuyerInMemoryStorage();
        }

        [TestMethod]
        [DataRow("Ivan Ivanov")]
        [DataRow("John")]
        public void TryAddBuyer(string name)
        {
            //arange
            _buyerStorage.AddBuyer(name);

            //act

            var actualBuyers = _buyerStorage.GetAllBuyers();
            var expectedBuyersCount = 1;
            var expextedName = name;

            //assert

            Assert.AreEqual(actualBuyers.Count, expectedBuyersCount);
            Assert.AreEqual(actualBuyers[0].Name, expextedName);

        }

        [TestMethod]
        [DataRow("D9h89hdh")]
        [DataRow("A")]
        public void TryDeleteBuyer(string name)
        {
            //arange
            var buyer = _buyerStorage.AddBuyer(name);
            var expextedBuyerCount = 0;
            //act
            _buyerStorage.DeleteBuyer(buyer);
            var buyerCount = _buyerStorage.GetAllBuyers();
            //assert
            Assert.AreEqual(expextedBuyerCount, buyerCount.Count);
        }

        [TestMethod]
        public void AddUserWithEmptyName_ThrowExeption()
        {
            //arange
            var name = String.Empty;

            //act
            var buyer = Assert.ThrowsException<ArgumentException>(() => _buyerStorage.AddBuyer(name));

            //assert
            var expectedExeption = "The string can't be left empty, null or consist of only whitespaces.";

            Assert.AreEqual(expectedExeption, buyer.Message);
            
        }
        


    }
}
