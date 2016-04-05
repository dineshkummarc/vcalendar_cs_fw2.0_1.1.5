//DateParameter Class @0-987E06DE
//Target Framework version is 2.0
using System;
using System.Collections;

namespace calendar.Data
{
  
  public class DateParameter : Parameter
  {
   
    public DateTime Value
    {
      get 
      { 
        return (DateTime)Values[0];
      }
      set 
      { 
        Values[0] = value;
      }
    }

	public DateParameter():this(DateTime.Now, "", "")
    {}

	public DateParameter(string format):this(DateTime.Now, format, "")
    {}

	public DateParameter(string format, string dbFormat):this(DateTime.Now, format, dbFormat)
    {}
   
    public DateParameter(DateTime Value):this(Value, "", "")
    {}

    public DateParameter(DateTime Value, string format):this(Value, format, "")
    {}

    public DateParameter(DateTime Value, string format, string dbFormat)
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
	  DateTime v; 
	  if(val != null)
		v = (DateTime)val;
	  else
		return "NULL";
		
	  if(format.Length==0)
		return v.ToString();
	  else if(format != null && format == "wi")
		return ((CCSCultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture).WeekdayNarrowNames[(int)v.DayOfWeek];
	  else
		return v.ToString(format);
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

	private static DateTime GetTypedVal(object val, string format)
	{
      if(val is string)
        return DBUtility.ParseDate(val.ToString(),format);
      else if(val is TimeSpan)
        return new DateTime(1,1,1) + (TimeSpan)val;
	  else
        return Convert.ToDateTime(val);

	}

 	public override string ToString()
	{
		return this.GetFormattedValue(DbFormat);
	}
  
    public static DateParameter GetParam(object param, object defaultValue)
    {
      return GetParam(param, "", defaultValue);
    }
   
    public static DateParameter GetParam(object param)
    {
      return GetParam(param, "", null);
    }
   
    public static DateParameter GetParam(object param, string format)
    {
      return GetParam(param, format, null);
    }

    public static DateParameter GetParam(object param, string format, object defaultValue)
	{
		return GetParam(param, ParameterSourceType.Expression, format, defaultValue, false);
	}
   
    public static DateParameter GetParam(object param, ParameterSourceType type, string format, object defaultValue, bool isNullable)
    {
	  object val = GetParamInternal(param,type);

	  if(val == null) val = defaultValue;
	  DateParameter p = new DateParameter();
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

//End DateParameter Class

