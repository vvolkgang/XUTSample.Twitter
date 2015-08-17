using System;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Evolve2016Twitter.UITest
{
    public static class IAppExtension
    {
        public static void TapAndWait(this IApp app, Func<AppQuery, AppQuery> tapQuery, Func<AppQuery, AppQuery> waitQuery, string afterWaitScreenshotTitle)
        {
            app.Tap(tapQuery);
            app.WaitForElement(waitQuery);
            app.Screenshot(afterWaitScreenshotTitle);

        }

        public static void TapAndWaitForNo(this IApp app, Func<AppQuery, AppQuery> tapQuery, Func<AppQuery, AppQuery> waitQuery, string afterWaitScreenshotTitle)
        {
            app.Tap(tapQuery);
            app.WaitForNoElement(waitQuery);
            app.Screenshot(afterWaitScreenshotTitle);
        }
        public static void WaitAndTap(this IApp app, Func<AppQuery, AppQuery> elementQuery, string afterWaitScreenshotTitle)
        {
            app.WaitForElement(elementQuery);
            app.Screenshot(afterWaitScreenshotTitle);
            app.Tap(elementQuery);
        }
        public static void WaitTapWait(this IApp app, Func<AppQuery, AppQuery> elementQuery, string afterWaitScreenshotTitle, Func<AppQuery, AppQuery> secondElementQuery, string afterSecondWaitScreenshotTitle)
        {
            app.WaitForElement(elementQuery);
            app.Screenshot(afterWaitScreenshotTitle);
            app.Tap(elementQuery);
            app.WaitForElement(secondElementQuery);
            app.Screenshot(afterSecondWaitScreenshotTitle);
        }

        public static void WaitAndEnterText( this IApp app, Func<AppQuery, AppQuery> elementQuery, string textToEnter, string afterTextEnterScreenshotTitle)
        {
            app.EnterText(elementQuery, textToEnter);
            app.Screenshot(afterTextEnterScreenshotTitle);
        }

        /// <summary>
        /// Suspends the test execution for X seconds
        /// </summary>
        /// <param name="app">IApp instance</param>
        /// <param name="seconds">Seconds the app will wait/sleep</param>
        public static void Wait(this IApp app, float seconds)
        {
            var waitTime = DateTime.Now + TimeSpan.FromSeconds(seconds);

            app.WaitFor(() => DateTime.Now > waitTime);
        }
    }

}