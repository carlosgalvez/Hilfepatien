namespace HilfepatienApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Puesto = c.String(),
                        Fecha_Ingreso = c.DateTime(nullable: false),
                        Sueldo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Medicina",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        IdProveedor = c.Int(nullable: false),
                        Presentacion = c.String(),
                        TipodeMedicamento = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Proveedor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Telefono = c.Int(nullable: false),
                        Direccion = c.String(),
                        MedicinaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicina", t => t.MedicinaId, cascadeDelete: true)
                .Index(t => t.MedicinaId);
            
            CreateTable(
                "dbo.Medico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Especialidad = c.String(),
                        Telefono = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Sexo = c.String(),
                        Edad = c.Int(nullable: false),
                        Direccion = c.String(),
                        Telefono = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Receta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo_Medicamento = c.String(),
                        Nombre_Medicamento = c.String(),
                        Nombre_Paciente = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        Paciente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paciente", t => t.Paciente_Id)
                .Index(t => t.Paciente_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Contraseña = c.String(),
                        Medico_Id = c.Int(),
                        Paciente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medico", t => t.Medico_Id)
                .ForeignKey("dbo.Paciente", t => t.Paciente_Id)
                .Index(t => t.Medico_Id)
                .Index(t => t.Paciente_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "Paciente_Id", "dbo.Paciente");
            DropForeignKey("dbo.Usuarios", "Medico_Id", "dbo.Medico");
            DropForeignKey("dbo.Receta", "Paciente_Id", "dbo.Paciente");
            DropForeignKey("dbo.Proveedor", "MedicinaId", "dbo.Medicina");
            DropIndex("dbo.Usuarios", new[] { "Paciente_Id" });
            DropIndex("dbo.Usuarios", new[] { "Medico_Id" });
            DropIndex("dbo.Receta", new[] { "Paciente_Id" });
            DropIndex("dbo.Proveedor", new[] { "MedicinaId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Receta");
            DropTable("dbo.Paciente");
            DropTable("dbo.Medico");
            DropTable("dbo.Proveedor");
            DropTable("dbo.Medicina");
            DropTable("dbo.Empleados");
        }
    }
}
