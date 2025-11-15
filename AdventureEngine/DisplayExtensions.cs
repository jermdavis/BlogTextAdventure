namespace AdventureEngine
{
    public static class DisplayExtensions
    {
        
        public static void Display(this World world, string text)
        {
            var w = Console.WindowWidth == 0 ? 80 : Console.WindowWidth;

            var lines = text.Split(System.Environment.NewLine);
            foreach (var line in lines)
            {

                if (line.Length < w)
                {
                    Console.WriteLine(line);
                }
                else
                {
                    int idx = w;
                    while (line[idx] != ' ')
                    {
                        idx -= 1;
                    }

                    Console.WriteLine(line.Substring(0, idx));
                    Console.WriteLine(line.Substring(idx + 1));
                }
            }
        }
    }

}