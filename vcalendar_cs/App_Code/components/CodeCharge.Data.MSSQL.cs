//CodeCharge.Data.SqlDAO Class @0-CBFA8CC9
//Target Framework version is 2.0
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient; 
using System.Data.SqlTypes; 

namespace calendar.Data
{

/// <summary>
/// Data Access Object for work with SQL server.
/// </summary>


public class SqlDao:DataAccessObject 
{ 
    private SqlDbType[] aliases=new SqlDbType[]{SqlDbType.BigInt,SqlDbType.Bit,SqlDbType.Char,SqlDbType.DateTime,
            SqlDbType.DateTime,SqlDbType.Decimal,SqlDbType.Float,SqlDbType.Int,SqlDbType.TinyInt,SqlDbType.SmallInt,
            SqlDbType.NChar,SqlDbType.NText,SqlDbType.Decimal,SqlDbType.NVarChar,SqlDbType.Real,SqlDbType.SmallDateTime,
            SqlDbType.Text,SqlDbType.DateTime,SqlDbType.VarChar};

    private SqlConnection m_connection;
    private ConnectionString s_connection;
    public SqlDao(ConnectionString connection):base(connection)
    {
        Connection=new SqlConnection(connection.Connection); 
        s_connection=connection; 
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

    ~ SqlDao()
    {
        //Release the resources
        this.Dispose();
    }

    public SqlConnection Connection
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
        set{Connection=new SqlConnection(value);}
    }

    protected void OnStateChange(object sender, StateChangeEventArgs e)
    {
        if(e.OriginalState == ConnectionState.Closed && e.CurrentState == ConnectionState.Open)
            foreach(string sql in s_connection.ConnectionCommands)
                using( System.Data.SqlClient.SqlCommand command=new System.Data.SqlClient.SqlCommand(s_connection.ConnectionCommands[sql],Connection) )
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
        using ( SqlDataAdapter adapter=new SqlDataAdapter(sql,Connection) ){
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
        using ( SqlDataAdapter adapter=new SqlDataAdapter(sql,Connection) ){
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

    protected override int ExecuteNonQueryImpl(string sql)
    { 
        int result;
        using( System.Data.SqlClient.SqlCommand command=new System.Data.SqlClient.SqlCommand(sql, Connection) ){
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

    protected override object ExecuteScalarImpl(string sql)
    { 
        object result;
        using( System.Data.SqlClient.SqlCommand command=new System.Data.SqlClient.SqlCommand(sql, Connection) ){
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

    protected System.Data.SqlClient.SqlCommand CreateCommand(string sprocName,ParameterCollection parameters)
    {
        System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand( sprocName, Connection );
        command.CommandType = CommandType.StoredProcedure;

        for(int i=0;i<parameters.Count;i++)
        command.Parameters.Add( (SqlParameter)parameters[i].Value );

        return command;
    }

    protected override IDataParameter GetSPParameterImpl(string name,object value,ParameterType paramType, ParameterDirection paramDirection, int size, byte scale,byte precision)
        {SqlParameter p = new SqlParameter(name,aliases[(int)paramType],size);
        p.Direction=paramDirection;
        if(value==null)
            p.Value=DBNull.Value;
        else
            p.Value=value;
        return p;
        }

    protected override int RunSPImpl(string sprocName, ParameterCollection parameters)
    {
        using( System.Data.SqlClient.SqlCommand command = CreateCommand( sprocName, parameters) ){
            command.Connection=Connection;
            bool flag = false;
            if(Connection.State == ConnectionState.Open)
                flag = true;
            else
                Connection.Open();
            command.ExecuteNonQuery();
            foreach ( SqlParameter parameter in command.Parameters)
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

    protected override int RunSPImpl( string sprocName, ParameterCollection parameters, DataSet retSet, int firstRecord, int recordsNumber)
    {
        using(retSet)
        using( SqlDataAdapter dataSetAdapter = new SqlDataAdapter() ){
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
            foreach ( SqlParameter parameter in dataSetAdapter.SelectCommand.Parameters)
                parameters[parameter.ParameterName] = parameter;
            if(!flag)
                Connection.Close();
        }
        return 0;
    }
}
}
//End CodeCharge.Data.SqlDAO Class

