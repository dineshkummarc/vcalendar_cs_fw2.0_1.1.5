//IntegerParameter Class @0-A3E3DC27
//Target Framework version is 2.0
using System;
using System.Collections;

namespace calendar.Data
 {
  public class IntegerParameter : Parameter
  {
   
    public Int64 Value
    {
      get 
      { 
        return (Int64)Values[0];
      }
      set 
      { 
        Values[0] = value;
      }
    }
   
	public IntegerParameter():this(0, "", "")
    {}

	public IntegerParameter(string format):this(0, format, "")
    {}

	public IntegerParameter(string format, string dbFormat):this(0, format, dbFormat)
    {}
   
    public IntegerParameter(Int64 Value):this(Value, "", "")
    {}

    public IntegerParameter(Int64 Value, string format):this(Value, format, "")
    {}

    public IntegerParameter(Int64 Value, string format, string dbFormat)
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
	  Int64 v = 0; 
	  if(val != null)
		v = (Int64)val;
	  else
		return "NULL";
		
	  return DBUtility.FormatNumber(v, format);
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

	private static Int64 GetTypedVal(object val, string format)
	{
	 if(val is string)
        return DBUtility.ParseInt(val.ToString(), format);
      else
        return Convert.ToInt64(val);

	}
   
    public static IntegerParameter GetParam(object param, object defaultValue)
    {
      return GetParam(param, "", defaultValue);
    }
   
    public static IntegerParameter GetParam(object param)
    {
      return GetParam(param, "", null);
    }
   
    public static IntegerParameter GetParam(object param, string format)
    {
      return GetParam(param, format, null);
    }
   
    public static IntegerParameter GetParam(object param, string format, object defaultValue)
	{
		return GetParam(param, ParameterSourceType.Expression, format, defaultValue, false);
	}
   
    public static IntegerParameter GetParam(object param, ParameterSourceType type, string format, object defaultValue, bool isNullable)
    {
	  object val = GetParamInternal(param,type);

	  if(val == null) val = defaultValue;
	  IntegerParameter p = new IntegerParameter();
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

//End IntegerParameter Class

