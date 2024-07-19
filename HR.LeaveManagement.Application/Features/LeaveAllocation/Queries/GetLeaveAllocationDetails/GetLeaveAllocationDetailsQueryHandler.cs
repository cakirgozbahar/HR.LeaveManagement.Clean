using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails
{
    public class GetLeaveAllocationDetailsQueryHandler : IRequestHandler<GetLeaveAllocationDetailsQuery, List<LeaveAllocationDetailsDto>>
    {
        public IMapper _mapper;
        public ILeaveAllocationRepository _leaveAllocationRepository;

        public GetLeaveAllocationDetailsQueryHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
        {
            this._mapper = mapper;
            this._leaveAllocationRepository = leaveAllocationRepository;
        }
        public async Task<List<LeaveAllocationDetailsDto>> Handle(GetLeaveAllocationDetailsQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);

            // convert data objects to DTO objects
            return _mapper.Map<List<LeaveAllocationDetailsDto>>(leaveAllocation);
            // return list of DTO object
            
        }

       
    }
}
