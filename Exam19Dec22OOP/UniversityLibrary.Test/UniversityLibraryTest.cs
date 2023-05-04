namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class UniversityLibraryTest
    {
        private TextBook textBook;
        private string title = "1984";
        private string author = "George Orwel";
        private string category = "Disthopy";

        private UniversityLibrary lib;
        [SetUp]
        public void Setup()
        {
            textBook = new TextBook(title,author,category);
            lib = new UniversityLibrary();
        }

        [Test]
        public void ConstructorSetValues()
        {
            lib.AddTextBookToLibrary(textBook);
            Assert.AreEqual(textBook.Category, category);
            Assert.AreEqual(textBook.Author, author);
            Assert.AreEqual(textBook.Title, title);
        }

        [Test]
        public void UniLibraryIsEmptyWhenNew()
        {
            Assert.AreEqual(lib.Catalogue.Count, 0);
            
        }
        [Test]
        public void AddTextBook()
        {
            string result = lib.AddTextBookToLibrary(textBook);
            Assert.AreEqual(textBook.InventoryNumber, 1);
            Assert.AreEqual(lib.Catalogue.Count, 1);
            Assert.AreEqual(lib.Catalogue[0].Title, title);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Book: 1984 - 1");
            sb.AppendLine($"Category: Disthopy");
            sb.AppendLine($"Author: George Orwel");
            var expectedResult = sb.ToString().TrimEnd();
            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        public void LoanTextbookTests()
        {
            lib.AddTextBookToLibrary(textBook); 
            Assert.AreEqual(textBook.Holder, null);

            string result = lib.LoanTextBook(1, "Pesho");

            Assert.AreEqual(textBook.Holder, "Pesho");
            Assert.AreEqual(result, $"{textBook.Title} loaned to Pesho.");

            result = lib.LoanTextBook(1, "Pesho");
            Assert.AreEqual(result, $"Pesho still hasn't returned {textBook.Title}!");
        }
        [Test]
        public void ReturnTextBookTests()
        {
            lib.AddTextBookToLibrary(textBook);
            string result = lib.LoanTextBook(1, "Pesho");
            result = lib.ReturnTextBook(1);
            Assert.AreEqual($"{textBook.Title} is returned to the library.", result);
            Assert.AreEqual("", textBook.Holder);
        }
    }
}