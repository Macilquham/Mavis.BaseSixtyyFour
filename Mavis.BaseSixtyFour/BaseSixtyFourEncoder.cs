using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Text;

namespace Mavis.BaseSixtyFour
{
    public class BaseSixtyFourEncoder
    {
        private char[] base64Chars =
        [
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P',
            'Q','R','S','T','U','V','W','X','Y','Z',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p',
            'q','r','s','t','u','v','w','x','y','z',
            '0','1','2','3','4','5','6','7','8','9',
            '+','/'
        ];

        public string Encode(string stringToEncode)
        {
            var byteArray = ASCIIEncoding.ASCII.GetBytes(stringToEncode);
            var count = 0;
            StringBuilder encodedText = new StringBuilder();
            
            while(count + 3 <= byteArray.Length) {
			    int block =	(byteArray[count] << 16) |	(byteArray[count + 1] << 8) | byteArray[count + 2];
                encodedText.Append(base64Chars[block >> 18 & 0b111111]);
                encodedText.Append(base64Chars[block >> 12 & 0b111111]);
                encodedText.Append(base64Chars[block >> 6 & 0b111111]);
                encodedText.Append(base64Chars[block & 0b111111]);
                count = count + 3;
            }

            if(byteArray.Length - count == 1)
            {
                var paddedTo12Bytes = byteArray[byteArray.Length - 1] << 4;
                encodedText.Append(base64Chars[paddedTo12Bytes >> 6 & 0b111111]);
                encodedText.Append(base64Chars[paddedTo12Bytes & 0b111111]);
                encodedText.Append("==");
            }

            if(byteArray.Length - count == 2)
            {
                var paddedTo18Bytes = (byteArray[byteArray.Length - 2] << 8 | byteArray[byteArray.Length - 1]) << 2;
                encodedText.Append(base64Chars[paddedTo18Bytes >> 12 & 0b111111]);
                encodedText.Append(base64Chars[paddedTo18Bytes >> 6 & 0b111111]);
                encodedText.Append(base64Chars[paddedTo18Bytes & 0b111111]);
                encodedText.Append("=");
            }

			return encodedText.ToString();
        }
    }
}
