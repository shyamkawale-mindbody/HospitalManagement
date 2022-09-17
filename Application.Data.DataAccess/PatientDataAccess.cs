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
    public class PatientDataAccess : IDataAccess<Patient, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public PatientDataAccess(IConfiguration configuration)
        {
            Conn = new SqlConnection(configuration.GetConnectionString("HospitalDatabase"));
        }
        Patient IDataAccess<Patient, int>.Create(Patient entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Insert into Patient Values ({entity.PatientId}, '{entity.FirstName}', '{entity.MiddleName}','{entity.LastName}', {entity.MobileNo}, '{entity.Email}', '{entity.Address}', '{entity.DateOfBirth}', '{entity.Gender}', '{entity.AgeType}', '{entity.IsAdmitted}', {entity.RoomId},{entity.BillId},{entity.AssignedDoctorId})";
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

        Patient IDataAccess<Patient, int>.Delete(int id)
        {
            Patient patient = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Delete From Patient where PatientId={id}";
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
            return patient;
        }

        IEnumerable<Patient> IDataAccess<Patient, int>.Get()
        {
            List<Patient> patientList = new List<Patient>();
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = "select * from Patient";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    patientList.Add(new Patient()
                    {
                        PatientId = Convert.ToInt32(reader["PatientId"]),
                        FirstName = reader["FirstName"].ToString(),
                        MiddleName = reader["MiddleName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        MobileNo = Convert.ToInt32(reader["MobileNo"]),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                        Gender = reader["Gender"].ToString(),
                        AgeType = reader["AgeType"].ToString(),
                        IsAdmitted = Convert.ToBoolean(reader["IsAdmitted"]),
                        AssignedDoctorId = Convert.ToInt32(reader["AssignedDoctorId"]),
                        BillId = Convert.ToInt32(reader["BillId"]),
                        RoomId = Convert.ToInt32(reader["RoomId"])
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
            return patientList;
        }

        Patient IDataAccess<Patient, int>.Get(int id)
        {
            Patient patient = null;
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandText = $"Select PatientId, FirstName,MiddleName, LastName, MobileNo, Email, Address, DateOfBirth, Gender, AgeType, IsAdmitted, AssignedDoctorId, BillId, RoomId from Patient where PatientId = {id}";
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    patient = new Patient()
                    {
                        PatientId = Convert.ToInt32(reader["PatientId"]),
                        FirstName = reader["FirstName"].ToString(),
                        MiddleName = reader["MiddleName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        MobileNo = Convert.ToInt32(reader["MobileNo"]),
                        Email = reader["Email"].ToString(),
                        Address = reader["Address"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                        Gender = reader["Gender"].ToString(),
                        AgeType = reader["AgeType"].ToString(),
                        IsAdmitted = Convert.ToBoolean(reader["IsAdmitted"]),
                        AssignedDoctorId = Convert.ToInt32(reader["AssignedDoctorId"]),
                        BillId = Convert.ToInt32(reader["BillId"]),
                        RoomId = Convert.ToInt32(reader["RoomId"])
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
            return patient;
        }

        Patient IDataAccess<Patient, int>.Update(int id, Patient entity)
        {
            try
            {
                Conn.Open();
                Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.Text;
                Cmd.CommandText = $"Update Patient Set FirstName='{entity.FirstName}', MiddleName='{entity.MiddleName}',LastName='{entity.LastName}',MobileNo={entity.MobileNo}, Email='{entity.Email}', Address='{entity.Address}', DateOfBirth='{entity.DateOfBirth}', Gender='{entity.Gender}', AgeType='{entity.AgeType}', IsAdmitted='{entity.IsAdmitted}', AssignedDoctorId={entity.AssignedDoctorId},BillId={entity.BillId},RoomId={entity.RoomId} where PatientId={id}";
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
