namespace AdventOfCode.Day6
{
    class Part1
    {   
        public static void Run()
        {
            string[] lines = File.ReadAllLines("AdventOfCode/Day6/input.txt");
            int n = lines.Length;
            string[][] trimmedLines = new string[n][];

            for (int i = 0; i < n; i++) {
                trimmedLines[i] = lines[i].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            }

            long vk = 0;

            for (int i = 0; i < trimmedLines[0].Length; i++) {
                long current = 0;
                string znak = trimmedLines[n - 1][i];
                for (int j = 0; j < n - 1; j++) {
                    if (znak == "+")
                    {
                        current += long.Parse(trimmedLines[j][i]);
                    } else
                    {
                        if (j == 0)
                        {
                            current = 1;
                        }

                        current *= long.Parse(trimmedLines[j][i]);
                    }
                }
                vk += current;
            }

            Console.WriteLine(vk);
        } 
    }
}