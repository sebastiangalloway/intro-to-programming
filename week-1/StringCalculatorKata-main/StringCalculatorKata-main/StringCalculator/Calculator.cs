
public class Calculator
{
    public int Add(string numbers)
    {
        int output = 0;
        List<char> delimiters = [ ',', '\n' ];

        if (numbers.Length >= 3 && numbers.Substring(0, 2).Equals("//"))
        {
            delimiters.Add(numbers[2]);
            numbers = numbers[3..];
        }

        string[] splitNumbers = numbers.Split(delimiters.ToArray());
        foreach (string number in splitNumbers)
        {
            output += number == "" ? 0 : int.Parse(number);
        }
        return output;
    }
}
