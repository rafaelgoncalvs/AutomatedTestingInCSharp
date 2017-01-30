using AutomatedTestingInCSharp.Domain;

namespace AutomatedTestingInCSharp.Application
{
    public class AddTeamToUserApplicationService
    {
        private readonly UserRepository _userRepository;

        private readonly TeamRepository _teamRepository;

        public AddTeamToUserApplicationService(UserRepository userRepository, TeamRepository teamRepository)
        {
            _userRepository = userRepository;
            _teamRepository = teamRepository;
        }

        public virtual void Add(AddTeamToUserDto addTeamToUserDto)
        {
            var user = _userRepository.Get(addTeamToUserDto.UserId);
            var team = _teamRepository.Get(addTeamToUserDto.TeamId);

            user.AddTeam(team);

            _userRepository.Update(user);
        }
    }
}