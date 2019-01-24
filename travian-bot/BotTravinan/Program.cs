/*
    // BotTravian - A C# .NET application
    // Copyright (C) 2018-2019 nbeny
    // <nbeny@student.42.fr>
    // This program is free software: you can redistribute it and/or modify
    // it under the terms of the GNU General Public License as published by
    // the Free Software Foundation, either version 3 of the License, or
    // (at your option) any later version.
    // This program is distributed in the hope that it will be useful,
    // but WITHOUT ANY WARRANTY; without even the implied warranty of
    // MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    // GNU General Public License for more details.
    // You should have received a copy of the GNU General Public License
    // along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BotTravinan.Travian;
using BotTravinan.Travian.Champs;

namespace BotTravinan
{
    class Program
    {
        static void PageLogin(string Url, ChromeDriver driver, Login Login)
        {
            driver.Navigate().GoToUrl(Url);

            

            // Get the html of the page
            var page = driver.PageSource;

            // Loads the page as html
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(page);

            //>>>>>>>>>>>>>>>>>>>>>>>>Login = NevisDeva<<<<<<<<<<<<<<<<<<<<<<<<<<<//
            ////*[@id="content"]/div[1]/div[1]/form/table/tbody/tr[1]/td[2]/input
            IWebElement Element_Login = driver.FindElement(By.Name("name"));//.SendKeys("//input[@name]");
            Element_Login.SendKeys(Login.Log);
            

            //>>>>>>>>>>>>>>>>>>>>>>>>PassWord = Azertrez<<<<<<<<<<<<<<<<<<<<<<<<<<<//
            IWebElement Element_PassWord = driver.FindElement(By.Name("password"));//.SendKeys("//input[@name]");
            Element_PassWord.SendKeys(Login.PassWord);
           

            IWebElement Element = driver.FindElementByXPath("//*[@id=\"s1\"]");
            Element.Click();

          
        }

        public static Bot Init(string Url, ChromeDriver driver, Bot Bot)
        {

            // Get the html of the page
            var page = driver.PageSource;

            // Loads the page as html
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(page);


            Bot = Ressource.InitRessources(Url, driver, Bot);
            Bot = MineArgile.InitMineArgile(Url, driver, Bot);
            Bot = Foret.InitForet(Url, driver, Bot);
            Bot = Ferme.InitFerme(Url, driver, Bot);
            Bot = MineRoche.InitMineRoche(Url, driver, Bot);

            return Bot;
        }

        public static string CheckChamps(Bot Bot, Login Login)
        {
            for (int i = 0; i < Bot.Champ.Fermes.Count; i++)
            {
                if (Login.Lvl == Int32.Parse(Bot.Champ.Fermes[i].Lvl))
                    return "Fermes";
            }
            for (int i = 0; i < Bot.Champ.Forets.Count; i++)
            {
                if (Login.Lvl == Int32.Parse(Bot.Champ.Forets[i].Lvl))
                    return "Forets";
            }
            for (int i = 0; i < Bot.Champ.MinesArgile.Count; i++)
            {
                if (Login.Lvl == Int32.Parse(Bot.Champ.MinesArgile[i].Lvl))
                    return "MinesArgile";
            }
            for (int i = 0; i < Bot.Champ.MinesRoche.Count; i++)
            {
                if (Login.Lvl == Int32.Parse(Bot.Champ.MinesRoche[i].Lvl))
                    return "MinesRoche";
            }
            return null;
        }

        static void Main(string[] args)
        {
            Login Login = new Login();

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--user-agent=(KHTML, like Gecko) Chrome/59.0.3071.115");
            options.AddArgument("--mute-audio");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--incognito");
            ChromeDriver driver = new ChromeDriver(options);
            Bot Bot = new Bot();

            PageLogin(Login.Url, driver, Login);
            while (true)
            {
                Bot = Init(Login.Url, driver, Bot);
                if (CheckChamps(Bot, Login).Contains("Fermes"))
                    Ferme.BuildFerme(Login.Url, driver, Bot, Login);
                else if (CheckChamps(Bot, Login).Contains("Forets"))
                    Foret.BuildForet(Login.Url, driver, Bot, Login);
                else if (CheckChamps(Bot, Login).Contains("MinesArgile"))
                    MineArgile.BuildMineArgile(Login.Url, driver, Bot, Login);
                else if (CheckChamps(Bot, Login).Contains("MinesRoche"))
                    MineRoche.BuildMineRoche(Login.Url, driver, Bot, Login);
                else
                {
                    //Champ.BuildChamp(Login.Url, driver, Bot);
                    Login.Lvl += 1;
                }
            }
            Console.WriteLine("End !");
        }
    }
}
