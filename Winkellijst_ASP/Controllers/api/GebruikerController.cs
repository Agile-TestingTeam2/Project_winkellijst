using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Winkellijst_ASP.Entities;
using Winkellijst_ASP.Helpers;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Winkellijst_ASP.Controllers.api
{
    [Route("api/[controller]")]
    public class GebruikerController : ControllerBase
    {
    //    private readonly SignInManager<CustomGebruiker> _signInManager;
    //    private readonly UserManager<CustomGebruiker> _gebruikerManager;
    //    private readonly AppSettings _appSettings;

        //public GebruikerController(
        //    UserManager<CustomGerbuiker> gebruikerManager,
        //    SignInManager<CustomGebruiker> signInManager,
        //    IOptions<AppSettings> appSettings
        //    )
        //{
        //    _gebruikerManager = gebruikerManager;
        //    _signInManager = signInManager;
        //    _appSettings = appSettings.Value;
        //}
        //[HttpPost("authenticate")]
        //public async Task<object> Authenticate([FromBody] ApiGebruiker apiGebruiker)
        //{
        //    Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(
        //        apiGebruiker.Gebruikersnaam, apiGebruiker.Wachtwoord, false, false);

        //    if (signInResult.Succeeded)
        //    {
        //        CustomGebruiker customGebruiker = _gebruikerManager.Gebruikers.SingleOrDefault(r => r.Email == apiGebruiker.Gebruikersnaam);
        //        apiGebruiker.Token = GenerateJwtToken(apiGebruiker.Gebruikersnaam, customGebruiker).ToString();

        //        return apiGebruiker;
        //    }

        //    return BadRequest(new { message = "Gebruikersnaam of Wachtwoord is incorrect" });
        //}
        //private string GenerateJwtToken(string email, CustomGebruiker gebruiker)
        //{
        //    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        //    byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        //    SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, gebruiker.Id.ToString()),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        //    return tokenHandler.WriteToken(token);
        //}
    } 
}
