using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace NoktaBilgiNotificationService.Classes
{
    internal class SQLCrud
    {
        internal static async Task<bool> ConnectionStringControlAddAsync(string serverName, string loginName, string password, string databaseName)
        {
            string connectionString = $"Server={serverName};Database={databaseName};User Id={loginName};Password={password};Connection Timeout=10;TrustServerCertificate=True;Max Pool Size=100;Min Pool Size=5;Pooling=true;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    await sqlConnection.OpenAsync();
                }
                catch (Exception ex)
                {
                    TextLog.TextLogging("SQL Connection Error: " + ex.Message + " --- " + ex.ToString(),"1");
                    return false;
                }
                finally
                {
                     sqlConnection.Close();
                }
            }
            var result = await SQLiteCrud.InsertUpdateDeleteAsync(
       $"UPDATE SqlConnectionString SET SQLConnectString = '{EncryptionHelper.Encrypt(connectionString)}'");
            return result.Success;
        }
        internal static async Task<DataTable> LoadDataIntoGridViewAsync(string query, string connection)
        {
            using (SqlConnection conn = new SqlConnection(EncryptionHelper.Decrypt(connection)))
            {
                try
                {
                    await conn.OpenAsync();

                    DataTable dt = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            try
                            {
                                da.Fill(dt); 
                            }
                            catch (Exception ex)
                            {
                                TextLog.TextLogging("DataAdapter.Fill hatası: " + ex.Message + " --- " + ex.ToString(),"1");
                                return null;
                            }
                        }
                    }
                    return dt;
                }
                catch (Exception e)
                {
                    TextLog.TextLogging("SQL bağlantı veya komut hatası: " + e.Message + " --- " + e.ToString(),"1");
                    return null;
                }
            }
        }
        internal static async Task<bool> InserUpdateDelete(string query, string connection)
        {
            using (SqlConnection conn = new SqlConnection(EncryptionHelper.Decrypt(connection)))
            {
                try
                {
                    await conn.OpenAsync();
                    string[] commands = query.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string command in commands)
                    {
                        string cleanCommand = command.Replace("\n", " ").Replace("\r", " ").Trim();
                        if (!string.IsNullOrWhiteSpace(cleanCommand))
                        {
                            using (SqlCommand cmd = new SqlCommand(cleanCommand, conn))
                            {
                                cmd.CommandTimeout = 300;
                                await cmd.ExecuteNonQueryAsync();
                            }
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    TextLog.TextLogging(ex.Message + " --- " + ex.ToString(),"1");
                    return false;
                }
            }
        }
    }
}