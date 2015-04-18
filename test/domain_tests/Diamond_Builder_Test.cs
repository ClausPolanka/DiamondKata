﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace domain_tests
{
    public class Diamond_Builder_Test
    {
        [Theory]
        [InlineData("A", "A")]
        public void Build_Diamond_For_Given_Input(string input, string expected_diamond )
        {
            var sut = new Diamond_Builder();
            var actual_diamond = sut.Build_Diamond(middle_letter: input);
            Assert.Equal(expected_diamond, actual_diamond);
        }
    }

    public class Diamond_Builder
    {
        public string Build_Diamond(string middle_letter)
        {
            return string.Empty;
        }
    }
}