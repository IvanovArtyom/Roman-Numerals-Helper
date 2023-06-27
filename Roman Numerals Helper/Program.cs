using System.Collections.Generic;
using System.Text;
using System.Linq;

public class RomanNumerals
{
    public static void Main()
    {
        // Tests
        var t1 = ToRoman(1666);
        // ...should return "MDCLXVI"
        var t2 = FromRoman("MDCLXVI");
        // ...should return 1666
    }

    public static Dictionary<string, int> romanValue = new()
    {
        { "CM", 900 }, { "CD", 400 }, { "XC", 90 }, { "XL", 40 }, { "IX", 9 }, { "IV", 4 },
        { "M", 1000 }, { "D", 500 }, { "C", 100 }, { "L", 50 }, { "X", 10 }, { "V", 5 }, { "I", 1 }
    };

    public static string ToRoman(int n)
    {
        var sortedRomanValues = romanValue.OrderByDescending(x => x.Value).ToList();
        var result = new StringBuilder();

        while (n != 0)
        {
            var temp = sortedRomanValues.Find(x => n >= x.Value);
            result.Append(temp.Key);
            n -= temp.Value;
        }

        return result.ToString();
    }

    public static int FromRoman(string romanNumeral)
    {
        int number = 0;

        for (int i = 0; i < romanNumeral.Length; ++i)
        {
            if (i < romanNumeral.Length - 1 && romanValue.TryGetValue(romanNumeral.Substring(i, 2), out int value))
            {
                number += value;
                ++i;
            }

            else number += romanValue[romanNumeral[i].ToString()];
        }

        return number;
    }
}