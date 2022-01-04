using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Uf_Municipio_CepOndeleteRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cep_Municipio_MunicipioId",
                table: "Cep");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipio_Uf_UfId",
                table: "Municipio");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("672532d6-726b-44aa-8d8e-2b0e2520fa66"));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(2041));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(2052));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(1938));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(2031));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(1969));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(2055));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(2059));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("5abca453-d035-4766-a81b-9f73d683a54b"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(1972));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(1975));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(1958));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(1986));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(2038));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(2062));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(2082));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(2065));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(2045));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("b81f95e0-f226-4afd-9763-290001637ed4"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(2071));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(1978));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(1965));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(2048));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 33, 23, 996, DateTimeKind.Utc).AddTicks(2075));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("45ab91d4-6c49-445c-8fc2-5f7614e6e37a"), new DateTime(2022, 1, 4, 0, 33, 23, 993, DateTimeKind.Local).AddTicks(6919), "gabriel@gabriel.com", "Administrador", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Cep_Municipio_MunicipioId",
                table: "Cep",
                column: "MunicipioId",
                principalTable: "Municipio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Municipio_Uf_UfId",
                table: "Municipio",
                column: "UfId",
                principalTable: "Uf",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cep_Municipio_MunicipioId",
                table: "Cep");

            migrationBuilder.DropForeignKey(
                name: "FK_Municipio_Uf_UfId",
                table: "Municipio");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("45ab91d4-6c49-445c-8fc2-5f7614e6e37a"));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8216));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("1dd25850-6270-48f8-8b77-2f0f079480ab"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8225));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("22ffbd18-cdb9-45cc-97b0-51e97700bf71"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8159));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("27f7a92b-1979-4e1c-be9d-cd3bb73552a8"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8205));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("29eec4d3-b061-427d-894f-7f0fecc7f65f"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8211));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3739969c-fd8a-4411-9faa-3f718ca85e70"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8208));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("409b9043-88a4-4e86-9cca-ca1fb0d0d35b"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8185));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("43a0f783-a042-4c46-8688-5dd4489d2ec7"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8228));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("542668d1-50ba-4fca-bbc3-4b27af108ea3"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8231));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("57a9e9f7-9aea-40fe-a783-65d4feb59fa8"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8202));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("5abca453-d035-4766-a81b-9f73d683a54b"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8188));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("5ff1b59e-11e7-414d-827e-609dc5f7e333"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8191));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("7cc33300-586e-4be8-9a4d-bd9f01ee9ad8"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8177));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("837a64d3-c649-4172-a4e0-2b20d3c85224"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8199));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("8411e9bc-d3b2-4a9b-9d15-78633d64fc7c"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8214));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("88970a32-3a2a-4a95-8a18-2087b65f59d1"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8239));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("924e7250-7d39-4e8b-86bf-a8578cbf4002"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("971dcb34-86ea-4f92-989d-064f749e23c9"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8251));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("9fd3c97a-dc68-4af5-bc65-694cca0f2869"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8236));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8219));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("b81f95e0-f226-4afd-9763-290001637ed4"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8242));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("bd08208b-bfca-47a4-9cd0-37e4e1fa5006"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8193));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("c623f804-37d8-4a19-92c1-67fd162862e6"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8196));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("cb9e6888-2094-45ee-bc44-37ced33c693a"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("f85a6cd0-2237-46b1-a103-d3494ab27774"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8222));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("fe8ca516-034f-4249-bc5a-31c85ef220ea"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 4, 3, 19, 21, 605, DateTimeKind.Utc).AddTicks(8245));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("672532d6-726b-44aa-8d8e-2b0e2520fa66"), new DateTime(2022, 1, 4, 0, 19, 21, 602, DateTimeKind.Local).AddTicks(9973), "gabriel@gabriel.com", "Administrador", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Cep_Municipio_MunicipioId",
                table: "Cep",
                column: "MunicipioId",
                principalTable: "Municipio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Municipio_Uf_UfId",
                table: "Municipio",
                column: "UfId",
                principalTable: "Uf",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
