using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Logic.Task4;


namespace NUnitTests.Task4
{
    [TestFixture]
    public class BinarySearchTests
    {
        private int[] intArray = { 1, 3, 5, 7, 9, 10, 35 };
        private FirstClass[] firstClassArray = { new FirstClass(2), new FirstClass(5), new FirstClass(8), new FirstClass(10) };
        private SecondClass[] secondClassArray = { new SecondClass(2), new SecondClass(4), new SecondClass(6), new SecondClass(19) };

        [TestCase(10, Result = 5)]
        [TestCase(-4, Result = -1)]
        [TestCase(40, Result = -1)]
        public int StartIntTest(int elem) => BinarySearch.Start(intArray, elem, Comparer<int>.Default);



        public IEnumerable<TestCaseData> StartFirstClassTestData
        {
            get
            {
                yield return new TestCaseData(new FirstClass(5)).Returns(1);
                yield return new TestCaseData(new FirstClass(4)).Returns(-1);
            }
        }

        [Test, TestCaseSource(nameof(StartFirstClassTestData))]
        public int StartFirstClassTest(FirstClass elem) => BinarySearch.Start(firstClassArray, elem, Comparer<FirstClass>.Default);

        public IEnumerable<TestCaseData> StartSecondClassTestData
        {
            get
            {
                yield return new TestCaseData(new SecondClass(6)).Returns(2);
                yield return new TestCaseData(new SecondClass(7)).Returns(-1);
            }
        }

        [TestCase(Result = -1)]
        public int StartSecondClassTest() => BinarySearch.Start(secondClassArray, new SecondClass(5), CompareMethod);

        public int CompareMethod(SecondClass x, SecondClass y)
        {
            if (x.Val > y.Val)
                return 1;
            else if (x.Val < y.Val)
                return -1;
            else
                return 0;
        }

    }

    public class FirstClass : IComparable<FirstClass>
    {
        private int value;

        public FirstClass(int value)
        {
            this.value = value;
        }

        public int CompareTo(FirstClass other)
        {
            if (value > other.value)
                return 1;
            else if (value < other.value)
                return -1;
            else
                return 0;
        }
    }

    public class SecondClass
    {
        private int value;

        public int Val { get { return value; } }

        public SecondClass(int value)
        {
            this.value = value;
        }
    }
}

