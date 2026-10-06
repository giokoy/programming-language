using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        var sb = new StringBuilder();
        bool capitalizeNext = false;

        for (int i = 0; i < identifier.Length; i++)
        {
            char c = identifier[i];

            if (c == ' ')
            {
                sb.Append('_');
            }
            else if (char.IsControl(c))
            {
                sb.Append("CTRL");
            }
            else if (c == '-')
            {
                capitalizeNext = true;
            }
            else if (c >= 'α' && c <= 'ω')
            {
                // Omite letras griegas en minúsculas
                continue;
            }
            else if (char.IsLetter(c))
            {
                if (capitalizeNext)
                {
                    sb.Append(char.ToUpperInvariant(c));
                    capitalizeNext = false;
                }
                else
                {
                    sb.Append(c);
                }
            }
            else if (c == '_')
            {
                sb.Append(c);
            }
            // Cualquier otro carácter (números, símbolos, etc.) se descarta automáticamente
        }

        return sb.ToString();
    }
}
