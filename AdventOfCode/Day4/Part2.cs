namespace AdventOfCode.Day4
{
    class Part2
    {   
        static void Run(string[] args)
        {
            string[] grid = File.ReadAllLines("Inputs/day04.txt");

            int result = 0;
            int y = grid.Length;
            int x = grid[0].Length;

            for (int b = 0; b < y; b++) {
                for (int a = 0; a < x; a++) {
                    int count = 0;

                    if (a - 1 >= 0) {
                        if (grid[b][a-1] == '@') {
                            count++;
                        }
                    }

                    if (a - 1 >= 0 && b - 1 >= 0) {
                        if (grid[b-1][a-1] == '@') {
                            count++;
                        }
                    }

                    if (b - 1 >= 0) {
                        if (grid[b-1][a] == '@') {
                            count++;
                        }
                    }

                    if (a + 1 < x && b - 1 >= 0) {
                        if (grid[b-1][a+1] == '@') {
                            count++;
                        }
                    }

                    if (a + 1 < x) {
                        if (grid[b][a+1] == '@') {
                            count++;
                        }
                    }

                    if (a + 1 < x && b + 1 < y) {
                        if (grid[b+1][a+1] == '@') {
                            count++;
                        }
                    }

                    if (b + 1 < y) {
                        if (grid[b+1][a] == '@') {
                            count++;
                        }
                    }

                    if (a - 1 >= 0 && b + 1 < y) {
                        if (grid[b+1][a-1] == '@') {
                            count++;
                        }
                    }

                    if (count < 4 && grid[b][a] == '@') {
                        result++;
                    }
                }
            }

            Console.WriteLine(result); 
        }
    }
}