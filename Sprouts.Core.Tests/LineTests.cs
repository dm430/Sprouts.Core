using Xunit;

namespace Sprouts.Core.Test
{
    public class LineTests
    {
        [Fact]
        public void NewLineContainsRefrencesToCorrectDots()
        {
            var leftDot = new Dot();
            var rightDot = new Dot();
            var midDot = new Dot();
            var line = new Line(leftDot, rightDot);

            var newLine = line.AddDot(midDot);

            Assert.NotNull(newLine);
            Assert.Equal(leftDot, newLine.LeftDot);
            Assert.Equal(midDot, newLine.RightDot);
        }

        [Fact]
        public void OldLineContainsCorrectRefrencesToDots() {

            var leftDot = new Dot();
            var rightDot = new Dot();
            var midDot = new Dot();
            var line = new Line(leftDot, rightDot);

            line.AddDot(midDot);

            Assert.Equal(midDot, line.LeftDot);
            Assert.Equal(rightDot, line.RightDot);
        }

        [Fact]
        public void LeftDotContainsCorrectLinesAfterDotAddition()
        {
            var leftDot = new Dot();
            var rightDot = new Dot();
            var midDot = new Dot();
            var line = new Line(leftDot, rightDot);

            var newLine = line.AddDot(midDot);

            Assert.DoesNotContain(line, leftDot.Lines);
            Assert.Contains(newLine, leftDot.Lines);
        }

        [Fact]
        public void MidDotContainsCorrectLinesAfterDotAddition()
        {
            var leftDot = new Dot();
            var rightDot = new Dot();
            var midDot = new Dot();
            var line = new Line(leftDot, rightDot);

            var newLine = line.AddDot(midDot);

            Assert.Contains(newLine, midDot.Lines);
            Assert.Contains(line, midDot.Lines);
        }

        [Fact]
        public void RightDotContainsCorrectLinesAfterDotAddition()
        {
            var leftDot = new Dot();
            var rightDot = new Dot();
            var midDot = new Dot();
            var line = new Line(leftDot, rightDot);

            var newLine = line.AddDot(midDot);

            Assert.DoesNotContain(newLine, rightDot.Lines);
            Assert.Contains(line, rightDot.Lines);
        }
    }
}
