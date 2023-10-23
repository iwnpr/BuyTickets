using System;
using BuyTickets.Domains;
using BuyTickets.Storages;
using BuyTickets.Facades;
using BuyTickets.StoragesInMemory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuyTicketsTests
{
    [TestClass]
    public class BuyerFacadeTests
    {
        //arange
        //act
        //assert

        private BuyerInMemoryStorage _buyerStorage;
        private BuyerFacade _buyerFacade;

        [TestInitialize]
        public void BuyerFacadeTestsInitialize()
        {
            _buyerStorage = new BuyerInMemoryStorage();
            _buyerFacade = new BuyerFacade(_buyerStorage);
        }

        [TestMethod]
        [DataRow("Ivan Ivanov")]
        [DataRow("John")]
        public void TryAddBuyer(string name)
        {
            //arrange
            var buyerId = _buyerFacade.AddBuyer(name);

            //act
            var expectedCount = 1;
            var expectedName = name;
            var expectedBuyerId = buyerId;
            var actualBuyers = _buyerStorage.GetAllBuyers();

            //assert

            Assert.AreEqual(expectedName, actualBuyers[0].Name);
            Assert.AreEqual(expectedBuyerId, actualBuyers[0].Id);
            Assert.AreEqual(expectedCount, actualBuyers.Count);
            
        }

        [TestMethod]
        public void TryDeleteBuyer(string name)
        {

            //arrange
            var buyerId = _buyerFacade.AddBuyer(name);

            //act
            _buyerFacade.DeleteBuyer(buyerId);

            //validation
            var expectedBuyerCount = 0;
            var buyers = _buyerStorage.GetAllBuyers();

            Assert.AreEqual(expectedBuyerCount, buyers.Count);
        }

        [TestMethod]
        public void AddBuyerWithEmptyName_ThrowExeption()
        {
            //prepare
            var name = string.Empty;

            //act
            var buyer = Assert.ThrowsException<ArgumentException>(() => _buyerFacade.AddBuyer(name));

            //validation
            string expectedException = "The string can't be left empty, null or consist of only whitespaces.";
            Assert.AreEqual(buyer.Message, expectedException);
        }

        [TestMethod]
        public void AddUserWithSpaceName_ThrowExeption()
        {
            //prepare
            var name = string.Empty;

            //act
            var buyer = Assert.ThrowsException<ArgumentException>(() => _buyerFacade.AddBuyer(name));

            //validation
            string expectedException = "The string can't be left empty, null or consist of only whitespaces.";
            Assert.AreEqual(buyer.Message, expectedException);
        }


    }
}
