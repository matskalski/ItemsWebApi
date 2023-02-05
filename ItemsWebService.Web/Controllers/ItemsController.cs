using ItemsWebService.Application.Commands;
using ItemsWebService.Application.Dto;
using ItemsWebService.Application.Queries;
using ItemsWebService.Shared.Abstractions.Commands;
using ItemsWebService.Shared.Abstractions.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItemsWebService.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public ItemsController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("/id", Name = "GetItem")]
        public async Task<ActionResult<ItemDto>> Get(int id)
        {
            var query = new GetItemQuery(id);
            var result = await _queryDispatcher.Query(query);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet(Name = "GetItems")]
        public async Task<ActionResult<IEnumerable<ItemDto>>> Get()
        {
            var query = new SearchItemsQuery();
            var result = await _queryDispatcher.Query(query);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Authorize(Roles = "ManagingItems-Administration")]
        [HttpPost(Name = "CreateItem")]
        public async Task<IActionResult> Post(CreateItemCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return CreatedAtAction(nameof(Get), new { id = command.Id }, null);
        }

        [Authorize(Roles = "ManagingItems-Administration")]
        [HttpPut(Name = "UpdateItem")]
        public async Task<IActionResult> Put([FromBody] UpdateItemCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }

        [Authorize(Roles = "ManagingItems-Administration")]
        [HttpDelete(Name = "DeleteItem")]
        public async Task<IActionResult> Delete([FromBody] DeleteItemCommand command)
        {
            await _commandDispatcher.Dispatch(command);
            return Ok();
        }


    }
}
