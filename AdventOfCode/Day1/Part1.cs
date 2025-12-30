namespace AdventOfCode.Day1
{
    class Part1
    {   
        public static void Run()
        {
            string[] lines = File.ReadAllLines("AdventOfCode/Day1/input.txt");

            int position = 50;
            int count = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                char direction = lines[i][0];
                int distance = int.Parse(lines[i].Substring(1));
                
                if (direction == 'R')
                {

                    position = (position + distance) % 100;
                } else
                {
                    position = (position - distance) % 100;
                    if (position < 0) position += 100;
                }
                
                if (position == 0)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}