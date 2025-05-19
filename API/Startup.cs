using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using System.Text.Json.Serialization;
using API.Uitilities.Repositories;
using API.Uitilities.Services;
namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var jwtKey = Configuration["Jwt:Key"];
            if (string.IsNullOrEmpty(jwtKey))
            {
                throw new ArgumentException("JWT Key is not configured properly.");
            }
            Console.WriteLine($"JWT Key Loaded: {jwtKey}");
            var Cors = Configuration.GetSection("Cors");
            //services.AddSignalR();
            services.AddMemoryCache();
            services.AddControllers()
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null; // Preserve property names
                opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never; // Prevent ignoring null values
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            //services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));

            // services.AddControllers();

            //SQL SERVER CONNECTION HERE

            //services.AddDbContext<DbContext>(option =>
            //{
            //    option.UseSqlServer(Configuration.GetConnectionString("DBConnection") ?? "");
            //});
            services.AddDbContext<DBContext>(option => {
                option.UseSqlServer(Configuration.GetConnectionString("DBConnection") ?? "");
            });

            // services.AddDbContext<axpcmContext>(option =>
            // {
            //     option.UseSqlServer(Configuration.GetConnectionString("axpcm"));
            // });

            services.AddCors(options =>
            {
                options.AddPolicy("allow-policy", policy =>
                {
                    policy
                    .WithOrigins(Cors.GetSection("Origins").Value ?? "")
                    .WithHeaders(Cors.GetSection("Headers").Value ?? "")
                    .WithMethods(Cors.GetSection("Methods").Value ?? "")
                    .AllowCredentials();
                });
            });

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                // jwt setup
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                    //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"] ?? ""))
                };

                // append header when jwt expired
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            //Remove due to conflict of Json Return Content Type 15-05-2025
            //services.AddControllersWithViews()
            //    .AddNewtonsoftJson(options =>
            //    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //); 

            services.AddCors();


            //SERVICES or REPOSITORY
            services.AddTransient<IAuthRepository, AuthRepository>();
            services.AddTransient<IAdmissionRepository, AdmissionRepository>();



            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 10_000_000; // 10 MB limit per file
                options.ValueLengthLimit = int.MaxValue;      // unlimited input length
                options.MultipartHeadersLengthLimit = int.MaxValue; // unlimited header length
            });
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("allow-policy", policy =>
            //    {
            //        policy
            //            .WithOrigins("http://localhost:5173")  // Specify frontend domain here
            //            .AllowAnyHeader()
            //            .AllowAnyMethod()
            //            .AllowCredentials();
            //    });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            //app.UseCors("allow-policy");

            app.UseRouting();

            app.UseCors(option =>
            {
                option.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            });

            // Local
            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"uploads")),
            //    RequestPath = new PathString("/uploads")
            //});

            // IIS
            // app.UseStaticFiles(new StaticFileOptions()
            // {
            //     FileProvider = new PhysicalFileProvider(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, @"uploads")),
            //     RequestPath = new PathString("/uploads")
            // }); 

            // for single host of web and api start
            // app.Use(async (context, next) =>

            // {

            //     await next();

            //     if (context.Response.StatusCode == 404 && !System.IO.Path.HasExtension(context.Request.Path.Value))

            //     {

            //         context.Request.Path = "/index.html";

            //         await next();

            //     }

            // });

            // app.UseDefaultFiles();
            // app.UseStaticFiles();
            // for single host of web and api end


            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapHub<ChatHub>("/chatHub");
                endpoints.MapControllers();

            });
        }
    }
}