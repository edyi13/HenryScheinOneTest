using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HenryScheinOneTest.Application.DTO;
using HenryScheinOneTest.Application.UseCases.Commons;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace HenryScheinOneTest.Application.UseCases.Patients.Queries.GetReformattedPatient
{
    public class GetReformattedPatient: IRequest<BaseReponse<string>>
    {
        public IFormFile Data { get; set; }
    }
}
