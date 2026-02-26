using Mavis.BaseSixtyFour;
using Shouldly;
using System.Text;

namespace Mavis.BasetSixtyFour.Tests
{
	public class BaseSixtyFourDecoderTests
	{
		[Fact]
		public void OneByteExcess()
		{
			var encoder = new BaseSixtyFourEncoder();
			var encodedString = encoder.Decode("YWFhYQ==");
            encodedString.ShouldBe("aaaa");
		}

		[Fact]
		public void TwoByteExcess()
		{
			var encoder = new BaseSixtyFourEncoder();
			var encodedString = encoder.Decode("YWFhYWE=");
			encodedString.ShouldBe("aaaaa");
		}

		[Fact]
		public void ExactlyThreeBytes()
		{
			var encoder = new BaseSixtyFourEncoder();
			var encodedString = encoder.Decode("YWFh");
            encodedString.ShouldBe("aaa");
		}

	}
	public class BaseSixtyFourEncoderTests
	{
		[Fact]
		public void OneCharacter()
		{
			var encoder = new BaseSixtyFourEncoder();
			var encodedString = encoder.Encode("m");
            encodedString.ShouldBe(Convert.ToBase64String(Encoding.UTF8.GetBytes("m")));
		}

		[Fact]
		public void ExactlyThreeBytes()
		{
			var encoder = new BaseSixtyFourEncoder();
			var encodedString = encoder.Encode("tes");
            encodedString.ShouldBe(Convert.ToBase64String(Encoding.UTF8.GetBytes("tes")));
		}

		[Fact]
		public void OneByteExceess()
		{
			var encoder = new BaseSixtyFourEncoder();
			var encodedString = encoder.Encode("test");
            encodedString.ShouldBe(Convert.ToBase64String(Encoding.UTF8.GetBytes("test")));
		}

		[Fact]
		public void TwoByteExceess()
		{
			var encoder = new BaseSixtyFourEncoder();
			var encodedString = encoder.Encode("testj");
            encodedString.ShouldBe(Convert.ToBase64String(Encoding.UTF8.GetBytes("testj")));
		}

		[Fact]
		public void NonAsciiCharacters()
		{
			var encoder = new BaseSixtyFourEncoder();
			var encodedString = encoder.Encode("testjÅ");
            encodedString.ShouldBe(Convert.ToBase64String(Encoding.UTF8.GetBytes("testjÅ")));
		}
	}
}
