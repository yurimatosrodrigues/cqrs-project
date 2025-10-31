using CleanArch.Application.Members.Commands;
using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Members.Handlers
{
    public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, Member>
    {
        IUnitOfWork _unitOfWork;
        public UpdateMemberCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Member> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var existingMember = await _unitOfWork.MemberRepository.GetMemberByIdAsync(request.Id);
            if (existingMember == null)
                throw new InvalidOperationException("Member not found.");

            existingMember.Update(request.FirstName, request.LastName, 
                request.Gender, request.Email, request.IsActive);

            _unitOfWork.MemberRepository.UpdateMember(existingMember);
            return existingMember;
        }
    }
}
