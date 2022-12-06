using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HenryScheinOneTest.Domain.Entities;

namespace HenryScheinOneTest.Application.Interface
{
    public interface IPatientRepository : IGenericRepository<Patient>
    {
    }
}
