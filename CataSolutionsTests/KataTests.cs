using Microsoft.VisualStudio.TestTools.UnitTesting;
using CataSolutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CataSolutions.Tests
{
    [TestClass]
    public class KataTests
    {

        [TestMethod]
        public void SampleTest()
        {
            var check = Kata.TowerBuilder(7);
        }

        [TestMethod()]
        public void SolveTest()
        {
            string result = Kata.Solve("DAta");
            string result2 = Kata.Solve("Data");
            string result3 = Kata.Solve("DATa");
            string result4 = Kata.Solve("DATa");
        }

        [TestMethod]
        public void ShouldWorkForSomeExamples()
        {
            Assert.AreEqual("ThIs", Kata.ToWeirdCase("This"));
            Assert.AreEqual("Is", Kata.ToWeirdCase("is"));
            string lower = Kata.ToWeirdCase("This is a test");
            Assert.AreEqual("ThIs Is A TeSt", lower);
        }

        [TestMethod]
        public void TestSimple()
        {
            var expected = new int[] { 1, 1, 3, 3, 7, 2, 2, 2 };

            var actual = Kata.DeleteNth(new int[] { 1, 1, 3, 3, 7, 2, 2, 2, 2 }, 3);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInArray()
        {
            string[] a1 = new string[] { "arp", "live", "strong" };
            string[] a2 = new string[] { "lively", "alive", "harp", "sharp", "armstrong" };
            string[] r = new string[] { "arp", "live", "strong" };

            CollectionAssert.AreEqual(r, Kata.inArray(a1, a2));

            string[] a3 = new string[] { "tarp", "mice", "bull" };
            string[] a4 = new string[] { "lively", "alive", "harp", "sharp", "armstrong" };

            string[] r2 = new string[] { };

            CollectionAssert.AreEqual(r2, Kata.inArray(a3, a4));

        }
    }
}