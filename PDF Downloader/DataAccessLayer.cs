using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_Downloader
{
    class DataAccessLayer
    {
        private String ConnectionString = @"Data Source=D:\Programming\C#\PDF Downloader\PDF Downloader\bin\Debug\Database.sdf";
        private SqlCeConnection SqlConnection;
        public DataAccessLayer(String baseFolder)
        {
            this.ConnectionString = @"Data Source="+baseFolder+@"\Database.sdf";
        }
        public void Connect()
        {
            SqlConnection = new SqlCeConnection(ConnectionString);
            SqlConnection.Open();
        }
        public void Disconnect()
        {
            SqlConnection.Close();
        }
        public bool ExecScaler(string command)
        {
            object ret;
            try
            {
                using (SqlCeConnection dataConnection = new SqlCeConnection(ConnectionString))
                {
                    using (SqlCeCommand dataCommand = dataConnection.CreateCommand())
                    {
                        dataCommand.CommandText = command;
                        dataConnection.Open();
                        ret = dataCommand.ExecuteScalar();
                        dataConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ret = false;
            }
            return (bool)ret;
        }
        public DataSet Select(String command)
        {
            try
            {
                DataSet dt;
                using (SqlCeConnection dataConnection = new SqlCeConnection(ConnectionString))
                {
                    using (SqlCeCommand dataCommand = dataConnection.CreateCommand())
                    {
                        dataCommand.CommandText = command;
                        dataConnection.Open();
                        SqlCeDataAdapter da = new SqlCeDataAdapter(dataCommand);
                        dt = new DataSet();
                        da.Fill(dt);
                        dataConnection.Close();
                    }
                }
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Insert(String command, List<SqlCeParameter> par)
        {
            try
            {
                using (SqlCeConnection dataConnection = new SqlCeConnection(ConnectionString))
                {
                    using (SqlCeCommand dataCommand = dataConnection.CreateCommand())
                    {
                        dataCommand.CommandText = command;
                        dataConnection.Open();
                        if (par != null)
                        {
                            foreach (var p in par)
                                dataCommand.Parameters.Add(p);
                        }
                        dataCommand.ExecuteNonQuery();
                        dataConnection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
