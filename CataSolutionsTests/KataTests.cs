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

        [TestMethod]
        public void TestCleanString()
        {
            Assert.AreEqual("ac", Kata.CleanString("abc#d##c"));
            Assert.AreEqual("jf", Kata.CleanString("abjd####jfk#"));
            Assert.AreEqual("*^7(Cyq!7c51Pm0Z&", Kata.CleanString("!#eE##l##f#*^7(Cyq!7oCy#KO*###Pn####cZ#51PmJ#0Q)#w##ZlhF#3##ndL*##o#jX#YH#Bc##Y######&S#*#UA##H#"));
            Assert.AreEqual("6wEawR", Kata.CleanString("KA#X7###6lS5##y##wq#!$BP#TU#A##rD##Pu!H####%j###Msx####tuQKX#####X##EsZ##ane##wR"));
            Assert.AreEqual("IZivm", Kata.CleanString(")&#6###Lb###p#a#UK#v)g###lu####!###@###n#wp##o#####Iy#Zivmta##M#"));
        }

        [TestMethod]
        public void waveBasicTest1()
        {
            Kata kata = new Kata();
            List<string> result = new List<string> { "Hello", "hEllo", "heLlo", "helLo", "hellO" };
            CollectionAssert.AreEqual(result, kata.wave("hello"), "it should return '" + result + "'");
        }

        [TestMethod]
        public void waveBasicTest2()
        {
            Kata kata = new Kata();
            List<string> result = new List<string> { "Codewars", "cOdewars", "coDewars", "codEwars", "codeWars", "codewArs", "codewaRs", "codewarS" };
            CollectionAssert.AreEqual(result, kata.wave("codewars"), "it should return '" + result + "'");
        }

        [TestMethod]
        public void waveBasicTest3()
        {
            Kata kata = new Kata();
            List<string> result = new List<string> { };
            CollectionAssert.AreEqual(result, kata.wave(""), "it should return '" + result + "'");
        }

        [TestMethod]
        public void waveBasicTest4()
        {
            Kata kata = new Kata();
            List<string> result = new List<string> { "Two words", "tWo words", "twO words", "two Words", "two wOrds", "two woRds", "two worDs", "two wordS" };
            CollectionAssert.AreEqual(result, kata.wave("two words"), "it should return '" + result + "'");
        }

        [TestMethod]
        public void waveBasicTest5()
        {
            Kata kata = new Kata();
            List<string> result = new List<string> { " Gap ", " gAp ", " gaP " };
            CollectionAssert.AreEqual(result, kata.wave(" gap "), "it should return '" + result + "'");
        }

        [TestMethod]
        public void MoveZeroesTest()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 1, 1, 3, 1, 0, 0, 0, 0 }, Kata.BestMoveZeroes(new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 }));
        }
    }
}