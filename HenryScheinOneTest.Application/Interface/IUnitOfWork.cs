using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenryScheinOneTest.Application.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepository Patients { get; }
    }
}
