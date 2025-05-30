﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
                    if (reg.Match(array2[j]).Length > 0)
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
                if (textChars[i] == '#' && i != 0)
                {
                    textChars.RemoveAt(i);
                    textChars.RemoveAt(i - 1);
                    i = -1;
                }
                else if (textChars[i] == '#' && (i == 0 || i == textChars.Count - 1))
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

        #region Strings Mix

        //https://www.codewars.com/kata/5629db57620258aa9d000014/train/csharp
        public static string Mix(string firstStr, string secondStr)
        {
            Dictionary<string, int> pairsFirst = new Dictionary<string, int>();
            Dictionary<string, int> pairsSecond = new Dictionary<string, int>();

            StringMixer mixer = new StringMixer();

            firstStr = new string(firstStr.Where(c => !char.IsWhiteSpace(c) && char.IsLetter(c) && !char.IsUpper(c)).ToArray());
            secondStr = new string(secondStr.Where(c => !char.IsWhiteSpace(c) && char.IsLetter(c) && !char.IsUpper(c)).ToArray());

            foreach (var item in firstStr)
            {
                int count = firstStr.Where(c => c == item).Count();

                if (count <= 1) continue;

                if (!pairsFirst.ContainsKey(item.ToString()))
                {
                    pairsFirst.Add(item.ToString(), count);
                    mixer.Add(new StrInfo(1, item, count));
                }
            }

            foreach (var item in secondStr)
            {
                int count = secondStr.Where(c => c == item).Count();

                if (count <= 1) continue;

                if (!pairsSecond.ContainsKey(item.ToString()))
                {
                    pairsSecond.Add(item.ToString(), count);
                    mixer.Add(new StrInfo(2, item, count));
                }
            }



            return mixer.GetString();
        }

        public class StringMixer
        {
            public List<StrInfo> Info { get; set; }

            public StringMixer()
            {
                Info = new List<StrInfo>();
            }

            public void Add(StrInfo info)
            {
                StrInfo tempInfo = Info.Find(i => i.EqualItem(info));

                if (tempInfo == null)
                {
                    Info.Add(new StrInfo(info));
                }
                else
                {
                    int index = Info.IndexOf(tempInfo);

                    if (info.CountItems > tempInfo.CountItems)
                    {
                        Info[index].AuthorId = info.AuthorId;
                        Info[index].Item = info.Item;
                        Info[index].CountItems = info.CountItems;
                    }
                    else if (info.CountItems < tempInfo.CountItems) /// ???
                    {
                        Info[index].AuthorId = tempInfo.AuthorId;
                        Info[index].Item = tempInfo.Item;
                        Info[index].CountItems = tempInfo.CountItems;
                    }
                    else
                    {
                        Info[index].AuthorId = 0;
                    }
                }


            }

            public string GetString()
            {
                Info = Info
                    .OrderByDescending(info => info.CountItems)
                    .ThenBy(info =>
                    {
                        if (info.AuthorId == 0)
                            return 2;
                        else if (info.AuthorId == 2)
                            return 1;
                        else
                            return 0;
                    })
                    .ThenBy(info => info.Item)
                    .ToList();

                string toReturn = "";

                //2:eeeee/2:yy/=:hh/=:rr

                for (int i = 0; i < Info.Count; i++)
                {
                    if ((i + 1) >= Info.Count)
                    {
                        toReturn += Info[i];
                    }
                    else
                    {
                        toReturn += Info[i] + "/";
                    }
                }

                return toReturn;
            }

        }

        public class StrInfo
        {
            public int AuthorId { get; set; }
            public char Item { get; set; }
            public int CountItems { get; set; }

            public StrInfo() { }
            public StrInfo(StrInfo info)
            {
                AuthorId = info.AuthorId;
                Item = info.Item;
                CountItems = info.CountItems;
            }
            public StrInfo(int authorId, char item, int countItems)
            {
                AuthorId = authorId;
                Item = item;
                CountItems = countItems;
            }

            public bool EqualItem(StrInfo info)
            {
                if (info.Item == Item)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public override string ToString()
            {
                char authorMark;
                if (AuthorId == 0)
                {
                    authorMark = '=';
                }
                else
                {
                    authorMark = AuthorId.ToString()[0];
                }

                string buf = "";

                for (int i = 0; i < CountItems; i++)
                {
                    buf += Item;
                }

                //Example: 1:aaaa, где 1 - id, aaaa - count char
                return $"{authorMark}:{buf}";
            }

        }

        #endregion

        //бля, чувак решил это в 4 сука строчки ахахахаххахаа
        //А у меня оптимизированнее
        public static int SumIntervals((int, int)[] intervals)
        {
            List<int> countIntervals = new List<int>();

            Dictionary<int, int> totalInterval = new Dictionary<int, int>();

            foreach (var itemInt in intervals)
            {
                List<int> toAdd = new List<int>();

                for (int i = itemInt.Item1; i < itemInt.Item2; i++)
                {
                    if (totalInterval.ContainsKey(i)) continue;

                    toAdd.Add(i);
                    totalInterval.Add(i, i);
                }

                countIntervals.Add(toAdd.Count);

            }

            int result = 0;

            for (int i = 0; i < countIntervals.Count; i++)
            {
                result += countIntervals[i];
            }

            return result;
        }

        public static int BestSumIntervals((int, int)[] intervals)
        {
            return intervals
              .SelectMany(i => Enumerable.Range(i.Item1, i.Item2 - i.Item1))
              .Distinct()
              .Count();
        }


        //Задача на будущее
        //https://www.codewars.com/kata/52685f7382004e774f0001f7/train/csharp
        public static string GetReadableTime(int seconds)
        {
            int bufTime = seconds;

            int hours = 0;

            for (int i = 1; 0 <= (bufTime - 3600); i++)
            {
                hours++;
                bufTime -= 3600;
            }

            int min = 0;

            for (int i = 1; 0 <= (bufTime - 60); i++)
            {
                min++;
                bufTime -= 60;
            }

            int sec = bufTime;

            string result = $"{hours.ToString("00")}:{min.ToString("00")}:{sec.ToString("00")}";

            return result;
        }

        public static string BestGetReadableTime(int seconds)
        {
            return string.Format("{0:d2}:{1:d2}:{2:d2}", seconds / 3600, seconds / 60 % 60, seconds % 60);
        }



        //https://www.codewars.com/kata/521c2db8ddc89b9b7a0000c1/train/csharp Задача на будущее
        //Later



        //Мой код работает не хуже остальных. В некоторых случаях даже лучше
        //Единственное что можно нормально исправить, это замена цифр этих бесполезных на умножение
        // sec = seconds
        // min = seconds - (60)
        // hour = seconds - (60 * 60)
        // days = seconds - (60 * 60 * 24)
        // year = seconds - (60 * 60 * 24 * 365)
        // Так будет выглядеть более лаконично что ли
        public static string FormatDuration(int seconds)
        {
            int years = 0;
            int days = 0;
            int hours = 0;
            int min = 0;
            int sec = 0;

            int bufTime = seconds;

            for (; 0 <= (bufTime - 31536000);)
            {
                years++;
                bufTime -= 31536000;
            }

            for (; 0 <= (bufTime - 86400);)
            {
                days++;
                bufTime -= 86400;
            }

            for (; 0 <= (bufTime - 3600);)
            {
                hours++;
                bufTime -= 3600;
            }

            for (; 0 <= (bufTime - 60);)
            {
                min++;
                bufTime -= 60;
            }

            sec = bufTime;

            List<string> toReturn = new List<string>();

            if (years != 0)
            {
                if (years > 1)
                {
                    toReturn.Add("{0}" + years + " years{1}");
                }
                else
                {
                    toReturn.Add("{0}" + years + " year{1}");
                }
            }

            if (days != 0)
            {
                if (days > 1)
                {
                    toReturn.Add("{0}" + days + " days{1}");
                }
                else
                {
                    toReturn.Add("{0}" + days + " day{1}");
                }
            }

            if (hours != 0)
            {
                if (hours > 1)
                {
                    toReturn.Add("{0}" + hours + " hours{1}");
                }
                else
                {
                    toReturn.Add("{0}" + hours + " hour{1}");
                }
            }

            if (min != 0)
            {
                if (min > 1)
                {
                    toReturn.Add("{0}" + min + " minutes{1}");
                }
                else
                {
                    toReturn.Add("{0}" + min + " minute{1}");
                }
            }

            if (sec != 0)
            {
                if (sec > 1)
                {
                    toReturn.Add("{0}" + sec + " seconds{1}");
                }
                else
                {
                    toReturn.Add("{0}" + sec + " second{1}");
                }
            }

            if (toReturn.Count == 0)
                return "now";

            if (toReturn.Count == 1)
                toReturn[toReturn.Count - 1] = string.Format(toReturn[toReturn.Count - 1], "", "");

            if (toReturn.Count > 1)
            {
                for (int i = 0; i < toReturn.Count; i++)
                {
                    if (i == toReturn.Count - 2)
                    {
                        toReturn[i] = string.Format(toReturn[i], "", "");
                        toReturn[i + 1] = string.Format(toReturn[i + 1], " and ", "");
                        break;
                    }
                    else if (i == 0)
                    {
                        toReturn[i] = string.Format(toReturn[i], "", ", ");
                        continue;
                    }
                    else
                    {
                        toReturn[i] = string.Format(toReturn[i], "", ", ");

                    }

                }
            }

            string completeResult = "";

            for (int i = 0; i < toReturn.Count; i++)
            {
                completeResult += toReturn[i];
            }

            //Enter Code here
            return completeResult;
        }

        //У меня проходят все тесты.... Но почему-то не проходят на сайте. Проверял на входе и выходе значения... 
        //Такое чувство, они меняются когда попадают на тест
        public static long NextBiggerNumber(long n)
        {
            string str = GetNumbers(n);
            for (long i = n + 1; i <= long.Parse(str); i++)
            {
                if (GetNumbers(n) == GetNumbers(i))
                {
                    return i;
                }
            }
            return -1;
        }

        public static string GetNumbers(long number)
        {
            return string.Join("", number.ToString().ToCharArray().OrderByDescending(x => x));
        }

        //Я не знаю почему тут не работало как надо, но у него почему-то работает :(
        public static long BestNextBiggerNumber(long n)
        {
            string nString = string.Concat(n.ToString().OrderByDescending(i => i));
            if (nString == n.ToString()) return -1;
            do
            {
                n++;
            } while (!string.Equals(string.Concat(n.ToString().OrderByDescending(i => i)), nString));
            return n;
        }


        #region Partition (number theory)

        //https://www.codewars.com/kata/55cf3b567fc0e02b0b00000b/train/csharp

        //enum(5) -> [[5],[4,1],[3,2],[3,1,1],[2,2,1],[2,1,1,1],[1,1,1,1,1]]
        //enum(4) -> [[4],[3,1],[2,2],[2,1,1],[1,1,1,1]]

        ///Есть целое число
        ///Нужно последовательно уменьшать на 1
        ///Но не каждый раз.
        ///При переходе на другое число, нужно уменьшать и прибавлять другое
        ///5 - 0 = 5                = [5]  // 0
        ///5 - 1 = 4, 4 - (4 - 1) = 1 = [4, 1]// 1
        ///5 - 2 = 3, 3 - (3 - 1) = 2 = [3, 2]// 2
        ///5 - 3 = 2, 2 - (2 - 1) =                      // 3


        public static string Part(long n)
        {
            var partitionArrs = GetAllUniqueParts(n);

            var prodArr = GetProd(partitionArrs);

            int range = GetRange(prodArr);
            double avg = GetAvg(prodArr);
            float med = GetMedian(prodArr);

            string toReturn = string.Format("Range: {0} Average: {1} Median: {2}", range, avg.ToString("0.00", new NumberFormatInfo()).Replace(',', '.'), med.ToString("0.00").Replace(',', '.'));

            return toReturn;
        }

        private static int[][] GetAllUniqueParts(long n)
        {
            int[] p = new int[n]; // An array to store a partition
            int k = 0; // Index of last element in a partition
            p[k] = (int)n; // Initialize first partition as number itself

            List<int[]> temp = new List<int[]>();

            // This loop first prints current partition then generates next
            // partition. The loop stops when the current partition has all 1s
            while (true)
            {

                // print current partition
                //printArray(p, k + 1);
                int[] tempArr = new int[k + 1];
                Array.Copy(p, tempArr, (k + 1));
                temp.Add(tempArr);
                // Generate next partition

                // Find the rightmost non-one value in p[]. Also, update the
                // rem_val so that we know how much value can be accommodated
                int rem_val = 0;
                while (k >= 0 && p[k] == 1)
                {
                    rem_val += p[k];
                    k--;
                }

                // if k < 0, all the values are 1 so there are no more partitions
                if (k < 0) break;

                // Decrease the p[k] found above and adjust the rem_val
                p[k]--;
                rem_val++;


                // If rem_val is more, then the sorted order is violated. Divide
                // rem_val in different values of size p[k] and copy these values at
                // different positions after p[k]
                while (rem_val > p[k])
                {
                    p[k + 1] = p[k];
                    rem_val = rem_val - p[k];
                    k++;
                }

                // Copy rem_val to next position and increment position
                p[k + 1] = rem_val;
                k++;
            }

            return temp.ToArray();
        }

        private static int[] GetProd(int[][] pertitionArrs)
        {

            List<int> toReturn = new List<int>(pertitionArrs.Length);


            for (int i = 0; i < pertitionArrs.Length; i++)
            {
                int prod = 1;
                for (int j = 0; j < pertitionArrs[i].Length; j++)
                {
                    prod *= pertitionArrs[i][j];
                }
                toReturn.Add(prod);
            }


            return toReturn.Distinct().OrderBy(i => i).ToArray();
        }

        private static int GetRange(int[] prod)
        {
            int max = prod.Max();
            int min = prod.Min();

            return max - min;
        }

        private static double GetAvg(int[] prod)
        {
            double sum = 0;

            for (int i = 0; i < prod.Length; i++)
            {
                sum += prod[i];
            }

            double avg = ((double)sum / (double)prod.Length);

            return avg;
        }

        private static float GetMedian(int[] prod)
        {

            int lenghtAllArr = prod.Length;

            if ((lenghtAllArr % 2) == 0)
            {
                int firstIndexArr = lenghtAllArr / 2;
                int secondIndexArr = firstIndexArr - 1;

                return (((float)prod[firstIndexArr] + (float)prod[secondIndexArr]) / 2f);

            }
            else
            {
                int midleIndex = lenghtAllArr / 2;

                return (float)prod[midleIndex];
            }
        }

        #endregion


        public static string StripComments(string text, string[] commentSymbols)
        {
            List<char> textChars = text.ToList();

            int beginIndex = 0;
            int endIndex = 0;
            int countLine = 0;

            string toReturn = "";

            for (int i = 0; i < textChars.Count; i++)
            {

                if (textChars[i] == '\n' || i == textChars.Count - 1)
                {
                    bool isHaveEnv = true;

                    endIndex = i;

                    string line = new string(textChars.ToArray());

                    countLine++;

                    line = line.Substring(beginIndex, countLine);

                    for (int j = 0; j < commentSymbols.Length; j++)
                    {
                        if (line.Contains(commentSymbols[j]))
                        {
                            int symbolIndex = line.IndexOf(commentSymbols[j]);
                            int razdelIIndex = line.IndexOf('\n');

                            if (razdelIIndex == -1)
                            {
                                isHaveEnv = false;
                                line = line.Remove(symbolIndex);
                                continue;
                            }

                            int count = razdelIIndex - symbolIndex;

                            line = line.Remove(symbolIndex, count);
                        }
                    }

                    if (line.IndexOf('\n') == -1)
                        isHaveEnv = false;

                    line = line.TrimEnd();

                    if (isHaveEnv)
                        line += '\n';

                    toReturn += line;

                    beginIndex = (i + 1);

                    countLine = 0;

                }
                else
                {
                    countLine++;
                }


            }

            return toReturn;

        }

        //Бля, красиво
        public static string BestStripComments(string text, string[] commentSymbols)
        {
            string[] lines = text.Split(new[] { "\n" }, StringSplitOptions.None);
            lines = lines.Select(x => x.Split(commentSymbols, StringSplitOptions.None).First().TrimEnd()).ToArray();
            return string.Join("\n", lines);
        }



        #region Line Safari - Is that a line?

        private const char LEFT_RIGHT = '-';
        private const char UP_DOWN = '|';
        private const char CORNER = '+';

        private const char POINT = 'X';
        private const char FREE_SPACE = ' ';

        private const char COMPLETE_STEP = '.';


        public enum TypeResult
        {
            Step,
            Complete,
            Error
        }

        public enum TypeCell
        {
            LeftRight,
            UpDown,
            Corner,
            Point,
            FreeSpace,
            CompleteStep
        }

        public enum TypeDir
        {
            LeftRight,
            UpDown,
            Corner,
            Any
        }

        public class Vector2
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Vector2()
            {
                X = -1;
                Y = -1;
            }

            public Vector2(int x, int y)
            {
                X = x;
                Y = y;
            }

            public Vector2(Vector2 vector)
            {
                X = vector.X;
                Y = vector.Y;
            }

            public static Vector2 operator +(Vector2 v1, Vector2 v2)
            {
                return new Vector2() { X = (v1.X + v2.X), Y = (v1.Y + v2.Y) };
            }

            public static Vector2 operator -(Vector2 v1, Vector2 v2)
            {
                return new Vector2() { X = (v1.X - v2.X), Y = (v1.Y - v2.Y) };
            }

        }

        public class Cell
        {

            public Vector2 Position { get; private set; }

            public char Mark { get; private set; }

            public TypeCell CellType { get; set; }

            public Cell(Vector2 pos, char mark)
            {
                Position = new Vector2(pos);
                Mark = mark;

                InitTypeCell();
            }

            private void InitTypeCell()
            {
                switch (Mark)
                {
                    case LEFT_RIGHT:
                        CellType = TypeCell.LeftRight;
                        break;
                    case UP_DOWN:
                        CellType = TypeCell.UpDown;
                        break;
                    case CORNER:
                        CellType = TypeCell.Corner;
                        break;
                    case POINT:
                        CellType = TypeCell.Point;
                        break;
                    case FREE_SPACE:
                        CellType = TypeCell.FreeSpace;
                        break;
                    case COMPLETE_STEP:
                        CellType = TypeCell.CompleteStep;
                        break;

                }
            }

            public void SetMark(char mark)
            {
                Mark = mark;
                InitTypeCell();
            }

        }

        public class Board
        {

            public Cell[][] Cells { get; private set; }

            public Board(char[][] grid)
            {
                InitCells(grid);
            }

            private void InitCells(char[][] grid)
            {

                Cells = new Cell[grid.Length][];

                for (int i = 0; i < grid.Length; i++)
                {
                    Cells[i] = new Cell[grid[i].Length];

                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        Cells[i][j] = new Cell(new Vector2(j, i), grid[i][j]);
                    }
                }

            }

            public Cell GetCell(Vector2 pos)
            {
                try
                {
                    var cell = Cells[pos.Y][pos.X];
                    return cell;
                }
                catch
                {
                    return null;
                }
            }

            public void SetCharCell(Vector2 pos, TypeCell type)
            {

                switch (type)
                {

                    case TypeCell.CompleteStep:
                        Cells[pos.Y][pos.X].SetMark(COMPLETE_STEP);
                        break;
                    case TypeCell.Corner:
                        Cells[pos.Y][pos.X].SetMark(CORNER);
                        break;
                    case TypeCell.FreeSpace:
                        Cells[pos.Y][pos.X].SetMark(FREE_SPACE);
                        break;
                    case TypeCell.LeftRight:
                        Cells[pos.Y][pos.X].SetMark(LEFT_RIGHT);
                        break;
                    case TypeCell.Point:
                        Cells[pos.Y][pos.X].SetMark(POINT);
                        break;
                    case TypeCell.UpDown:
                        Cells[pos.Y][pos.X].SetMark(UP_DOWN);
                        break;

                }


            }

        }

        public class Bot
        {

            public Vector2 Position { get; private set; }

            public TypeDir CurrentDir { get; private set; }

            public Board Board { get; private set; }

            public Bot(char[][] grid)
            {
                Board = new Board(grid);
                CurrentDir = TypeDir.Any;
                InitStartPosition();
            }

            private void InitStartPosition()
            {
                bool isPoint = false;
                for (int i = 0; i < Board.Cells.Length; i++)
                {
                    for (int j = 0; j < Board.Cells[i].Length; j++)
                    {
                        if (Board.Cells[i][j].Mark == POINT)
                        {
                            Position = new Vector2(Board.Cells[i][j].Position);
                            isPoint = true;
                            break;
                        }
                    }
                    if (isPoint)
                        break;
                }


            }

            public TypeResult Move()
            {

                Cell nextCell = SearchNextStep();

                if (nextCell == null) return TypeResult.Error;

                Cell currentCell = Board.GetCell(Position);

                switch (nextCell.CellType)
                {
                    case TypeCell.LeftRight:

                        CurrentDir = TypeDir.LeftRight;
                        Board.SetCharCell(currentCell.Position, TypeCell.CompleteStep);
                        Position = new Vector2(nextCell.Position);
                        return TypeResult.Step;
                        break;
                    case TypeCell.UpDown:

                        CurrentDir = TypeDir.UpDown;
                        Board.SetCharCell(currentCell.Position, TypeCell.CompleteStep);
                        Position = new Vector2(nextCell.Position);
                        return TypeResult.Step;
                        break;
                    case TypeCell.Corner:

                        if (CurrentDir == TypeDir.LeftRight)
                        {
                            CurrentDir = TypeDir.UpDown;
                            Board.SetCharCell(currentCell.Position, TypeCell.CompleteStep);
                            Position = new Vector2(nextCell.Position);
                            return TypeResult.Step;
                        }
                        else if (CurrentDir == TypeDir.UpDown)
                        {
                            CurrentDir = TypeDir.LeftRight;
                            Board.SetCharCell(currentCell.Position, TypeCell.CompleteStep);
                            Position = new Vector2(nextCell.Position);
                            return TypeResult.Step;
                        }
                        else if (currentCell.CellType == TypeCell.Corner)
                        {
                            if (CurrentDir == TypeDir.LeftRight)
                            {
                                //UpDown
                                CurrentDir = TypeDir.UpDown;
                                Board.SetCharCell(currentCell.Position, TypeCell.CompleteStep);
                                Position = new Vector2(nextCell.Position);
                                return TypeResult.Step;
                            }
                            else if (CurrentDir == TypeDir.UpDown)
                            {
                                //LeftRight
                                CurrentDir = TypeDir.LeftRight;
                                Board.SetCharCell(currentCell.Position, TypeCell.CompleteStep);
                                Position = new Vector2(nextCell.Position);
                                return TypeResult.Step;
                            }
                        }

                        break;
                    case TypeCell.Point:
                        Board.SetCharCell(currentCell.Position, TypeCell.CompleteStep);
                        Position = new Vector2(nextCell.Position);
                        return TypeResult.Complete;
                        break;
                }

                return TypeResult.Error;
            }


            private Cell SearchNextStep()
            {

                Cell up = CellUp();
                Cell down = CellDown();
                Cell left = CellLeft();
                Cell right = CellRight();

                if (left != null)
                {
                    CurrentDir = TypeDir.LeftRight;
                    return left;
                }
                else if (right != null)
                {
                    CurrentDir = TypeDir.LeftRight;
                    return right;
                }
                else if (up != null)
                {
                    CurrentDir = TypeDir.UpDown;
                    return up;
                }
                else if (down != null)
                {
                    CurrentDir = TypeDir.UpDown;
                    return down;
                }

                return null;
            }

            private Cell CellUp()
            {
                Vector2 curPos = new Vector2(Position);

                curPos.Y--;

                Cell cell = Board.GetCell(curPos);

                if (cell != null && cell.CellType != TypeCell.CompleteStep && cell.CellType != TypeCell.FreeSpace && (CurrentDir == TypeDir.Any || CurrentDir == TypeDir.UpDown))
                    return cell;
                else
                    return null;
            }

            private Cell CellDown()
            {
                Vector2 curPos = new Vector2(Position);
                curPos.Y++;

                Cell cell = Board.GetCell(curPos);

                if (cell != null && cell.CellType != TypeCell.CompleteStep && cell.CellType != TypeCell.FreeSpace && (CurrentDir == TypeDir.Any || CurrentDir == TypeDir.UpDown))
                    return cell;
                else
                    return null;
            }

            private Cell CellLeft()
            {
                Vector2 curPos = new Vector2(Position);
                curPos.X--;

                Cell cell = Board.GetCell(curPos);

                if (cell != null && cell.CellType != TypeCell.CompleteStep && cell.CellType != TypeCell.FreeSpace && (CurrentDir == TypeDir.Any || CurrentDir == TypeDir.LeftRight))
                    return cell;
                else
                    return null;
            }

            private Cell CellRight()
            {
                Vector2 curPos = new Vector2(Position);
                curPos.X++;

                Cell cell = Board.GetCell(curPos);

                if (cell != null && cell.CellType != TypeCell.CompleteStep && cell.CellType != TypeCell.FreeSpace && (CurrentDir == TypeDir.Any || CurrentDir == TypeDir.LeftRight))
                    return cell;
                else
                    return null;
            }

        }

        public static bool Line(char[][] grid)
        {
            Bot bot = new Bot(grid);

            do
            {

                var result = bot.Move();

                WriteBoard(bot.Board);

                if (result == TypeResult.Complete)
                {
                    return true;
                }
                else if (result == TypeResult.Error)
                {
                    return false;
                }

            } while (true);

        }

        private static void WriteBoard(Board board)
        {

            for (int i = 0; i < board.Cells.Length; i++)
            {
                for (int j = 0; j < board.Cells[i].Length; j++)
                {
                    System.Diagnostics.Debug.Write(board.Cells[i][j].Mark);
                }
                System.Diagnostics.Debug.WriteLine("");
            }

        }

        #endregion


        public static int[] MoveZeroesRemember(int[] arr)
        {
            int countZeros = arr.Where(a => a == 0).Count();

            List<int> newArr = arr.Where(a => a != 0).ToList();

            for (int i = 0; i < countZeros; i++)
            {
                newArr.Add(0);
            }

            return newArr.ToArray();
        }


        public static int ClosestMultiple10(int num)
        {
            int howMuch = num % 10;

            int result = num;

            if (howMuch < 5)
            {
                result -= howMuch;
            }
            else
            {
                result += (10 - howMuch);
            }

            return result;
        }

        public int BestClosestMultiple10(int num)
        {
            return (int)(Math.Round(num / 10d, MidpointRounding.AwayFromZero) * 10);
        }

        public static string DiamondPrint(int countStages)
        {
            if (countStages % 2 == 0 || countStages < 0) return null;

            int center = (int)Math.Floor((double)countStages / 2d);

            string[] lines = new string[countStages];

            for (int i = 0; i < countStages; i++)
            {
                if (i == center)
                {
                    string line = string.Concat(new string('*', i * 2 + 1), "\n");
                    lines[i] = line;
                    break;
                }
                else
                {
                    int spaceCount = (center - i);
                    string line = string.Concat(new string(' ', spaceCount),
                                          new string('*', i * 2 + 1),
                                          "\n");
                    lines[i] = line;
                    lines[lines.Length - 1 - i] = line;
                }


            }

            return string.Join("", lines);
        }

        public static string BestDiamondPrint(int n)
        {
            if (n % 2 == 0 || n < 0)
            {
                return null;
            }

            int middle = n / 2;
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < n; index++)
            {
                sb.Append(' ', Math.Abs(middle - index));
                sb.Append('*', n - Math.Abs(middle - index) * 2);
                sb.Append("\n");
            }

            return sb.ToString();
        }


        public static bool AreTheySameComp(int[] a, int[] b)
        {
            if (a == null || b == null) return false;

            List<int> listA = new List<int>(a);
            List<int> listB = new List<int>(b);

            for (int i = 0; listA.Count > 0 && listB.Count > 0;)
            {
                int sqr = listA[i] * listA[i];
                bool find = listB.Any(num => num == sqr);

                if (!find) return find;

                listA.RemoveAt(i);
                int bIndex = listB.FindIndex(num => num == sqr);
                if (bIndex != -1)
                    listB.RemoveAt(bIndex);
            }

            if (listA.Count == 0 && listB.Count == 0) return true;

            return false;
        }

        public static bool BestAreTheySameComp(int[] a, int[] b)
        {
            if ((a == null) || (b == null))
            {
                return false;
            }

            int[] copy = a.Select(x => x * x).ToArray();
            Array.Sort(copy);
            Array.Sort(b);

            return copy.SequenceEqual(b);
        }

        #region Spiralize

        public static int[,] Spiralize(int size)
        {
            return new Spiralizer().GetSpiral(size);
        }

        public enum Direction
        {
            UP,
            RIGHT,
            DOWN,
            LEFT
        }

        public class Spiralizer
        {
            private int[,] _spiral;
            private Position _posStep = new Position();
            private Direction _direction = Direction.RIGHT;

            public int[,] GetSpiral(int size)
            {
                _spiral = new int[size, size];

                for (int y = 0; y < size; y++)
                {
                    for (; y < 3; y++)
                    {

                        MakeStep(size);
                        NextDir();
                    }

                    int delimiter = 0;
                    int countStep = size - 2;

                    for (; y < size; y++)
                    {
                        if(delimiter < 2)
                        {
                            MakeStep(countStep);
                            NextDir();
                            delimiter++;
                        }
                        else
                        {
                            countStep -= 2;
                            delimiter = 0;
                            y--;
                        }
                    }
                }
                return _spiral;
            }


            private void NextDir()
            {
                switch (_direction)
                {
                    case Direction.UP:
                        _direction = Direction.RIGHT;
                        break;
                    case Direction.RIGHT:
                        _direction = Direction.DOWN;
                        break;
                    case Direction.DOWN:
                        _direction = Direction.LEFT;
                        break;
                    case Direction.LEFT:
                        _direction = Direction.UP;
                        break;

                }
            }

            private void MakeStep(int countStep)
            {
                switch (_direction)
                {
                    case Direction.UP:
                        for (int i = 0; i < countStep; i++)
                        {
                            _spiral[_posStep.Y, _posStep.X] = 1;
                            _posStep.Y--;
                        }
                        _posStep.Y++;
                        break;

                    case Direction.RIGHT:
                        for (int i = 0; i < countStep; i++)
                        {
                            _spiral[_posStep.Y, _posStep.X] = 1;
                            _posStep.X++;
                        }
                        _posStep.X--;
                        break;

                    case Direction.DOWN:
                        for (int i = 0; i < countStep; i++)
                        {
                            _spiral[_posStep.Y, _posStep.X] = 1;
                            _posStep.Y++;
                        }
                        _posStep.Y--;
                        break;

                    case Direction.LEFT:

                        for (int i = 0; i < countStep; i++)
                        {
                            _spiral[_posStep.Y, _posStep.X] = 1;
                            _posStep.X--;
                        }
                        _posStep.X++;
                        break;

                }
            }

        }

        public class Position
        {
            public int X { get; set; } 
            public int Y { get; set; }

            public Position()
            {
                X = 0;
                Y = 0;
            }

        }

        #endregion

        #region Sudoku

        public static bool ValidateSolution(int[][] board)
        {
            SudokyBlocks blocks = new SudokyBlocks(board);

            for (int i = 0; i < blocks.Blocks.Count; i++)
            {
                if (!blocks.Blocks[i].IsCorrect()) return false;
            }

            List<SudokuElement> elements = new List<SudokuElement>();

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    elements.Add(new SudokuElement(board[i][j]));
                    elements[elements.Count - 1].TakeHorizontal(board, j);
                    elements[elements.Count - 1].TakeVertical(board, i);
                }
            }

            for (int i = 0; i < elements.Count; i++)
            {
                if (!elements[i].IsRight()) return false;
            }

            return true;
        }

        public class SudokuElement
        {
            private int _element;

            private int[] _horizontal;
            private int[] _vertical;

            public SudokuElement(int element)
            {
                _element = element;
            }

            public void TakeVertical(int[][] board, int posX)
            {
                _vertical = new int[board.Length];

                for (int y = 0; y < board.Length; y++)
                {
                    _vertical[y] = board[y][posX];

                }

            }

            public void TakeHorizontal(int[][] board, int posY)
            {
                _horizontal = new int[board[posY].Length];

                for (int x = 0; x < board[posY].Length; x++)
                {
                    _horizontal[x] = board[posY][x];

                }
            }

            public bool IsRight()
            {

                int countHorizontal = _horizontal.Where(x => x == _element).Count();
                int countVertical = _vertical.Where(y => y == _element).Count();

                if(countHorizontal > 1 || countVertical > 1) 
                    return false;
                return true;

            }

        }

        public class SudokyBlocks
        {

            private List<int[]> _lines;

            public List<SudokyBlock> Blocks;

            public SudokyBlocks(int[][] board)
            {
                _lines = new List<int[]>();
                Blocks = new List<SudokyBlock>();

                int maxStage = (int)Math.Sqrt(board.Length);

                for (int stage = 0; stage < maxStage; stage++)
                {
                    for (int y = 0; y < board.Length; y++)
                    {
                        int[] line = new int[3];

                        for (int x = stage * 3, i = 0; x < ((stage + 1) * 3); x++, i++)
                        {
                            line[i] = board[y][x];
                        }

                        _lines.Add(line);

                        if(_lines.Count > 2)
                        {
                            int[] toLine = new int[9];

                            int indexLine = 0;

                            for (int i = 0; i < _lines.Count; i++)
                            {
                                for (int j = 0; j < _lines[i].Length; j++)
                                {
                                    toLine[indexLine] = _lines[i][j];
                                    indexLine++;
                                }
                            }
                            Blocks.Add(new SudokyBlock(toLine));
                            _lines.Clear();
                        }

                    }

                }
            }

        }

        public class SudokyBlock
        {

            private int[] lineBlock;

            public SudokyBlock(int[] block)
            {
                lineBlock = block;
            }

            public bool IsCorrect()
            {
                for (int i = 1; i <= 10; i++)
                {
                    int countFind = lineBlock.Where(x => x == i).Count();
                    if (countFind > 1) return false;
                }

                return true;
            }

        }


        #region best

        private static int[] nineNumbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public static bool BestValidateSolution(int[][] board)
        {
            for (int i = 0; i < 9; ++i)
            {
                var row = new List<int>();
                for (int j = 0; j < 9; ++j) row.Add(board[i][j]);
                if (!ValidateNine(row)) return false;

                var col = new List<int>();
                for (int j = 0; j < 9; ++j) col.Add(board[j][i]);
                if (!ValidateNine(col)) return false;

                var block = new List<int>();
                int br = (i / 3) * 3;
                int bc = (i % 3) * 3;
                for (int j = 0; j < 9; ++j) block.Add(board[br + j / 3][bc + j % 3]);
                if (!ValidateNine(block)) return false;
            }

            return true;
        }

        private static bool ValidateNine(IList<int> nine)
        {
            return nineNumbers.All(nine.Contains);
        }

        #endregion

        #endregion

        #region To square(root) or not to square(root)

        public static int[] SquareOrSquareRoot(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                double resultSqrt = Math.Sqrt(array[i]);

                string tempStr = resultSqrt.ToString();

                if (tempStr.IndexOf(',') != -1)
                    array[i] *= array[i];
                else
                    array[i] = (int)resultSqrt;
            }

            return array;
        }

        public static int[] BestSquareOrSquareRoot(int[] array)
        {
            return array.Select(x => (int)(Math.Sqrt(x) % 1 == 0 ? Math.Sqrt(x) : x * x)).ToArray();
        }

        #endregion

    }
}
