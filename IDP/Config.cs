using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IDP
{
	public static class Config
	{
		public static List<TestUser> GetUsers()
		{
			return new List<TestUser>
			{
				new TestUser
				{
					SubjectId = "bedbd487-4df1-4514-ace2-367db9c08715",
					Username = "Alex",
					Password = "Ab12345!",
					Claims = new List<Claim>
					{
						new Claim("given_name", "Alex"),
						new Claim("family_name", "Floor")
					}
				},
				new TestUser
				{
					SubjectId = "e5426a3e-3a84-4cb6-bed6-787df159b54a",
					Username = "Test",
					Password = "Ab12345!",
					Claims = new List<Claim>
					{
						new Claim("given_name", "Test"),
						new Claim("family_name", "Tester")
					}
				}
			};
		}

		// identity-related resources (scopes)
		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile()
			};
		}

		public static IEnumerable<ApiResource> GetApiResources()
		{
			return new List<ApiResource>
			{
				new ApiResource("taxationexpertapi", "Taxation Expert API")
			};
		}

		public static IEnumerable<Client> GetClients()
		{
			return new List<Client>
			{
				new Client
				{
					ClientName = "Taxation Expert",
					ClientId = "TaxationExpertWebClient",
					AllowedGrantTypes = GrantTypes.Hybrid,
					RedirectUris = new List<string>
					{
						"https://localhost:8000/signin-oidc"
					},
					PostLogoutRedirectUris = new List<string>
					{
						"https://localhost:8000/signout-callback-oidc"
					},
					AllowedScopes =
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Email,
						IdentityServerConstants.StandardScopes.Profile,
						"roles",
						"taxationexpertapi"
					},
					ClientSecrets =
					{
						new Secret("secret".Sha256())
					}
				}
			};
		}
	}
}