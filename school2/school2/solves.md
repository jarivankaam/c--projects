````c#
 float temperatuur = 12.5f;
        float freezingPoint = 0.0f;

        if (temperatuur < freezingPoint)
        {
            Console.WriteLine($"{temperatuur} is lower then the freezing point of water");
        }
        else
        {
            Console.WriteLine($"{temperatuur} is higher then the freezing point");
        }

        Console.ReadKey();


````

`````c#
   int getal1 = 10;
        int getal2 = 100;
        int getal3 = -10;

        if (getal1 > 0 && getal2 > 0 && getal3 > 0)
        {
            int total = getal1 + getal2 + getal3;
            int sum = total / 3;
            
            Console.WriteLine($"the sum is {sum}");
        }
        else
        {
            Console.WriteLine("Make sure the numbers are above 0");
        }
`````