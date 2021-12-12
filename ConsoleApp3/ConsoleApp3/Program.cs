using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };
            //ThreeSum(nums);
            RomanToInt("DCCXLVII");
        }
        public static IList<IList<int>> ThreeSum(int[] nums)
        {

            List<IList<int>> res = new List<IList<int>>();
            if (nums == null || nums.Length < 3)
                return res;

            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                // If nums[i] > 0, we can't find a valid triplet, since nums is sorted and nums[i] the smallest number.
                // To avoid duplicate triplets, we should skip nums[i] if nums[i] == nums[i-1]
                if (nums[i] > 0 || (i > 0 && nums[i] == nums[i - 1]))
                    continue;

                int left = i + 1, right = nums.Length - 1;
                while (left < right)
                {
                    if (nums[i] + nums[left] + nums[right] == 0)
                    {
                        res.Add(new List<int>() { nums[i], nums[left], nums[right] });
                        left++;
                        right--;

                        while (left < right && nums[left] == nums[left - 1])
                            left++;
                        while (left < right && nums[right] == nums[right + 1])
                            right--;
                    }
                    else if (nums[i] + nums[left] + nums[right] > 0)

                        right--;
                    else
                        left++;
                }
            }

            return res;
        }
        public bool IsPalindrome(int x)
        {
            string test = "";
            if (x < 0) { return false; }
            var test2 = x.ToString().Reverse();
            foreach (char a in test2)
            {
                test = test + a;
            }
            if (test.Equals(x.ToString())) return true;
            return false;
        }
        public static int RomanToInt(string s)
        {
            if (String.IsNullOrEmpty(s)) return 0;
            int ans = 0;
            Dictionary<string, int> roman = new Dictionary<string, int>();
            roman.Add("M", 1000);
            roman.Add("D", 500);
            roman.Add("C", 100);
            roman.Add("L", 50);
            roman.Add("X", 10);
            roman.Add("V", 5);
            roman.Add("I", 1);
            roman.Add("CM", 900);
            roman.Add("CD", 400);
            roman.Add("XC", 90);
            roman.Add("XL", 40);
            roman.Add("IX", 9);
            roman.Add("IV", 4);
            for (int i = 0; i < s.Length; i++)
            {
                string t;
                int num = i + 1;
                int now;
                t = s.Substring(i, 1);
                now = roman[t];

                if (num < s.Length && now < roman[s.Substring(num, 1)])
                {
                    ans = ans + roman[s.Substring(i, 2)];
                    i++;
                }
                else
                {
                    ans = ans + now;
                }
            }

            return ans;
        }
    }
}
