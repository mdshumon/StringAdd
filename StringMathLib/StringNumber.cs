using System;
using System.Linq;
using System.Threading.Tasks;

namespace StringMathLib
{
    public class StringNumber
    {
        private readonly NumberHelper numhelp;
        public StringNumber(NumberHelper numin)
        {
            this.numhelp = numin;
        }
        public string AddOrSubNumber(string x, string y)
        {
            //check null
            if (string.IsNullOrEmpty(x) || string.IsNullOrWhiteSpace(x)) throw new ArgumentNullException(nameof(x));
            else if (string.IsNullOrEmpty(y) || string.IsNullOrWhiteSpace(y)) throw new ArgumentNullException(nameof(y));

            // check valid int number even exclude . as per requirments
            if (x.StartsWith("-") || y.StartsWith("-"))
            {
                if (!x.Replace("-", "").IsCharDigit() || !y.Replace("-", "").IsCharDigit())
                    throw new FormatException("Invalid number format");
            }
            else if (!x.IsCharDigit() || !y.IsCharDigit())
                throw new FormatException("Invalid number format");
            //it could be like -- or --- or more at the begining so just take one - 
            if (x.StartsWith("--"))
            {
                x = x.Replace("--", "");
                x = "-" + x;
            }
            else if (y.StartsWith("--"))
            {
                y = y.Replace("-", "");
            }
            x = x.TrimStart('0');
            y = y.TrimStart('0');
            if (x.StartsWith("-") && y.StartsWith("-"))
            {
                return "-" + numhelp.AddStringToNumber(x.Substring(1, x.Length - 1), y.Substring(1, y.Length - 1));
            }
            else if (!x.StartsWith("-") && y.StartsWith("-"))
            {
                y = y.Replace("-", "");
                var xmax = numhelp.IsFirstNumberMaxOrEqual(x, y);
                if (xmax)
                    return numhelp.SubMe(x.ToCharArray(), y.ToCharArray()).ToString();
                else
                {
                    var result = numhelp.SubMe(y.ToCharArray(), x.ToCharArray());
                    return result == "0" ? "0" : "-" + result;
                }
            }
            else if (x.StartsWith("-") && !y.StartsWith("-"))
            {
                x = x.Replace("-", "");
                var xmax = numhelp.IsFirstNumberMaxOrEqual(x, y);
                if (xmax)
                {
                    var result = numhelp.SubMe(x.ToCharArray(), y.ToCharArray());
                    return result == "0" ? "0" : "-" + result;
                }
                return numhelp.SubMe(y.ToCharArray(), x.ToCharArray()).ToString();
            }
            else
            {
                return numhelp.AddStringToNumber(x, y);
            }
        }

    }
}
