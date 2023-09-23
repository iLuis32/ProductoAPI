using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProductoAPI.Context;
using ProductoAPI.DTOs;
using ProductoAPI.Entities;
using ProductoAPI.Repositories.Interfaces;
using ProductoAPI.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductoAPI.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;  
        private readonly TokenSettings _tokenSettings;

        public UsuarioRepository(ApplicationDbContext db, IMapper mapper, IOptions<TokenSettings> tokenSettings)
        {
            _db = db;
            _mapper = mapper;
            _tokenSettings = tokenSettings.Value; 
        }

        public string GenerarToken(UsuarioDTO usuario)
        {
            var sysmmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.Key));
            var credentials = new SigningCredentials(sysmmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new List<Claim>
            {
                new Claim("id", usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                new Claim(ClaimTypes.Role, usuario.Rol),
            };
            var jwt = new JwtSecurityToken(
                    issuer: _tokenSettings.Issuer,
                    audience: _tokenSettings.Audience,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: credentials,
                    claims: userClaims
                    );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<UsuarioDTO> Login(UsuarioLogin usuario)
        {
            var entidad = await _db.Usuarios.FirstOrDefaultAsync(x=>x.NombreUsuario == usuario.NombreUsuario && x.Clave == usuario.Clave);
            var login = _mapper.Map<Usuario, UsuarioDTO>(entidad);

            return login;
        }
    }
}
