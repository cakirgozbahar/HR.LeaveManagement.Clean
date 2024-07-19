using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    //public class GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>
    //{
    //}
    // record  class dan farkı immutable olmasıdır. 
    public record GetLeaveTypesQuery : IRequest<List<LeaveTypeDto>>;
}
