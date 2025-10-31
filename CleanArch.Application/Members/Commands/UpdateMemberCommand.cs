using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Members.Commands
{
    public class UpdateMemberCommand : IRequest<Member>
    {
        public int Id { get; set; }
    }
}
