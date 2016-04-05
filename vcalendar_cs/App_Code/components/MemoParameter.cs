//MemoParameter Class @0-CD5C4BB3
//Target Framework version is 2.0
using System;
using System.Collections;

namespace calendar.Data
 {
  public class MemoParameter : Parameter
  {
   
    public string Value
    {
      get 
      { 
        return (string)Values[0];
      }
      set 
      { 
        Values[0] = value;
      }
    }
   
	public MemoParameter():this(null, "", "")
    {}

    public MemoParameter(string Value):this(Value, "", "")
    {}

    public MemoParameter(string Value, string format):this(Value, format, "")
    {}

    public MemoParameter(string Value, string format, string dbFormat)
    {
      this.Value = Value;
	  Format = format;
	  DbFormat = dbFormat;
    }
   
    public override object GetValue()
    {
      return (object)Value;
    }

	public override string GetFormattedValue(int index, string format)
    {
  	  object val = null;
	  if(Values.Length > index)
		  val = Values[index];
	  else
		  return "NULL";
	  if(val != null)
		return (string)val;
	  else
		return "NULL";
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

	private static string GetTypedVal(object val, string format)
	{
        return val as string;
	}
   
    public static MemoParameter GetParam(object param, object defaultValue)
    {
      return GetParam(param, "", defaultValue);
    }
   
    public static MemoParameter GetParam(object param)
    {
      return GetParam(param, "", null);
    }
   
    public static MemoParameter GetParam(object param, string format)
    {
      return GetParam(param, format, null);
    }
   
    public static MemoParameter GetParam(object param, string format, object defaultValue)
	{
		return GetParam(param, ParameterSourceType.Expression, format, defaultValue, false);
	}
   
    public static MemoParameter GetParam(object param, ParameterSourceType type, string format, object defaultValue, bool isNullable)
    {
	  object val = GetParamInternal(param,type);

	  if(val == null) val = defaultValue;
	  MemoParameter p = new MemoParameter();
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

//End MemoParameter Class

