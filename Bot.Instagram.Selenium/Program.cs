using System;
using OpenQA.Selenium;
using prmToolkit.Configuration;
using prmToolkit.Selenium;
using prmToolkit.Selenium.Enum;

namespace Bot.Instagram.Selenium
{
    class Program
    {
        static void Main(string[] args)
        {

            var username = Configuration.GetKeyAppSettings("usuario");
            var password = Configuration.GetKeyAppSettings("senha");

            IWebDriver webDriver = WebDriverFactory.CreateWebDriver(Browser.Chrome, @"/Volumes/Dev2/Estudo/bot/Driver");

            try
            {
                webDriver.LoadPage(TimeSpan.FromSeconds(30), "https://www.facebook.com/");


                webDriver.FindElement(By.XPath("/html/body/div[1]/div[2]/div[1]/div/div/div/div[2]/div/div[1]/form/div[1]/div[1]/input")).SendKeys(username);

                //webDriver.SetText(By.Name("password"), username);

                //webDriver.Submit(By.TagName("button"));

            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }
            

            Console.ReadKey();
        }
    }
}
