using Xunit;

namespace Sprouts.Core.Tests
{
    public class LineTest
    {
        [Fact]
        public void Test1()
        {
            var leftDot = new Dot("left dot");
            var rightDot = new Dot("rightt dot");
            var midDot = new Dot("mid dot");
            var line = new Line(leftDot, rightDot);

            var newLine = line.AddDot(midDot);

            Assert.NotNull(newLine);
            Assert.Equal(leftDot, newLine.LeftDot);
            Assert.Equal(midDot, newLine.RightDot);
            Assert.Equal(midDot, line.LeftDot);
            Assert.Equal(rightDot, line.RightDot);
        }

        [Fact]
        public void LeftDotContainsCorrectLinesAfterDotAddition()
        {
            var leftDot = new Dot("left dot");
            var rightDot = new Dot("rightt dot");
            var midDot = new Dot("mid dot");
            var line = new Line(leftDot, rightDot);

            var newLine = line.AddDot(midDot);

            Assert.DoesNotContain(line, leftDot.Lines);
            Assert.Contains(newLine, leftDot.Lines);
        }

        [Fact]
        public void MidDotContainsCorrectLinesAfterDotAddition()
        {
            var leftDot = new Dot("left dot");
            var rightDot = new Dot("rightt dot");
            var midDot = new Dot("mid dot");
            var line = new Line(leftDot, rightDot);

            var newLine = line.AddDot(midDot);

            Assert.Contains(newLine, midDot.Lines);
            Assert.Contains(line, midDot.Lines);
        }

        [Fact]
        public void RightDotContainsCorrectLinesAfterDotAddition()
        {
            var leftDot = new Dot("left dot");
            var rightDot = new Dot("rightt dot");
            var midDot = new Dot("mid dot");
            var line = new Line(leftDot, rightDot);

            var newLine = line.AddDot(midDot);

            Assert.DoesNotContain(newLine, rightDot.Lines);
            Assert.Contains(line, rightDot.Lines);
        }
    }
}
