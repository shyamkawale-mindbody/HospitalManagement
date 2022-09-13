using Application.Dal.Contract;
using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.DataAccess
{
    public class DoctorDataAccess : IDataAccess<Doctor, int>
    {
        Doctor IDataAccess<Doctor, int>.Create(Doctor entity)
        {
            throw new NotImplementedException();
        }

        Doctor IDataAccess<Doctor, int>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Doctor> IDataAccess<Doctor, int>.Get()
        {
            throw new NotImplementedException();
        }

        Doctor IDataAccess<Doctor, int>.Get(int id)
        {
            throw new NotImplementedException();
        }

        Doctor IDataAccess<Doctor, int>.Update(int id, Doctor entity)
        {
            throw new NotImplementedException();
        }
    }
}