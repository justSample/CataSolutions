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
    }
}