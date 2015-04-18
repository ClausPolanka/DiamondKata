using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain;
using Xunit;

namespace domain_tests
{
    public class Diamond_Builder_Test
    {
        [Theory]
        [InlineData("A", "A")]
        [InlineData("B", " A \nB B\n A ")]
        [InlineData("C", "  A  \n B B \nC   C\n B B \n  A  ")]
        public void Build_Diamond_For_Given_Input(string input, string expected_diamond )
        {
            var sut = new Diamond_Builder();
            var actual_diamond = sut.Build_Diamond(middle_letter: input);
            Assert.Equal(expected_diamond, actual_diamond);
        }
    }
}
