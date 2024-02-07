using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GifFinder
{
    public partial class GifFinder : Form
    {

        SearchForm searchForm;
        public GifFinder()
        {
            InitializeComponent();

            try
            {
                // Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; WOW64; Trident / 7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729; wbx 1.0.0)
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(
                    @"SOFTWARE\\WOW6432Node\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION",
                    true);
                key.SetValue(Application.ExecutablePath.Replace(Application.StartupPath + "\\", ""), 12001, Microsoft.Win32.RegistryValueKind.DWord);
                key.Close();
            }
            catch
            {

            }

            searchForm = new SearchForm();

            timer1.Interval = 100;
            timer1.Tick += new EventHandler(Timer1__Tick);

            webBrowser1.Navigate("https://people.rit.edu/dxsigm/gif-finder.html");

            this.tileToolStripMenuItem.Click += new EventHandler(TileToolStripMenuItem__Click);
            this.cascadeToolStripMenuItem.Click += new EventHandler(CascadeToolStripMenuItem__Click);
            this.exitToolStripMenuItem.Click += new EventHandler(ExitToolStripMenuItem__Click);
            this.newSearchToolStripMenuItem.Click += new EventHandler(NewSearchToolStripMenuItem__Click);
        }

        public void TileToolStripMenuItem__Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }
        public void CascadeToolStripMenuItem__Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }
        public void ExitToolStripMenuItem__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void NewSearchToolStripMenuItem__Click(object sender, EventArgs e)
        {
            this.searchForm.ShowDialog();

            if(searchForm.response == "OK")
            {
                HtmlElement htmlElement;

                htmlElement = webBrowser1.Document.GetElementById("searchterm");
                htmlElement.SetAttribute("value", searchForm.searchTerm);

                htmlElement = webBrowser1.Document.GetElementById("limit");
                htmlElement.SetAttribute("value", Convert.ToString(searchForm.maxItems));

                webBrowser1.Document.InvokeScript("searchButtonClicked");

                timer1.Start();
            }
        }

        private void Timer1__Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            HtmlElement htmlElement = webBrowser1.Document.GetElementById("lastelement");

            if( htmlElement != null)
            {
                HtmlElementCollection htmlElementCollection;
                htmlElementCollection = webBrowser1.Document.GetElementsByTagName("img");
                foreach (HtmlElement htmlElement1 in htmlElementCollection)
                {
                    ImageForm imageForm = new ImageForm(this, htmlElement1.GetAttribute("src"), htmlElement.GetAttribute("title"));
                    imageForm.Show();
                }

                htmlElement.OuterHtml = "";

            }
            else
            {
                timer1.Start();
            }
        } 

    }
}
