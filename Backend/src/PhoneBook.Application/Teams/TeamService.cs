using AutoMapper;
using PhoneBook.Application.Contract.Teams;
using PhoneBook.Application.Contract.Teams.DTOs.Requests;
using PhoneBook.Application.Contract.Teams.DTOs.Responses;
using PhoneBook.Domain.TeamMembers;
using PhoneBook.Domain.Teams;
using PhoneBook.Domain.Teams.Exceptions;


namespace PhoneBook.Application.Teams
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly ITeamManager _teamManager;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepository teamrepository,  ITeamMemberRepository teamMemberRepository, ITeamManager teamManager, IMapper mapper)
        {
            _teamRepository = teamrepository;
            _teamMemberRepository = teamMemberRepository;
            _teamManager = teamManager;
            _mapper = mapper;
            
        }

        public TeamService()
        {

        }
        public async Task CreateAsync(TeamCreateRequest input)
        {
            var team = await _teamManager.CreateAsync(input.Name);
            if(team != null)
            {
               await _teamRepository.CreateAsync(team);
            }

        }

        public async Task DeleteAsync(int id)
        {
            await _teamRepository.DeleteAsync(id);
        }

        public async Task<List<TeamResponse>> GetAllAsync()
        {
           
            var items = await _teamRepository.GetListAsync();
            return _mapper.Map<List<Team>, List<TeamResponse>>(items);
           
        }

        public async Task<TeamResponse> GetByIdAsync(int id)
        {
            return _mapper.Map<Team, TeamResponse>(await _teamRepository.GetAsync(id));
        }

        public async Task UpdateAsync(int id, TeamUpdateRequest input)
        {

            var team = await _teamRepository.GetAsync(id);
            if (team != null)
            {
                var updatedTeam = await _teamManager.UpdateAsync(team, input.Name);
                await _teamRepository.UpdateAsync(updatedTeam);
            }
            else
            {
                throw new TeamNotFoundException(id);
            }
        }
    }
}
