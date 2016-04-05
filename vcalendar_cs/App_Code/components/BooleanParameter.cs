//BooleanParameter Class @0-C5947CCE
//Target Framework version is 2.0
using System;
using System.Globalization;
using System.Collections;

namespace calendar.Data
{

  public class BooleanParameter : Parameter
  {
  
    public bool Value
    {
      get 
      {
		return (bool)Values[0];
	  }
      set 
      {
		Values[0] = value;
	  }
    }

	public BooleanParameter():this(false, "", "")
    {}

	public BooleanParameter(string format):this(false, format, "")
    {}

	public BooleanParameter(string format, string dbFormat):this(false, format, dbFormat)
    {}
   
    public BooleanParameter(bool boolValue):this(boolValue, "", "")
    {}

    public BooleanParameter(bool boolValue, string format):this(boolValue, format, "")
    {}

    public BooleanParameter(bool boolValue, string format, string dbFormat)
    {
      Value = boolValue;
	  Format = format;
	  DbFormat = dbFormat;
    }
   
    public override object GetValue()
    {
      return (object)Value;
    }

	public override string GetFormattedValue(int index, string format)
    {
  	  object v = null;
	  if(Values.Length > index)
		  v = Values[index];
	  else
		  return "NULL";
	  bool val = false; 
	  if(v != null)
		val = (bool)v;
	  else
		return "NULL";
		
	  string fVal = DBUtility.FormatBool(val, format);
	  try{
		Int32.Parse(fVal);
		return fVal;
	  }catch{
		if(fVal.ToLower(CultureInfo.CurrentCulture)=="true" || fVal.ToLower(CultureInfo.CurrentCulture)=="false")
		  return fVal;
		else
		  return "'"+fVal+"'";
	  }
    }

	public override string ToString()
	{
		return this.GetFormattedValue(DbFormat);
	}

	public override void SetValue(object value)
	{
		SetValue(value, null);
	}

	public override void SetValue(object value, object defaultValue)
	{
		if(value == null)
			value = defaultValue;
		if(value == null)
			_IsNull = true;
		else
			Value = GetTypedVal(value, Format);
	}

	private static bool GetTypedVal(object val, string format)
	{
      if(val is string)
        return DBUtility.ParseBool(val.ToString(),format);
      else
        return Convert.ToBoolean(val);
	}

    public static BooleanParameter GetParam(object param, object defaultValue)
    {
      return GetParam(param, "", defaultValue);
    }
   
    public static BooleanParameter GetParam(object param)
    {
      return GetParam(param, "", null);
    }
   
    public static BooleanParameter GetParam(object param, string format)
    {
      return GetParam(param, format, null);
    }

    public static BooleanParameter GetParam(object param, string format, object defaultValue)
	{
		return GetParam(param, ParameterSourceType.Expression, format, defaultValue, false);
	}
   
    public static BooleanParameter GetParam(object param, ParameterSourceType type, string format, object defaultValue, bool isNullable)
    {
	  object val = GetParamInternal(param,type);

	  if(val == null) val = defaultValue;
	  BooleanParameter p = new BooleanParameter();
	  if(val == null)
	  {
		if(!isNullable) return null;
		p._IsNull = true;
		return p;
	  }

      if(val is ICollection)
	  {
		p.Values = new object[((ICollection)val).Count];
		((ICollection)val).CopyTo(p.Values,0);
		for(int i = 0; i<p.Values.Length; i++)
			if(p.Values[i] != null)
				p.Values[i] = GetTypedVal(p.Values[i], format);
	  }
	  else
	  {
		p.Value = GetTypedVal(val, format);
	  }
      return p;
    }

	
    
  } 
  
}

//End BooleanParameter Class

