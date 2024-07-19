using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocations
{
    public class GetLeaveAllocationsQueryHandler : IRequestHandler<GetLeaveAllocationsQuery, List<LeaveAllocationDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        
        public GetLeaveAllocationsQueryHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
        {
            this._mapper = mapper;
            this._leaveAllocationRepository = leaveAllocationRepository;
            
        }
        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationsQuery request, CancellationToken cancellationToken)
        {
            //To Add later
            //- Get records for specific user
            //- Get allocations per employee

            var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationsWithDetails();
            var allocations = _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);

            return allocations;
        }
    }
}
