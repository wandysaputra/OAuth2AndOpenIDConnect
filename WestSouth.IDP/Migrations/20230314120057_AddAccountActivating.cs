using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WestSouth.IDP.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountActivating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("0bb2bca5-39c5-42d5-bdd6-008086ea6881"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("4e6ea32e-f6a4-48e4-85a7-b09ea4f0d3cb"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("57c92a47-8730-423e-8e48-9f9c255a2ec2"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("67d4d0a5-fe5a-48a0-9791-1e42eff05044"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("7a46836e-aacd-4551-b8d8-ee5bd95c70fa"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("8f757b9d-5d36-4eb7-b34b-b0dac758b825"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("ac520452-0c89-4643-8c1a-ee590589c6d0"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("af9cffc7-f921-443d-bd2c-499be59fed3e"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecurityCode",
                table: "Users",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SecurityCodeExpirationDate",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("07789dd2-8196-4d4b-a4e7-b476f4fb5d0b"), "4702f484-de0f-43ff-bf64-57ec412a319f", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("17b3c618-1c8c-4ef8-83c1-426d1a916495"), "79f06bcf-57ac-42ef-8b5e-fd05937e5346", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("a4d59050-2c37-4f1d-9bf2-00cbf7040484"), "71b4129c-2c4f-45b5-b1ce-5eaaafb2727b", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("b50e96d5-0244-43b7-bf1d-3df230f1a9fb"), "06f928f4-dbe4-42e1-8e40-5240f43a3a92", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("c6936098-a849-44f6-a0ad-c6e523478eb8"), "799e43a4-3cfc-4c96-88ca-b9444af8644a", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("d22bf44b-b9b1-47c9-988e-9062eba43708"), "a0cd73af-f711-4e50-85d0-571af60b3bc6", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("d4c3c288-e05c-496e-bbac-4eb0e555ef9d"), "9660ae57-22b6-47da-b0d3-f7ef59f8cabb", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("e97fe5ff-08f4-4cce-8af3-a11efd4ea315"), "7af8132d-1206-4423-aaed-230ca4eac59f", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityCode", "SecurityCodeExpirationDate" },
                values: new object[] { "4165cc79-be32-41e7-8f32-0e896434afa0", "david@someprovider.com", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityCode", "SecurityCodeExpirationDate" },
                values: new object[] { "ed551ea4-6ab4-48d8-990a-6ef03f9b294a", "emma@someprovider.com", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("07789dd2-8196-4d4b-a4e7-b476f4fb5d0b"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("17b3c618-1c8c-4ef8-83c1-426d1a916495"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("a4d59050-2c37-4f1d-9bf2-00cbf7040484"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("b50e96d5-0244-43b7-bf1d-3df230f1a9fb"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c6936098-a849-44f6-a0ad-c6e523478eb8"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("d22bf44b-b9b1-47c9-988e-9062eba43708"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("d4c3c288-e05c-496e-bbac-4eb0e555ef9d"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e97fe5ff-08f4-4cce-8af3-a11efd4ea315"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCodeExpirationDate",
                table: "Users");

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("0bb2bca5-39c5-42d5-bdd6-008086ea6881"), "9c496942-97cb-44e2-897f-5f085308c375", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("4e6ea32e-f6a4-48e4-85a7-b09ea4f0d3cb"), "77893bae-be67-4aad-b395-3c0729296e65", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("57c92a47-8730-423e-8e48-9f9c255a2ec2"), "d1f01603-fc1c-4695-91f6-6cb3ea7ff343", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("67d4d0a5-fe5a-48a0-9791-1e42eff05044"), "8ae7d0b8-e00f-42cb-aec5-e075b444ff2d", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("7a46836e-aacd-4551-b8d8-ee5bd95c70fa"), "343c535f-e11a-4962-8b20-2cde3b94c181", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("8f757b9d-5d36-4eb7-b34b-b0dac758b825"), "6119b49d-df55-4fc1-bb80-5db347b89b6a", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("ac520452-0c89-4643-8c1a-ee590589c6d0"), "30d5630a-3cdb-42c5-8d84-e29da0863ffb", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("af9cffc7-f921-443d-bd2c-499be59fed3e"), "1aba9816-251b-4dbe-bca6-833304c6dac3", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "ebc692a9-67b8-4b42-81c9-d09465c96efb");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "7939d0e9-8326-4e3e-b849-514108b58bd4");
        }
    }
}
