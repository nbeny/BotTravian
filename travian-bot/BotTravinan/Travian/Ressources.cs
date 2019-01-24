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

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * List current ressources available
 * Depot, bois, argile, fer, cereale et cilot
 */
namespace BotTravinan.Travian
{
    public class Ressources : List<Ressource>
    {

    }

    public class Ressource
    {
        public string Type { get; set; } = "";

        public string Xpath { get; set; } = "";
        public string Id { get; set; } = "";
        public string Value { get; set; } = "";

        public string XpathMax { get; set; } = "";
        public string IdMax { get; set; } = "";
        public string ValueMax { get; set; } = "";

        public static Bot InitRessources(string Url, ChromeDriver driver, Bot Bot)
        {
            string[] Type = { "Bois", "Terre", "Fer", "Cereales"};
            string[] Id = { "l1", "l2", "l3", "l4"};
            string[] IdMax = { "stockBarWarehouse", "stockBarWarehouse", "stockBarWarehouse", "stockBarGranary" };

            for (int i = 0; i < Id.Length; i++)
            {
                Ressource Ressource = new Ressource();
                IWebElement Value = driver.FindElement(By.Id(Id[i]));
                IWebElement ValueMax = driver.FindElement(By.Id(IdMax[i]));
                Ressource.Type = Type[i];
                Ressource.Id = Id[i];
                Ressource.Value = Value.Text;
                Ressource.IdMax = IdMax[i];
                Ressource.ValueMax = ValueMax.Text;
                Bot.Ressources.Add(Ressource);
            }

            return Bot;
        }

    }
}