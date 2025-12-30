namespace AdventOfCode.Day2
{
    class Part1
    {   
        public static void Run()
        {
            string[] lines = File.ReadAllLines("AdventOfCode/Day2/input.txt");
            List<(long start, long end)> ranges = new();

            foreach (string line in lines) {
                string[] parts = line.Split(',');
                foreach (string part in parts) {
                    string[] numbers = part.Split('-');

                    long start = long.Parse(numbers[0]);
                    long end = long.Parse(numbers[1]);

                    ranges.Add((start, end));
                }
            }

            long count = 0;

            for (int i = 0; i < ranges.Count; i++) {
                for (long j = ranges[i].start; j <= ranges[i].end; j++) {
                    if (j.ToString().Length % 2 == 0) {
                        string del1 = j.ToString().Substring(0, j.ToString().Length / 2);
                        string del2 = j.ToString().Substring(j.ToString().Length / 2, j.ToString().Length / 2);

                        if (del1 == del2) {
                            count += j;
                        }
                    }
                }
            }
            
            Console.WriteLine(count);
        }
    }
}