namespace MainConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardMechanicsIdInt2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CardMechanics");
            AddColumn("dbo.CardMechanics", "cardMechanicId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CardMechanics", "cardMechanicId");
            DropColumn("dbo.CardMechanics", "entityFrameworkCardMechanicId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CardMechanics", "entityFrameworkCardMechanicId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.CardMechanics");
            DropColumn("dbo.CardMechanics", "cardMechanicId");
            AddPrimaryKey("dbo.CardMechanics", "entityFrameworkCardMechanicId");
        }
    }
}
