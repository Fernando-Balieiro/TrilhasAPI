using Microsoft.AspNetCore.Identity;

namespace CaminhadasAPI.Interfaces; 

public interface ITokenRepository {
    string CreateJwtToken(IdentityUser user, List<string> roles);
}