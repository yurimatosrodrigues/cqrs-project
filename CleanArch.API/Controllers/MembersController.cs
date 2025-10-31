﻿using CleanArch.Application.Members.Commands;
using CleanArch.Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace CleanArch.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MembersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            //var members = await _unitOfWork.MemberRepository.GetMembersAsync();
            return Ok();
        }

        [HttpPost]        
        public async Task<IActionResult> CreateMember(CreateMemberCommand command)
        {
            var createdMember = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetMembers), new { id = createdMember.Id, createdMember });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMember(int id, UpdateMemberCommand command)
        {
            command.Id = id;
            var updatedMember = await _mediator.Send(command);
            return updatedMember != null ? Ok(updatedMember) : NotFound("Member not found.");
        }
    }
}
