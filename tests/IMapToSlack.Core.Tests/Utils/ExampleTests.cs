using IMapToSlack.Core.Utils;
using FluentAssertions;
using Xunit;

namespace IMapToSlack.Core.Tests.Utils
{
  public class ExampleTests
  {
    private Example? _example;


    #region Setup/Teardown

    private void Setup()
    {
      _example = new Example();
    }

    #endregion

    [Fact]
    public void Valid_WhenCalled_ShouldReturnTrue()
    {
      // arrange
      Setup();
      // action
      var valid = _example!.Valid();

      // assert
      valid.Should().Be(true);
    }

  
  }
}
