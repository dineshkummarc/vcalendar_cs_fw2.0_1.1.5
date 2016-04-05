//FloatParameter Class @0-52E47F65
//Target Framework version is 2.0
using System;
using System.Collections;

namespace calendar.Data
{
  
  public class FloatParameter : Parameter
  {
   
    public Double Value
    {
      get 
      { 
        return (Double)Values[0];
      }
      set 
      { 
        Values[0] = value;
      }
    }
   
	public FloatParameter():this(Double.NaN, "", "")
    {}

	public FloatParameter(string format):this(Double.NaN, format, "")
    {}

	public FloatParameter(string format, string dbFormat):this(Double.NaN, format, dbFormat)
    {}
   
    public FloatParameter(Double Value):this(Value, "", "")
    {}

    public FloatParameter(Double Value, string format):this(Value, format, "")
    {}

    public FloatParameter(Double Value, string format, string dbFormat)
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
	  double v = 0; 
	  if(val != null)
		v = (double)val;
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

	private static Double GetTypedVal(object val, string format)
	{
	 if(val is string)
        return DBUtility.ParseDouble(val.ToString(), format);
      else
        return Convert.ToDouble(val);

	}
   
    public static FloatParameter GetParam(object param, object defaultValue)
    {
      return GetParam(param, "", defaultValue);
    }
   
    public static FloatParameter GetParam(object param)
    {
      return GetParam(param, "", null);
    }
   
    public static FloatParameter GetParam(object param, string format)
    {
      return GetParam(param, format, null);
    }
   
    public static FloatParameter GetParam(object param, string format, object defaultValue)
	{
		return GetParam(param, ParameterSourceType.Expression, format, defaultValue, false);
	}
   
    public static FloatParameter GetParam(object param, ParameterSourceType type, string format, object defaultValue, bool isNullable)
    {
	  object val = GetParamInternal(param,type);

	  if(val == null) val = defaultValue;
	  FloatParameter p = new FloatParameter();
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

