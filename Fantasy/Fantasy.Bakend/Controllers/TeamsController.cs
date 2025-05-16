using Fantasy.Backend.UnitsOfWork.Interfaces;
using Fantasy.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy.Backend.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class TeamsController : GenericController<Team>
    {
        public TeamsController(IGenericUnitOfWork<Team> unitsOfWork) : base(unitsOfWork)
        {
        }
    }
}