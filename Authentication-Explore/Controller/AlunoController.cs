using Microsoft.AspNetCore.Mvc;

namespace Authentication_Explore.Controller;

[Route("api/[controller]")]
[ApiController]

public class AlunoController : ControllerBase
{ 
    Guid Guid { get; set; }
    
}