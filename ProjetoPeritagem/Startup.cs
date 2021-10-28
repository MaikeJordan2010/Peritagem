using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Xml;
using Modelo;
using Newtonsoft.Json.Serialization;
using Rotativa.AspNetCore;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace ProjetoPeritagem
{
    public class Startup
    {
        private CookiePolicyOptions cookiePolicyOptions;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddMemoryCache();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(options =>
           {
               options.LoginPath = "/Login/Index";
           });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                //options.IOTimeout = TimeZone.CurrentTimeZone
                options.Cookie.HttpOnly = false;
                // Make the session cookie essential
                options.Cookie.IsEssential = false; /// estava true

            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IConfiguration>(Configuration);

            /////////////  VAIDANDO AUTENTICAÇÃO POR METODO JWT BEARER
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>                            // CRIANDO OPÇÕES
            //    {
            //    options.RequireHttpsMetadata = false;
            //    options.SaveToken = true;
            //    options.TokenValidationParameters = new TokenValidationParameters // CRIANDO VALIDAÇÃO DE TOKEN
            //        {
            //        RequireExpirationTime = false,
            //        ValidateIssuer = false,                                          // VALIDAR ISSUER
            //            ValidateAudience = false,                                        // VALIDAR AUDIENCE
            //            ValidateLifetime = true,                                        // VALIDAR TEMPO DE VIDA 
            //            ValidateIssuerSigningKey = true,                                // VALIDAR ISSUERSINGINKEY
            //            ValidIssuer = Configuration["JWT:Issuer"],                      // PASSANDO O ISSUER
            //            ValidAudience = Configuration["JWT:Audience"],                  // PASSANDO O ANDIENCE
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"])) // PASSANDO A CHAVE
            //        };

            //    options.Events = new JwtBearerEvents                                        // VALIDANDO O TOKEN
            //        {
            //        OnAuthenticationFailed = context =>                                     // FALHA NA AUTENTICAÇÃO
            //            {
            //            Console.WriteLine("Token Inválido" + context.Exception.Message);    // RETORNA MSG DE TOKEN INVÁLIDO
            //                return Task.CompletedTask;
            //        },
            //        OnTokenValidated = context =>                                           // COMFIRMAÇÃO DE AUTENTICAÇÃO
            //            {
            //            Console.WriteLine("Token Válido" + context.SecurityToken);          // RETORNA MSG DE TOKEN VÁLIDO
            //                return Task.CompletedTask;
            //        }
            //    };

            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseAuthentication();
            }
            else
            {
                app.UseExceptionHandler("/Login/Index");
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();                        // INICIANDO AUTENTICAÇÃO

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });

            // Configuração para usar a biblioteca de PDF Rotativa
            RotativaConfiguration.Setup(env);
        }
    }
}
