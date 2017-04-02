namespace MainConsole.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        cardId = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        cardSet = c.String(),
                        type = c.String(),
                        rarity = c.String(),
                        text = c.String(),
                        playerClass = c.String(),
                        locale = c.String(),
                        faction = c.String(),
                        health = c.Int(),
                        collectible = c.Boolean(),
                        img = c.String(),
                        imgGold = c.String(),
                        attack = c.Int(),
                        race = c.String(),
                        cost = c.Int(),
                        flavor = c.String(),
                        artist = c.String(),
                        howToGet = c.String(),
                        howToGetGold = c.String(),
                        durability = c.Int(),
                        elite = c.Boolean(),
                        imgFilePath = c.String(),
                        imgFilePathGold = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.cardId);
            
            CreateTable(
                "dbo.CardMechanics",
                c => new
                    {
                        entityFrameworkCardMechanicId = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        Card_cardId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.entityFrameworkCardMechanicId)
                .ForeignKey("dbo.Cards", t => t.Card_cardId)
                .Index(t => t.Card_cardId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CardMechanics", "Card_cardId", "dbo.Cards");
            DropIndex("dbo.CardMechanics", new[] { "Card_cardId" });
            DropTable("dbo.CardMechanics");
            DropTable("dbo.Cards");
        }
    }
}
