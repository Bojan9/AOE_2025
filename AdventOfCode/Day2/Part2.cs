namespace AdventOfCode.Day2
{
    class Part2
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
                    string s = j.ToString();
                    long[] deliteli = najdiDeliteli(s.Length);
                    bool flag = true;
                    for (int x = 0; x < deliteli.Length && deliteli[x] != 0; x++) {
                        long dolzina = s.Length / deliteli[x];
                        string[] result = new string[dolzina];

                        for (long z = 0; z < dolzina; z++) {
                            flag = true;
                            result[z] = s.Substring((int)(z * deliteli[x]), (int)deliteli[x]);
                            if (z > 0) {
                                if (result[z-1] != result[z]) {
                                    flag = false;
                                    break; 
                                }
                            }
                        }

                        if (flag) {
                            count += j;
                            break;
                        }
                    }

                }
            }

            Console.WriteLine(count); 
        }

        public static long[] najdiDeliteli(long broj) {
            long[] deliteli = new long[broj];
            int j = 0;

            for (long i = broj - 1; i > 0; i--) {
                if (broj % i == 0) {
                    deliteli[j] = i;
                    j++;
                }
            }

            return deliteli;
        }
    }
}