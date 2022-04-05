using Microsoft.AspNetCore.Mvc;
using Product.Application.Bases;
using System.Net.Mime;

namespace Product.API.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1", Deprecated = false)]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class BaseControllerV1<TRequest, TResponse, TId>
        : Controller
        where TRequest : IRequest
        where TResponse : IResponse

    {
        private readonly IBaseService<TRequest, TResponse, TId> _service;

        public BaseControllerV1(IBaseService<TRequest, TResponse, TId> service)
        {
            _service = service;
        }

        [HttpGet(template: "all")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _service.GetAllAsync(cancellationToken);

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet(template: "id/{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetById(TId id, CancellationToken cancellationToken)
        {
            var result = await _service.GetAsync(id, cancellationToken);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> SaveAsync(TRequest request)
        {
            await _service.SaveAsync(request);

            return Ok();
        }
    }
}
