using SingleStore.NET.Application.Common;
using SingleStore.NET.Application.Countries.Commands;
using SingleStore.NET.Application.Countries.Queries;
using SingleStore.NET.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SingleStore.NET.API.Controllers
{
    //[Authorize]
    public class CountryController : BaseController
    {

        [HttpGet("getall")]
        public async Task<ActionResult<ServiceResult<IEnumerable<CountryViewModel>>>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllCountriesQuery(), cancellationToken));
        }

        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<ServiceResult<IEnumerable<CountryViewModel>>>> GetById(long id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCountryByIdQuery(id), cancellationToken));
        }

        [HttpPost("create")]
        public async Task<ActionResult<ServiceResult<IEnumerable<CountryViewModel>>>> Create([FromBody] CountryViewModel model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateCountryCommand(model), cancellationToken));
        }

        [HttpPost("update")]
        public async Task<ActionResult<ServiceResult<IEnumerable<CountryViewModel>>>> Update([FromBody] CountryViewModel model, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new UpdateCountryCommand(model), cancellationToken));
        }

        [HttpPost("delete/{id}")]
        public async Task<ActionResult<ServiceResult<IEnumerable<CountryViewModel>>>> Delete(long id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteCountryCommand(id), cancellationToken));
        }
    }
}
