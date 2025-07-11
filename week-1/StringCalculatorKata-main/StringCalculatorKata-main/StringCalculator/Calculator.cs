
using System.Text;

public class Calculator
{
    public int Add(string numbers)
    {
        int output = 0;
        bool isNegative = false;
        List<int> negatives = new List<int>();

        List<string> delimiters = new List<string>() { ",", "\n" };

        if (numbers.Length >= 3 && numbers.Substring(0, 2).Equals("//"))
        {
            delimiters.Add(numbers[2].ToString());
            numbers = numbers[3..];
        }
        else if(numbers.StartsWith("//[") && numbers.LastIndexOf(']') > 3)
        {
            delimiters.Add(numbers.Substring(3, numbers.LastIndexOf(']') - 1));
            numbers = numbers.Substring(numbers.LastIndexOf(']') + 1);
        }

        string[] splitNumbers = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
        foreach (string number in splitNumbers)
        {
            int temp = number == "" ? 0 : int.Parse(number);
            if (temp < 0)
            {
                isNegative = true;
                negatives.Add(temp);
                continue;
            }
            if (temp <= 1000)
            {
                output += temp;
            }
        }
        if (isNegative) throw new ArgumentException(String.Join(", ", negatives.ToArray()));
        else return output;
    }
}
