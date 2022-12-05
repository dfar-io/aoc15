public class S04 : BaseSolver
{
    public S04(string input)
        : base(input)
    {
        var x = 0;

        while (true)
        {
            var hash = GetHash($"{Input[0]}{x}");
            if (hash.StartsWith("00000") && Answer1 == null)
            {
                Answer1 = x.ToString();
            }

            if (hash.StartsWith("000000"))
            {
                Answer2 = x.ToString();
                break;
            }

            x++;
        }
    }

    // https://stackoverflow.com/a/24031467
    private string GetHash(string input)
    {
        using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}