using NUnit.Framework;
using System;
using Xamarin.UITest.Android;
using System.Reflection;
using System.IO;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Linq;
using System.Diagnostics;

namespace Evolve2016Twitter.UITest
{
    [TestFixture]
    public abstract class BaseTestFixture
    {
        protected IApp _app;
        protected internal IScreenQueries _queries;
        private IUITestConfiguration _config;

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            //NOTE(alison) multiple configurations should be supported here
            _config = new MainLocalConfiguration();
        }

        [SetUp]
        public void SetUp()
        {
            switch (TestEnvironment.Platform)
            {
                case TestPlatform.TestCloudiOS:
                    _queries = new iOSQueries();
                    _app = ConfigureApp.iOS.StartApp();
                    break;

                case TestPlatform.TestCloudAndroid:
                    _queries = new AndroidQueries();
                    _app = ConfigureApp.Android.StartApp();
                    break;

                case TestPlatform.Local:
#if __IOS__
                    throw new NotImplementedException("Try implementing this functionality");

#elif __ANDROID__
                    _app = ConfigureApp
                              .Android
                              .ApkFile(_config.PathToAPK)
                              .ApiKey(_config.API_KEY)
                              .StartApp();
                  _queries = new AndroidQueries();
#elif __IOS_DEVICE__
                    throw new NotImplementedException("Try implementing this functionality");
#endif
                    break;
                default:
                    throw new NotImplementedException($"I don't know this platform {TestEnvironment.Platform}");
            }
        }

        [Test]
        public void OpenREPL()
        {
            _app.Repl();
        }
    }
}

