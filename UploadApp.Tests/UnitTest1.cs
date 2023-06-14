using UploadApp.Services;
using UploadApp.Models;


namespace UploadApp.Tests
{
    [TestFixture]
    public class Tests
    {
        private ISettingsStorageService<SettingsDto> _settingsStorageService;

        [SetUp]
        public void Setup()
        {
            _settingsStorageService = new SettingsStorageService();
        }

        [Test]
        public void Test1()
        {
            
                
            Assert.Null(null, "mdksmkdms");
        }
    }
}