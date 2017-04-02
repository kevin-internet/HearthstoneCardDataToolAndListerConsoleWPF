using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsole.Classes
{
    public class CardContext : DbContext
    {
        public CardContext() : base("SQLServer2016Developer") 
        {

        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<CardMechanic> CardMechanics { get; set; }
    }
}
