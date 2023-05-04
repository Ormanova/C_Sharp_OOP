namespace Book.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;


    [TestFixture]
    public class Tests
    {
        private Book defaultBook;
        [SetUp]     
        public void SetUp()
        {
            this.defaultBook = new Book("Harry Potter", "J.K.Rowling");
        }
        // Първо тестваме конструктура
        [Test]
        public void ConstructorShouldInitializeBookNameCorrectly()
        {
            string expectedBookName = "Harry Potter";
            Book book = new Book(expectedBookName, "J.K.Rowling");

            string actualBookName = book.BookName;
            Assert.AreEqual(expectedBookName, actualBookName);
        }

        [Test]
        public void ConstructorShouldInitializeAuthorNameCorrectly()
        {
            string expectedAuthorName = "J.K.Rowling";
            Book book = new Book("Harry Potter", expectedAuthorName);
            string actualName = book.Author;
            Assert.AreEqual(expectedAuthorName, actualName);
        }

        [Test] //проверка за речника в конструктура
        public void ConstructorShouldInitializeFootNoteDictionary() // Reflection
        {
            Type bookType = this.defaultBook.GetType();
            FieldInfo dictionaryFieldInfo = bookType
                .GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).FirstOrDefault(fi => fi.Name == "footnote");
            object fieldValue = dictionaryFieldInfo.GetValue(this.defaultBook);
            Assert.IsNotNull(fieldValue);
        }
        [Test]
        public void CountShouldReturnZeroWhenNoFootNotes()
        {
            int expectedCount = 0;
            int actualCount = 0;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CountShouldReturnZeroWhenNoFootnotesAdded()
        {
            int expectedCount = 0;
            int actualCount = this.defaultBook.FootnoteCount;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void CountShouldReturnCorrectWhenFootnotesAdded()
        {
            int expectedCount = 2;
            for (int i = 0; i < expectedCount; i++)
            {
                defaultBook.AddFootnote(i, i.ToString());
            }
            int actualCount = defaultBook.FootnoteCount;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [TestCase("Real name")]
        [TestCase("1")]
        [TestCase("   ")]
        public void BookNameShouldSetCorrectValues(string bookName)
        {
            Book book = new Book(bookName, "Author");

            string expectedBookName = bookName;
            string actualBookName = book.BookName;
            Assert.AreEqual(expectedBookName, actualBookName);
        }
        [TestCase(null)]
        [TestCase("")]
        public void BookNameShouldThrowExceptionWhenBookNameNullOrEmpty(string bookName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book(bookName, "Author");
            }, "Invalid BookName!");
        }
        [TestCase("Real name")]
        [TestCase("1")]
        [TestCase("   ")]
        public void AuthorShouldSetCorrectValues(string author)
        {
            Book book = new Book("BookName", author);
            string expectedAuthor = author;
            string actualAuthor = book.Author;
            Assert.AreEqual(expectedAuthor, actualAuthor);
        }
        [TestCase(null)]
        [TestCase("")]
        public void AuthorShouldThrowExceptionWhenNullOrEmpty(string author)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Book book = new Book("BookName", author);
            }, "Invalid Author!"
                );
        }
        [Test]
        public void AddingFootnoteShouldIncreaseCount()
        {
            int expectedCount = 1;
            for (int i = 0; i < expectedCount; i++)
            {
                defaultBook.AddFootnote(i, i.ToString());
            }
            int actualCount = defaultBook.FootnoteCount;
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void AddingFootNoteShouldAddKeyInTheDictionary() //reflection
        {
            //инициализираме си един ключ
            int addedKey = 1;
            //в дефолтната книга си добавяме един таккъв ключ с някакъв текст
            this.defaultBook.AddFootnote(addedKey, "text");
            //Чрез рефлекшън вземаме информация за полетата и вземаме това което е със същото име
            Type bookType = this.defaultBook.GetType();
            FieldInfo dictFieldInfo = bookType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.Name == "footnote");
            //кастваме си намерената стойност към речник
            Dictionary<int, string> fieldValue = (Dictionary<int, string>)dictFieldInfo.GetValue(this.defaultBook);
            bool containsKey = fieldValue.ContainsKey(addedKey);
             Assert.IsTrue(containsKey);
        }
        [Test]
        public void AddingExistingFootNoteShouldThrowException()
        {
            int sameKey = 1;
            this.defaultBook.AddFootnote(sameKey, "text");
            Assert.Throws<InvalidOperationException>(() =>
           {
               this.defaultBook.AddFootnote(sameKey, "Another text");
           }, "Footnote already exists!");
        }
        [Test]
        public void FindFootNoteShouldReturnCorrectTextWhenExisting()
        {
            int footKey = 1;
            string footText = "Text";
            this.defaultBook.AddFootnote(footKey, footText);
            string expectedResult = $"Footnote #{footKey}: {footText}";
            string actualResult = this.defaultBook.FindFootnote(footKey);
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void FindFootNoteShouldThrowExceptionIfThereAreFootNotesButPassedKeyDoesNotExist()
        {
            int footKey = 1;
            string footText = "Text";
            this.defaultBook.AddFootnote(footKey,footText);

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultBook.FindFootnote(98);
            }, "Footnote does not exists!");
        }
        [Test]
        public void FindFoodNoteShouldThrowExceptionIfThereAreNoFootNotesAtAll()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultBook.FindFootnote(1);
            }, "Footnote does not exists!");
        }
        [Test]
        public void AlterFootNoteShouldChangeTextWhenFootNoteExits()
        {
            int footKey = 1;
            string footText = "Text";
            this.defaultBook.AddFootnote(footKey,footText);

            string expectedText = "Next text";
            this.defaultBook.AlterFootnote(footKey,expectedText);
            Type bookType = this.defaultBook.GetType();
            FieldInfo dictFieldInfo = bookType
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.Name == "footnote");
            //кастваме си намерената стойност към речник
            Dictionary<int, string> fieldValue = (Dictionary<int, string>)dictFieldInfo.GetValue(this.defaultBook);
            string actualText = fieldValue[footKey];
            Assert.AreEqual(expectedText, actualText);
        }
        [Test]
        public void AlterFootNoteShouldThrowExceptionIfThereAreFootNotesButPassedKeyDoesNotExist()
        {
            int footKey = 1;
            string footText = "Text";
            this.defaultBook.AddFootnote(footKey, footText);
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultBook.AlterFootnote(98, "New invalid text");
            }, "Footnote does not exists!");
        }
        [Test]
        public void AlterFoodNoteShouldThrowExceptionIfThereAreNoFootNotesAtAll()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.defaultBook.AlterFootnote(98, "New invalid text");
            }, "Footnote does not exists!");
        }
    }
}