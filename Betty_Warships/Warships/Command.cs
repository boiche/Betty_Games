using System.Text;

namespace Betty_Games.Warships
{
    public record Command(int Col, int Row)
    {
        public static bool TryParse(string input, out Command? command)
        {
            command = default;

            try
            {
                string col = string.Empty;

                StringBuilder builder = new();
                builder.Append(input[0]);
                for (int i = 1; i < input.Length; i++)
                {
                    if (string.IsNullOrEmpty(col))
                    {

                        if (char.IsLetter(input[i]))
                            builder.Append(input[i]);
                        else
                        {
                            col = builder.ToString();
                            builder.Clear();
                            builder.Append(input[i]);
                        }
                    }
                    else
                    {
                        builder.Append(input[i]);
                    }
                }

                if (!int.TryParse(builder.ToString(), out int row))
                    return false;

                int parsedCol = GetCol(col.ToUpper());
                if (parsedCol < 0)
                    return false;

                command = new Command(parsedCol, row);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"TODO: Log the exception with serilog: {e.Message}");
                return false;
            }
        }

        private static int GetCol(string col)
        {
            int _base = 'Z' - 'A';
            int result = col[^1] - 'A';
            int power = 1;
            for (int i = col.Length - 2; i >= 0; i--)
            {
                int current = col[i] - 'A' + 1;
                result += current * (int)Math.Pow(_base, power++);
            }

            return result;
        }
    }
}
