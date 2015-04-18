using System.Collections.Generic;
using System.Linq;

namespace domain
{
    public class Diamond_Builder
    {
        private const string NEW_LINE = "\n";

        private static readonly List<string> alphabet = new List<string>
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" 
        }; 

        public string Build_Diamond(string middle_letter)
        {
            var letters = Get_Necessary_Letters(last_letter: middle_letter);
            var letters_with_spaces = Insert_Spaces(letters);
            var diamond = Duplicate_First_Half_of_Diamond(half_diamond: letters_with_spaces);
            var result_diamond = To_String(diamond);
            return result_diamond;
        }

        private List<string> Get_Necessary_Letters(string last_letter)
        {
            var index_of_last_letter = alphabet.IndexOf(last_letter);
            var letters = alphabet.Take(count: index_of_last_letter + 1).ToList();
            var correct_nr_of_letters = letters
                .Where(l => l != "A")
                .Select(l => l + l)
                .ToList();
            correct_nr_of_letters.Insert(0, "A");
            return correct_nr_of_letters;
        }

        private List<string> Insert_Spaces(List<string> letters)
        {
            // TODO Build skeleton.
            return letters;
        }

        private IEnumerable<string> Duplicate_First_Half_of_Diamond(List<string> half_diamond)
        {
            var duplicate = half_diamond
                .Take(count: half_diamond.Count - 1)
                .ToList();
            half_diamond.AddRange(duplicate);
            return half_diamond;
        }

        private string To_String(IEnumerable<string> diamond)
        {
            return string.Join(separator: NEW_LINE, values: diamond);
        }
    }
}