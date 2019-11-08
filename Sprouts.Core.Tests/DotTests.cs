using System;
using Xunit;

namespace Sprouts.Core.Test
{
    public class DotTests
    {
        [Fact]
        public void DotThrowsInvalidOperationExceptionWhenNolongerPlayable()
        {
            var dot = new Dot();
            var dot2 = new Dot();
            var dot3 = new Dot();

            var line = new Line(dot, dot);
            var line2 = new Line(dot, dot2);

            var exception = Assert.Throws<InvalidOperationException>(() => new Line(dot, dot3));
            Assert.Equal("Cannot add a line to an unplayable dot.", exception.Message);
        }

        [Fact]
        public void DotThrowsInvalidOperationExceptionWhenTwoSelfReferencingLinesAreAdded()
        {
            var dot = new Dot();
            var line = new Line(dot, dot);

            var exception = Assert.Throws<InvalidOperationException>(() => new Line(dot, dot));
            Assert.Equal("This dot already has a self reference. Another cannot be added as it would result in the line becoming unplayable.", exception.Message);
        }
    }
}
