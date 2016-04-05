//Parameter Class @0-959C082F
//Target Framework version is 2.0
using System;
using System.Collections;

namespace calendar.Data
{
  
  public enum ParameterSourceType
  {
  	URL,
	Form,
	Cookie,
	Application,
	Session,
	Expression,
	Control
  }

  public abstract class Parameter
  {
	
	private object[] _values = new object[1];
	public object[] Values
	{
		get
		{
			return _values;
		}
		set
		{
			_values = value;
		}
	}

	public bool IsMultiple
	{
		get
		{
			return _values.Length > 1;
		}
	}


	private string _format = "";
	public string Format
	{
		get
		{
			return _format;
		}
		set
		{
			_format = value;
		}
	}

	private string _dBformat = "";
	public string DbFormat
	{
		get
		{
			return _dBformat;
		}
		set
		{
			_dBformat = value;
		}
	}

	protected bool _IsNull = false;
	public bool IsNull
	{
		get
		{
			return _IsNull;
		}
	}

    protected static object GetParamAsString(object param, object defaultValue)
    {
      if (param == null) return defaultValue;
      string strValue;
      strValue = param.ToString();
      if (strValue == "") return defaultValue;
      return param;
    }

	protected static object GetParamInternal(object val, ParameterSourceType type)
	{
		object result = null;
		System.Web.HttpContext current = System.Web.HttpContext.Current;
		switch(type)
		{
			case ParameterSourceType.URL:
				if(current.Request.QueryString[val.ToString()] == null) break;
				result = current.Request.QueryString.GetValues(val.ToString());
				break;
			case ParameterSourceType.Form:
				if(current.Request.Form[val.ToString()] == null) break;
				result = current.Request.Form.GetValues(val.ToString());
				break;
			case ParameterSourceType.Cookie:
				if(current.Request.Cookies[val.ToString()] == null) break;
				string[] temp = new string[current.Request.Cookies[val.ToString()].Values.Count];
				current.Request.Cookies[val.ToString()].Values.CopyTo(temp,0);
				result = temp;
				break;
			case ParameterSourceType.Application:
				result = current.Application[val.ToString()];
				break;
			case ParameterSourceType.Session:
				result = current.Session[val.ToString()];
				break;
			case ParameterSourceType.Expression:
			case ParameterSourceType.Control:
				result = val;
				break;

		}
		if(result is ICollection)
		{
			object[] temp = new object[((ICollection)result).Count];
			((ICollection)result).CopyTo(temp,0);
			bool flag = false;
			foreach(object o in temp)
				flag = flag || (o!=null && o.ToString() != "");
			if(!flag)
				return null;
		}
		else
		{
			if(result!=null && result.ToString()=="")
				return null;
		}
		return result;
	}

	public string ToString(string format)
	{
		return this.GetFormattedValue(format);
	}

	public string ToString(int index, string format)
	{
		return this.GetFormattedValue(index, format);
	}

	public virtual string GetFormattedValue(string format)
    {
      string result = "";
	  for(int i = 0; i < Values.Length; i++)
	  {
		  result += GetFormattedValue(i, format)+ ",";
	  }
	  return result.TrimEnd(',');
    }

	public abstract string GetFormattedValue(int index, string format);
	public abstract object GetValue();
	public abstract void SetValue(object value);
	public abstract void SetValue(object value, object defaultValue);
  } 
  
}

//End Parameter Class

