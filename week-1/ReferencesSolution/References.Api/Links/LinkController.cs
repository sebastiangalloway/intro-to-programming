using Marten;
using Microsoft.AspNetCore.Mvc;
 
namespace References.Api.Links;
 
public class LinkController(IDocumentSession session) : ControllerBase
{
 
 
    // some code here that will get called when a GET /links is sent to this server.
 
    [HttpGet("/links")]
    public async Task<ActionResult> GetAllLinksAsync(CancellationToken token)
    {
        return Ok();
    }
 
    [HttpPost("/links")]
    public async Task<ActionResult> AddALinkAsync([FromBody] LinkCreateRequest request, CancellationToken token)
    {
        return Ok(request);
    }
 
 
}
 
/*{
    "href": "https://microsoft.com",
    "description": "Microsoft's Main Site"
}*/
 
public record LinkCreateRequest(string Href, string Description);

public class LinkEntity
{
    public Guid Id { get; set; }
    public string Href { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}