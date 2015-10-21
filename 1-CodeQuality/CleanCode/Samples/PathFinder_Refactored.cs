using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CleanCode.Samples
{
    public class PathFinder_Refactored
    {
        public static Point GetNextStepToTarget(Point source, Point target, IWorld world)
        {
            var queue = new Queue<Point>();
            var used = new HashSet<Point>();
            queue.Enqueue(target);
            used.Add(target);
            while (queue.Any())
            {
                var p = queue.Dequeue();
                foreach (var neighbour in GetNeighbours(p, world))
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

        // TODO Вынести этот метод другой класс
        public static IWorld GenerateRandomWorld()
        {
            throw new NotImplementedException("TODO");
        }

        private static IEnumerable<Point> GetNeighbours(Point from, IWorld world)
        {
            return new[] { new Size(1, 0), new Size(-1, 0), new Size(0, 1), new Size(0, -1) }
                .Select(shift => from + shift)
                .Where(world.InsideWorld)
                .Where(world.IsFree);
        }
    }
}