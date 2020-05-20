using System;
using Xunit;

namespace blazor.wasm.ghpages.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Given
            var index = new blazor.wasm.ghpages.Pages.Index();

            // Then
            Assert.NotNull(index);
        }
    }
}
