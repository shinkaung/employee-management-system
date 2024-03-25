using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Migrations
{
    /// <inheritdoc />
    public partial class v03_Modified_Employee_Department : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_Departments_DepartmentId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Section_DepartmentId",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Employees",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentCode",
                table: "Section",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentCode",
                table: "Departments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_Section_DepartmentCode",
                table: "Section",
                column: "DepartmentCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Departments_DepartmentCode",
                table: "Section",
                column: "DepartmentCode",
                principalTable: "Departments",
                principalColumn: "DepartmentCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_Departments_DepartmentCode",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Section_DepartmentCode",
                table: "Section");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepartmentCode",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentCode",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Employees",
                newName: "EmailAddress");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Section",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_DepartmentId",
                table: "Section",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Departments_DepartmentId",
                table: "Section",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }
    }
}
