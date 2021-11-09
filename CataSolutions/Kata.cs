using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CataSolutions
{
    public class Kata
    {

        public static string[] TowerBuilder(int nFloors)
        {
            //if (nFloors == 1) return new string[] { "*" };

            char towerChar = '*';

            string[] tower = new string[nFloors];

            int totalCount = 1;

            for (int i = 1; i < nFloors; i++)
            {
                totalCount += 2;
            }


            int increesingNumber = 1;

            for (int i = 0; i < tower.Length; i++)
            {
                char[] rowChars = new char[totalCount];

                for (int j = 0; j < totalCount; j++)
                {
                    rowChars[j] = ' ';
                }

                for (int j = 0; j < increesingNumber; j++)
                {
                    int indexForSetChar = (totalCount / 2) + i;

                    indexForSetChar -= j;

                    rowChars[indexForSetChar] = towerChar;

                }

                tower[i] = new string(rowChars);

                increesingNumber += 2;
            }

            return tower;
        }

        public static string[] BestPractikTowerBuilder(int nFloors)
        {
            var result = new string[nFloors];
            for (int i = 0; i < nFloors; i++)
                result[i] = string.Concat(new string(' ', nFloors - i - 1),
                                          new string('*', i * 2 + 1),
                                          new string(' ', nFloors - i - 1));
            return result;
        }

    }
}
