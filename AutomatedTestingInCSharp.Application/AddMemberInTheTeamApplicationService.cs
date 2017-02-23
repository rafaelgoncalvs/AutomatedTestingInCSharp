using AutomatedTestingInCSharp.Domain;

namespace AutomatedTestingInCSharp.Application
{
    public class AddMemberInTheTeamApplicationService
    {
        private readonly TeamRepository _teamRepository;
        private readonly MemberRepository _memberRepository;

        public AddMemberInTheTeamApplicationService(TeamRepository teamRepository, MemberRepository memberRepository)
        {
            _teamRepository = teamRepository;
            _memberRepository = memberRepository;
        }

        public virtual void Add(AddMemberInTheTeamDto addMemberInTheTeamDto)
        {
            var member = _memberRepository.Get(addMemberInTheTeamDto.MemberId);
            var team = _teamRepository.Get(addMemberInTheTeamDto.TeamId);

            team.AddMember(member);

            _teamRepository.Update(team);
        }
    }
}
