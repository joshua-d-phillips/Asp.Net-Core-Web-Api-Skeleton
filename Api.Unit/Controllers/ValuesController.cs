using Api.Controllers;
using Xunit;

namespace Api.Unit.Controllers {
    public class ValuesControllerTest {

        public class GetShould {
            [Trait ("Category", "Unit")]
            [Fact (DisplayName = "API - Unit - ValuesController - Get - Should return a list of string values")]
            public void ReturnListOfValues () {
                //Arrange
                void action (string value) => Assert.IsType<string> (value);

                //Act
                var actual = new ValuesController ().Get ();

                //Assert
                Assert.All<string> (actual.Value, action);
            }

            [Trait ("Category", "Unit")]
            [Fact (DisplayName = "API - Unit - ValuesController - Get - Should return string value for specified id")]
            public void ReturnValueForId () {
                //Act
                var actual = new ValuesController ().Get (2);

                //Assert
                Assert.True (actual.Value is string);
            }
        }
    }
}
