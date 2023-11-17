using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Dyscord
{
    public delegate void UpdateConversationDelegate(string text);
    public partial class DyscordForm : Form
    {
        string targetUser = "";
        string targetIp = "";
        int targetPort;
        string userIP = "";
        int userPort = 2222;
        Thread thread;
        Socket listener;

        public DyscordForm()
        {
            InitializeComponent();

            this.Show();
            SettingsForm settingsForm = new SettingsForm(this, userPort);
            settingsForm.ShowDialog();
            this.userPort = settingsForm.userPort;

            ThreadStart threadStart = new ThreadStart(Listen);
            thread = new Thread(threadStart);
            thread.Start();

            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress iPAddress in ipHost.AddressList)
            {
                if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    this.userIP = iPAddress.ToString();
                    break;
                }
            }

            this.loginButton.Click += new EventHandler(LoginButton__Click);
            this.userButton.Click += new EventHandler(UserButton__Click);
            this.exitButton.Click += new EventHandler(ExitButton__Click);
            this.sendButton.Click += new EventHandler(SendButton__Click);
            this.webBrowser2.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser2__DocumentCompleted);

            this.FormClosing += new FormClosingEventHandler(Form__FormClosing);
        }
        private void LoginButton__Click(object sender, EventArgs e)
        {
            if (userTextBox.TextLength > 0)
            {
                webBrowser2.Navigate("http://people.rit.edu/dxsigm/php/login.php?login=" + userTextBox.Text + "&ip=" + userIP + ":" + userPort);
                webBrowser2.Visible = false;
                userTextBox.Enabled = false;
                loginButton.Enabled = false;
            }
        }
        private void UserButton__Click(object sender, EventArgs e)
        {
            webBrowser2.Navigate("http://people.rit.edu/dxsigm/php/login.php?logins");
            webBrowser2.Visible = true;
            convoRichTextBox.SendToBack();
        }
        private void WebBrowser2__DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElementCollection htmlElementCollection;
            htmlElementCollection = webBrowser2.Document.GetElementsByTagName("button");
            foreach (HtmlElement htmlElement in htmlElementCollection)
            {
                htmlElement.Click += new HtmlElementEventHandler(HtmlElement__Click);
            }
        }

        private void HtmlElement__Click(object sender, HtmlElementEventArgs e)
        {
            string title;
            string[] ipPort;

            HtmlElement htmlElement = (HtmlElement)sender;
            title = htmlElement.GetAttribute("title");
            ipPort = title.Split(':');
            this.targetIp = ipPort[0];
            this.targetPort = Int32.Parse(ipPort[1]);

            this.targetUser = htmlElement.GetAttribute("name");
            this.groupBox1.Text = "conversing with " + targetUser;

            webBrowser2.Visible = false;
            webBrowser2.SendToBack();

        }
        private void SendButton__Click(object sender, EventArgs e)
        {
            if (targetIp.Length > 0)
            {
                IPAddress iPAddress = IPAddress.Parse(this.targetIp);
                IPEndPoint remoteEndPoint = new IPEndPoint(iPAddress, this.targetPort);

                Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Connect(remoteEndPoint);
                Stream netStream = new NetworkStream(server);
                StreamWriter writer = new StreamWriter(netStream);

                string msg = userTextBox.Text + ": " + messageRichTextBox.Text;
                writer.Write(msg.ToCharArray(), 0, msg.Length);
                writer.Close();
                netStream.Close();
                server.Close();

                this.convoRichTextBox.Text += "> " + this.targetUser + ": " + messageRichTextBox.Text + "\n";
                messageRichTextBox.Clear();
            }
        }

        private void ExitButton__Click(object sender, EventArgs e)
        {
            listener.Close();
            thread.Abort();
            Application.Exit();
        }

        private void Form__FormClosing(object sender, FormClosingEventArgs e)
        {
            listener.Close();
            thread.Abort();
        }

        public void UpdateConversation(string text)
        {
            this.convoRichTextBox.Text += text + '\n';
        }
        public void Listen()
        {
            UpdateConversationDelegate updateConversationDelegate;
            updateConversationDelegate = new UpdateConversationDelegate(UpdateConversation);

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, this.userPort);
            this.listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(serverEndPoint);

            listener.Listen(300);

            while (true)
            {
                Socket client = listener.Accept();
                Stream netStream = new NetworkStream(client);
                StreamReader reader = new StreamReader(netStream);
                string result = reader.ReadToEnd();

                // we cannot directly access windows forms controls from within a thread process
                //this.convoRichTextBox.Text += result + '\n';

                // we must use Invoke() with a delegate method that changes the contents of the control
                Invoke(updateConversationDelegate, result);

                reader.Close();
                netStream.Close();
                client.Close();

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DyscordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
