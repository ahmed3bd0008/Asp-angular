using System;
using Entity.Core.authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Repository.Context;

namespace TestApplication.Extension
{
    public static class ConfigurationIdentityExtension
    {
       public static void ConfigurationIdentity(this IServiceCollection services)
       {
         var builder= services.AddIdentity<userIdentity,roleIdentity>(Policy=>
                        {
                                    Policy.SignIn.RequireConfirmedAccount=true;
                                    Policy.Password.RequiredLength=4;
                                    Policy.Password.RequireUppercase=false;
                                    Policy.Password.RequireNonAlphanumeric=false;
                                    Policy.Password.RequiredUniqueChars=0;
                                    Policy.Password.RequireDigit=false;
                                    Policy.User.RequireUniqueEmail=true;     
                        }); 
              builder=new IdentityBuilder(builder.UserType,builder.RoleType,builder.Services);
              builder.AddEntityFrameworkStores<AppDbContextTest>().AddDefaultTokenProviders();
       }
    }
}