namespace MioBarber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class barberworks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barbers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 100),
                        HorarioId = c.Int(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Horarios", t => t.HorarioId, cascadeDelete: true)
                .Index(t => t.HorarioId);
            
            CreateTable(
                "dbo.Horarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Citas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Day = c.DateTime(nullable: false),
                        Time = c.Time(nullable: false, precision: 7),
                        BarberId = c.Int(nullable: false),
                        CorteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Barbers", t => t.BarberId, cascadeDelete: true)
                .ForeignKey("dbo.Cortes", t => t.CorteId, cascadeDelete: true)
                .Index(t => t.BarberId)
                .Index(t => t.CorteId);
            
            CreateTable(
                "dbo.Cortes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 100),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Citas", "CorteId", "dbo.Cortes");
            DropForeignKey("dbo.Citas", "BarberId", "dbo.Barbers");
            DropForeignKey("dbo.Barbers", "HorarioId", "dbo.Horarios");
            DropIndex("dbo.Citas", new[] { "CorteId" });
            DropIndex("dbo.Citas", new[] { "BarberId" });
            DropIndex("dbo.Barbers", new[] { "HorarioId" });
            DropTable("dbo.Cortes");
            DropTable("dbo.Citas");
            DropTable("dbo.Horarios");
            DropTable("dbo.Barbers");
        }
    }
}
