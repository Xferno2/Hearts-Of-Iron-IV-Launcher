using Gecko;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace Hoi4_Launcher.Parser
{
    public class SteamHandler
    {
        public string steamLogin = "https://store.steampowered.com/login/";
        public string steamStore = "https://store.steampowered.com/";
        public string[] steamMods = { "https://steamcommunity.com/id/", "/myworkshopfiles/?appid=394360&browsefilter=mysubscriptions", "&p=" };
        public bool isAuthentificated = false;
        public List<string> userAndID = new List<string>();

        Timer browserCheck = new Timer(100);
        public bool checkIfAuthentificated(string url)
        {
            if (url == steamStore)
            { return true; }
            else { return false; }
        }
        public void getUser(GeckoWebBrowser browser)
        {
            HtmlDocument content = new HtmlDocument();
            content.LoadHtml(browser.Document.Body.OuterHtml);
            if (content.DocumentNode.OuterHtml != null)
            {
                HtmlNode contentNode = content.DocumentNode.SelectSingleNode("//div[contains(@class,'playerAvatar')]");
                string id = contentNode.ChildNodes[1].Attributes["href"].Value;
                string user = id.Split('/')[4];
                userAndID.Add(id);
                userAndID.Add(user);
            }
        }
        public Dictionary<string, Image> getModsImages(GeckoWebBrowser browser)
        {
            Dictionary<string, Image> modsIMG = new Dictionary<string, Image>();
            var steamModsUrl = steamMods[0] + userAndID.Last() + steamMods[1];
            browser.Navigate(steamModsUrl);
            while (browser.IsBusy) {
            };
            HtmlDocument content = new HtmlDocument();
            content.LoadHtml(browser.Document.Body.OuterHtml);
            if (content.DocumentNode.OuterHtml != null)
            {
                HtmlNode contentNode = content.DocumentNode.SelectSingleNode("//div[contains(@class,'workshopBrowsePagingControls')]");
                string lastEntri = contentNode.ChildNodes[contentNode.ChildNodes.Count - 2].InnerText;
            }
            return modsIMG;
        }
    }
}
