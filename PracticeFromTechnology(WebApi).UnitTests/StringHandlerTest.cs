using Microsoft.Extensions.Options;

using PracticeFromTechnology_WebApi_.Handler;

namespace PracticeFromTechnology_WebApi_.UnitTests
{
    [TestFixture]
    public class StringHandlerTest
    {
        private StringHandler _stringHandler;

        [SetUp]
        public void Setup()
        {
            _stringHandler = new StringHandler();
        }

        [Test]
        public void StringReverseTestWithEvenSymbolsLength()
        {
            var input = "abcdef";
            var expected = "cbafed";

            var result = _stringHandler.StringReverse(input);
            Assert.That(result, Is.EqualTo(expected), "If there is an even number of characters, then the method must keep the characters in two substrings, reverse and connect back.");
        }

        [Test]
        public void StringReverseTestWithOddSymbolsLength()
        {
            var input = "abcde";
            var expected = "edcbaabcde";

            var result = _stringHandler.StringReverse(input);
            Assert.That(result, Is.EqualTo(expected), "If the number of characters is odd, the method should reverse the string and append the original to it.");
        }

        [Test]
        public void GetInvalidCharactersTest()
        {
            var input = "ABcdef!123";
            var expected = "Недопустимые символы: A,B,!,1,2,3";

            var result = _stringHandler.GetInvalidCharacters(input);
            Assert.That(result, Is.EqualTo(expected), "The method should output all characters except lowercase English letters.");
        }

        [Test]
        public void CharCounterTest()
        {
            var input = "abcdef";
            var expected = new Dictionary<char, int>() { { 'a', 1 }, { 'b', 1 }, { 'c', 1 }, { 'd', 1 }, { 'e', 1 }, { 'f', 1 } };
            
            var result = _stringHandler.CharCounter(input);
            Assert.That(result, Is.EqualTo(expected), "The method should count the number of times each character occurs in a string.");
        }

        [Test]
        public void SearchVowelsSubstringTest()
        {
            var input = "cbafed";
            var expected = "afe";

            var result = _stringHandler.SearchVowelsSubstring(input);
            Assert.That(result, Is.EqualTo(expected), "The method should find the longest substring that starts and ends with vowel.");
        }

        [Test]
        public void ChooseSortTestWithQuickSort()
        {
            var input = "cbafed";
            var expected = "abcdef";

            var result = _stringHandler.ChooseSort(input, "quick");
            Assert.That(result, Is.EqualTo(expected), "Sorting a string sing Quicksort");
        }

        [Test]
        public void ChooseSortTestWithTreeSort()
        {
            var input = "cbafed";
            var expected = "abcdef";

            var result = _stringHandler.ChooseSort(input, "tree");
            Assert.That(result, Is.EqualTo(expected), "Sorting a string using TreeSort");
        }

        [Test]
        public void ChooseSortTestWithInvalidSortSelection()
        {
            var input = "cbafed";
            var expected = "Choose 'quick' or 'tree', case sensitive";

            var result = _stringHandler.ChooseSort(input, "car");
            Assert.That(result, Is.EqualTo(expected), "The user can only choose quick or tree.");
        }
    }
}