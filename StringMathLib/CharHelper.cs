using System;
using System.Collections.Generic;
using System.Text;

namespace StringMathLib
{
    public static class CharHelper
    {
        public static bool IsCharDigit(this string val)
        {
            foreach (char c in val)
            {
                if (!(c >= '0') && (c <= '9'))
                    return false;
            }
            return true;
        }
        public static char IntToChar(this int ch)
        {
            switch (ch)
            {
                case 1:
                    return '1';
                case 2:
                    return '2';
                case 3:
                    return '3';
                case 4:
                    return '4';
                case 5:
                    return '5';
                case 6:
                    return '6';
                case 7:
                    return '7';
                case 8:
                    return '8';
                case 9:
                    return '9';
                case 0:
                    return '0';
            }

            return new char();
        }
    }
}
