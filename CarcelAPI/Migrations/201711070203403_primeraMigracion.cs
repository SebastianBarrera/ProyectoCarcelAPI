namespace CarcelAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primeraMigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CondenaDelitos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CondenaId = c.Int(),
                        DelitoId = c.Int(),
                        Condena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Condenas", t => t.CondenaId)
                .Index(t => t.CondenaId);
            
            CreateTable(
                "dbo.Condenas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FechaInicioCondena = c.DateTime(nullable: false),
                        FechaCondena = c.DateTime(nullable: false),
                        PresoId = c.Int(),
                        JuezId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Jueces", t => t.JuezId)
                .ForeignKey("dbo.Presos", t => t.PresoId)
                .Index(t => t.PresoId)
                .Index(t => t.JuezId);
            
            CreateTable(
                "dbo.Jueces",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Rut = c.String(),
                        Sexo = c.Boolean(nullable: false),
                        Domicilio = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Presos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Rut = c.String(),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Domicilio = c.String(),
                        Sexo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Delitos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        CondenaMinima = c.Int(nullable: false),
                        CondenaMaxima = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Condenas", "PresoId", "dbo.Presos");
            DropForeignKey("dbo.Condenas", "JuezId", "dbo.Jueces");
            DropForeignKey("dbo.CondenaDelitos", "CondenaId", "dbo.Condenas");
            DropIndex("dbo.Condenas", new[] { "JuezId" });
            DropIndex("dbo.Condenas", new[] { "PresoId" });
            DropIndex("dbo.CondenaDelitos", new[] { "CondenaId" });
            DropTable("dbo.Delitos");
            DropTable("dbo.Presos");
            DropTable("dbo.Jueces");
            DropTable("dbo.Condenas");
            DropTable("dbo.CondenaDelitos");
        }
    }
}
