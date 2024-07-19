using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Models.Email;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.ChangeLeaveRequest
{
    public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public ChangeLeaveRequestApprovalCommandHandler(IMapper mapper, IEmailSender emailSender,
            ILeaveTypeRepository leaveTypeRepository, ILeaveRequestRepository leaveRequestRepository)
        {
            this._emailSender = emailSender;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRequestRepository = leaveRequestRepository;
        }
        public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetByIdAsync(request.Id);

            if (leaveRequest is null)
            {
                throw new NotFoundException(nameof(LeaveRequest), request.Id);
            }
            leaveRequest.Approved = request.Approved;
            await _leaveRequestRepository.UpdateAsync(leaveRequest);

            //if request is approved, get and update the employee's allocations

            // send confirmation email
            var email = new EmailMessage
            {
                To = string.Empty, /* Get email from employee record */
                Body = $"The approval status for your leave request for {leaveRequest.StartDate:D} to {leaveRequest.EndDate:D}" +
                       $" has been updated successfully.",
                Subject = "Leave Request Approval Status Updated"
            };
            await _emailSender.SendEmail(email);
            return Unit.Value;
        }
    }
}
