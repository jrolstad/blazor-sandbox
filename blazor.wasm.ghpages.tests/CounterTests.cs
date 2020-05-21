using System;
using Xunit;
using Bunit;

namespace blazor.wasm.ghpages.tests
{
    public class CounterTests:TestContext
    {
        [Fact]
        public void Counter_ClickButton_IncrementsCount()
        {
            // Given
            var page = RenderComponent<Pages.Counter>();

            // When
            page.Find("button").Click();

            // Then
            page.Find("p").MarkupMatches("<p>Current count: 1</p>");
        }
    }
}
