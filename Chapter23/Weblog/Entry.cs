using System;
using System.IO;
using System.Xml.Serialization;

namespace WebLog
{
	/// <summary>
	/// Summary description for Entry.
	/// </summary>
	public class Entry
	{
		// members...
		private String _filename;
		private DateTime _timestamp;
		private String _title;
		private String _details;

		public Entry()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void Save()
		{
			// do we have a filename?
			if(Filename == null)
			{
				// get a filename based on the date...
				Timestamp = DateTime.Now;
				Filename = String.Format("{0:d4}{1:d2}{2:d2}_{3:d2}{4:d2}.xml",
												(int)Timestamp.Year, (int)Timestamp.Month, (int)Timestamp.Day,
												(int)Timestamp.Hour, (int)Timestamp.Minute);
			}

			// get the whole filename...
			String filepath = Global.EntryFilePath + "\\" + Filename;

			// create a serializer and save...
			FileInfo fileInfo = new FileInfo(filepath);
			if(fileInfo.Exists == true)
				fileInfo.Delete();
			FileStream stream = new FileStream(fileInfo.FullName, FileMode.Create);
			XmlSerializer serializer = new XmlSerializer(this.GetType());
			serializer.Serialize(stream, this);
			stream.Close();
		}

		[XmlIgnore()] public DateTime Timestamp
		{
			get
			{
				return _timestamp;
			}
			set
			{
				_timestamp = value;
			}
		}

		public String Title
		{
			get
			{
				return _title;
			}
			set
			{
				_title = value;
			}
		}

		public String Details
		{
			get
			{
				return _details;
			}
			set
			{
				_details = value;
			}
		}

		public String TimestampAsString
		{
			get
			{
				return Timestamp.ToString("dddd") + ", " + Timestamp.ToLongDateString();
			}
		}

		[XmlIgnore()] public String Filename
		{
			get
			{
				return _filename;
			}
			set
			{
				_filename = value;
			}
		}
	}
}
