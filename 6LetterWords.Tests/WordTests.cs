using _6LetterWords.Services.Models;

namespace _6LetterWords.Tests
{
    public class WordTests
    {
        [Fact]
        public void GetAllPossibleCombinations_WhenSectionsMatch()
        {
            var word = new Word("letter");
            var sections = new HashSet<string> { "l", "e", "t", "r", "tt", "ter", "tter" };

            var result = word.GetAllPossibleCombination(sections);

            var expectedResult = new List<string>
            {
                "l+e+t+t+e+r=letter",
                "l+e+tt+e+r=letter",
                "l+e+t+ter=letter",
                "l+e+tter=letter",
            };

            Assert.True(expectedResult.ToHashSet().SetEquals(result));
        }

        [Fact]
        public void GetAllPossibleCombinations_WhenNoSectionsMatch()
        {
            var word = new Word("letter");
            var sections = new HashSet<string> { "a", "b", "c" };

            var result = word.GetAllPossibleCombination(sections);

            Assert.Empty(result);
        }

        [Fact]
        public void GetAllPossibleCombinations_WhenEmptySectionsProvider()
        {
            var word = new Word("letter");
            var sections = new HashSet<string> {  };

            var result = word.GetAllPossibleCombination(sections);

            Assert.Empty(result);
        }

        [Fact]
        public void GetAllPossibleCombinations_WhenSectionContainsWord()
        {
            var word = new Word("letter");
            var sections = new HashSet<string> { "letter" };

            var result = word.GetAllPossibleCombination(sections);

            Assert.Empty(result);
        }
    }
}