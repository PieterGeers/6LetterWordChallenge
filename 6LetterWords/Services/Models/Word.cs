namespace _6LetterWords.Services.Models
{
    internal class Word
    {
        private readonly string _word;

        public Word(string word)
        {
            _word = word;
        }

        public List<string> GetAllPossibleCombination(IEnumerable<string> allPossibleSections)
        {
            var possibleCombination = GenerateAllPossibleCombinations();

            HashSet<string> distinctSections = new HashSet<string>(possibleCombination.SelectMany(x => x).Distinct());
            HashSet<string> availableSections = new HashSet<string>(allPossibleSections.Where(distinctSections.Contains));

            List<string> result = new List<string>();
            foreach (var combination in possibleCombination)
            {
                if (combination.All(availableSections.Contains))
                {
                    result.Add($"{string.Join('+', combination)}={_word}");
                }
            }

            return result;
        }

        private List<List<string>> GenerateAllPossibleCombinations()
        {
            List<List<string>> result = new List<List<string>>();
            List<string> currentCombination = new List<string>();
            GenerateCombinations(0, currentCombination, result);

            return result;
        }

        private void GenerateCombinations(int start, List<string> currentCombination, List<List<string>> result)
        {
            int currentCombinationLenght = currentCombination.Select(c => c.Length).Sum();

            if (currentCombinationLenght == _word.Length)
            {
                result.Add(currentCombination.ToList());
                return;
            }

            for (int sectionLength = 1; sectionLength < _word.Length; sectionLength++)
            {
                if (start + sectionLength > _word.Length)
                {
                    return;
                }

                currentCombination.Add(_word.Substring(start, sectionLength));
                GenerateCombinations(start + sectionLength, currentCombination, result);
                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        } 
    }
}
