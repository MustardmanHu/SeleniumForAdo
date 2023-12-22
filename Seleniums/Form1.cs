using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Seleniums
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private By findbyXpath(string xpath)
        {
            return By.XPath(xpath);
        }
        private By findbyCSSSelector(string selector)
        {
            return By.CssSelector(selector);
        }

        private void Form1_LoadAsync(object sender, EventArgs e)
        {
            var service = EdgeDriverService.CreateDefaultService(@".", "msedgedriver.exe");
            using (IWebDriver driver = new OpenQA.Selenium.Edge.EdgeDriver(service))
            {
                driver.Navigate().GoToUrl("https://ticketplus.com.tw/activity/54fdee72c71c18cc2b694801e11e77cd");
                var source = driver.PageSource;
                Thread.Sleep(300);
                var confirm = driver.FindElement(findbyXpath("/html/body/div/div[2]/div/div/div[3]/div[2]/div[2]/button"));
                confirm.Click();
                Thread.Sleep(1000);
                var buybtn = driver.FindElement(findbyXpath("/html/body/div/div/div/div/main/div/div/div[4]/div[1]/div/div/div[2]/div/button"));
                buybtn.Click();
                var cellphonenumber = driver.FindElement(findbyXpath("//*[@id=\"MazPhoneNumberInput-102_phone_number\"]"));
                cellphonenumber.SendKeys("0932833520");
                var password = driver.FindElement(findbyXpath("//*[@id=\"input-108\"]"));
                password.SendKeys("Hu870803");
                var Login = driver.FindElement(findbyXpath("//*[@id=\"app\"]/div[3]/div/div[1]/div/div[2]/div[1]/form/button"));
                Login.Click();
                Thread.Sleep(2000);
                var ChooseSeat = driver.FindElement(findbyXpath("/html/body/div/div[1]/div/div/main/div/div/div[2]/div[3]/div/div[2]/div[2]/div[2]/div/div[2]/div/div/div/div[4]/button"));
                Thread.Sleep(1500);
                var picture = driver.FindElement(findbyCSSSelector("#app > div.v-application--wrap > div > div > main > div > div > div:nth-child(2) > div.order-content > div > div.v-card.v-sheet.theme--light.py-5.mt-4.mt-md-10.has-ticketarea > div.recaptcha-area.grey.lighten-3.pa-5.ma-md-5 > div > div.d-flex.flex-column.flex-md-row.align-start.align-md-center.col-sm-4.col-6 > span.captcha-img"));
                Thread.Sleep(8000);
                /////////////////////////////////填入驗證碼////////////////////////////////////////
                ChooseSeat.Click();
                var read = driver.FindElement(findbyXpath("/html/body/div/div/div/div/main/div/div/div/div[5]/div/div/div[2]/div/div/div/div/input"));
                read.Click();
                var nextStep = driver.FindElement(findbyXpath("/html/body/div/div/div/div/main/div/div/div/div[5]/div/div/div[3]/button"));
                nextStep.Click();
                var getTicket = driver.FindElement(findbyXpath("/html/body/div/div[1]/div/div/main/div/div/div[2]/div[4]/div/div[2]/div[2]/div/div/div[1]/div/div/div/input"));
                getTicket.Click();
                var CreditCard = driver.FindElement(findbyXpath("/html/body/div/div[1]/div/div/main/div/div/div[2]/div[4]/div/div[3]/div[2]/div/div/div[1]/div/div[1]/div/input"));
                CreditCard.Click();
                var GoPay = driver.FindElement(findbyXpath("/html/body/div/div[1]/div/div/main/div/div/div[2]/div[5]/div/div/div[2]/button[2]"));
                GoPay.Click();
            }
        }
        private string TwoCaptchaAsync()
        {
            TwoCaptcha.TwoCaptcha solver = new TwoCaptcha.TwoCaptcha("d2e8876f3decfa2ddf2476f7b444f57f");
            TwoCaptcha.Captcha.ReCaptcha captcha = new TwoCaptcha.Captcha.ReCaptcha();
            captcha.SetSiteKey("6LeIR-kgAAAAAP97q8LZhoBdGpLjbB7hez8rPCLB");
            captcha.SetUrl("https://ticketplus.com.tw/order/54fdee72c71c18cc2b694801e11e77cd/f0f79e5625bc6c00e54cbe419bbde9fe");
            try
            {
                solver.Solve(captcha).Wait();
                Console.WriteLine("Captcha solved: " + captcha.Code);
                return captcha.Code;
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Error occurred: " + e.InnerExceptions.First().Message);
                return e.InnerExceptions.First().Message;
            }
        }
    }
}