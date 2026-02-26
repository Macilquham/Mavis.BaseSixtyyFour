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
            var byteArray = ASCIIEncoding.UTF8.GetBytes(stringToEncode);
            var count = 0;
            StringBuilder encodedText = new();

            while (count + 3 <= byteArray.Length)
            {
                int block = (byteArray[count] << 16) | (byteArray[count + 1] << 8) | byteArray[count + 2];
                encodedText.Append(base64Chars[block >> 18 & 0b111111]);
                encodedText.Append(base64Chars[block >> 12 & 0b111111]);
                encodedText.Append(base64Chars[block >> 6 & 0b111111]);
                encodedText.Append(base64Chars[block & 0b111111]);
                count = count + 3;
            }

            if (byteArray.Length - count == 1)
            {
                var paddedTo12Bytes = byteArray[byteArray.Length - 1] << 4;
                encodedText.Append(base64Chars[paddedTo12Bytes >> 6 & 0b111111]);
                encodedText.Append(base64Chars[paddedTo12Bytes & 0b111111]);
                encodedText.Append("==");
            }

            if (byteArray.Length - count == 2)
            {
                var paddedTo18Bytes = (byteArray[byteArray.Length - 2] << 8 | byteArray[byteArray.Length - 1]) << 2;
                encodedText.Append(base64Chars[paddedTo18Bytes >> 12 & 0b111111]);
                encodedText.Append(base64Chars[paddedTo18Bytes >> 6 & 0b111111]);
                encodedText.Append(base64Chars[paddedTo18Bytes & 0b111111]);
                encodedText.Append("=");
            }

            return encodedText.ToString();
        }

        public string Decode(string input)
        {
            StringBuilder decodedText = new();

            int count = 0;
            while(count + 4 <= input.Length)
            {
                var index1 = base64Chars.IndexOf(input[count]);
                var index2 = base64Chars.IndexOf(input[count + 1]);
                var index3 = base64Chars.IndexOf(input[count + 2]);
                var index4 = base64Chars.IndexOf(input[count + 3]);
                var parsedAsBytes = index1 << 18 | index2 << 12 | (index3 == -1 ? 0 : index3) << 6 | (index4 == -1 ? 0 : index4);
                
                decodedText.Append((char)(parsedAsBytes >> 16& 0b11111111));
                decodedText.Append((char)(parsedAsBytes >> 8& 0b11111111));
                decodedText.Append((char)(parsedAsBytes & 0b11111111));
                count += 4;
            }

            return decodedText.ToString();
        }
    }
}
