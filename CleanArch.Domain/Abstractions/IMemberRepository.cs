using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Abstractions
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetMembersAsync();
        Task<Member> GetMemberByIdAsync(int memberId);
        Task<Member> AddMemberAsync(Member member);
        void UpdateMemberAsync(Member member);
        Task DeleteMemberAsync(int memberId);
    }
}
