using LaGuineuData;
using System;

namespace LaGuineuService.Services
{
    public interface ITokenService
    {
        Token CreateToken(Usuario usuario);
        Object DecodingToken(string token);
    }
}