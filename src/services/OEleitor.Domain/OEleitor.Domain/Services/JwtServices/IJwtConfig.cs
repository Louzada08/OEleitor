using OEleitor.Domain.Entities;

namespace OEleitor.Domain.Services.JwtServices;

public interface IJwtService
{
    string GerarToken(Usuario usuario);
}
