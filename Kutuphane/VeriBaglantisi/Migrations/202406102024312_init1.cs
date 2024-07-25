namespace VeriBaglantisi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kitaplar", "KitapTuruID", "dbo.KitapTurler");
            DropForeignKey("dbo.Kitaplar", "YazarID", "dbo.Yazarlar");
            DropIndex("dbo.Kitaplar", new[] { "YazarID" });
            DropIndex("dbo.Kitaplar", new[] { "KitapTuruID" });
            AddColumn("dbo.EmanetKitaplar", "YazarID", c => c.Int());
            AlterColumn("dbo.Kitaplar", "YazarID", c => c.Int());
            AlterColumn("dbo.Kitaplar", "KitapTuruID", c => c.Int());
            CreateIndex("dbo.EmanetKitaplar", "YazarID");
            CreateIndex("dbo.Kitaplar", "YazarID");
            CreateIndex("dbo.Kitaplar", "KitapTuruID");
            AddForeignKey("dbo.EmanetKitaplar", "YazarID", "dbo.Yazarlar", "YazarID");
            AddForeignKey("dbo.Kitaplar", "KitapTuruID", "dbo.KitapTurler", "KitapTuruID");
            AddForeignKey("dbo.Kitaplar", "YazarID", "dbo.Yazarlar", "YazarID");
            DropColumn("dbo.EmanetKitaplar", "KitapVerildiMi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmanetKitaplar", "KitapVerildiMi", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Kitaplar", "YazarID", "dbo.Yazarlar");
            DropForeignKey("dbo.Kitaplar", "KitapTuruID", "dbo.KitapTurler");
            DropForeignKey("dbo.EmanetKitaplar", "YazarID", "dbo.Yazarlar");
            DropIndex("dbo.Kitaplar", new[] { "KitapTuruID" });
            DropIndex("dbo.Kitaplar", new[] { "YazarID" });
            DropIndex("dbo.EmanetKitaplar", new[] { "YazarID" });
            AlterColumn("dbo.Kitaplar", "KitapTuruID", c => c.Int(nullable: false));
            AlterColumn("dbo.Kitaplar", "YazarID", c => c.Int(nullable: false));
            DropColumn("dbo.EmanetKitaplar", "YazarID");
            CreateIndex("dbo.Kitaplar", "KitapTuruID");
            CreateIndex("dbo.Kitaplar", "YazarID");
            AddForeignKey("dbo.Kitaplar", "YazarID", "dbo.Yazarlar", "YazarID", cascadeDelete: true);
            AddForeignKey("dbo.Kitaplar", "KitapTuruID", "dbo.KitapTurler", "KitapTuruID", cascadeDelete: true);
        }
    }
}
