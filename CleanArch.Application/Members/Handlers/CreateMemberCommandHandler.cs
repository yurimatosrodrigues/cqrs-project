﻿using CleanArch.Application.Members.Commands;
using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Members.Handlers
{
    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Member>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateMemberCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Member> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var newMember = new Member(request.FirstName, request.LastName, 
                request.Gender, request.Email, request.IsActive);

            await _unitOfWork.MemberRepository.AddMemberAsync(newMember);
            await _unitOfWork.CommitAsync();
            return newMember;
        }
    }
}
