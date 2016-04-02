using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Logic.Task5;

namespace NUnitTests.Task5
{
    [TestFixture]
    public class SortTests
    {
        [Test]
        public void BubbleSortIntTest()
        {
            int[] initialIntArr = { 2, 7, -23, 5, 79, 5 };
            int[] expectedIntArr = { -23, 2, 5, 5, 7, 79 };

            Sort.BubbleSort(initialIntArr, Comparer<int>.Default);
            CollectionAssert.AreEqual(expectedIntArr, initialIntArr);
        }

        [Test]
        public void BubbleSortStringTest()
        {
            string[] initialStringArr = { "aqqqq", "bcd", "032", "wer", "sdf", "bac" };
            string[] expectedStringArr = { "032", "aqqqq", "bac", "bcd", "sdf", "wer" };

            Sort.BubbleSort(initialStringArr, Comparer<string>.Default);
            CollectionAssert.AreEqual(expectedStringArr, initialStringArr);
        }

        [Test]
        public void BubbleSortTestClassTest()
        {
            TestClass[] initialTestClassArr = { new TestClass(4), new TestClass(-34), new TestClass(2) };
            TestClass[] expectedTestClassArr = { new TestClass(-34), new TestClass(2), new TestClass(4) };

            Sort.BubbleSort(initialTestClassArr, new Comparator());
            CollectionAssert.AreEqual(expectedTestClassArr, initialTestClassArr);
        }
    }

    public class TestClass: IEquatable<TestClass>
    {
        private int value;

        public int Value { get { return value; } }

        public TestClass(int value)
        {
            this.value = value;
        }

        public int GetHashCode(TestClass obj)
        {
            return obj.value.GetHashCode();
        }

        public bool Equals(TestClass other)
        {
            if (other == null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (value == other.value)
                return true;
            else
                return false;
        }
    }

    public class Comparator : IComparer<TestClass>
    {
        public int Compare(TestClass x, TestClass y)
        {
            if (x.Value > y.Value)
                return 1;
            else if (x.Value < y.Value)
                return -1;
            else return 0;
        }
    }
}
