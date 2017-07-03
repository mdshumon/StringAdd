using System;
using System.Collections.Generic;
using System.Text;

namespace StringMathLib
{
    public sealed class NumberHelper
    {
        public bool IsFirstNumberMaxOrEqual(string first, string second)
        {
            if (first.Length > second.Length)
            {
                return true;
            }
            else if (second.Length == first.Length)
            {
                for (int i = 0; i < first.Length;)
                {
                    var x = char.GetNumericValue(first[i]);
                    var y = char.GetNumericValue(second[i]);
                    if (x > y) return true;
                    else if (x == y) return true;
                    return false;
                }
            }
            return false;
        }
        public string SubMe(char[] s1, char[] s2)
        {
            int len1 = s1.Length;
            int len2 = s2.Length;

            char[] res = new char[len1 + 1];
            res[len1] = '\0';

            int carry = 0;

            int i1 = len1 - 1;
            int i2 = len2 - 1;
            for (; i1 >= 0 && i2 >= 0; i1--, i2--)
            {
                if (s1[i1] - s2[i2] >= 0)
                {
                    res[i1] = (s1[i1] - (s2[i2] + carry)).IntToChar();
                    carry = 0;
                }
                else
                {
                    res[i1] = ((s1[i1] + 10) - (s2[i2] + carry)).IntToChar();
                    carry = 1;
                }
            }

            while (i1 >= 0)
            {
                if (s1[i1] - (carry + '0') >= 0)
                {
                    res[i1] = (char)(s1[i1] - carry);
                    carry = 0;
                }
                else
                {
                    res[i1] = (char)(s1[i1] + 10 - carry);
                    carry = 1;
                }
                i1--;
            }         
            return new string(res).Replace("\0", string.Empty);
        }

        public string AddStringToNumber(string s1, string s2)
        {
            string n1 = s1.Length >= s2.Length ? s1 : s2;
            string n2 = s1.Length >= s2.Length ? s2 : s1;

            int l1 = n1.Length - 1;
            int l2 = n2.Length - 1;
            int x2 = l1 - l2;
            int carry = 0;

            string common = "01234567890123456789";
            string result = "";

            for (int i = l1; i >= 0; i--)
            {
                int ix = common.IndexOf(n1[i]);
                if (i <= l2 + x2 && l1 - i <= l2)
                    ix += common.IndexOf(n2[i - x2]);
                ix += carry;
                carry = ix > 9 ? 1 : 0;

                result = common[ix] + result;
            }
            return carry > 0 ? result = '1' + result : result;

        }
    }
}
