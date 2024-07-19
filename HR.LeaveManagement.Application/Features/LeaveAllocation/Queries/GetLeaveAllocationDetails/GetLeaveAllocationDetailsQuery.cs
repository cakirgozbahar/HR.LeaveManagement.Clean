using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetLeaveAllocationDetails
{
    public class GetLeaveAllocationDetailsQuery :IRequest<List<LeaveAllocationDetailsDto>>
    {
        public int Id { get; set; }
    }
}
