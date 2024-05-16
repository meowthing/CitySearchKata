using CitySearch;

namespace SearchTests
{
    public class Tests
    {
        CitySearcher cSearcher;

        [SetUp]
        public void Setup()
        {
            cSearcher = new CitySearcher();
        }

        [Test]
        public void NoResultsIfInputIsBelowMinInputLength()
        {
            Assert.That(cSearcher.Search("a"), Is.EqualTo(""));
        }

        [Test]
        public void ReturnCitiesStartingWithInputCharacters()
        {
            Assert.That(cSearcher.Search("Va"), Does.Contain("Valencia, Vancouver"));
        }

        [Test]
        public void InputIsCaseInsensitive()
        {
            Assert.That(cSearcher.Search("va"), Does.Contain("Valencia, Vancouver"));
        }

        [Test]
        public void ReturnCitiesMatchingAnyPartOfInput()
        {
            Assert.That(cSearcher.Search("ape"), Does.Contain("Budapest"));
        }

        [Test]
        public void ReturnAllCitiesUsingSpecialCharacter()
        {
            Assert.That(cSearcher.Search("ape"), Has.Count.AtLeast(1));
        }
    }
}