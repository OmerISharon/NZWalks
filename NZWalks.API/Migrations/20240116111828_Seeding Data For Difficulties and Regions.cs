using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7887f7b9-5edb-46d1-8cdc-a26e5df926d5"), "Medium" },
                    { new Guid("c274310d-5adb-44f2-a241-5b4a11a41e57"), "Hard" },
                    { new Guid("c7b6bfa2-7cf3-4a06-8c5a-582dc531e6c8"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0489db1b-80ae-4324-9525-84b32b8408f6"), "STL", "Southland", "https://assets.simpleviewinc.com/simpleview/image/upload/c_limit,h_1200,q_75,w_1200/v1/clients/southlandnz/Riverton_Southland_New_Zealand_Credit_Great_South_3__6fa0c09a-a1e3-414a-bf34-be25daa667b9.jpg" },
                    { new Guid("11c7a514-d8bf-402c-a87a-8161b3903467"), "NSN", "Nelson", "https://www.eatworktravel.com/wp-content/uploads/2017/04/Nelson-New-Zealand-4711.jpg" },
                    { new Guid("54c87543-f499-448f-9db7-c5ad06b5937b"), "WGN", "Wellington", "https://wellington.govt.nz/-/media/wellington-city/about-wellington/profile/images/86568_1763_rt.jpg" },
                    { new Guid("57c1f6c8-df1f-47ff-a6e1-7386b00d524e"), "BOP", "Bay Of Plenty", "https://www.newzealand.com/assets/Tourism-NZ/Bay-of-Plenty/6d1047c26a/img-1536927287-1206-10060-p-7CD33CA5-0906-4B8F-DC8DDBFCCE92BB46-2544003__aWxvdmVrZWxseQo_CropResizeWzE5MDAsMTAwMCw3NSwicG5nIl0.png" },
                    { new Guid("8ff729a6-35c5-4524-aa19-8194ebba88c6"), "AKL", "Auckland", "https://encrypted-tbn1.gstatic.com/licensed-image?q=tbn:ANd9GcSbtmRCui6cHdhj9GjDOoUyIWIQ6Uf-K_AXud-wgl6frpAkB5XYBNClHhNjyPfKEve4lozjoXS_2sCPbu3FmOw1Iq9D5iKF5pahkOOaYA" },
                    { new Guid("bea81efc-fdf4-4b29-8ba5-1c32ea479b3b"), "NTL", "Northland", "https://lp-cms-production.imgix.net/2019-06/14e0f74f559b51878ae048fbd6b81be6ef9272af969a7e3d1b1d5482920cf9b8.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7887f7b9-5edb-46d1-8cdc-a26e5df926d5"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c274310d-5adb-44f2-a241-5b4a11a41e57"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("c7b6bfa2-7cf3-4a06-8c5a-582dc531e6c8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0489db1b-80ae-4324-9525-84b32b8408f6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("11c7a514-d8bf-402c-a87a-8161b3903467"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("54c87543-f499-448f-9db7-c5ad06b5937b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("57c1f6c8-df1f-47ff-a6e1-7386b00d524e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8ff729a6-35c5-4524-aa19-8194ebba88c6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("bea81efc-fdf4-4b29-8ba5-1c32ea479b3b"));
        }
    }
}
