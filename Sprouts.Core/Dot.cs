using System;
using System.Linq;
using System.Collections.Generic;

namespace Sprouts.Core
{
    public class Dot
    {
        private const int MaxNumberOfLines = 3;
        private const int MaxNumberOfSelfReferencedLines = 2;

        protected readonly IList<Line> lines;

        public Dot()
        {
            lines = new List<Line>();
        }

        public IEnumerable<Line> Lines => lines;

        public bool IsPlayable => lines.Count < MaxNumberOfLines;

        public void AddLine(Line line)
        {
            if (!CanAddSelfReferencedLine(line))
            {
                throw new InvalidOperationException("This dot already has a self reference. Another cannot be added as it would result in the line becoming unplayable.");
            }

            if (!IsPlayable)
            {
                throw new InvalidOperationException("Cannot add a line to an unplayable dot.");
            }

            lines.Add(line);
        }

        public void RemoveLine(Line line)
        {
            lines.Remove(line);
        }

        private bool CanAddSelfReferencedLine(Line newLine)
        {
            var count = lines.Count(line => line.LeftDot == newLine.RightDot);

            return count < MaxNumberOfSelfReferencedLines;
        }
    }
}
