namespace PSDWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // confire the app to serve static files from the wwwroot folder

            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames=new List<string> { "home.html" };
            app.UseDefaultFiles(options);
            app.UseStaticFiles();



            /*
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
            */

            app.Run();
        }
    }
}
