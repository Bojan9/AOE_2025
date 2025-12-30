namespace AdventOfCode.Day5
{
    class Part2
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

            long count = 0;

            var ordered = mapa.OrderBy(kv => kv.Key).ToList();
            Dictionary<long, long> merged = new Dictionary<long, long>();

            foreach (KeyValuePair<long, long> map in ordered) {
                if (merged.Count == 0) {
                    merged[map.Key] = map.Value;
                    continue;
                }

                if (map.Key <= merged.Last().Value) {
                    merged[merged.Last().Key] = Math.Max(merged.Last().Value, map.Value);
                } else {
                    merged[map.Key] = map.Value;
                }
            }

            foreach (KeyValuePair<long, long> map in merged) {
                count += map.Value - map.Key + 1;
            }

            Console.WriteLine(count);
        } 
    }
}