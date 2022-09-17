using Application.Dal.Contract;
using Application.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.DataAccess
{
    public class BillDataAccess : IDataAccess<Bill, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public BillDataAccess(IConfiguration configuration)
        {
            Conn = new SqlConnection(configuration.GetConnectionString("HospitalDatabase"));
        }
        Bill IDataAccess<Bill, int>.Create(Bill entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                entity.Total_Fees= entity.OPD_Fees + entity.Doctor_Fees + entity.Other_Fees + entity.MedicineCharges + entity.CanteenCharges+ entity.IPD_Advance_Fees+ entity.RoomCharges;
                Cmd.CommandText = $"Insert into Bill Values ({entity.BillId}, {entity.OPD_Fees}, {entity.Doctor_Fees}, {entity.Other_Fees}, {entity.MedicineCharges}, {entity.CanteenCharges}, {entity.IPD_Advance_Fees}, {entity.RoomCharges},{entity.Total_Fees})";
                int result = Cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return entity;
        }

        Bill IDataAccess<Bill, int>.Delete(int id)
        {
            Bill bill = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From Bill where BillId={id}";
                int result = Cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error Occured while Processoing Request {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error {ex.Message}");
            }
            finally
            {
                Conn.Close();
            }
            return bill;
        }

        IEnumerable<Bill> IDataAccess<Bill, int>.Get()
        {
            List<Bill> billList = new List<Bill>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from Bill";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    billList.Add(new Bill()
                    {
                        BillId = Convert.ToInt32(reader["BillId"]),
                        OPD_Fees = Convert.ToDecimal(reader["OPD_Fees"]),
                        Doctor_Fees = Convert.ToDecimal(reader["Doctor_Fees"]),
                        Other_Fees = Convert.ToDecimal(reader["Other_Fees"]),
                        MedicineCharges = Convert.ToDecimal(reader["MedicineCharges"]),
                        CanteenCharges = Convert.ToDecimal(reader["CanteenCharges"]),
                        RoomCharges = Convert.ToDecimal(reader["RoomCharges"]),
                        IPD_Advance_Fees = Convert.ToDecimal(reader["IPD_Advance_Fees"]),
                        Total_Fees = Convert.ToDecimal(reader["Total_Fees"])
                    });

                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return billList;
        }

        Bill IDataAccess<Bill, int>.Get(int id)
        {
            Bill bill = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = $"Select BillId, OPD_Fees, Doctor_Fees, Other_Fees, MedicineCharges, CanteenCharges, IPD_Advance_Fees, RoomCharges, Total_Fees  from Bill where BillId = {id}";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    bill = new Bill()
                    {
                        BillId = Convert.ToInt32(reader["BillId"]),
                        OPD_Fees = Convert.ToDecimal(reader["OPD_Fees"]),
                        Doctor_Fees = Convert.ToDecimal(reader["Doctor_Fees"]),
                        Other_Fees = Convert.ToDecimal(reader["Other_Fees"]),
                        MedicineCharges = Convert.ToDecimal(reader["MedicineCharges"]),
                        CanteenCharges = Convert.ToDecimal(reader["CanteenCharges"]),
                        RoomCharges = Convert.ToDecimal(reader["RoomCharges"]),
                        IPD_Advance_Fees = Convert.ToDecimal(reader["IPD_Advance_Fees"]),
                        Total_Fees = Convert.ToDecimal(reader["Total_Fees"])
                    };
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return bill;
        }

        Bill IDataAccess<Bill, int>.Update(int id, Bill entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                entity.Total_Fees = entity.OPD_Fees + entity.Doctor_Fees + entity.Other_Fees + entity.MedicineCharges + entity.CanteenCharges;
                Cmd.CommandText = $"Update Bill Set OPD_Fees={entity.OPD_Fees}, Doctor_Fees={entity.Doctor_Fees},Other_Fees={entity.Other_Fees}, MedicineCharges={entity.MedicineCharges}, CanteenCharges={entity.CanteenCharges},RoomCharges={entity.RoomCharges},IPD_Advance_Fees={entity.IPD_Advance_Fees}, Total_Fees={entity.Total_Fees} where BillId={id}";
                int result = Cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
            return entity;
        }
    }
}
