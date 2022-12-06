using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HenryScheinOneTest.Application.DTO;
using HenryScheinOneTest.Domain.Entities;

namespace HenryScheinOneTest.Application.UseCases.Mappings
{
    public class PatientMapper: Profile
    {
        public PatientMapper()
        {
            CreateMap<Patient, PatientDto>().ReverseMap();
        }
    }
}
