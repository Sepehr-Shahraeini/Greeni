﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using API.Models;
using System.Web.Http.Cors;
using API.Repositories;

namespace API.Providers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;

        public ApplicationOAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
        }
        //ati login
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                UnitOfWork unitOfWork = new UnitOfWork();
                var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

                ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);



                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }
                var roles = userManager.GetRoles(user.Id).First();


                var scope = context.Scope.ToList();
                var customerId = Convert.ToInt32(context.Scope[0]);



                ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
                   OAuthDefaults.AuthenticationType);
                ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
                    CookieAuthenticationDefaults.AuthenticationType);
                oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                if (roles == "Company")
                    oAuthIdentity.AddClaim(new Claim(ClaimTypes.Role, "Company"));
                else if (roles == "User")
                    oAuthIdentity.AddClaim(new Claim(ClaimTypes.Role, "User"));
                else
                    oAuthIdentity.AddClaim(new Claim(ClaimTypes.Role, "xuser"));


                oAuthIdentity.AddClaim(new Claim("sub", context.UserName));
                oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, "Vahid"));

                AuthenticationProperties properties = CreateProperties(user.UserName, (context.ClientId == null) ? string.Empty : context.ClientId);
                properties.Dictionary.Add("AuthId", user.Id);
                var company = await unitOfWork.CompanyRepository.GetViewCompanyByMobile(context.UserName);
                if (roles == "Company")
                {
                    
                    if (company != null)
                    {
                        properties.Dictionary.Add("Name", company.Name);
                        properties.Dictionary.Add("UserId", company.Id.ToString());
                        properties.Dictionary.Add("Image", string.IsNullOrEmpty(company.ImageUrl) ? "" : company.ImageUrl.ToString());
                        properties.Dictionary.Add("Role", "Company");
                        //   properties.Dictionary.Add("EmployeeId", employee.Id.ToString());

                    }
                }
                else
                {
                    //ViewPerson person = await unitOfWork.PersonRepository.GetViewPersonByUserId(user.Id);
                    if (company != null)
                    {
                        properties.Dictionary.Add("Name", company.FullName);
                        properties.Dictionary.Add("UserId", company.Id.ToString());
                        properties.Dictionary.Add("Image", string.IsNullOrEmpty(company.ImageUrl) ? "" : company.ImageUrl.ToString());
                        properties.Dictionary.Add("Role",   "User");
                        //   properties.Dictionary.Add("EmployeeId", employee.Id.ToString());

                    }
                }


                AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
                context.Validated(ticket);
                context.Request.Context.Authentication.SignIn(cookiesIdentity);
            }
            catch (Exception ex)
            {
                int i = 0;
            }

        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
        //ati login
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {

            string clientId = string.Empty;
            string clientSecret = string.Empty;
            //Client client = null;

            //if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            //{
            //    context.TryGetFormCredentials(out clientId, out clientSecret);
            //}

            //if (context.ClientId == null)
            //{
            //    //Remove the comments from the below line context.SetError, and invalidate context 
            //    //if you want to force sending clientId/secrects once obtain access tokens. 
            //    context.Validated();
            //    //context.SetError("invalid_clientId", "ClientId should be sent.");
            //    return Task.FromResult<object>(null);
            //}
            //EPAGRIFFINEntities db = new EPAGRIFFINEntities();
            //client = db.Clients.FirstOrDefault(q => q.Id == context.ClientId);
            ////using (AuthRepository _repo = new AuthRepository())
            ////{
            ////    client = _repo.FindClient(context.ClientId);
            ////}

            //if (client == null)
            //{
            //    context.SetError("invalid_clientId", string.Format("Client '{0}' is not registered in the system.", context.ClientId));
            //    return Task.FromResult<object>(null);
            //}

            //if (client.ApplicationType == (int)ApplicationTypes.NativeConfidential)
            //{
            //    if (string.IsNullOrWhiteSpace(clientSecret))
            //    {
            //        context.SetError("invalid_clientId", "Client secret should be sent.");
            //        return Task.FromResult<object>(null);
            //    }
            //    else
            //    {
            //        if (client.Secret != Helper.GetHash(clientSecret))
            //        {
            //            context.SetError("invalid_clientId", "Client secret is invalid.");
            //            return Task.FromResult<object>(null);
            //        }
            //    }
            //}

            //if (!client.Active)
            //{
            //    context.SetError("invalid_clientId", "Client is inactive.");
            //    return Task.FromResult<object>(null);
            //}

            // context.OwinContext.Set<string>("as:clientAllowedOrigin", client.AllowedOrigin);
            // context.OwinContext.Set<string>("as:clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(string userName, string clientId)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", userName },
                {"as:client_id",clientId },

            };
            return new AuthenticationProperties(data);
        }


        ////////NEW/////
        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;

            if (originalClient != currentClient)
            {
                context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
                return Task.FromResult<object>(null);
            }

            // Change auth ticket for refresh token requests
            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);

            var newClaim = newIdentity.Claims.Where(c => c.Type == "newClaim").FirstOrDefault();
            if (newClaim != null)
            {
                newIdentity.RemoveClaim(newClaim);
            }
            newIdentity.AddClaim(new Claim("newClaim", "newValue"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }
        //////////////
    }


}