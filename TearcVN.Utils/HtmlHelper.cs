﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TearcVN.Utils
{
    public static class HtmlHelper
    {
        public static string GetNodeAttribute(string page, string xPath, string attribute = "")
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(page);
            var node = doc.DocumentNode.SelectSingleNode(xPath);
            if (node != null)
            {
                return string.IsNullOrWhiteSpace(attribute) ? node.InnerText : node.Attributes[attribute].Value;
            }
            else
            {
                return "";
            }
        }
    }
}
