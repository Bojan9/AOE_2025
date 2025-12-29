namespace AdventOfCode.Day1
{
    class Part2
    {   
        static void Run(string[] args)
        {
            string[] lines = File.ReadAllLines("Inputs/day01.txt");

            int position = 50;
            int count = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                char direction = lines[i][0];
                int distance = int.Parse(lines[i].Substring(1));
                
                if (direction == 'R')
                {

                    count += (position + distance) / 100;
                    position = (position + distance) % 100;
                } else
                {
                    if (position == 0) {
                        count += distance / 100;
                    } else if (distance > position) {
                        count += (distance - position - 1) / 100 + 1;
                        if ((distance - position) % 100 == 0) {
                            count++;
                        }
                    } else if (distance == position) {
                        count++;
                    }

                    position = (position - distance) % 100;
                    if (position < 0) position += 100;
                }
            }

            Console.WriteLine(count);
        }
    }
}