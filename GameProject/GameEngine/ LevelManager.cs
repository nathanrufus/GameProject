using System;
using System.Collections.Generic;

namespace GameEngine
{
    
   public static class LevelManager
{
    private static Random random = new Random();

    public static List<Item> GenerateItems(int count, int frameWidth, int frameHeight)
    {
        var items = new List<Item>();
        HashSet<(int, int)> positions = new HashSet<(int, int)>();

        while (items.Count < count)
        {
            int x = random.Next(1, frameWidth - 2);
            int y = random.Next(1, frameHeight - 2);

            // Ensure no overlap with existing positions
            if (!positions.Contains((x, y)))
            {
                items.Add(new Item(x, y));
                positions.Add((x, y));
            }
        }

        return items;
    }

    public static List<Hazard> GenerateHazards(int count, int frameWidth, int frameHeight)
    {
        var hazards = new List<Hazard>();
        HashSet<(int, int)> positions = new HashSet<(int, int)>();

        while (hazards.Count < count)
        {
            int x = random.Next(1, frameWidth - 2);
            int y = random.Next(1, frameHeight - 2);

            // Ensure no overlap with existing positions
            if (!positions.Contains((x, y)))
            {
                hazards.Add(new Hazard(x, y));
                positions.Add((x, y));
            }
        }

        return hazards;
    }
}

}
