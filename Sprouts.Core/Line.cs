using System;

namespace Sprouts.Core
{
    public class Line
    {
        public Dot LeftDot { get;  protected set; }
        public Dot RightDot { get; protected set; }

        public Line(Dot leftDot, Dot rightDot)
        {
            LeftDot = leftDot ?? throw new ArgumentNullException(nameof(leftDot));
            RightDot = rightDot ?? throw new ArgumentNullException(nameof(rightDot));

            leftDot.AddLine(this);
            rightDot.AddLine(this);
        }

        public Line AddDot(Dot dot)
        {
            var newLine = new Line(LeftDot, dot);

            dot.AddLine(newLine);
            dot.AddLine(this);
            LeftDot.AddLine(newLine);
            LeftDot.RemoveLine(this);
            LeftDot = dot;

            return newLine;
        }
    }
}
