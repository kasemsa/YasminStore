﻿using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using YasminStore.ApplicationContract.DTOs.Auth;
using YasminStore.ApplicationContract.Identity;

namespace YasminStore.API.Controllers
{
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
    {
        var result = await _authService.RegisterAsync(dto);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
    {
        var result = await _authService.LoginAsync(dto);
        return Ok(result);
    }
}
}
