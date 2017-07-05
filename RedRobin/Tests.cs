using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace RedRobin
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
            app.Screenshot("App Launched");
        }

        [Test]
        public void AppLaunched()
        {
            app.WaitForElement(x => x.Css("#ext-home-create-a-meal-btn-1"), timeout: TimeSpan.FromSeconds(80));
            app.Screenshot("First Page");
        }

        [Test]
        public void Repl()
        {
            app.Repl();
        }

        [Test]
        public void FirstTest()
        {
            #region Web CheatSheet
            //http://www.w3schools.com/cssref/css_selectors.asp
            #endregion

            #region How to Query for ALL elements 
            //app.Query(x => x.Css("body"));  
            #endregion

            #region How to Query for platform-specifc elements 
            //Android: app.Query(x => x.WebView().Invoke("getUrl"))
            //iOS: app.Query(x => x.WebView().Invoke("request").Invoke("URL").Invoke("absoluteString"))
            #endregion

            Thread.Sleep(15000);
            app.WaitForElement(x => x.Css("#ext-home-create-a-meal-btn-1"), timeout: TimeSpan.FromSeconds(80));
            app.Screenshot("App Launched");

            app.Tap(x => x.Css("#ext-home-create-a-meal-btn-1"));
            app.Screenshot("Tapped on 'Create a Meal' Button");

            app.Tap(x => x.Css(".x-list-item-label"));
            app.Screenshot("Tapped on 'Finest Burger'");

            app.Tap(x => x.Css(".x-list-item-label"));
            Thread.Sleep(2000);
            app.Screenshot("Tapped on 'Southen Charm' Button");

            Thread.Sleep(2000);
            app.Screenshot("Shows 'Sorry, No Photo Available'");

            app.Tap(x => x.Css("#ext-toolbar-allergens-1"));
            app.Screenshot("Tapped on 'Allergen Menu'");
            Thread.Sleep(8000);

            app.Tap(x => x.Css(".top"));
            app.Screenshot("Tapped on 'Red Robin Locations'");

            app.Tap(x => x.Css(".grey-text.loc_search_text"));
            app.Screenshot("Tapped on 'Enter Zip, Or City, State'");
            Thread.Sleep(4000);

            app.EnterText("94111");
            app.Screenshot("Entered in '94111'");

            app.DismissKeyboard();
            app.Screenshot("Dismissed Keyboard");

            app.Tap(x => x.Css(".loc_search_btn"));
            app.Screenshot("Tapped on Search Button");

            app.Back();
            app.Screenshot("Pressed back to get back to Main Menu");

            app.Back();
            app.Screenshot("Pressed back to get back to Main Menu");
        }
    }
}
