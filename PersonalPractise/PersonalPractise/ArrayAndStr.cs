﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PersonalPractise
{
    class ArrayAndStr
    {
        // 面试金典1.1 https://leetcode-cn.com/problems/is-unique-lcci/submissions/
        public bool IsUnique(string astr)
        {
            //HashSet<char> temp = new HashSet<char>();
            //foreach(char s in astr.ToCharArray())
            //{
            //    if (!temp.Contains(s))
            //    {
            //        temp.Add(s);
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //return true;

            for (int i = 0; i < astr.Length; i++)
            {
                for (int j = i + 1; j < astr.Length; j++)
                {
                    if (astr[i] == astr[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // 面试金典1.2 https://leetcode-cn.com/problems/check-permutation-lcci/
        public bool CheckPermutation(string s1, string s2)
        {
            //var _s1 = s1.ToList();
            //var _s2 = s2.ToList();

            //_s1.Sort();
            //_s2.Sort();
            //return new String(_s1.ToArray()) == new string(_s2.ToArray());
            if (s1.Length != s2.Length)
            {
                return false;
            }
            int[] char_set = new int[128];
            for (int i = 0; i < s1.Length; i++)
            {
                char_set[s1[i]]++;
            }

            for (int j = 0; j < s2.Length; j++)
            {
                char_set[s2[j]]--;
                if (char_set[s2[j]] < 0)
                {
                    return false;
                }
            }
            return true;
        }

        // 面试金典1.3 https://leetcode-cn.com/problems/string-to-url-lcci/
        public string ReplaceSpaces(string S, int length)
        {
            int index = 0;
            int space_count = 0;
            for (int i = 0; i < length; i++)
            {
                if (S[i] == ' ')
                {
                    space_count++;
                }
            }
            char[] temp = new char[length + space_count * 2];

            for (int i = 0; i < length; i++)
            {
                if (S[i] == ' ')
                {
                    temp[index++] = '%';
                    temp[index++] = '2';
                    temp[index++] = '0';
                }
                else
                {
                    temp[index++] = S[i];
                }
            }
            return new string(temp);
        }

        // 面试金典1.4 https://leetcode-cn.com/problems/palindrome-permutation-lcci/
        public bool CanPermutePalindrome(string s)
        {
            char[] temp = new char[123];
            foreach (char i in s.ToCharArray())
            {
                temp[i]++;
            }
            int one = 0;
            for (int i = 0; i < 123; i++)
            {
                if (temp[i] == 0 || temp[i] == 2)
                    continue;
                else
                    one++;
            }
            return one <= 1;
        }

        // 面试金典1.5 https://leetcode-cn.com/problems/one-away-lcci/
        public static bool OneEditAway(string first, string second)
        {
            if (first.Length == second.Length)
            {
                var diffCount = 0;
                for (int i = 0; i < first.Length; i++)
                {
                    if (first[i] != second[i])
                        diffCount++;
                    if (diffCount > 1)
                        return false;
                }
            }
            else if (Math.Abs(first.Length - second.Length) > 1)
                return false;
            else
            {
                int index1 = 0;
                int index2 = 0;
                int count = 0;
                while (index1 < first.Length && index2 < second.Length)
                {
                    Console.WriteLine(first[index1] + "," + second[index2]);
                    if (first[index1] != second[index2])
                    {
                        if (first.Length > second.Length)
                            index1++;
                        else
                            index2++;
                        count++;
                    }
                    else
                    {
                        index1++;
                        index2++;
                    }
                    if (count > 1)
                        return false;
                }
            }

            return true;
        }

        // 面试金典1.6 https://leetcode-cn.com/problems/compress-string-lcci/
        public string CompressString(string S)
        {
            if (S.Length == 0)
                return "";
            StringBuilder sbuilder = new StringBuilder();
            int count = 1, index = 0;

            while (index < S.Length)
            {
                if (index == S.Length - 1)
                {
                    sbuilder.Append(S[index]);
                    sbuilder.Append(count);
                    count = 1;
                }
                else if (S[index] == S[index + 1])
                {
                    count++;
                }
                else
                {
                    sbuilder.Append(S[index]);
                    sbuilder.Append(count);
                    count = 1;
                }
                index++;
            }



            string answer = sbuilder.ToString();

            return S.Length > answer.Length ? answer : S;
        }

        // 面试金典1.7 https://leetcode-cn.com/problems/rotate-matrix-lcci/
        public void Rotate(int[][] matrix)
        {
            //int x = 0, y = i;
            //int newX = matrix[i].Length-1-y, newY = x;

            //int temp = matrix[x][y];
            //matrix[x][y] = matrix[newX][newY];

            //x = newX;
            //y = newY;

            //newX = matrix[i].Length - 1 - y;
            //newY = x;
            //matrix[x][y] = matrix[newX][newY];

            //x = newX;
            //y = newY;

            //newX = matrix[i].Length - 1 - y;
            //newY = x;
            //matrix[x][y] = matrix[newX][newY];

            //matrix[newX][newY] = temp;
            int N = matrix[0].Length;
            for (int i = 0; i < N / 2; i++)
            {
                for (int j = 0; j < (N + 1) / 2; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[N - 1 - j][i];
                    matrix[N - 1 - j][i] = matrix[N - 1 - i][N - 1 - j];
                    matrix[N - 1 - i][N - 1 - j] = matrix[j][N - 1 - i];
                    matrix[j][N - 1 - i] = temp;
                }

            }
        }

        // 面试金典1.8 https://leetcode-cn.com/problems/zero-matrix-lcci/
        public void SetZeroes(int[][] matrix)
        {
            bool[] y = new bool[matrix.Length];
            bool[] x = new bool[matrix[0].Length];

            for (int i = 0; i < y.Length; i++)
            {
                for (int j = 0; j < x.Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        y[i] = true;
                        x[j] = true;
                    }
                }
            }

            for (int i = 0; i < y.Length; i++)
            {
                if (y[i])
                {
                    for (int j = 0; j < x.Length; j++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            for (int j = 0; j < x.Length; j++)
            {
                if (x[j])
                {
                    for (int i = 0; i < y.Length; i++)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }

        // 面试金典1.9 https://leetcode-cn.com/problems/string-rotation-lcci/
        public bool IsFlipedString(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return false;
            if (string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2))
                return true;
            string doubleS2 = s2 + s2;
            if (doubleS2.Contains(s1))
                return true;
            return false;
        }

        // 字符
        // 520 检测大写字母
        public bool DetectCapitalUse(string word)
        {
            // 我的版本
            //int n = word.Length;
            //int count = 0;
            //for (int i = 0; i < n; i++)
            //{
            //    if (word[i] >= 'A' && word[i] <= 'Z')
            //    {
            //        count++;
            //    }
            //}

            //return count == n || count == 0 || (count == 1 && word[0] >= 'A' && word[0] <= 'Z');

            // 大佬版本
            int upCount = 0;
            for (int i = 0; i < word.Length; i++)
            {
                // 这里检测大写数量很聪明，而且可以剪枝
                if (char.IsUpper(word[i]) && upCount++ < i)
                {
                    return false;
                }
            }
            return (upCount == word.Length) || (upCount <= 1);
        }

        // 回文串的定义
        // 125 验证回文串
        public bool IsPalindrome(string s)
        {
            int n = s.Length;
            int left = 0, right = n - 1;

            while (left < right)
            {
                while (left < right && !Char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }

                while (left < right && !Char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }

                if (left < right)
                {
                    if (Char.ToLower(s[left]) != Char.ToLower(s[right]))
                    {
                        return false;
                    }
                    left++;
                    right--;
                }
            }

            return true;
        }
        // 公共前缀
        // 14 最长公共前缀
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length < 1 || strs == null)
            {
                return "";
            }
            int len = strs[0].Length;
            int count = strs.Length;
            for (int i = 0; i < len; i++)
            {
                char curr = strs[0][i];
                for (int j = 0; j < count; j++)
                {
                    if (i == strs[j].Length || strs[j][i] != curr)
                    {
                        return strs[0].Substring(0, i);
                    }
                }
            }
            return strs[0];
        }
        // 单词
        // 434 字符串中单词字数
        public int CountSegments(string s)
        {
            if (s == null || s.Length < 1)
            {
                return 0;
            }
            s.Trim();
            string[] words = s.Trim().Split();
            int ans = 0;
            for (int i = 0; i < words.Length; i++)
            {
                string curr = words[i];
                if (curr.Trim().Length > 0)
                {
                    ans++;
                }
            }


            return ans;
        }
        // 58  最后一个单词长度
        public int LengthOfLastWord(string s)
        {
            if (s == null || s.Length < 1)
            {
                return 0;
            }
            int ans = 0;
            string[] words = s.Trim().Split();

            string last = words[words.Length - 1];
            if (last.Trim().Length == last.Length)
            {
                ans = last.Length;
            }


            return ans;
        }
        // 字符串的反转
        // 344 反转字符串
        public void ReverseString(char[] s)
        {
            if (s == null || s.Length < 1)
            {
                return;
            }
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }
        }
        // 541 反转字符串2
        public string ReverseStr(string s, int k)
        {
            char[] characters = s.ToCharArray();
            for (int i = 0; i < s.Length; i += 2 * k)
            {
                int left = i, right = Math.Min(left + k - 1, characters.Length - 1);
                while (left < right)
                {
                    char tmp = characters[left];
                    characters[left] = characters[right];
                    characters[right] = tmp;
                    left++;
                    right--;
                }
            }

            return new string(characters);
        }
        // 557 反转字符串中的单词
        public string ReverseWords(string s)
        {
            string[] strs = s.Split(" ");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strs.Length; i++)
            {
                char[] temp = strs[i].ToCharArray();
                Array.Reverse(temp);
                if (i == strs.Length - 1)
                {
                    sb.Append(new string(temp));
                }
                else
                {
                    sb.Append(new string(temp) + " ");
                }
            }
            return sb.ToString();
        }
        // 151 翻转字符串中的单词 包含空格处理
        public string ReverseWords2(string s)
        {
            return string.Join(" ", s.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse());
        }

        // 字符的统计 
        // 387 字符串的第一个唯一字符
        public int FirstUniqChar(string s)
        {
            if (s == null || s.Length < 1)
            {
                return -1;
            }
            int[] temp = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                temp[s[i] - 'a']++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (temp[s[i] - 'a'] == 1)
                {
                    return i;
                }
            }
            return -1;
        }
        // 389 找不同
        public char FindTheDifference(string s, string t)
        {
            char ans = '';
            int[] temp = new int[26];
            for (int i = 0; i < t.Length; i++)
            {
                temp[t[i] - 'a']++;
            }
            for (int i = 0; i < s.Length; i++)
            {
                temp[s[i] - 'a']--;
            }
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == 1)
                {
                    return (char)('a' + i);
                }
            }
            return ans;
        }
        // 383 赎金信
        public bool CanConstruct(string ransomNote, string magazine)
        {
            int[] temp = new int[26];
            for (int i = 0; i < magazine.Length; i++)
            {
                temp[magazine[i] - 'a']++;
            }

            for (int i = 0; i < ransomNote.Length; i++)
            {
                temp[ransomNote[i] - 'a']--;
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] < 0)
                {
                    return false;
                }
            }

            return true;
        }
        // 242 有效的字母异位词
        public bool IsAnagram(string s, string t)
        {
            int[] temp = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                temp[s[i] - 'a']++;
            }
            for (int i = 0; i < t.Length; i++)
            {
                temp[t[i] - 'a']--;
            }
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != 0)
                {
                    return false;
                }
            }
            return true;
        }
        // 49 字母异位词分组 重点复习，通过Dictionary的方式进行添加
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs == null || strs.Length < 0)
            {
                return new List<IList<string>>();
            }
            Dictionary<string, List<string>> ans = new Dictionary<string, List<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                char[] help = strs[i].ToCharArray();
                Array.Sort(help);
                string key = new string(help);
                if (!ans.ContainsKey(key))
                {
                    ans[key] = new List<string>();
                }
                ans[key].Add(strs[i]);
            }

            return new List<IList<string>>(ans.Values);
        }
        // 451 根据字符出现频率排序 优先队列
        // 657 机器人能否返回原点
        public bool JudgeCircle(string moves)
        {
            int[] place = new int[2];
            for (int i = 0; i < moves.Length; i++)
            {
                switch (moves[i])
                {
                    case 'R':
                        place[1]++;
                        break;
                    case 'L':
                        place[1]--;
                        break;
                    case 'U':
                        place[0]--;
                        break;
                    default:
                        place[0]++;
                        break;
                }
            }
            return place[0] == 0 && place[1] == 0;
        }

        // 551 学生出勤记录1
        public bool CheckRecord(string s)
        {
            return s.IndexOf('A') == s.LastIndexOf('A') && !s.Contains("LLL");
        }

        // 696 计数二进制字串
        public int CountBinarySubstrings(string s)
        {
            return 0;
        }


        // 467 环绕字符串中唯一的字符
        public int FindSubstringInWraproundString(string p)
        {
            return 0;
        }


        // 535 TinyURL的加密与解密 有很多的加密方法
        public class Codec
        {
            Dictionary<string, string> map = new Dictionary<string, string>();
            int num = 0;
            // Encodes a URL to a shortened URL
            public string encode(string longUrl)
            {
                string newUrl = "http://tinyurl.com" + num;
                num++;
                map.Add(newUrl, longUrl);
                return newUrl;
            }

            // Decodes a shortened URL to its original URL.
            public string decode(string shortUrl)
            {
                return map[shortUrl];
            }
        }

        // 数字与字符串之间的转换
        // 299 猜数字游戏
        public string GetHint(string secret, string guess)
        {
            int bullCount = 0;
            int cowCount = 0;
            bool[] visited = new bool[secret.Length];
            IList<char> helper = new List<char>();
            for (int i = 0; i < secret.Length; i++)
            {
                if (secret[i] == guess[i])
                {
                    bullCount++;
                    visited[i] = true;
                }
                else
                {
                    helper.Add(secret[i]);
                }
            }

            for (int i = 0; i < secret.Length; i++)
            {
                if (!visited[i])
                {
                    if (helper.Contains(guess[i]))
                    {
                        helper.Remove(guess[i]);
                        cowCount++;
                    }
                }
            }


            StringBuilder ansBuilder = new StringBuilder();

            ansBuilder.Append(bullCount + "A");
            ansBuilder.Append(cowCount + "B");

            return ansBuilder.ToString();
        }

        // 506 相对名次
        public string[] FindRelativeRanks(int[] nums)
        {
            if (nums == null || nums.Length < 1)
            {
                return new string[0];
            }
            int[] helper = new int[nums.Length];
            Array.Copy(nums, helper, nums.Length);
            Array.Sort(helper);

            string[] ans = new string[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                int index = nums.Length - Array.IndexOf(helper, nums[i]) - 1;
                if (index == 0)
                {
                    ans[i] = "Gold Medal";
                }
                else if (index == 1)
                {
                    ans[i] = "Silver Medal";
                }
                else if (index == 2)
                {
                    ans[i] = "Bronze Medal";
                }
                else
                {
                    ans[i] = (index + 1) + "";
                }
            }

            return ans;
        }

        // 539 最小时间差 注意如何处理开头和结尾的时间
        public int FindMinDifference(IList<string> timePoints)
        {
            if (timePoints == null || timePoints.Count < 2)
            {
                return -1;
            }

            int[] timeCount = new int[timePoints.Count];
            for (int i = 0; i < timePoints.Count; i++)
            {
                string[] temp = timePoints[i].Split(":");
                int hour2min = int.Parse(temp[0]) * 60;
                int min = int.Parse(temp[1]);
                timeCount[i] = hour2min + min;
            }
            Array.Sort(timeCount);
            int ans = int.MaxValue;
            for (int i = 1; i < timeCount.Length; i++)
            {
                int val = timeCount[i] - timeCount[i - 1];
                ans = Math.Min(ans, val);
            }

            return Math.Min(ans, timeCount[0]+1440 - timeCount[timeCount.Length-1]);
        }

        // 553 最优除法 数学法
        public string OptimalDivision(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0] + "";
            }
            else if (nums.Length == 2)
            {
                return nums[0] + "/" + nums[1];
            }
            StringBuilder sb = new StringBuilder(nums[0]+"/("+nums[1]);
            for (int i = 2; i < nums.Length; i++)
            {
                sb.Append("/"+nums[i]);
            }
            sb.Append(")");
            return sb.ToString();
        }

        // 537


        // 592
        // 640
        // 38
        // 443
        // 8
        // 13
        // 12
        // 273
        // 165
        // 481

        // 子序列
        // 392
        // 524
        // 521
        // 552

        // 高精度运算
        // 66
        // 67
        // 415
        // 43
        // 306

        // 字符串变换
        // 482
        // 6
        // 68

        // 字符串匹配
        // 28
        // 686
        // 459
        // 214

        // 中心拓展法
        // 5
        // 647
    }
}
