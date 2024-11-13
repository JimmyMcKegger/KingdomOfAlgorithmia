namespace KingdomOfAlgorithmia
{
    public static class Day1
    {
        private static string p1 = "d1p1.txt";
        private static string p2 = "d1p2.txt";
        private static string p3 = "d1p3.txt";
        
        public static void Solve()
        {
            Console.WriteLine($"Part 1: {Part1(p1)}");
            Console.WriteLine($"Part 2: {Part2(p2)}");
            Console.WriteLine($"Part 3: {Part3(p3)}");
        }
        
        private static int Part1(string input)
        {
            return new StreamReader(input)
                .ReadToEnd()
                .TrimEnd()
                .ToCharArray()
                .Aggregate(0, (acc, chr) => acc + legend[chr]);
        }
        
        private static int Part2(string input)
        {
            return Battle(input, 2);
        }

        private static int Part3(string input)
        {
            return Battle(input, 3);
        }

        private static int Battle(string input, int steps)
        {
            return new StreamReader(input)
                .ReadToEnd()
                .TrimEnd()
                .Chunk(steps)
                .Aggregate(0, (acc, chunk) => acc + PotionCount(chunk));
        }
        
        private static int PotionCount(char[] chars)
        {
            int enemyCount = 0;
            int result = 0;

            foreach (char c in chars)
            {
                if (c != 'x')
                {
                    enemyCount++;
                    result += legend[c];
                }
            }

            switch (enemyCount)
            {
                case 2:
                    result += 2;
                    break;
                case 3:
                    result += 6;
                    break;
            }
            return result;
        }
        
        private static readonly Dictionary<char, int> legend = new Dictionary<char, int>
        {
            { 'A', 0 },
            { 'B', 1 },
            { 'C', 3 },
            { 'D', 5 }
        };
    }
}