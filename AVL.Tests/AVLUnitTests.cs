using System;
using Xunit;
using AVL;

namespace AVL.Tests
{
    public class AVLUnitTests
    {
        AVL<int> tree;
        public AVLUnitTests()
        {
            tree = new AVL<int>();
        }


        [Fact]
        public void EmptyTreeCountIsZero()
        {
            Assert.Equal(0, tree.Count);
        }


        [Theory]
        [InlineData(5)]
        [InlineData(-5)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-3)]
        public void NumsLessThanZero(int num)
        {
            Assert.True(IsLessThanZero(num));
        }

        public bool IsLessThanZero(int num)
        {
            return num < 0;
        }
    }
}
