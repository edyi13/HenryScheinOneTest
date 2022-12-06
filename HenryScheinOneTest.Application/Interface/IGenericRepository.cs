using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HenryScheinOneTest.Application.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<string> GetAsync(IFormFile data);
    }
}
