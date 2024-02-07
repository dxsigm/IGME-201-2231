using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE20Dom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 11001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }

            this.webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser1__DocumentCompleted);
            this.webBrowser1.Navigate("people.rit.edu/dxsigm/example.html");

        }

        private void WebBrowser1__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = (WebBrowser)sender;
            HtmlElementCollection htmlElementCollection;
            HtmlElement htmlElement;

            htmlElementCollection = webBrowser.Document.GetElementsByTagName("h1");
            htmlElementCollection[0].InnerText = "My UFO Page";

            htmlElementCollection = webBrowser.Document.GetElementsByTagName("h2");
            htmlElementCollection[0].InnerText = "My UFO Info";
            htmlElementCollection[1].InnerText = "My UFO Pictures";
            htmlElementCollection[2].InnerText = "";

            htmlElement = webBrowser.Document.Body;
            htmlElement.Style += "font-family: sans-serif; color: #a00000;";

            htmlElementCollection = webBrowser.Document.GetElementsByTagName("p");
            htmlElementCollection[0].InnerHtml = "Report your UFO sightings here: <a href='http://www.nuforc.org'>www.nuforc.org</a>";
            htmlElementCollection[0].Style += "color: green; font-weight: bold; font-size: 2em; text-transform: uppercase; text-shadow: 3px 2px #A44";
            htmlElementCollection[1].InnerText = "";

            htmlElement = webBrowser.Document.CreateElement("img");
            htmlElement.SetAttribute("src", "https://images.hindustantimes.com/rf/image_size_630x354/HT/p2/2020/04/28/Pictures/ufo-in-space_e22330e2-8917-11ea-8e78-f1b6d2f5bc87.jpg");

            htmlElementCollection[2].InsertAdjacentElement(HtmlElementInsertionOrientation.AfterBegin, htmlElement);

            htmlElement = webBrowser.Document.CreateElement("footer");

            htmlElement.InnerHtml = "&copy;2019 <a href='http://www.nerdtherapy.org'>D.Schuh</a>";

            webBrowser.Document.Body.AppendChild(htmlElement);

        }

    }
}
