namespace AdventOfCode.Day3
{
    class Part2
    {   
        public static void Run()
        {
            string[] batteries = File.ReadAllLines("Day3/input.txt");

            long count = 0;

            for (int i = 0; i < batteries.Length; i++)
            {
                int idxMax = 0;
                long num = 0;

                for (int size = 11; size >= 0; size--) {
                    int max = 0;
                    for (int j = idxMax; j < batteries[i].Length - size; j++) {
                        if ((batteries[i][j] - '0') > max) {
                            max = batteries[i][j] - '0';
                            idxMax = j;
                        }
                    }
                    idxMax++;

                    num = 10 * num + max;
                }
                
                count += num;
            }

            Console.WriteLine(count); 
        }
    }
}