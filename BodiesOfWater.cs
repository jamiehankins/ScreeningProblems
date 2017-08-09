// If this were a real-world task that didn't have to be solved in minutes
// instead of hours, then a stack-based solution that doesn't involve recursion
// would be a lot better choice. With a big data-set, this much recursion would
// cause problems.
class Program
{
    public static void Main(string[] args)
    {
        int l = Convert.ToInt32(Console.ReadLine());
        var map = new int[l][];
        for (int i = 0; i < l; ++i)
        {
            map[i] = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
        }
        foreach (int i in CountBodies(map))
        {
            Console.WriteLine(i.ToString());
        }
    }
    static int[] CountBodies(int[][] map)
    {
        var bodies = new List<int>();
        for (int row = 0; row < map.Length; ++row) 
        {
            for (int col = 0; col < map[row].Length; ++col)
            {
                int size = GetBodyRecursive(row, col, ref map);
                if (size > 0)
                {
                    bodies.Add(size);
                }
            }
        }
        bodies.Sort();
        return bodies.ToArray();
    }
    static int GetBodyRecursive(int row, int col, ref int[][] map, int size = 0)
    {
        // If the section isn't water, drop.
        // If we've already painted it, drop.
        if (0 == map[row][col])
        {
            // Paint this one.
            map[row][col] = -1;
            // Add to current size.
            ++size;

            // North
            if (row > 0)
            {
                size = GetBodyRecursive(row - 1, col, ref map, size);
                // Northeast
                if (col < map[row].Length - 1)
                {
                    size = GetBodyRecursive(row - 1, col + 1, ref map, size);
                }
            }
            // East
            if (col < map[row].Length - 1)
            {
                size = GetBodyRecursive(row, col + 1, ref map, size);
                // Southeast
                if (row < map.Length - 1)
                {
                    size = GetBodyRecursive(row + 1, col + 1, ref map, size);
                }
            }
            // South
            if (row < map.Length - 1)
            {
                size = GetBodyRecursive(row + 1, col, ref map, size);
                // Southwest
                if (col > 0)
                {
                    size = GetBodyRecursive(row + 1, col - 1, ref map, size);
                }
            }
            // West
            if (col > 0)
            {
                size = GetBodyRecursive(row, col - 1, ref map, size);
                // Northwest
                if (row > 0)
                {
                    size = GetBodyRecursive(row - 1, col - 1, ref map, size);
                }
            }
        }
        return size;
    }
}
