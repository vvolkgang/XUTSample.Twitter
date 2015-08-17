using System;
using Xamarin.UITest.Queries;

namespace Evolve2016Twitter.UITest
{
    public class iOSQueries : IScreenQueries
    {
        //Login or Signup initial view
        public Func<AppQuery, AppQuery> LoginInFirstViewButton => v => v.Id("log_in");

        //Authentication view
        public Func<AppQuery, AppQuery> Username => v => v.Id("login_identifier");
        public Func<AppQuery, AppQuery> Password => v => v.Id("login_password");
        public Func<AppQuery, AppQuery> LoginButton => v => v.Id("login_login");

        //Timeline
        public Func<AppQuery, AppQuery> OkButton => v => v.Marked("OK");
        public Func<AppQuery, AppQuery> CreateNewTweet => v => v.Id("composer_write");

        //Tweet Composer
        public Func<AppQuery, AppQuery> TweetBox => v => v.Id("tweet_box");
        public Func<AppQuery, AppQuery> SendTweetButton => v => v.Id("composer_post");
    }
}

