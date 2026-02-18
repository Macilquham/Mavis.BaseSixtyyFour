using Mavis.BaseSixtyFour;

namespace Mavis.BasetSixtyFour.Tests
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{
			var encoder = new BaseSixtyFourEncoder();
			var encodedString = encoder.Encode("test");
		}
	}
}
