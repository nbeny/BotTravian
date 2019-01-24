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
using BotTravinan.Travian.Champs;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;

namespace BotTravinan.Travian
{
    public class Champ
    {
        public Champ()
        {
            Fermes = new Fermes();
            Forets = new Forets();
            MinesRoche = new MinesRoche();
            MinesArgile = new MinesArgile();
        }

        public Fermes Fermes { get; set; }
        public Forets Forets { get; set; }
        public MinesRoche MinesRoche { get; set; }
        public MinesArgile MinesArgile { get; set; }

        public static void BuildChamp(string Url, ChromeDriver driver, Bot Bot)
        {
            for (int i = 0; i < Bot.Champ.Fermes.Count; i++)
            {
                IWebElement Ferme = driver.FindElementByXPath(Bot.Champ.Fermes[i].Xpath);
                Ferme.Click();
                Thread.Sleep(2000);

                var page = driver.PageSource;

                // Loads the page as html
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(page);

                var Gold = doc.DocumentNode.SelectNodes("/html/body/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[3]/div[4]/div[1]/button/div/div[2]/span");
                if (Gold == null)
                {
                    IWebElement Up3 = driver.FindElementByXPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[3]/div[4]/div[1]/span");
                    string opgg3 = Up3.Text;
                    if (opgg3[1] == ':')
                        opgg3 = "0" + Up3.Text;
                    DateTime time_build = DateTime.ParseExact(opgg3, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                    DateTime time_now = DateTime.Now;

                    DateTime time_update = time_now.AddHours(time_build.Hour);
                    time_update = time_update.AddMinutes(time_build.Minute);
                    time_update = time_update.AddSeconds(time_build.Second);
                    double millisec = (time_update.ToUniversalTime() - time_now.ToUniversalTime()).TotalMilliseconds;

                    IWebElement Up = driver.FindElementByXPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[3]/div[4]/div[1]/button/div");
                    Up.Click();
                    Thread.Sleep((int)millisec);
                }
                else
                {
                    IWebElement Close = driver.FindElementByXPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[1]/a");
                    if (Close != null)
                        Close.Click();
                    Thread.Sleep(1000);
                }

            }

            for (int i = 0; i < Bot.Champ.Forets.Count; i++)
            {
                IWebElement Foret = driver.FindElementByXPath(Bot.Champ.Forets[i].Xpath);
                Foret.Click();
                Thread.Sleep(2000);

                var page = driver.PageSource;

                // Loads the page as html
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(page);

                var Gold = doc.DocumentNode.SelectNodes("/html/body/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[3]/div[4]/div[1]/button/div/div[2]/span");
                if (Gold == null)
                {
                    IWebElement Up3 = driver.FindElementByXPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[3]/div[4]/div[1]/span");
                    string opgg3 = Up3.Text;
                    DateTime time_build = DateTime.ParseExact(opgg3, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                    DateTime time_now = DateTime.Now;

                    DateTime time_update = time_now.AddHours(time_build.Hour);
                    time_update = time_update.AddMinutes(time_build.Minute);
                    time_update = time_update.AddSeconds(time_build.Second);
                    double millisec = (time_update.ToUniversalTime() - time_now.ToUniversalTime()).TotalMilliseconds;

                    IWebElement Up = driver.FindElementByXPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[3]/div[4]/div[1]/button/div");
                    Up.Click();
                    Thread.Sleep((int)millisec);
                }
                else
                {
                    IWebElement Close = driver.FindElementByXPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[1]/a");
                    if (Close != null)
                        Close.Click();
                    Thread.Sleep(1000);
                }

            }

            for (int i = 0; i < Bot.Champ.MinesArgile.Count; i++)
            {
                IWebElement MineAgrile = driver.FindElementByXPath(Bot.Champ.MinesArgile[i].Xpath);
                MineAgrile.Click();
                Thread.Sleep(2000);

                var page = driver.PageSource;

                // Loads the page as html
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(page);

                var Gold = doc.DocumentNode.SelectNodes("/html/body/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[3]/div[4]/div[1]/button/div/div[2]/span");
                if (Gold == null)
                {
                    IWebElement Up3 = driver.FindElementByXPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[3]/div[4]/div[1]/span");
                    string opgg3 = "0" + Up3.Text;
                    DateTime time_build = DateTime.ParseExact(opgg3, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                    DateTime time_now = DateTime.Now;

                    DateTime time_update = time_now.AddHours(time_build.Hour);
                    time_update = time_update.AddMinutes(time_build.Minute);
                    time_update = time_update.AddSeconds(time_build.Second);
                    double millisec = (time_update.ToUniversalTime() - time_now.ToUniversalTime()).TotalMilliseconds;

                    IWebElement Up = driver.FindElementByXPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[3]/div[4]/div[1]/button/div");
                    Up.Click();
                    Thread.Sleep((int)millisec);
                }
                else
                {
                    IWebElement Close = driver.FindElementByXPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[1]/a");
                    if (Close != null)
                        Close.Click();
                    Thread.Sleep(1000);
                }
            }

            for (int i = 0; i < Bot.Champ.MinesRoche.Count; i++)
            {
                IWebElement MineRoche = driver.FindElementByXPath(Bot.Champ.MinesRoche[i].Xpath);
                MineRoche.Click();
                Thread.Sleep(1000);

                var page = driver.PageSource;

                // Loads the page as html
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(page);

                var Gold = doc.DocumentNode.SelectNodes("/html/body/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[3]/div[4]/div[1]/button/div/div[2]/span");
                if (Gold == null)
                {
                    IWebElement Up3 = driver.FindElementByXPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[3]/div[4]/div[1]/span");
                    string opgg3 = Up3.Text;
                    DateTime time_build = DateTime.ParseExact(opgg3, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                    DateTime time_now = DateTime.Now;

                    DateTime time_update = time_now.AddHours(time_build.Hour);
                    time_update = time_update.AddMinutes(time_build.Minute);
                    time_update = time_update.AddSeconds(time_build.Second);
                    double millisec = (time_update.ToUniversalTime() - time_now.ToUniversalTime()).TotalMilliseconds;

                    ////html/body/div[1]/div[2]/div[2]/div[2]/div[1]
                    IWebElement Up = driver.FindElementByXPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[3]/div[4]/div[1]/button/div");
                    Up.Click();
                    Thread.Sleep((int)millisec);
                }
                else
                {
                    IWebElement Close = driver.FindElementByXPath("/html/body/div[1]/div[2]/div[2]/div[2]/div[1]/a");
                    if (Close != null)
                        Close.Click();
                }
            }
        }
    }
}
