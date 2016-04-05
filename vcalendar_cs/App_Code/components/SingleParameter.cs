//FloatParameter Class @0-355698E8
//Target Framework version is 2.0
using System;
using System.Collections;

namespace calendar.Data
{
  
  public class SingleParameter : Parameter
  {
   
    public Single Value
    {
      get 
      { 
        return (Single)Values[0];
      }
      set 
      { 
        Values[0] = value;
      }
    }
   
	public SingleParameter():this(Single.NaN, "", "")
    {}

	public SingleParameter(string format):this(Single.NaN, format, "")
    {}

	public SingleParameter(string format, string dbFormat):this(Single.NaN, format, dbFormat)
    {}
   
    public SingleParameter(Single Value):this(Value, "", "")
    {}

    public SingleParameter(Single Value, string format):this(Value, format, "")
    {}

    public SingleParameter(Single Value, string format, string dbFormat)
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
	  Single v = 0; 
	  if(val != null)
		v = (Single)val;
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

	private static Single GetTypedVal(object val, string format)
	{
	 if(val is string)
        return DBUtility.ParseSingle(val.ToString(), format);
      else
        return Convert.ToSingle(val);

	}
   
    public static SingleParameter GetParam(object param, object defaultValue)
    {
      return GetParam(param, "", defaultValue);
    }
   
    public static SingleParameter GetParam(object param)
    {
      return GetParam(param, "", null);
    }
   
    public static SingleParameter GetParam(object param, string format)
    {
      return GetParam(param, format, null);
    }
   
    public static SingleParameter GetParam(object param, string format, object defaultValue)
	{
		return GetParam(param, ParameterSourceType.Expression, format, defaultValue, false);
	}
   
    public static SingleParameter GetParam(object param, ParameterSourceType type, string format, object defaultValue, bool isNullable)
    {
	  object val = GetParamInternal(param,type);

	  if(val == null) val = defaultValue;
	  SingleParameter p = new SingleParameter();
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

//End FloatParameter Class

