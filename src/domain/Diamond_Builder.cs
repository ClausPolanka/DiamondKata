using System;
using System.Collections.Generic;
using System.Linq;

namespace domain
{
    public class Diamond_Builder
    {
        private const string NEW_LINE = "\n";
        private const char WHITE_SPACE = ' ';

        private static readonly List<string> alphabet = new List<string>
        {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z"
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
            var letters_with_left_and_right_spaces = Add_Left_And_Right_Spaces_To(letters);
            var letters_with_spaces = Inject_Spaces_in_the_Middle(letters_with_left_and_right_spaces);
            return letters_with_spaces;
        }

        private List<string> Add_Left_And_Right_Spaces_To(List<string> letters)
        {
            var spaces = Create_Spaces_For(letters);

            var letters_with_prepended_spaces = letters
                .Zip(spaces, (l, s) => s + l + s)
                .ToList();

            return letters_with_prepended_spaces;
        }

        private IEnumerable<string> Create_Spaces_For(IReadOnlyCollection<string> letters)
        {
            var spaces = new List<string>();

            for (var i = letters.Count - 1; i > 0; i--)
                spaces.Add(new String(WHITE_SPACE, count: i));

            spaces.Add("");
            return spaces;
        }

        private List<string> Inject_Spaces_in_the_Middle(List<string> letters)
        {
            var spaces = Create_Middle_Spaces_For(letters);

            var letters_with_middle_spaces = letters
                .Zip(spaces, (l, s) => l.Insert(startIndex: (l.Count() / 2), value: s))
                .ToList();

            return letters_with_middle_spaces;
        }

        private IEnumerable<string> Create_Middle_Spaces_For(List<string> letters)
        {
            var spaces = new List<string> { "" };

            var odd_nr = 1;
            letters.ForEach(l => 
            {
                spaces.Add(new String(WHITE_SPACE, count: odd_nr));
                odd_nr += 2;
            });

            return spaces;
        }

        private IEnumerable<string> Duplicate_First_Half_of_Diamond(List<string> half_diamond)
        {
            var duplicate = half_diamond
                .Take(count: half_diamond.Count - 1)
                .ToList();
            duplicate.Reverse();
            half_diamond.AddRange(duplicate);
            return half_diamond;
        }

        private string To_String(IEnumerable<string> diamond)
        {
            return string.Join(separator: NEW_LINE, values: diamond);
        }
    }
}