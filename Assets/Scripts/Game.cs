
using System;

public class Game 
{
    private Random random = new Random();

    public string MakeEquation()
    {

        int initial;
        do
        {
            initial = random.Next(1, 51);
        } while (IsPrime(initial));

        int mult;
        do
        {
            mult = random.Next(1, 10);
        } while (initial % mult != 0);

        int divisionResult = initial / mult;
        int additionResult = 31 - divisionResult;

        return $"{initial} / {mult} + {additionResult}";
    }

    private bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number <= 3) return true;

        if (number % 2 == 0 || number % 3 == 0) return false;

        for (int i = 5; i * i <= number; i += 6)
        {
            if (number % i == 0 || number % (i + 2) == 0)
                return false;
        }

        return true;
    }


}
