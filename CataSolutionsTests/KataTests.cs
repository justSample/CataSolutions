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
            CollectionAssert.AreEqual(new int[] { 1, 2, 1, 1, 3, 1, 0, 0, 0, 0 }, Kata.MoveZeroesRemember(new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 }));
            CollectionAssert.AreEqual(new int[] { 1, 6, 3, 1, 1, 6, 8, 9, 1, 0 }, Kata.MoveZeroesRemember(new int[] { 0, 1, 6, 3, 1, 1, 6, 8, 9, 1 }));
            CollectionAssert.AreEqual(new int[] { 6, 2, 1, 3, 5, 0, 0, 0, 0, 0 }, Kata.MoveZeroesRemember(new int[] { 0, 6, 0, 2, 0, 1, 0, 3, 0, 5 }));
        }


        [TestMethod]
        public void FindMissingTest()
        {
            Assert.AreEqual(7, Kata.FindMissing(new List<int> { 1, 3, 5, 9, 11 }));
            Assert.AreEqual(15, Kata.FindMissing(new List<int> { 0, 5, 10, 20, 25 }));
            Assert.AreEqual(10, Kata.FindMissing(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 }));
            Assert.AreEqual(1400, Kata.FindMissing(new List<int> { 1040, 1220, 1580 }));
            Assert.AreEqual(1220, Kata.FindMissing(new List<int> { 1040, 1400, 1580 }));

        }

        [TestMethod]
        public void MixTest()
        {
            //Assert.AreEqual("", Kata.Mix("codewars", "codewars"));
            Assert.AreEqual("2:eeeee/2:yy/=:hh/=:rr", Kata.Mix("Are they here", "yes, they are here"));
            Assert.AreEqual("1:ooo/1:uuu/2:sss/=:nnn/1:ii/2:aa/2:dd/2:ee/=:gg",
                    Kata.Mix("looping is fun but dangerous", "less dangerous than coding"));
            Assert.AreEqual("1:aaa/1:nnn/1:gg/2:ee/2:ff/2:ii/2:oo/2:rr/2:ss/2:tt",
                    Kata.Mix(" In many languages", " there's a pair of functions"));
            Assert.AreEqual("1:ee/1:ll/1:oo", Kata.Mix("Lords of the Fallen", "gamekult"));
            Assert.AreEqual("", Kata.Mix("codewars", "codewars"));
            Assert.AreEqual("1:nnnnn/1:ooooo/1:tttt/1:eee/1:gg/1:ii/1:mm/=:rr",
                    Kata.Mix("A generation must confront the looming ", "codewarrs"));
        }


        [TestMethod]
        public void SumIntervalsShouldHandleEmptyIntervalsTest()
        {
            Assert.AreEqual(0, Kata.SumIntervals(new (int, int)[] { }));
            Assert.AreEqual(0, Kata.SumIntervals(new (int, int)[] { (4, 4), (6, 6), (8, 8) }));
        }

        [TestMethod]
        public void SumIntervalsShouldAddDisjoinedIntervalsTest()
        {
            Assert.AreEqual(9, Kata.SumIntervals(new (int, int)[] { (1, 2), (6, 10), (11, 15) }));
            Assert.AreEqual(11, Kata.SumIntervals(new (int, int)[] { (4, 8), (9, 10), (15, 21) }));
            Assert.AreEqual(7, Kata.SumIntervals(new (int, int)[] { (-1, 4), (-5, -3) }));
            Assert.AreEqual(78, Kata.SumIntervals(new (int, int)[] { (-245, -218), (-194, -179), (-155, -119) }));
        }

        [TestMethod]
        public void SumIntervalsShouldAddAdjacentIntervalsTest()
        {
            Assert.AreEqual(54, Kata.SumIntervals(new (int, int)[] { (1, 2), (2, 6), (6, 55) }));
            Assert.AreEqual(23, Kata.SumIntervals(new (int, int)[] { (-2, -1), (-1, 0), (0, 21) }));
        }

        [TestMethod]
        public void SumIntervalsShouldAddOverlappingIntervalsTest()
        {
            Assert.AreEqual(7, Kata.SumIntervals(new (int, int)[] { (1, 4), (7, 10), (3, 5) }));
            Assert.AreEqual(6, Kata.SumIntervals(new (int, int)[] { (5, 8), (3, 6), (1, 2) }));
            Assert.AreEqual(19, Kata.SumIntervals(new (int, int)[] { (1, 5), (10, 20), (1, 6), (16, 19), (5, 11) }));
        }

        [TestMethod]
        public void SumIntervalsShouldHandleMixedIntervalsTest()
        {
            Assert.AreEqual(13, Kata.SumIntervals(new (int, int)[] { (2, 5), (-1, 2), (-40, -35), (6, 8) }));
            Assert.AreEqual(1234, Kata.SumIntervals(new (int, int)[] { (-7, 8), (-2, 10), (5, 15), (2000, 3150), (-5400, -5338) }));
            Assert.AreEqual(158, Kata.SumIntervals(new (int, int)[] { (-101, 24), (-35, 27), (27, 53), (-105, 20), (-36, 26) }));
        }

        [TestMethod]
        public void SumIntervalsShouldHandleRandomIntervalsTest()
        {
            Assert.AreEqual(19410, Kata.SumIntervals(new (int, int)[] { (-6214, 2339), (-3925, 8404), (-6335, 2279), (-1532, -1076), (-1910, 2009), (-5643, 2900), (195, 7610), (-5844, 5629), (-7459, -4028), (-7983, -2422), (-7400, -208), (-4992, 9663), (-8173, -7663), (-3328, -1358), (-9589, 7944), (901, 7886), (-7124, -5335), (-3209, 6222), (-4971, 1754), (-4104, 7066), (2413, 7885), (-8340, 9021), (-5402, -3559), (-1215, 2217), (1236, 8203), (6393, 8223), (-3323, 618), (-7454, 7293), (-5877, 3395), (-6262, 451), (-9718, 6992), (523, 1597), (5013, 7188), (4734, 9692), (3973, 7364), (-6126, 7511), (-8318, -1095), (-5868, 187), (771, 8002) }));
            Assert.AreEqual(19417, Kata.SumIntervals(new (int, int)[] { (-7799, 3153), (-9381, 3553), (-8169, 7211), (-5915, 9169), (-846, 4095), (-4868, 3750), (-615, 4775), (-9482, -6825), (1571, 6665), (-6407, -4251), (2809, 3219), (-508, 8487), (-9874, 9483), (6212, 8970), (-9182, -3040), (-9077, 7413), (-2009, 4004), (-4233, 6359), (3599, 4332), (-2455, 9543), (3067, 4644), (-6556, 1086), (3327, 4022), (-1511, 694), (6274, 8688), (-8230, -7302), (-990, 7612), (-8142, -609), (-5939, 4666), (-9508, -7653), (-9802, -9002), (-1664, 7125) }));
            Assert.AreEqual(19161, Kata.SumIntervals(new (int, int)[] { (-2110, -1711), (-92, 2001), (1808, 1969), (-6983, 4174), (-554, 3680), (-1982, 7468), (3606, 7906), (-6538, 2479), (3069, 3810), (-8199, -6008), (-5744, 8807), (-2013, 4950), (-6588, 7360), (2313, 7953), (-2337, -796), (-7300, 471), (-8844, -3412), (-6254, 2546), (-7730, 6353), (-3561, 5045), (6051, 6546), (2399, 7383), (-9805, 9356), }));
            Assert.AreEqual(19404, Kata.SumIntervals(new (int, int)[] { (-4286, -82), (-8692, 7485), (-9444, 2029), (-3469, 8805), (-838, -487), (1996, 7915), (-7941, 311), (2261, 5006), (233, 9960), (-2162, -633), }));
        }

        [TestMethod]
        public void HumanReadableTimeTest()
        {
            Assert.AreEqual("00:00:00", Kata.GetReadableTime(0));
            Assert.AreEqual("00:00:05", Kata.GetReadableTime(5));
            Assert.AreEqual("00:01:00", Kata.GetReadableTime(60));
            Assert.AreEqual("23:59:59", Kata.GetReadableTime(86399));
            Assert.AreEqual("99:59:59", Kata.GetReadableTime(359999));
        }

        [TestMethod]
        public void FormatDurationTest()
        {
            Assert.AreEqual("now", Kata.FormatDuration(0));
            Assert.AreEqual("1 second", Kata.FormatDuration(1));
            Assert.AreEqual("1 minute and 2 seconds", Kata.FormatDuration(62));
            Assert.AreEqual("2 minutes", Kata.FormatDuration(120));
            Assert.AreEqual("1 hour, 1 minute and 2 seconds", Kata.FormatDuration(3662));
            Assert.AreEqual("182 days, 1 hour, 44 minutes and 40 seconds", Kata.FormatDuration(15731080));
            Assert.AreEqual("4 years, 68 days, 3 hours and 4 minutes", Kata.FormatDuration(132030240));
            Assert.AreEqual("6 years, 192 days, 13 hours, 3 minutes and 54 seconds", Kata.FormatDuration(205851834));
            Assert.AreEqual("8 years, 12 days, 13 hours, 41 minutes and 1 second", Kata.FormatDuration(253374061));
            Assert.AreEqual("7 years, 246 days, 15 hours, 32 minutes and 54 seconds", Kata.FormatDuration(242062374));
            Assert.AreEqual("3 years, 85 days, 1 hour, 9 minutes and 26 seconds", Kata.FormatDuration(101956166));
            Assert.AreEqual("1 year, 19 days, 18 hours, 19 minutes and 46 seconds", Kata.FormatDuration(33243586));
        }


        [TestMethod]
        public void NextBiggerNumberTest()
        {
            Assert.AreEqual(21, Kata.NextBiggerNumber(12));
            Assert.AreEqual(531, Kata.NextBiggerNumber(513));
            Assert.AreEqual(2071, Kata.NextBiggerNumber(2017));
            Assert.AreEqual(441, Kata.NextBiggerNumber(414));
            Assert.AreEqual(414, Kata.NextBiggerNumber(144));
            Assert.AreEqual(123456798, Kata.NextBiggerNumber(123456789));
        }


        [TestMethod]
        public void PartTest()
        {
            Console.WriteLine("****** Basic Tests Small Numbers");
            Assert.AreEqual("Range: 1 Average: 1.50 Median: 1.50", Kata.Part(2));
            Assert.AreEqual("Range: 2 Average: 2.00 Median: 2.00", Kata.Part(3));
            Assert.AreEqual("Range: 3 Average: 2.50 Median: 2.50", Kata.Part(4));
            Assert.AreEqual("Range: 5 Average: 3.50 Median: 3.50", Kata.Part(5));
            Assert.AreEqual("Range: 531440 Average: 26832.81 Median: 5865.00", Kata.Part(36));
            Assert.AreEqual("Range: 1594322 Average: 63823.27 Median: 11475.00", Kata.Part(39));
        }



        [TestMethod]
        public void StripCommentsTest()
        {
            Assert.AreEqual(
                    "apples, pears\ngrapes\nbananas",
                    Kata.StripComments("apples, pears # and bananas\ngrapes\nbananas !apples", new string[] { "#", "!" }));

            Assert.AreEqual("a\nc\nd", Kata.StripComments("a #b\nc\nd $e f g", new string[] { "#", "$" }));
            Assert.AreEqual("a\n b\nc", Kata.StripComments("a \n b \nc ", new string[] { "#", "$" }));

        }



        #region Line Safari - Is that a line?

        //https://www.codewars.com/kata/59c5d0b0a25c8c99ca000237/train/csharp

        [TestMethod]
        public void GridExGood1()
        {
            var grid = MakeGrid(new[]
            {
            "           ",
            "X---------X",
            "           ",
            "           "
        });
            WriteGrid(grid);
            Assert.AreEqual(true, Kata.Line(grid));
        }

        [TestMethod]
        public void GridExGood2()
        {
            var grid = MakeGrid(new[]
            {
            "     ",
            "  X  ",
            "  |  ",
            "  |  ",
            "  X  "
        });
            WriteGrid(grid);
            Assert.AreEqual(true, Kata.Line(grid));
        }

        [TestMethod]
        public void GridExGood3()
        {
            var grid = MakeGrid(new[]
            {
            "                    ",
            "     +--------+     ",
            "  X--+        +--+  ",
            "                 |  ",
            "                 X  ",
            "                    "
        });
            WriteGrid(grid);
            Assert.AreEqual(true, Kata.Line(grid));
        }

        [TestMethod]
        public void GridExGood4()
        {
            var grid = MakeGrid(new[]
            {
            "                     ",
            "    +-------------+  ",
            "    |             |  ",
            " X--+      X------+  ",
            "                     "
        });
            WriteGrid(grid);
            Assert.AreEqual(true, Kata.Line(grid));
        }

        [TestMethod]
        public void GridExGood5()
        {
            var grid = MakeGrid(new[]
            {
            "                      ",
            "   +-------+          ",
            "   |      +++---+     ",
            "X--+      +-+   X      "
        });
            WriteGrid(grid);
            Assert.AreEqual(true, Kata.Line(grid));
        }


        // "Bad" examples from the Kata description.

        [TestMethod]
        public void GridExBad1()
        {
            var grid = MakeGrid(new[]
            {
            "X-----|----X"
        });
            WriteGrid(grid);
            Assert.AreEqual(false, Kata.Line(grid));
        }

        [TestMethod]
        public void GridExBad2()
        {
            var grid = MakeGrid(new[]
            {
            " X  ",
            " |  ",
            " +  ",
            " X  "
        });
            WriteGrid(grid);
            Assert.AreEqual(false, Kata.Line(grid));
        }

        [TestMethod]
        public void GridExBad3()
        {
            var grid = MakeGrid(new[]
            {
            "   |--------+    ",
            "X---        ---+ ",
            "               | ",
            "               X "
        });
            WriteGrid(grid);
            Assert.AreEqual(false, Kata.Line(grid));
        }

        [TestMethod]
        public void GridExBad4()
        {
            var grid = MakeGrid(new[]
            {
            "              ",
            "   +------    ",
            "   |          ",
            "X--+      X   ",
            "              "
        });
            WriteGrid(grid);
            Assert.AreEqual(false, Kata.Line(grid));
        }

        [TestMethod]
        public void GridExBad5()
        {
            var grid = MakeGrid(new[]
            {
            "      +------+",
            "      |      |",
            "X-----+------+",
            "      |       ",
            "      X       ",
        });
            WriteGrid(grid);
            Assert.AreEqual(false, Kata.Line(grid));
        }


        //Other tests... Я устал босс

        [TestMethod]
        public void GridExBreadcrumbsExtras()
        {
            var grid = MakeGrid(new[]
            {
            "   X-----+  ",
            "         |  ",
            "   X-----+  ",
            "         |  ",
            "   ------+  ",
        });
            WriteGrid(grid);
            Assert.AreEqual(false, Kata.Line(grid));
        }

        [TestMethod]
        public void GridExBreadcrumbsOneWay()
        {
            var grid = MakeGrid(new[]
            {
            "         X   ",
            "   X+++  +-+ ",
            "    +++--+ | ",
            "         +-+ ",
        });
            WriteGrid(grid);
            Assert.AreEqual(true, Kata.Line(grid));
        }

        [TestMethod]
        public void GridExBreadcrumbsTwoWays()
        {
            var grid = MakeGrid(new[]
            {
            "            ",
            "   X+++     ",
            "    +++X    ",
        });
            WriteGrid(grid);
            Assert.AreEqual(true, Kata.Line(grid));
        }

        [TestMethod]
        public void GridExLoopAmbiguous()
        {
            var grid = MakeGrid(new[]
            {
            "            ",
            "   X-----+  ",
            "   X     |  ",
            "   |     |  ",
            "   |     |  ",
            "   +-----+  ",
        });
            WriteGrid(grid);
            Assert.AreEqual(false, Kata.Line(grid));
        }

        [TestMethod]
        public void GridExMoreEdgeCases()
        {
            var grid = MakeGrid(new[]
            {
            "             ",
            "    +++X     ",
            "    +++      ",
            "   X+++      ",
            "             ",
            "    ++++X    ",
            "   X++++     ",
            "    ++++     ",
            "   X++++     ",
            "       X     ",
            "    ++++     ",
            "   X++++X    ",
        });
            WriteGrid(grid);
            Assert.AreEqual(true, Kata.Line(grid));
        }

        [TestMethod]
        public void GridExSpiralAnticlockwise()
        {
            var grid = MakeGrid(new[]
            {
            "   +-----+  ",
            "   |+---+|  ",
            "   ||+-+||  ",
            "   |||X+||  ",
            "   X|+--+|  ",
            "    +----+  ",
        });
            WriteGrid(grid);
            Assert.AreEqual(true, Kata.Line(grid));
        }

        [TestMethod]
        public void GridExSpiralClockwise()
        {
            var grid = MakeGrid(new[]
            {
            "    +----+  ",
            "    |+--+|  ",
            "    ||X+||  ",
            "    |+-+||  ",
            "    +---+|  ",
            "X--------+  ",
        });
            WriteGrid(grid);
            Assert.AreEqual(true, Kata.Line(grid));
        }


        private char[][] MakeGrid(string[] arr)
        {
            int y = arr.Length;
            int x = arr[0].Length;

            char[][] toReturn = new char[y][];

            for (int i = 0; i < y; i++)
            {
                toReturn[i] = new char[x];

                for (int j = 0; j < x; j++)
                {
                    toReturn[i][j] = arr[i][j];
                }
            }

            return toReturn;
        }

        private void WriteGrid(char[][] grid)
        {

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    System.Diagnostics.Debug.Write(grid[i][j]);
                }
                System.Diagnostics.Debug.WriteLine("");
            }

        }

        #endregion

        [TestMethod]
        public void ClosestMultiple10Test()
        {
            for (int i = 10; i <= 14; ++i)
            {
                Assert.AreEqual(10, Kata.ClosestMultiple10(i));
            }

            for (int i = 15; i <= 20; ++i)
            {
                Assert.AreEqual(20, Kata.ClosestMultiple10(i));
            }
        }


        #region DiamondTests

        [TestMethod]
        public void TestNull()
        {
            Assert.IsNull(Kata.DiamondPrint(0));
            Assert.IsNull(Kata.DiamondPrint(-2));
            Assert.IsNull(Kata.DiamondPrint(2));
        }

        [TestMethod]
        public void TestDiamond1()
        {
            var expected = new StringBuilder();
            expected.Append("*\n");
            Assert.AreEqual(expected.ToString(), Kata.DiamondPrint(1));
        }
        [TestMethod]
        public void TestDiamond3()
        {
            var expected = new StringBuilder();
            expected.Append(" *\n");
            expected.Append("***\n");
            expected.Append(" *\n");

            Assert.AreEqual(expected.ToString(), Kata.DiamondPrint(3));
        }

        [TestMethod]
        public void TestDiamond5()
        {
            var expected = new StringBuilder();
            expected.Append("  *\n");
            expected.Append(" ***\n");
            expected.Append("*****\n");
            expected.Append(" ***\n");
            expected.Append("  *\n");

            Assert.AreEqual(expected.ToString(), Kata.DiamondPrint(5));
        }

        [TestMethod]
        public void TestDiamond7()
        {
            var expected = new StringBuilder();
            expected.Append("   *\n");
            expected.Append("  ***\n");
            expected.Append(" *****\n");
            expected.Append("*******\n");
            expected.Append(" *****\n");
            expected.Append("  ***\n");
            expected.Append("   *\n");

            Assert.AreEqual(expected.ToString(), Kata.DiamondPrint(7));
        }

        [TestMethod]
        public void TestDiamond9()
        {
            var expected = new StringBuilder();

            expected.Append("    *\n");
            expected.Append("   ***\n");
            expected.Append("  *****\n");
            expected.Append(" *******\n");
            expected.Append("*********\n");
            expected.Append(" *******\n");
            expected.Append("  *****\n");
            expected.Append("   ***\n");
            expected.Append("    *\n");


            Assert.AreEqual(expected.ToString(), Kata.DiamondPrint(9));
        }

        [TestMethod]
        public void TestDiamond11()
        {
            var expected = new StringBuilder();
            expected.Append("     *\n");
            expected.Append("    ***\n");
            expected.Append("   *****\n");
            expected.Append("  *******\n");
            expected.Append(" *********\n");
            expected.Append("***********\n");
            expected.Append(" *********\n");
            expected.Append("  *******\n");
            expected.Append("   *****\n");
            expected.Append("    ***\n");
            expected.Append("     *\n");

            Assert.AreEqual(expected.ToString(), Kata.DiamondPrint(11));
        }

        [TestMethod]
        public void TestDiamond13()
        {
            var expected = new StringBuilder();

            expected.Append("      *\n");
            expected.Append("     ***\n");
            expected.Append("    *****\n");
            expected.Append("   *******\n");
            expected.Append("  *********\n");
            expected.Append(" ***********\n");
            expected.Append("*************\n");
            expected.Append(" ***********\n");
            expected.Append("  *********\n");
            expected.Append("   *******\n");
            expected.Append("    *****\n");
            expected.Append("     ***\n");
            expected.Append("      *\n");


            Assert.AreEqual(expected.ToString(), Kata.DiamondPrint(13));
        }

        #endregion


        #region AreTheySameTest

        [TestMethod]
        public void AreTheySameTest()
        {
            int[] a = new int[] { 121, 144, 19, 161, 19, 144, 19, 11 };
            int[] b = new int[] { 11 * 11, 121 * 121, 144 * 144, 19 * 19, 161 * 161, 19 * 19, 144 * 144, 19 * 19 };
            bool r = Kata.AreTheySameComp(a, b); // True
            Assert.AreEqual(true, r);
        }
        #endregion

        #region Spiralizor

        //https://www.codewars.com/kata/534e01fbbb17187c7e0000c6/train/csharp

        [TestMethod]
        public void SpiralizeTest05()
        {
            int input = 5;
            int[,] expected = new int[,]{
            {1, 1, 1, 1, 1},
            {0, 0, 0, 0, 1},
            {1, 1, 1, 0, 1},
            {1, 0, 0, 0, 1},
            {1, 1, 1, 1, 1}
        };

            int[,] actual = Kata.Spiralize(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SpiralizeTest08()
        {
            int input = 8;
            int[,] expected = new int[,]{
            {1, 1, 1, 1, 1, 1, 1, 1},
            {0, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 0, 1},
            {1, 0, 0, 0, 0, 1, 0, 1},
            {1, 0, 1, 0, 0, 1, 0, 1},
            {1, 0, 1, 1, 1, 1, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1},
        };

            int[,] actual = Kata.Spiralize(input);
            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Sudoku

        //https://www.codewars.com/kata/529bf0e9bdf7657179000008/train/csharp

        [TestClass]
        public class Sample_Tests
        {
            private static object[] testCases = new object[]
            {
      new object[]
      {
        true,
        new int[][]
        {
          new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
          new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
          new int[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
          new int[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
          new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
          new int[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
          new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
          new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
          new int[] {3, 4, 5, 2, 8, 6, 1, 7, 9},
        },
      },
      new object[]
      {
        false,
        new int[][]
        {
          new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
          new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
          new int[] {1, 9, 8, 3, 0, 2, 5, 6, 7},
          new int[] {8, 5, 0, 7, 6, 1, 4, 2, 3},
          new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
          new int[] {7, 0, 3, 9, 2, 4, 8, 5, 6},
          new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
          new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
          new int[] {3, 0, 0, 2, 8, 6, 1, 7, 9},
        },
      },
            };

            [TestMethod]
            public void Test(bool expected, int[][] board) => Assert.AreEqual(expected, Kata.ValidateSolution(board));

            #endregion

        }
    }
}