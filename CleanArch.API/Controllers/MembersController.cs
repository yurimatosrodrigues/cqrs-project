using CleanArch.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MembersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            var members = await _unitOfWork.MemberRepository.GetMembersAsync();
            return Ok(members);
        }
    }
}
