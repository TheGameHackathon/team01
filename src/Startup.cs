using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using thegame.Models;
using thegame.Services;

namespace thegame
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
            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<Game, GameDto>();
                cfg.CreateMap<Cell, CellDto>()
                    .ForMember(cfg => cfg.Type, opt => opt.MapFrom(src => Palette.ConvertColor(src.Color)))
                    .ForMember(cfg => cfg.Pos, opt => opt.MapFrom(src => new VectorDto(src.Pos.X, src.Pos.Y)));

            }, new System.Reflection.Assembly[0]);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
            app.Use((context, next) =>
            {
                context.Request.Path = "/index.html";
                return next();
            });
            app.UseStaticFiles();
        }
    }
}