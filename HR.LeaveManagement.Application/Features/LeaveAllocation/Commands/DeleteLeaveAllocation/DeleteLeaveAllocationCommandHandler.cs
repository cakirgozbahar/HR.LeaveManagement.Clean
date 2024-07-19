using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation
{
    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,
            IMapper mapper)
        {
            this._leaveAllocationRepository =  leaveAllocationRepository;
            this._mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var leaveAllocationtoDelete = await _leaveAllocationRepository.GetByIdAsync(request.Id)?? throw new NotFoundException(nameof(LeaveAllocation), request.Id);
            await _leaveAllocationRepository.DeleteAsync(leaveAllocationtoDelete);
            return Unit.Value;
        }
    }
}
