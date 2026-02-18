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
            
            var stream = new MemoryStream();
            var byteArray = ASCIIEncoding.ASCII.GetBytes(stringToEncode);
			int block =	(byteArray[0] << 16) |	(byteArray[1] << 8) | byteArray[2];

            var block1 = base64Chars[block >> 18 & 0b111111];
            var block2 = base64Chars[block >> 12 & 0b111111];
            var block3 = base64Chars[block >> 6 & 0b111111];
            var block4 = base64Chars[block & 0b111111];




			return "";
        }
    }
}
