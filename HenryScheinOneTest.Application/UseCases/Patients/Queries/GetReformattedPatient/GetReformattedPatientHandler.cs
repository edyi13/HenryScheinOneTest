using AutoMapper;
using HenryScheinOneTest.Application.DTO;
using HenryScheinOneTest.Application.Interface;
using HenryScheinOneTest.Application.UseCases.Commons;
using HenryScheinOneTest.Domain.Entities;
using MediatR;

namespace HenryScheinOneTest.Application.UseCases.Patients.Queries.GetReformattedPatient
{
    public class GetReformattedPatientHandler : IRequestHandler<GetReformattedPatient, BaseReponse<string>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetReformattedPatientHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<BaseReponse<string>> Handle(GetReformattedPatient request, CancellationToken cancellationToken)
        {
            var response = new BaseReponse<string>();
            try
            {
                var getPatient = await _unitOfWork.Patients.GetAsync(request.Data);
                if (getPatient is not null)
                {
                    response.Data = getPatient;
                    response.Success = true;
                    response.Message = "Data was reformatted";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
