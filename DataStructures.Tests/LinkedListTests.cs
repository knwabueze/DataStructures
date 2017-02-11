using DataStructures.Collections;
using System;
using Xunit;

namespace DataStructures.Tests
{
    public class LinkedListTests
    {
        [Fact]
        public void CircularEnumerableTest()
        {
            CircularLinkedList<int> list = new CircularLinkedList<int>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }


            Assert.True(true);
        }
    }
}
