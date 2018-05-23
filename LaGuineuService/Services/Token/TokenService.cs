using System;
using System.Collections.Generic;
using LaGuineuData;
using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json.Linq;

namespace LaGuineuService.Services
{
    public class TokenService : ITokenService
    {
        private LaGuineuEntities db = new LaGuineuEntities();
        private string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

        public Token CreateToken(Usuario usuario)
        {
            var today = DateTime.Now;
            var payload = new Dictionary<string, object>
            {
                { "IdUsuario", usuario.Id },
                { "IdEscuela", usuario.IdEscuela },
                { "exp", today.AddHours(12) }
            };
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var tokenString = encoder.Encode(payload, secret);
            Token token = new Token();
            token.Nombre = tokenString;
            token.IdEscuela = usuario.IdEscuela;
            token.IdUsuario = usuario.Id;
            token.FechaCrea = today;
            token.Id = usuario.Id;
            db.Token.Add(token);
            db.SaveChanges();
            return token;
        }

        // Verifica
        public Object DecodingToken(string token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer(); 
                 IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);
                var json = decoder.Decode(token, secret, verify: false);
                Token tokenObj = new Token();
                JObject obj = JObject.Parse(json);
                var aux = ((string)obj.SelectToken("exp")).Split(' ');
                var fecha = aux[0].Split('/');
                var horas = aux[1].Split(':');
                var exp = new DateTime(int.Parse(fecha[2]), int.Parse(fecha[0]), int.Parse(fecha[1]), int.Parse(horas[0]), int.Parse(horas[1]), int.Parse(horas[2]));
                tokenObj.IdUsuario = (int)obj.SelectToken("IdUsuario");
                tokenObj.IdEscuela = (int)obj.SelectToken("IdEscuela");
                return tokenObj;
            }
            catch (TokenExpiredException)
            {
                return "Token has expired";
            }
            catch (SignatureVerificationException)
            {
                return  "Token has invalid signature";
            }

        }



        /*
        Custom JSON serializer

        By default JSON serialization is done by JsonNetSerializer implemented using Json.Net. To configure a different one first implement the IJsonSerializer interface:

        public class CustomJsonSerializer : IJsonSerializer
        {
            public string Serialize(object obj)
            {
                // Implement using favorite JSON Serializer
            }

            public T Deserialize<T>(string json)
            {
                // Implement using favorite JSON Serializer
            }
        }
        And then pass this serializer as a dependency to JwtEncoder constructor:

        IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
        IJsonSerializer serializer = new CustomJsonSerializer();
        IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
        IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

        */



    }
    }


