using NUnit.Framework;
using KTPO4311.Osanov.Lib.src.LogAn;

namespace KTPO4311.Osanov.UnitTest.src.LogAn
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_BadExtension_ReturnFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");
            Assert.False(result);
        }
        [Test]
        public void IsValidLogFileName_GoodExtensionUppercase_ReturnTrue()
        {
            LogAnalyzer analyzer= new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("fileName.OKG");
            Assert.True(result);
        }
        [Test]
        public void IsValidLogName_GoodExtensionLowercase_ReturnTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("fileName.okg");
            Assert.True(result);
        }
        [TestCase("fileName.OKG")]
        [TestCase("fileName.okg")]
        public void IsValidLogName_ValidExtension_ReturnsTrue(string file)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName(file);
            Assert.True(result);
        }
        [Test]
        public void IsValidFileName_EmptyFileName_Throws()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            var ex = Assert.Catch<Exception>(() => analyzer.IsValidLogFileName(""));
            StringAssert.Contains("имя файла должно быть задано", ex.Message);
        }
        [TestCase("badfile.foo",false)]
        [TestCase("goodfile.OKG",true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string file,bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            analyzer.IsValidLogFileName(file);
            Assert.AreEqual(expected, analyzer.WasLastFileNameValid);
        }
    }
}
