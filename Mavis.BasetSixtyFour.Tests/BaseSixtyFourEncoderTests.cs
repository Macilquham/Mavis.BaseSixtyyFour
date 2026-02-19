using Mavis.BaseSixtyFour;
using Shouldly;
using System.Text;

namespace Mavis.BasetSixtyFour.Tests
{
	public class BaseSixtyFourEncoderTests
	{
		[Fact]
		public void ExactlyThreeBytes()
		{
			var encoder = new BaseSixtyFourEncoder();
			var encodedString = encoder.Encode("tes");
            encodedString.ShouldBe(Convert.ToBase64String(Encoding.ASCII.GetBytes("tes")));
		}

		[Fact]
		public void OneByteExceess()
		{
			var encoder = new BaseSixtyFourEncoder();
			var encodedString = encoder.Encode("test");
            encodedString.ShouldBe(Convert.ToBase64String(Encoding.ASCII.GetBytes("test")));
		}

		[Fact]
		public void TwoByteExceess()
		{
			var encoder = new BaseSixtyFourEncoder();
			var encodedString = encoder.Encode("testj");
            encodedString.ShouldBe(Convert.ToBase64String(Encoding.ASCII.GetBytes("testj")));
		}
	}
}
