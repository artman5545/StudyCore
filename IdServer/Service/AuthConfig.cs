using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataManage.Models;
using DataManage.Service;

namespace IdServer
{
    public class AuthConfig
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1","我的api")
            };
        }
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Address(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
                new IdentityResources.Profile(),
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId="client",
                    AllowedGrantTypes=GrantTypes.ImplicitAndClientCredentials,
                    ClientSecrets={new Secret("secret".Sha256())},
                    RequireConsent=false,
                    PostLogoutRedirectUris={ "https://localhost:44359/signout-callback-oidc" },//登出后跳转
                    RedirectUris={ "https://localhost:44359/signin-oidc" },//登录后跳转
                    FrontChannelLogoutUri="https://localhost:44359/signout-oidc",
                    AlwaysIncludeUserClaimsInIdToken=true,//将用户所有的claims包含在idtoken内
                    AllowOfflineAccess=true,//是否offline_access,是否refreshtoken
                    AllowedScopes= {
                        "api1",
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Address,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Phone,
                        IdentityServerConstants.StandardScopes.Profile
                    },

                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId="1",
                    Username="admin",
                    Password="123"
                }
            };
        }
    }
}
