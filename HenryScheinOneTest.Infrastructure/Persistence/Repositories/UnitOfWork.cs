using HenryScheinOneTest.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenryScheinOneTest.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        public IPatientRepository Patients { get; }

        public UnitOfWork(IPatientRepository patients)
        {
            Patients = patients ?? throw new ArgumentNullException(nameof(patients));
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
