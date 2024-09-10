using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Commands.Blogs;
using Project.Application.Features.Queries.Blogs;

namespace Project.WebApi.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class BlogController : ControllerBase
{
    public readonly IMediator _mediator;

    public BlogController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsSuccessful)
        {
            return Ok(new { message = response.Data });
        }

        return StatusCode(response.StatusCode, new { errors = response.ErrorMessages });
    }
    [HttpPost]
    public async Task<IActionResult> Update(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsSuccessful)
        {
            return Ok(new { message = response.Data });
        }

        return StatusCode(response.StatusCode, new { errors = response.ErrorMessages });
    }
    [HttpPost]
    public async Task<IActionResult> GetAll(GetAllBlogQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsSuccessful)
        {
            return Ok(response.Data);
        }

        return StatusCode(response.StatusCode, response.ErrorMessages);
    }
    [HttpPost]
    public async Task<IActionResult> GetById(GetByIdBlogQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsSuccessful)
        {
            return Ok(response.Data);
        }

        return StatusCode(response.StatusCode, response.ErrorMessages);
    }
    [HttpPost]
    public async Task<IActionResult> Delete(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsSuccessful)
        {
            return Ok(response.Data);
        }

        return StatusCode(response.StatusCode, response.ErrorMessages);
    }

}
