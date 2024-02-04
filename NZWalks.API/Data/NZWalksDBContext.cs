using Microsoft.EntityFrameworkCore;
using NZWalks.API.Controllers;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDBContext : DbContext
    {
        public NZWalksDBContext(DbContextOptions<NZWalksDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties:
            // Easy, Medium, Hard
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("c7b6bfa2-7cf3-4a06-8c5a-582dc531e6c8"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("7887f7b9-5edb-46d1-8cdc-a26e5df926d5"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("c274310d-5adb-44f2-a241-5b4a11a41e57"),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            // Seed data for Regions
            var regions = new List<Region>() {
                new Region
                {
                    Id = Guid.Parse("8ff729a6-35c5-4524-aa19-8194ebba88c6"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://encrypted-tbn1.gstatic.com/licensed-image?q=tbn:ANd9GcSbtmRCui6cHdhj9GjDOoUyIWIQ6Uf-K_AXud-wgl6frpAkB5XYBNClHhNjyPfKEve4lozjoXS_2sCPbu3FmOw1Iq9D5iKF5pahkOOaYA"
                },
                new Region
                {
                    Id = Guid.Parse("bea81efc-fdf4-4b29-8ba5-1c32ea479b3b"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = "https://lp-cms-production.imgix.net/2019-06/14e0f74f559b51878ae048fbd6b81be6ef9272af969a7e3d1b1d5482920cf9b8.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("57c1f6c8-df1f-47ff-a6e1-7386b00d524e"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = "https://www.newzealand.com/assets/Tourism-NZ/Bay-of-Plenty/6d1047c26a/img-1536927287-1206-10060-p-7CD33CA5-0906-4B8F-DC8DDBFCCE92BB46-2544003__aWxvdmVrZWxseQo_CropResizeWzE5MDAsMTAwMCw3NSwicG5nIl0.png"
                },
                new Region
                {
                    Id = Guid.Parse("54c87543-f499-448f-9db7-c5ad06b5937b"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://wellington.govt.nz/-/media/wellington-city/about-wellington/profile/images/86568_1763_rt.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("11c7a514-d8bf-402c-a87a-8161b3903467"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://www.eatworktravel.com/wp-content/uploads/2017/04/Nelson-New-Zealand-4711.jpg"
                },
                new Region
                {
                    Id = Guid.Parse("0489db1b-80ae-4324-9525-84b32b8408f6"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = "https://assets.simpleviewinc.com/simpleview/image/upload/c_limit,h_1200,q_75,w_1200/v1/clients/southlandnz/Riverton_Southland_New_Zealand_Credit_Great_South_3__6fa0c09a-a1e3-414a-bf34-be25daa667b9.jpg"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
