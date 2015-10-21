using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CleanCode.Samples
{
    public class PathFinder
    {
        public static IWorld world;

        public static void GenerateRandomWorld()
        {
            // world = ...
        }

        private static readonly Queue<Point> queue = new Queue<Point>();
        private static readonly ISet<Point> used = new HashSet<Point>();

        public static Point GetNextStepToTarget(Point source, Point target)
        {
            queue.Clear();
            used.Clear();
            queue.Enqueue(target);
            used.Add(target);
            while (queue.Any())
            {
                var p = queue.Dequeue();
                foreach (var neighbour in GetNeighbours(p))
                {
                    if (used.Contains(neighbour)) continue;
                    if (neighbour == source)
                        return neighbour;
                    queue.Enqueue(neighbour);
                    used.Add(neighbour);
                }
            }
            return source;
        }


        private static IEnumerable<Point> GetNeighbours(Point from)
        {
            return new[] { new Size(1, 0), new Size(-1, 0), new Size(0, 1), new Size(0, -1) }
                .Select(shift => from + shift)
                .Where(world.InsideWorld)
                .Where(world.IsFree);
        }
    }
    #region stuff
    internal class Wall
    {
    }

    public interface IWorld
    {
        bool InsideWorld(Point arg);
        bool IsFree(Point loc);
    }
    #endregion

}