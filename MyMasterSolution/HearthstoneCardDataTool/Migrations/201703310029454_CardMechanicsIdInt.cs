namespace MainConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardMechanicsIdInt : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CardMechanics");
            AlterColumn("dbo.CardMechanics", "entityFrameworkCardMechanicId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CardMechanics", "entityFrameworkCardMechanicId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CardMechanics");
            AlterColumn("dbo.CardMechanics", "entityFrameworkCardMechanicId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.CardMechanics", "entityFrameworkCardMechanicId");
        }
    }
}
