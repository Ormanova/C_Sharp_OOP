using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;
        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
            item = new Item("Dimitrichko", "1234");
        }
        //test AddItem 
        [Test]
        public void WhenCellDoesNotExistThrowException()
        {
            ////if (!this.vaultCells.ContainsKey(cell))
            //{
            //    throw new ArgumentException("Cell doesn't exists!");
            //}
            Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("nqma takuv", item);
            }, "Cell doesn't exists!");
        }
        [Test]
        public void WhenCellExistButIsTakenThrowException()
        {
            //if (this.vaultCells[cell] != null)
            //{
            //    throw new ArgumentException("Cell is already taken!");
            //}
            Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("A2", item);
                vault.AddItem("A2", new Item("Pesho", "3"));
            }, "Cell is already taken!");

        }
        [Test]
        public void WhenItemAlreadyExistThrowException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                vault.AddItem("A2", item);
                vault.AddItem("A3", item);
            }, "Item is already in cell!!");
        }
        [Test]
        public void WhenItemIsAddedSuccessfulyReturnMessage()
        {
            string result = vault.AddItem("A2", item);

            Assert.AreEqual(result, $"Item:{item.ItemId} saved successfully!");
        }
        [Test]
        public void WhenRemoveItemAndCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("nqma takuv", item);
            }, "Cell doesn't exists!");
        }
        [Test]
        public void WhenRemoveItemAndSuchItemDoesNotExist()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("A3", new Item("Pesho", "2"));
            }, "Item in that cell doesn't exists!");
        }

    }
}