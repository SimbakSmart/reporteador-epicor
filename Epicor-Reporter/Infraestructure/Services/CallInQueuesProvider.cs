

using Core.Models;
using Infraestructure.Data;
using Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Infraestructure.Services
{
    public class CallInQueuesProvider : ICallInQueuesProvider
    {
        private string connectionString = DBContext.GetConnectionString;
       
        private string query = string.Empty;

        

        public async Task<int> FetchCountAsync( string queryParams = "")
        {
            int count = 0;
            try
            {
                query = CallInQueues_SQL.TotalCount(queryParams);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    await con.OpenAsync();
                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        var result = await com.ExecuteScalarAsync();

                        if (result != null)
                            count = Convert.ToInt32(result);
                    }
                }

                return count;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                return count;
            }
        }

        public async Task<List<CallInQueues>> FetchAllAsync(int pageSize = 50, int startRow = 0, string queryParams = "")
        {
            List<CallInQueues> list = new List<CallInQueues>();
            try
            {
                query = CallInQueues_SQL.Query(pageSize,startRow,queryParams);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    await con.OpenAsync();
                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = await com.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                list.Add( new CallInQueues.CallInQueuesBuilder()
                                    .WithSupportCallID(reader["SupportCallID"].ToString())
                                    .WithNumber(Convert.ToInt32(reader["Number"]))
                                    .WithTypes(reader["Types"].ToString())
                                    .WithSummary(reader["Summary"].ToString())
                                    .WithQueue(reader["Queue"].ToString())
                                    .WithStatus(reader["Status"].ToString())
                                    .WithOpenDate(Convert.ToDateTime(reader["OpenDate"]))
                                    .WithDueDate(Convert.ToDateTime(reader["DueDate"]))
                                    .WithStartDate(Convert.ToDateTime(reader["StartDate"]))
                                    .WithDateAssignTo(Convert.ToDateTime(reader["DateAssignedTo"]))
                                    .WithPriority(reader["Priority"].ToString())
                                    .WithAttribute(Convert.ToInt32(reader["Attribute"]))
                                    .Build());
                            }
                        }
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        public async Task<List<AttributeInQueue>> FetchAttributesAsync(string id)
        {
            List<AttributeInQueue> list = new List<AttributeInQueue>();
            try
            {
                query = CallInQueues_SQL.Query(id);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    await con.OpenAsync();
                    using (SqlCommand com = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = await com.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                list.Add(new AttributeInQueue.AttributeInQueueBuilder()
                                              .WithAttribute(reader["Attribute"].ToString())
                                              .WithValue(reader["Value"].ToString())
                                             .Build());
                            }
                        }
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message.ToString());
                return null;
            }
        }
    }
}
