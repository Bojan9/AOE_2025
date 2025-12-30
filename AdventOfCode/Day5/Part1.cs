namespace AdventOfCode.Day5
{
    class Part1
    {   
        public static void Run()
        {
            string[] lines = File.ReadAllLines("AdventOfCode/Day5/input.txt");

            Dictionary<long, long> mapa = new Dictionary<long, long>();

            int k = 0;

            while (lines[k] != "") {
                string[] numbers = lines[k].Split('-');
                
                long start = long.Parse(numbers[0]);
                long end = long.Parse(numbers[1]);

                if (!mapa.ContainsKey(start)) {
                    if (!mapa.ContainsValue(end)) {
                        mapa.Add(start, end);
                    } else {
                        long key = mapa.FirstOrDefault(x => x.Value == end).Key;
                        if (start < key) {
                            mapa.Remove(key);
                            mapa.Add(start, end);
                        }
                    }
                } else {
                    if (end > mapa[start]) {
                        mapa[start] = end;
                    }
                }

                k++;
            }

            k++;

            int count = 0;
            while (k < lines.Length) {
                long num = long.Parse(lines[k]);

                foreach (KeyValuePair<long, long> map in mapa) {
                    if (num >= map.Key && num <= map.Value) {
                        count++;
                        break;
                    }
                }

                k++;
            }

            Console.WriteLine(count);
        } 
    }
}