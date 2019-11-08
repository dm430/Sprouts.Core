using System.Collections.Generic;

namespace Sprouts.Core
{
    public class Dot
    {
        private const int MaxNumberOfLines = 3;

        protected readonly IList<Line> lines;

        public Dot(string name)
        {
            Name = name;
            lines = new List<Line>();
        }

        public string Name { get; protected set; }
        public IEnumerable<Line> Lines => lines;

        public void AddLine(Line line)
        {
            if (lines.Count < MaxNumberOfLines)
            {
                lines.Add(line);
            }
        }

        public void RemoveLine(Line line)
        {
            lines.Remove(line);
        }
    }
}
