using System.ComponentModel;
using System.Text;

namespace Mavis.BaseSixtyFour
{
    public class BaseSixtyFourEncoder
    {
        public string Encode(string stringToEncode)
        {
            //Convert.ToB
            Byte[] bytes = new Byte[4];
            var stream = new MemoryStream();
            var byteArray = ASCIIEncoding.ASCII.GetBytes(stringToEncode);
			int block =
	(byteArray[0] << 16) |
	(byteArray[1] << 8) |
	byteArray[2];

            int blocks =
    (byteArray[0] << 16);
			return "";
        }
    }
}
