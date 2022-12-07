using MVC_Hotel.Models;

namespace MVC_Hotel
{
    public class Program
    {
        public static Hotel Hotel { get; set; }
        public static void Main(string[] args)
        {
            InitializeHotel();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        public static void InitializeHotel()
        {
            Hotel = new("Possum Hotel", "123 Main Street");

            Hotel.Clients.Add(new Client("Alex", "1234 5678 9012 3456"));
            Hotel.Clients.Add(new Client("Andrew", "0000 0000 0000 0000"));
            Hotel.Clients.Add(new Client("Adam", "1111 1111 1111 1111"));

            Random rng = new();
            for (int i = 0; i < 30; i++)
            {
                Hotel.Rooms.Add(new Room()
                {
                    Number = $"i-0{i}",
                    Capacity = rng.Next(6) + 1,
                    Occupied = rng.Next(3) == 0,
                    Reservations = new()
                });
            }
        }
    }
}