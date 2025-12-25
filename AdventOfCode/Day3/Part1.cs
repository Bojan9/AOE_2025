namespace AdventOfCode.Day3
{
    class Part1
    {   
        public static void Run()
        {
            string[] batteries = File.ReadAllLines("Day3/input.txt");

            int count = 0;

            for (int i = 0; i < batteries.Length; i++)
            {
                int maxPrv = 0, maxVtor = 0, idxMaxPrv = 0;

                for (int j = 0; j < batteries[i].Length - 1; j++) {
                    if ((batteries[i][j] - '0') > maxPrv) {
                        maxPrv = batteries[i][j] - '0';
                        idxMaxPrv = j;
                    }
                }

                for (int j = idxMaxPrv + 1; j < batteries[i].Length; j++) {
                    if ((batteries[i][j] - '0') > maxVtor) {
                        maxVtor = batteries[i][j] - '0';
                    }
                }

                count += maxPrv * 10 + maxVtor;
            }

            Console.WriteLine(count); 
        }
    }
}