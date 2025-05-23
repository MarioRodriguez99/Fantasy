using Fantasy.Backend.UnitsOfWork.Interfaces;
using Fantasy.Shared.DTOs;
using Fantasy.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy.Backend.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class TeamsController : GenericController<Team>
    {
        private readonly ITeamsUnitsOfWork _teamsUnitsOfWork;

        public TeamsController(IGenericUnitOfWork<Team> unitsOfWork, ITeamsUnitsOfWork teamsUnitsOfWork) : base(unitsOfWork)
        {
            _teamsUnitsOfWork = teamsUnitsOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAsync()
        {
            var response = await _teamsUnitsOfWork.GetAsync();
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var response = await _teamsUnitsOfWork.GetAsync(id);
            if (response.WasSuccess)
            {
                return Ok(response.Result);
            }
            return NotFound(response.Message);
        }

        [HttpGet("combo/{countryId:int}")]
        public async Task<IActionResult> GetCombo(int countryId)
        {
            return Ok(await _teamsUnitsOfWork.GetComboAsync(countryId));
        }

        [HttpPost("full")]
        public async Task<IActionResult> PostAsync(TeamDTO teamDTO)
        {
            var action = await _teamsUnitsOfWork.AddAsync(teamDTO);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }

        [HttpPut("full")]
        public async Task<IActionResult> PutAsync(TeamDTO teamDTO)
        {
            var action = await _teamsUnitsOfWork.UpdateAsync(teamDTO);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }
    }
}