using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoi4_Launcher.Parser
{
    class Parser
    {
        private string removeBrackets(string text, string from, string to, bool tolast = true)
        {
            int pFrom = text.IndexOf(from) + from.Length;
            int pTo = 0;
            if (tolast)
            {
                pTo = text.LastIndexOf(to);
            }
            else
            {
                pTo = text.IndexOf(to);
            }
            try
            {
                return text.Substring(pFrom, pTo - pFrom);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        private string removeBrackets(string text, string limits, bool tolast = true)
        {
            int pFrom = text.IndexOf(limits) + limits.Length;
            int pTo = 0;
            if (tolast)
            {
                pTo = text.LastIndexOf(limits);
            }
            else
            {
                pTo = text.IndexOf(limits);
            }
            try
            {
                return text.Substring(pFrom, pTo - pFrom);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
