using System.Text;

namespace Betty_Games.Warships
{
    public record WarshipsCommand(int Col, int Row)
    {
        public static bool TryParse(string input, out WarshipsCommand? command)
        {
            command = default;

            try
            {
                string row = string.Empty;

                StringBuilder builder = new();
                builder.Append(input[0]);
                for (int i = 1; i < input.Length; i++)
                {
                    if (string.IsNullOrEmpty(row))
                    {

                        if (char.IsLetter(input[i]))
                            builder.Append(input[i]);
                        else if (char.IsDigit(input[i]))
                        {
                            row = builder.ToString();
                            builder.Clear();
                            builder.Append(input[i]);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        builder.Append(input[i]);
                    }
                }

                if (!int.TryParse(builder.ToString(), out int col))
                    return false;

                int parsedRow = GetCol(row.ToUpper());
                if (parsedRow < 0)
                    return false;

                command = new WarshipsCommand(col - 1, parsedRow);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static int GetCol(string col)
        {
            if (col.Length > 1)
            {
                int _base = 'Z' - 'A';
                int result = 0;
                for (int power = 1, i = col.Length - 2; i >= 0; i--, power++)
                {
                    int poweredBase = (int)Math.Pow(_base, power);

                    result += poweredBase * (col[i] - 'A' + 1);
                }

                return result + (col[^1] - 'A') + 1;
            }
            else
                return char.Parse(col) - 'A';
        }
    }
}
