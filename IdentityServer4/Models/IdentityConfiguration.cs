using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer4.ModsenTask.Models
{
    public class IdentityConfiguration
    {
        public static List<TestUser> Users =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "Maks",
                    Password = "password",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Maksim Silkou"),
                        new Claim(JwtClaimTypes.GivenName, "Maksim"),
                        new Claim(JwtClaimTypes.FamilyName, "Silkou"),
                        new Claim(JwtClaimTypes.Email, "maxim.silkou.2002@gmail.com"),
                    }
                }
            };

        public static IEnumerable<IdentityResource> identityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<Scope> ApiScopes =>
            new Scope[]
            {
                new Scope("Event.read"),
                new Scope("Event.write")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ApiResource("EventApi")
                {
                    Scopes = new List<Scope>
                    {
                        new Scope("EventApi.read"),
                        new Scope("EventApi.write"),
                    },
                    ApiSecrets = new List<Secret>
                    {
                        new Secret("a75a559d-1dab-4c65-9bc0-f8e590cb388d".Sha256())
                    }
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "t8agr5xKt4$3",
                    ClientName = "Client1",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = {new Secret("eb300de4-add9-42f4-a3ac-abd3c60f1919".Sha256())},
                    AllowedScopes = { "EventApi.read" }
                }
            };
    }
}