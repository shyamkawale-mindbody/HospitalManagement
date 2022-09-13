using Application.Dal.Contract;
using Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.DataAccess
{
    public class BillDataAccess : IDataAccess<Bill, int>
    {
        Bill IDataAccess<Bill, int>.Create(Bill entity)
        {
            throw new NotImplementedException();
        }

        Bill IDataAccess<Bill, int>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Bill> IDataAccess<Bill, int>.Get()
        {
            throw new NotImplementedException();
        }

        Bill IDataAccess<Bill, int>.Get(int id)
        {
            throw new NotImplementedException();
        }

        Bill IDataAccess<Bill, int>.Update(int id, Bill entity)
        {
            throw new NotImplementedException();
        }
    }
}
