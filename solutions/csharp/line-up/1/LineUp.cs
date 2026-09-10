public static class LineUp
{
    public static string Format(string name, int number)
    {
        string suffix = "th";

        int lastTwoDigits = number % 100;
        int lastDigit = number % 10;

        if (lastTwoDigits != 11 && lastTwoDigits != 12 && lastTwoDigits != 13)
        {
            if (lastDigit == 1)
            {
                suffix = "st";
            }
            else if (lastDigit == 2)
            {
                suffix = "nd";
            }
            else if (lastDigit == 3)
            {
                suffix = "rd";
            }
        }

        return $"{name}, you are the {number}{suffix} customer we serve today. Thank you!";
    }
}