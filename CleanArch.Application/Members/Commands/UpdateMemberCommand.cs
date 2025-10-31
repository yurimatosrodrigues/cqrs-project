﻿using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Members.Commands
{
    public class UpdateMemberCommand : IRequest<Member>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
    }
}
