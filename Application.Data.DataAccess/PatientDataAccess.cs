using Application.Dal.Contract;
using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.DataAccess
{
    public class PatientDataAccess : IDataAccess<Patient, int>
    {
        Patient IDataAccess<Patient, int>.Create(Patient entity)
        {
            throw new NotImplementedException();
        }

        Patient IDataAccess<Patient, int>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Patient> IDataAccess<Patient, int>.Get()
        {
            throw new NotImplementedException();
        }

        Patient IDataAccess<Patient, int>.Get(int id)
        {
            throw new NotImplementedException();
        }

        Patient IDataAccess<Patient, int>.Update(int id, Patient entity)
        {
            throw new NotImplementedException();
        }
    }
}
