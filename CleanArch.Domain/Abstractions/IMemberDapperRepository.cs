using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Abstractions
{
    public interface IMemberDapperRepository
    {
        Task<IEnumerable<Member>> GetMembersAsync();
        Task<Member> GetMemberByIdAsync(int id);
    }
}
