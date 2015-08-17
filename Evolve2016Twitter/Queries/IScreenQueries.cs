using System;
using Xamarin.UITest.Queries;

namespace Evolve2016Twitter.UITest
{
    public interface IScreenQueries
    {
        //Login or Signup initial view
        Func<AppQuery, AppQuery> LoginInFirstViewButton { get; }

        //Authentication view
        Func<AppQuery, AppQuery> Username { get; }
        Func<AppQuery, AppQuery> Password { get; }
        Func<AppQuery, AppQuery> LoginButton { get; }

        //Timeline
        Func<AppQuery, AppQuery> OkButton { get; }
        Func<AppQuery, AppQuery> CreateNewTweet { get; }

        //Tweet Composer
        Func<AppQuery, AppQuery> TweetBox { get; }
        Func<AppQuery, AppQuery> SendTweetButton { get; }

        

    }
}

