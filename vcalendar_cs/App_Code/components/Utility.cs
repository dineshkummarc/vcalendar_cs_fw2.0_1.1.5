//Using statements @1-496ABA10
//Target Framework version is 2.0
namespace calendar
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Web;
    using System.Web.UI.WebControls;
	using System.IO;
	using System.Text;
	using System.Web.SessionState;
	using System.Resources;
	using System.Globalization;
	using System.Collections.Specialized;

//End Using statements

//ResponseFilter class @2b-810E296A
	public delegate bool OnFilterCloseHandler (string htmlContent, Stream responseStream);
	public class ResponseFilter : Stream 
	{
 
		#region properties
 
		Stream responseStream;
		long position;
		StringBuilder html = new StringBuilder();
		public event OnFilterCloseHandler OnFilterClose;
 
		#endregion
 
		#region constructor

		public ResponseFilter(Stream inputStream) 
		{
 			responseStream = inputStream;
 		}
 
		#endregion

		#region implemented abstract members
 
		public override bool CanRead 
		{
			get { return true; }
		}

		public override bool CanSeek 
		{
			get { return true; }
		}

		public override bool CanWrite 
		{
			get { return true; }
		}

		public override void Close() 
		{
			byte[] data;

			if(OnFilterClose != null)
			{
				string temp = html.ToString();
				if(!OnFilterClose(temp, responseStream)) return;
				data = System.Text.UTF8Encoding.UTF8.GetBytes(temp);
				
			}
			else
			{
				data = System.Text.UTF8Encoding.UTF8.GetBytes(html.ToString());
			}
			responseStream.Write(data, 0, data.Length);			
			responseStream.Close();
		}

		public override void Flush() 
		{
			responseStream.Flush();
		}
 
		public override long Length 
		{
			get { return 0; }
		}

		public override long Position 
		{
			get { return position; }
			set { position = value; }
		}

		public override long Seek(long offset, System.IO.SeekOrigin direction) 
		{
			return responseStream.Seek(offset, direction);
		}

		public override void SetLength(long length) 
		{
			responseStream.SetLength(length);
		}

		public override int Read(byte[] buffer, int offset, int count) 
		{
			return responseStream.Read(buffer, offset, count);
		}
 
		#endregion

		#region write method
 
		public override void Write(byte[] buffer, int offset, int count) 
		{
			html.Append(System.Text.UTF8Encoding.UTF8.GetString(buffer, offset, count));
		}
  
		#endregion
  
	}

//End ResponseFilter class

//CCSResourceManager class @1-12C3AB9C
		public class CCSResourceManager:ResourceManager
		{

			public CCSResourceManager(string baseName, System.Reflection.Assembly assembly):base(baseName,assembly)
			{}

			public override string GetString(string name)
			{
				string val = null;
				val = base.GetString(name);
				if(val == null) val = name;
				return val;
			}
			public override string GetString(string name, CultureInfo culture)
			{
				string val = null;
				val = base.GetString(name, culture);
				if(val == null) val = name;
				return val;
			}

		}

//End CCSResourceManager class

    public class Utility{ //Utility class @1-F3513C2E

//SetThreadCulture method @1-3D69C828
        public static void SetThreadCulture()
        {
		  bool isCultureSelected = false;
		  HttpContext current = HttpContext.Current;
		  Hashtable locales = (Hashtable)current.Application["_locales"];
		  if( current.Application[current.Request.PhysicalPath] != null )
            current.Request.ContentEncoding = System.Text.Encoding.GetEncoding(current.Application[current.Request.PhysicalPath].ToString());
          string culture = "";
		  
		  if(current.Request.QueryString["locale"]!=null)
		    culture = current.Request.QueryString["locale"];
		  
		  if(culture=="" && current.Request.Cookies["locale"]!=null)
			culture = current.Request.Cookies["locale"].Value;
		  
		  if(culture=="" && current.Session["locale"]!=null)
		    culture = current.Session["locale"].ToString();
		  else if(culture=="" && current.Session["lang"]!=null)
		    culture = current.Session["lang"].ToString();
		  

		  if(!isCultureSelected)
		  {
			if(locales.ContainsKey(culture) && culture.IndexOf("-")>0)
				isCultureSelected = true;

			if(!locales.ContainsKey(culture) && culture.IndexOf("-")>0)
				culture = culture.Split(new char[]{'-'})[0];

			if(locales.ContainsKey(culture) && culture.IndexOf("-")<0)
				isCultureSelected = true;
		  }

		  if(!isCultureSelected) 
		  
			 culture = Configuration.Settings.SiteLanguage;

	      System.Threading.Thread.CurrentThread.CurrentCulture = (CultureInfo)locales[culture];
		  System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;
  		  
			HttpCookie cookie = new HttpCookie("locale",culture);
			
			cookie.Expires = DateTime.Now.AddDays(365);
			
			current.Response.Cookies.Add(cookie);
		  
		    current.Session["locale"] = culture;
		    current.Session["lang"]= System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
		    Configuration.Settings.BoolFormat = ((CCSCultureInfo)locales[culture]).BooleanFormat;
		  
        }

//End SetThreadCulture method

//GetPageStyle method @1-F8F70EAE
        public static string GetPageStyle()
        {
		  HttpContext current = HttpContext.Current;
          string style = "";
		  
		  if(current.Request.QueryString["style"]!=null)
		    style = current.Request.QueryString["style"];
		  
		  if(style=="" && current.Request.Cookies["style"]!=null)
			style = current.Request.Cookies["style"].Value;
		  
		  if(style=="" && current.Session["style"]!=null)
		    style = current.Session["style"].ToString();
		  
			HttpCookie cookie = new HttpCookie("style",style);
			
			cookie.Expires = DateTime.Now.AddDays(365);
			
			current.Response.Cookies.Add(cookie);
		  
		    current.Session["style"]= style;
		  
		  style = style.Trim();
		  if(style!="") 
		  {
			string root = HttpContext.Current.Server.MapPath("~/Styles/" + style + "/Style.css");
			if(!System.IO.File.Exists(root))
				style = "";
		  }
		  
//End GetPageStyle method

//		  if(style == null || style == "")
//			  style = CommonFunctions.str_calendar_config("default_style");

//GetPageStyle method tail @1-D9858089
		  if(style == null || style == "")
			  style = "Blueprint"; 
		  
		  return style;
        }
//End GetPageStyle method tail

//ManageGalleryPanels method @1-6668F875
        public static void ManageGalleryPanels(RepeaterItem currentItem, int numberOfColumns, int currentRow, int pageSize, string openPanelName, string closePanelName, string controlsPanelName, int dataRows, ref bool isForceIteration)
        {
		    int maxRowNumber = dataRows % numberOfColumns == 0 ? dataRows :  (dataRows / numberOfColumns + 1) * numberOfColumns;
			System.Web.UI.Control c = currentItem.FindControl(openPanelName);
			if(c!=null)
				c.Visible = currentRow % numberOfColumns == 1 && currentRow < maxRowNumber;
			c = currentItem.FindControl(closePanelName);
			if(c!=null)
			    c.Visible = currentRow % numberOfColumns == 0 || currentRow == maxRowNumber;
			c = currentItem.FindControl(controlsPanelName);
			if(c!=null)
				c.Visible = currentRow <= dataRows;

			isForceIteration = currentRow < maxRowNumber && currentRow >= pageSize;
        }

//End ManageGalleryPanels method

//End Utility class @1-FCB6E20C
	}
//End End Utility class

} //End namespace @1-FCB6E20C

