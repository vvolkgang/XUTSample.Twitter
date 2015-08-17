using NUnit.Framework;
using System;
using Xamarin.UITest.Android;
using System.Reflection;
using System.IO;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Linq;
using Evolve2016Twitter;

namespace Evolve2016Twitter.UITest
{
    [TestFixture]
    public class TwitterUiTest : BaseTestFixture
    {
        private const string _username = "CHAMGE_ME";
        private const string _password = "CHANGE_ME";
        private readonly string _tweet = $"@XamarinHQ #TweetCeption from device {DeviceId} in #TestCloud. Check #DementedVice and @vvolkgang for results!";

        private static string DeviceId => Environment.GetEnvironmentVariable("XTC_DEVICE_INDEX") ?? "1";

        [Test]
        public void Login_and_tweet()
        {
            //LOGIN
            _app.WaitTapWait(_queries.LoginInFirstViewButton, "Given I'm in the initial view",
                            _queries.Username, "When I tap Login button, I'm presented with the Login view");
            _app.WaitAndEnterText(_queries.Username, _username, "After I insert my Username, I can see the username field filled");
            _app.WaitAndEnterText(_queries.Password, _password, "After I insert my Password, I can see the password field filled");

            _app.TapAndWait(_queries.LoginButton, _queries.OkButton, "When I tap the Login button, I can see the Logged in view");

            _app.Tap(_queries.OkButton); //NOTE(alison) this is the "Twitter would like to use your location" dialog

            _app.Screenshot("After I login, I can see the twitter timeline");

            //TWEET
            _app.TapAndWait(_queries.CreateNewTweet, _queries.TweetBox, "After I tap the Whats Happening box, I can see the tweet composer");
            _app.EnterText(_queries.TweetBox, _tweet );
            _app.Screenshot("After I insert my tweet, I can see the composer view filled");

            _app.TapAndWait(_queries.SendTweetButton, _queries.CreateNewTweet, "When I tap Tweet button, I'm back to the timeline");
        }

    }
}

