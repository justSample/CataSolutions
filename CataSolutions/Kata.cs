using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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


        public static string Solve(string s)
        {
            char[] chars = s.ToCharArray();

            int countLower = chars.Where(c => char.IsLower(c)).Count();

            int otherChars = chars.Count() - countLower;

            if (countLower > otherChars || countLower == otherChars)
                return s.ToLower();
            else
                return s.ToUpper();
        }

        public static string BestSolve(string s)
        {
            return s.Count(char.IsLower) < s.Length / 2 ? s.ToUpper() : s.ToLower();
        }


        public static string ToWeirdCase(string s)
        {
            char[] chars = s.ToCharArray();

            int countLength = 0;

            for (int i = 0; i < chars.Length; i++)
            {

                for (int j = i; j < chars.Length; j++)
                {
                    if (chars[j] != ' ')
                        countLength++;
                    else
                        break;
                }

                for (int j = 0; j < countLength; j++, i++)
                {
                    if (j % 2 == 0)
                    {
                        chars[i] = char.ToUpper(chars[i]);
                    }
                    else
                    {
                        chars[i] = char.ToLower(chars[i]);
                    }
                }
                countLength = 0;

            }

            return new string(chars);

        }

        public static string BestToWeirdCase(string s)
        {
            return string.Join(" ",
              s.Split(' ')
              .Select(w => string.Concat(
                w.Select((ch, i) => i % 2 == 0 ? char.ToUpper(ch) : char.ToLower(ch)
              ))));
        }


        public static int[] DeleteNth(int[] arr, int x)
        {
            List<int> toReturn = new List<int>();

            for (int i = 0; i < arr.Length; i++)
                if (toReturn.Where(c => c == arr[i]).Count() != x) toReturn.Add(arr[i]);

            return toReturn.ToArray();
        }

        public static int[] BestDeleteNth(int[] arr, int x)
        {
            return arr.Where((t, i) => arr.Take(i + 1).Count(s => s == t) <= x).ToArray();
        }


        public static string[] inArray(string[] array1, string[] array2)
        {
            List<string> toReturn = new List<string>();

            for (int i = 0; i < array1.Length; i++)
            {
                Regex reg = new Regex(array1[i]);

                for (int j = 0; j < array2.Length; j++)
                {
                    if(reg.Match(array2[j]).Length > 0)
                    {
                        toReturn.Add(array1[i]);
                        break;
                    }
                }
            }

            return toReturn.Distinct().OrderBy(s => s).ToArray();
        }

        public static string[] BestInArray(string[] array1, string[] array2)
        {
            return array1.Distinct()
                         .Where(s1 => array2.Any(s2 => s2.Contains(s1)))
                         .OrderBy(s => s)
                         .ToArray();
        }


        //Заметка. Можно бросать exception чтоб узнать какие данные есть в тестах
        //using System;
        //throw new Exception();

        public static string CleanString(string text)
        {

            List<char> textChars = text.ToList();

            for (int i = 0; i < textChars.Count; i++)
            {
                if(textChars[i] == '#' && i != 0)
                {
                    textChars.RemoveAt(i);
                    textChars.RemoveAt(i - 1);
                    i = -1;
                }
                else if(textChars[i] == '#' && (i == 0 || i == textChars.Count - 1))
                {
                    textChars.RemoveAt(i);
                    i = -1;
                }
            }

            return new string(textChars.ToArray());
        }

        public List<string> wave(string str)
        {

            List<string> toReturn = new List<string>();

            char[] charsStr = str.ToCharArray();

            for (int i = 0; i < str.Length; i++)
            {
                if (charsStr[i] == ' ') continue;

                charsStr[i] = char.ToUpper(charsStr[i]);
                toReturn.Add(new string(charsStr));
                charsStr[i] = char.ToLower(charsStr[i]);
            }

            return toReturn;
        }

        public List<string> bestWave(string str) =>
          str
            .Select((c, i) => str.Substring(0, i) + Char.ToUpper(c) + str.Substring(i + 1))
            .Where(x => x != str)
            .ToList();


        public static int[] MoveZeroes(int[] arr)
        {

            List<int> numbers = arr.ToList().Where(num => num != 0).ToList();

            int countZero = arr.ToList().Where(num => num == 0).ToArray().Length;

            for (int i = 0; i < countZero; i++)
                numbers.Add(0);

            return numbers.ToArray();
        }

        public static int[] BestMoveZeroes(int[] arr)
        {
            return arr.OrderBy(x => x == 0).ToArray();
        }



        public static int FindMissing(List<int> list)
        {
            
            int difference = int.MinValue;
            int indexDifferent = -1;

            for (int i = 0, j = 1; i < list.Count; i++, j++)
            {
                if (j == list.Count) continue;

                int dif = list[j] - list[i];

                if (dif > difference)
                {
                    difference = dif;
                    indexDifferent = i;
                }

            }

            return list[indexDifferent + 1] - (difference / 2);
        }

        public static int BestFindMissing(List<int> list)
        {
            // Figure out the step of the Arithmetic Progression
            int step = (list.Last() - list.First()) / list.Count();
            int current = list.First();

            // Iterate over the list and return the first value which is not present in the Progression
            for (int i = 0; i < list.Count(); ++i)
            {
                if (list[i] != current) { return current; }
                current += step;
            }

            throw new ArgumentException("No missing values were found in the provided list.");
        }


        //https://www.codewars.com/kata/5629db57620258aa9d000014/train/csharp
        public static string Mix(string firstStr, string secondStr)
        {

            List<string> listToReturn = new List<string>();

            Dictionary<char, int> firstCharsDictionary = new Dictionary<char, int>();
            Dictionary<char, int> secondCharsDictionary = new Dictionary<char, int>();

            char[] firstStrChars = firstStr.ToCharArray();
            char[] secondStrChars = secondStr.ToCharArray();

            for (int i = 0; i < secondStrChars.Length; i++)
            {
                if (firstCharsDictionary.ContainsKey(secondStrChars[i])) continue;

                int countInFirstArr = firstStrChars.Where(c => c == secondStrChars[i]).Count();
                firstCharsDictionary.Add(secondStrChars[i], countInFirstArr);

            }

            for (int i = 0; i < firstStrChars.Length; i++)
            {
                if (secondCharsDictionary.Keys.Contains(firstStrChars[i])) continue;

                int countInSecondArr = secondStrChars.Where(c => c == firstStrChars[i]).Count();
                secondCharsDictionary.Add(firstStrChars[i], countInSecondArr);
            }

            firstCharsDictionary.Remove(' ');
            secondCharsDictionary.Remove(' ');

            var tempFirstArr = firstCharsDictionary.Keys.Where(k => !char.IsLetterOrDigit(k)).ToArray();

            for (int i = 0; i < tempFirstArr.Length; i++)
            {
                firstCharsDictionary.Remove(tempFirstArr[i]);
            }

            var tempSecondArr = secondCharsDictionary.Keys.Where(k => !char.IsLetterOrDigit(k)).ToArray();

            for (int i = 0; i < tempSecondArr.Length; i++)
            {
                secondCharsDictionary.Remove(tempSecondArr[i]);
            }

            foreach (var charValue in firstCharsDictionary)
            {

                if (!secondCharsDictionary.ContainsKey(charValue.Key)) continue;

                if (charValue.Value < 2 && secondCharsDictionary[charValue.Key] < 2) continue;

                string toAdd = string.Empty;

                if (secondCharsDictionary[charValue.Key] > charValue.Value)
                {
                    toAdd += "2:";

                    for (int i = 0; i < secondCharsDictionary[charValue.Key]; i++)
                    {
                        toAdd += charValue.Key;
                    }

                }
                else if (secondCharsDictionary[charValue.Key] < charValue.Value)
                {
                    toAdd += "1:";

                    for (int i = 0; i < charValue.Value; i++)
                    {
                        toAdd += charValue.Key;
                    }
                }
                else
                {
                    toAdd += "=:";

                    for (int i = 0; i < charValue.Value; i++)
                    {
                        toAdd += charValue.Key;
                    }

                }


                toAdd += "/";

                listToReturn.Add(toAdd);
            }


            if (listToReturn.Count == 0) return "";


            listToReturn = listToReturn.OrderByDescending(s => s.Count()).ThenByDescending(s => s).ToList();

            if(listToReturn.Last().Last() == '/')
                listToReturn[listToReturn.Count - 1] = listToReturn.Last().Remove(listToReturn.Last().Count() - 1, 1);

            string toReturn = string.Empty;

            for (int i = 0; i < listToReturn.Count; i++)
            {
                toReturn += listToReturn[i];
            }

            // your code
            return toReturn;
        }

    }
}
