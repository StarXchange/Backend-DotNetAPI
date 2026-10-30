using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using DotnetAI;

namespace DotnetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly DataContextDapper _dapper;

    public UserController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("TestConnection")]
    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }

    [HttpGet("GetUsers/{testValue}")]
    public string[] GetUsers(string testValue)
    {
        string[] responseArray = new string[]
        {
            "user1",
            "user2",
            testValue
        };

        return responseArray;
    }
}