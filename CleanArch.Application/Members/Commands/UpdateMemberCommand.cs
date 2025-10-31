using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Members.Commands
{
    public class UpdateMemberCommand : MemberCommandBase
    {
        public int Id { get; set; }
    }
}
