using NUnit.Framework;

namespace HQ35PUIKLUMR
{
    [TestFixture]
    public class ECOCodeServiceTests
    {
        [TestCase("A00", "Egyéb")]
        [TestCase("A01", "Larsen")]
        [TestCase("A04", "Réti")]
        [TestCase("A10", "Angol")]
        [TestCase("B00", "Királygyalog")]
        [TestCase("B01", "Skandináv")]
        [TestCase("B20", "Szicíliai mellékvarik")]
        [TestCase("C00", "Francia")]
        [TestCase("C60", "Spanyol")]
        [TestCase("D00", "JobavaLondon")]
        [TestCase("D43", "Szláv")]
        [TestCase("E20", "Nimzoindiai")]
        [TestCase("E60", "Királyindiai")]
        public void GetOpeningName_ValidECOCode_ReturnsCorrectName(string eco, string expected)
        {
            
            string result = ECOCodeService.GetOpeningName(eco);

            
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("")]
        [TestCase("Z99")]
        [TestCase("A-1")]
        [TestCase("C100")]        
        [TestCase("123")]
        public void GetOpeningName_InvalidECOCode_ReturnsError(string eco)
        {
            
            string result = ECOCodeService.GetOpeningName(eco);

            
            Assert.That(result, Is.EqualTo("Hiba"));
        }


        [TestCase("1D0")]
        [TestCase("ASD")]
        [TestCase("E")]
        public void GetOpeningName_InvalidECOCode_ReturnsException(string eco)
        {
            
            Assert.Throws<FormatException>(() => ECOCodeService.GetOpeningName(eco));
        }


    }
}
