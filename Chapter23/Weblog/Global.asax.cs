using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.IO;
using System.Xml.Serialization;

namespace WebLog 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		// members...
        public static String EntryFilePath;		

		protected void Application_Start(Object sender, EventArgs e)
		{
			// set the shared entry path member...
			EntryFilePath = Server.MapPath("Entries");
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
			// configure the session...
			Session["canedit"] = false;
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}

		// LoadEntry - load an entry from disk...
		public static Entry LoadEntry(String filename)
		{
			// we have the name, but we need the path...
			String filepath = EntryFilePath + "\\" + filename;

			// open the file...
			FileStream file = new FileStream(filepath, FileMode.Open);

			// create a serializer...
			XmlSerializer serializer = new XmlSerializer(typeof(Entry));
			Entry newEntry = (Entry)serializer.Deserialize(file);

			// close the file...
			file.Close();

			// update timestamp and filename...
			newEntry.Timestamp = new FileInfo(filepath).LastWriteTime;
			newEntry.Filename = filename;

			// return the entry...
			return newEntry;
		}

		// LoadAllEntries - load all entries from disk...
		public static Entry[] LoadAllEntries()
		{
			// get the path containing the entries...
			DirectoryInfo entryFolder = new DirectoryInfo(EntryFilePath);

			// get a list of files...
			FileInfo[] files = entryFolder.GetFiles();

			// create an array of entries...
			Entry[] entries = new Entry[files.Length];

			// loop through and load each file...
			int index = files.Length - 1;
			foreach(FileInfo file in files)
			{
				entries[index] = LoadEntry(file.Name);
				index--;
			}

			// return the list...
			return entries;
		}
	}
}

