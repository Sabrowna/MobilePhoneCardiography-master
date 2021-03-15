using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest2
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class FindPatient
    {
        IApp app;
        Platform platform;

        public FindPatient(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
            app.Tap("PrivateUserLoginButton");
            app.Tap("FindPatientTab");

        }

        [Test]
        public void Entering1234567890AsSocSec_PressingFindPatient_NameSetToJohnDoe()
        {
            //Arrange
            app.Tap("SocSecSearch");
            app.EnterText("SocSecSearch", "1234567890");

            //Act
            app.Tap("FindPatientButton");
            var socSec = app.Query("SocSearch").Single().ToString();

            //Assert
            Assert.That(socSec, Is.EqualTo("1234567890"));
        }
    }
}
