public class S08 : BaseSolver
{
    public int CharCount { get; private set; }
    public int StringCount { get; private set; }

    public S08(string[] input) : base(input)
    {
        foreach (var line in _input)
        {
            CharCount += GetCharCount(line);
            StringCount += GetStringCount(line);
        }

        _answer1 = CharCount - StringCount;
    }

    private int GetStringCount(string value)
    {
        // trim off the quotes
        var trimmed = value[1..^1];
        var result = 0;
        for (int i = 0; i < trimmed.Length; i++)
        {
            if (trimmed[i] == '\\')
            {
                if (trimmed[i + 1] == '"' || trimmed[i + 1] == '\\')
                {
                    i++;
                }
                else if (trimmed[i + 1] == 'x')
                {
                    i += 3;
                }
            }

            result++;
        }

        return result;
    }

    private int GetCharCount(string value)
    {
        var result = 0;
        for (int i = 0; i < value.Length; i++)
        {
            if (value[i] == '\\' && value[i + 1] == 'x')
            {
                i += 3;
                result += 3;
            }

            result++;
        }

        return result;
    }
}