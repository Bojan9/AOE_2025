namespace AdventOfCode.Day4
{
    class Part2
    {   
        public static void Run()
        {
            string[] lines = File.ReadAllLines("AdventOfCode/Day4/input.txt");
            
            char[][] grid = new char[lines.Length][];
            for (int i = 0; i < lines.Length; i++) {
                grid[i] = lines[i].ToCharArray();
            }

            int result = 0;
            int y = grid.Length;
            int x = grid[0].Length;

            bool changed = true;
            while (changed) {
                changed = false;
                List<(int, int)> toRemove = new List<(int, int)>();

                for (int b = 0; b < y; b++) {
                    for (int a = 0; a < x; a++) {
                        if (grid[b][a] != '@') continue;

                        int count = CountNeighbors(grid, a, b, x, y);

                        if (count < 4) {
                            toRemove.Add((a, b));
                        }
                    }
                }

                if (toRemove.Count > 0) {
                    changed = true;
                    foreach (var (a, b) in toRemove) {
                        grid[b][a] = '.';
                        result++;
                    }
                }
            }

            Console.WriteLine(result); 
        }

        private static int CountNeighbors(char[][] grid, int a, int b, int x, int y) {
            int count = 0;

            if (a - 1 >= 0 && grid[b][a-1] == '@') count++;
            if (a - 1 >= 0 && b - 1 >= 0 && grid[b-1][a-1] == '@') count++;
            if (b - 1 >= 0 && grid[b-1][a] == '@') count++;
            if (a + 1 < x && b - 1 >= 0 && grid[b-1][a+1] == '@') count++;
            if (a + 1 < x && grid[b][a+1] == '@') count++;
            if (a + 1 < x && b + 1 < y && grid[b+1][a+1] == '@') count++;
            if (b + 1 < y && grid[b+1][a] == '@') count++;
            if (a - 1 >= 0 && b + 1 < y && grid[b+1][a-1] == '@') count++;

            return count;
        }
    }
}