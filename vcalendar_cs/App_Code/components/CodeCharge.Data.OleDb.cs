//Using statements @0-533EAA00
//Target Framework version is 2.0
using System;
using System.Collections;
using System.Data;
using System.Data.OleDb; 

namespace calendar.Data
{
//End Using statements

//CodeCharge.Data.OleDbDAO Class @0-96351FCC
/// <summary>
/// Data Access Object for work with OleDb data providers.
/// </summary>

public class OleDbDao:DataAccessObject 
{
    private OleDbConnection m_connection;
    private ConnectionString s_connection;
    private OleDbType[] aliases=new OleDbType[]{OleDbType.BigInt,OleDbType.Boolean,OleDbType.Char,OleDbType.DBDate,
            OleDbType.Date,OleDbType.Decimal,OleDbType.Double,OleDbType.Integer,OleDbType.TinyInt,OleDbType.SmallInt,
            OleDbType.WChar,OleDbType.LongVarWChar,OleDbType.Numeric,OleDbType.VarWChar,OleDbType.Single,OleDbType.DBTimeStamp,
            OleDbType.LongVarChar,OleDbType.DBTime,OleDbType.VarChar};

    public OleDbDao(ConnectionString connection):base(connection)
    {
        Connection = new OleDbConnection(connection.Connection); 
        s_connection = connection; 
    }

    public override void Dispose()
    {
        base.Dispose();
        if( Connection != null ){
            Connection.Close();
            Connection.Dispose();
        }
        //suppressfinalization
        GC.SuppressFinalize(this);
    }

    ~ OleDbDao()
    {
        //Release the resources
        this.Dispose();
    }

    public OleDbConnection Connection
    {
        get{return m_connection;}
        set{
            m_connection = value;
            m_connection.StateChange += new StateChangeEventHandler(OnStateChange);
        }
    }

    public override IDbConnection NativeConnection
    {
        get
        {
            return m_connection;
        }
    }

    public string ConnectionString
    {
        get{return Connection.ConnectionString;}
        set{Connection=new OleDbConnection(value);}
    }

    protected void OnStateChange(object sender, StateChangeEventArgs e)
    {
        if(e.OriginalState == ConnectionState.Closed && e.CurrentState == ConnectionState.Open)
            foreach(string sql in s_connection.ConnectionCommands)
                using( OleDbCommand command=new OleDbCommand(s_connection.ConnectionCommands[sql],Connection) )
                    command.ExecuteNonQuery();
    }

    protected override bool CheckConnectionImpl(string login,string password)
    {
        ConnectionString+=";User ID=\""+login+"\";Password=\""+password+"\"";
        try{
            Connection.Open();
            Connection.Close();
        }catch{return false;}
        return true;
    }

    protected override DataSet RunSqlImpl(string sql)
    {
        DataSet dataSet=new DataSet();
        using ( OleDbDataAdapter adapter=new OleDbDataAdapter(sql,Connection) ){
            bool flag = false;
            if(Connection.State == ConnectionState.Open)
                flag = true;
            else
                Connection.Open();
            adapter.Fill(dataSet);
            if(!flag)
                Connection.Close();
        }
        return dataSet;
    }

    protected override DataSet RunSqlImpl(string sql,int firstRecord,int recordsNumber)
    {
        DataSet dataSet=new DataSet();
        using ( OleDbDataAdapter adapter=new OleDbDataAdapter(sql,Connection) ){
            bool flag = false;
            if(Connection.State == ConnectionState.Open)
                flag = true;
            else
                Connection.Open();
            adapter.Fill(dataSet,firstRecord,recordsNumber,"Table");
            if(!flag)
                Connection.Close();
        }
        return dataSet;
    }

    protected override object ExecuteScalarImpl(string sql)
    { 
        object result;
        using( OleDbCommand command=new OleDbCommand(sql,Connection) ){
            bool flag = false;
            if(Connection.State == ConnectionState.Open)
                flag = true;
            else
                Connection.Open();
            result= command.ExecuteScalar();
            if(!flag)
                Connection.Close();
        }
        return result;
    }

    protected override int ExecuteNonQueryImpl(string sql)
    { 
        int result;
        using( OleDbCommand command=new OleDbCommand(sql,Connection) ){
            bool flag = false;
            if(Connection.State == ConnectionState.Open)
                flag = true;
            else
                Connection.Open();
            result=Convert.ToInt32(command.ExecuteNonQuery());
            if(!flag)
                Connection.Close();
        }
        return result;
    }

    protected override IDataReader ExecuteReaderImpl(string sql)
    { 
        OleDbDataReader result;
        OleDbCommand command=new OleDbCommand(sql,Connection);
            bool flag = false;
            if(Connection.State == ConnectionState.Open)
                flag = true;
            else
                Connection.Open();
        result=command.ExecuteReader(CommandBehavior.CloseConnection);
        return result;
    }

    protected OleDbCommand CreateCommand(string sprocName,ParameterCollection parameters)
    {
        OleDbCommand command = new OleDbCommand( sprocName, Connection );
        command.CommandType = CommandType.StoredProcedure;
        for(int i=0;i<parameters.Count;i++)
        command.Parameters.Add( ((OleDbParameter)parameters[i].Value) );
        return command;
    }

    protected override IDataParameter GetSPParameterImpl(string name,object value,ParameterType paramType, ParameterDirection paramDirection, int size, byte scale,byte precision)
    {
        if(paramType == ParameterType.RecordSet) return null;
        OleDbParameter p = new OleDbParameter(name,aliases[(int)paramType],size);
        p.Direction=paramDirection;
        if(value==null)
            p.Value=DBNull.Value;
        else
            p.Value=value;
        return p;
    }

    protected override int RunSPImpl(string sprocName, ParameterCollection parameters)
    {
        using( OleDbCommand command = CreateCommand( sprocName, parameters) ){
            command.Connection=Connection;
            bool flag = false;
            if(Connection.State == ConnectionState.Open)
                flag = true;
            else
                Connection.Open();
            command.ExecuteNonQuery();
            foreach ( OleDbParameter parameter in command.Parameters)
                parameters[parameter.ParameterName] = parameter;
            if(!flag)
                Connection.Close();
        }
        return 0;
    }

    protected override int RunSPImpl( string sprocName, ParameterCollection parameters, DataSet retSet)
    {
        return RunSPImpl(sprocName, parameters, retSet, -1, -1);
    }

    protected override int RunSPImpl( string sprocName, ParameterCollection parameters, IDataReader dr)
    {
        using( OleDbCommand command = CreateCommand( sprocName, parameters) ){
            command.Connection=Connection;
            bool flag = false;
            if(Connection.State == ConnectionState.Open)
                flag = true;
            else
                Connection.Open();
            command.ExecuteNonQuery();
            foreach ( OleDbParameter parameter in command.Parameters)
                parameters[parameter.ParameterName] = parameter;
            if(!flag)
                Connection.Close();
        }
        return 0;
    }

    protected override int RunSPImpl( string sprocName, ParameterCollection parameters, DataSet retSet, int firstRecord, int recordsNumber)
    {
        using(retSet)
        using( OleDbDataAdapter dataSetAdapter = new OleDbDataAdapter() ){
            dataSetAdapter.SelectCommand = CreateCommand( sprocName, parameters );
            bool flag = false;
            if(Connection.State == ConnectionState.Open)
                flag = true;
            else
                Connection.Open();
            if (firstRecord < 0)
                dataSetAdapter.Fill( retSet, "SourceTable" );
            else
                dataSetAdapter.Fill( retSet, firstRecord , recordsNumber, "SourceTable" );
            foreach ( OleDbParameter parameter in dataSetAdapter.SelectCommand.Parameters)
                parameters[parameter.ParameterName] = parameter;
            if(!flag)
                Connection.Close();
        }
        return 0;
    }
}
}
//End CodeCharge.Data.OleDbDAO Class

