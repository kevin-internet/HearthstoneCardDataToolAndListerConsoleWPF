using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Data;
using System.IO;
using System.Data.Entity.Validation;
using System.Reflection;

namespace MainConsole.Classes
{
    public class WebServiceManager
    {
        static string jsonContent = null;

        private static string _regularImagesFilePath = @"file:///C:\HS_RegularCardsTemp\";
        private static string _goldImagesFilePath = @"file:///C:\HS_GoldCardsTemp\";
        private static string _csvFilePath = @"file:///C:\HS_CardsCSV\";

        public static string JSON_Content
        {
            get { return jsonContent; }
        }

        public static string RegularImagesFilePath
        {
            get { return _regularImagesFilePath; }
            set { _regularImagesFilePath = value; }
        }
        public static string GoldImagesFilePath
        {
            get { return _goldImagesFilePath; }
            set { _goldImagesFilePath = value; }
        }
        public static string CSVFilePath
        {
            get { return _csvFilePath; }
            set { _csvFilePath = value; }
        }



        public static List<Card> ProvideCardList()
        {
            RootObject cards = JsonConvert.DeserializeObject<RootObject>(jsonContent);

            List<Card> listAllCards = new List<Card>();

            listAllCards.AddRange(cards.Basic);
            listAllCards.AddRange(cards.BlackrockMountain);
            listAllCards.AddRange(cards.Classic);
            listAllCards.AddRange(cards.Credits);
            listAllCards.AddRange(cards.Debug);
            listAllCards.AddRange(cards.GoblinsvsGnomes);
            listAllCards.AddRange(cards.HeroSkins);
            listAllCards.AddRange(cards.Karazhan);
            listAllCards.AddRange(cards.MeanStreetsofGadgetzan);
            listAllCards.AddRange(cards.Missions);
            listAllCards.AddRange(cards.Naxxramas);
            listAllCards.AddRange(cards.Promo);
            //List<sys> listCardsSystem = cards.System; // this is empty in the json web api
            listAllCards.AddRange(cards.TavernBrawl);
            listAllCards.AddRange(cards.TheGrandTournament);
            listAllCards.AddRange(cards.TheLeagueofExplorers);
            listAllCards.AddRange(cards.WhispersoftheOldGods);
            listAllCards.AddRange(cards.JourneyToUnGoro);
            //
            listAllCards.AddRange(cards.KnightsOfTheFrozenThrone);
            listAllCards.AddRange(cards.KoboldsAndCatacombs);
            listAllCards.AddRange(cards.TheWitchwood);
            listAllCards.AddRange(cards.TheBoomsdayProject);
            listAllCards.AddRange(cards.RastakhansRumbles);
            listAllCards.AddRange(cards.RiseofShadows);
            //listAllCards.AddRange(cards.KnightsOfTheFrozenThrone);

            foreach (var item in listAllCards)
            {
                if (item.img != null)
                {
                    item.imgFilePath = RegularImagesFilePath + Path.GetFileName(item.img);
                }
                if (item.imgGold != null)
                {
                    item.imgFilePathGold = GoldImagesFilePath + Path.GetFileName(item.imgGold);
                } 
            }

            return listAllCards;
        }

        public static void GetAllCards(int isCollectible)
        {
            var url = "https://omgvamp-hearthstone-v1.p.mashape.com/cards";
            var client = new WebClient();
            client.Headers.Set("X-Mashape-Key", "URzOTo39w1mshcfB4WzfWVaRrc4up1CdK4XjsnYFfZsescLikL");
            client.QueryString.Set("collectible", isCollectible.ToString()); // enter "1" for only collectible cards
            var downloadedJsonContent = client.DownloadString(url);
            jsonContent = downloadedJsonContent;
        }

        public static int DownloadRegularImageFiles()
        {
            List<Card> cardList = ProvideCardList();
            byte[] data;
            string filename = "";
            string url;
            int count = 0;
            Uri uriRegularImageFilePath = new Uri(RegularImagesFilePath);

            using (WebClient client = new WebClient())
            {
                foreach (var item in cardList)
                {
                    url = item.img;
                    if (url != null)
                    {
                        data = client.DownloadData(url);
                        filename = Path.GetFileName(url);
                        DirectoryInfo di = Directory.CreateDirectory(uriRegularImageFilePath.LocalPath);
                        FileStream fs = new FileStream(uriRegularImageFilePath.LocalPath + filename, FileMode.Create);
                    }  
                }

                count = (from c in cardList
                         where c.img != null
                         select c).Count();
            }

            return count;
        }

        public static int DownloadGoldImageFiles()
        {
            List<Card> cardList = ProvideCardList();
            byte[] data;
            string filename = "";
            string url;
            int count = 0;
            Uri uriGoldImageFilePath = new Uri(GoldImagesFilePath);

            using (WebClient client = new WebClient())
            {
                foreach (var item in cardList)
                {
                    url = item.imgGold;
                    if (url != null)
                    {
                        data = client.DownloadData(url);
                        filename = Path.GetFileName(url);
                        DirectoryInfo di = Directory.CreateDirectory(uriGoldImageFilePath.LocalPath);
                        FileStream fs = new FileStream(uriGoldImageFilePath.LocalPath + filename, FileMode.Create);
                    }
                }

                count = (from c in cardList
                         where c.imgGold != null
                         select c).Count();
            }

            return count;
        }

        public static bool CheckIfDatabaseExists()
        {
            CardContext databaseContext = new CardContext();
            bool databaseExists = databaseContext.Database.Exists();

            return databaseExists;
        }

        public static int CreateLoadDatabase()
        {
            var cardList = ProvideCardList();
            int count = 0;

            using (var cardContext = new CardContext())
            {
                try
                {
                    int dummyIdCount = 0;

                    foreach (var card in cardList)
                    {
                        if (card.mechanics != null)
                        {
                            foreach (var mechanic in card.mechanics)
                            {
                                mechanic.cardMechanicId = dummyIdCount + 1;

                                if (!cardContext.CardMechanics.Any(o => o.cardMechanicId == mechanic.cardMechanicId))
                                {
                                    cardContext.Entry(mechanic).State = System.Data.Entity.EntityState.Added;
                                }
                                if (cardContext.CardMechanics.Any(o => o.cardMechanicId == mechanic.cardMechanicId))
                                {
                                    cardContext.Entry(mechanic).State = System.Data.Entity.EntityState.Modified;
                                }
 
                                dummyIdCount += 1;
                            }
                        }

                        if (!cardContext.Cards.Any(o => o.cardId == card.cardId))
                        {
                            cardContext.Cards.Add(card);
                            cardContext.Entry(card).State = System.Data.Entity.EntityState.Added;
                        }
                        else if (cardContext.Cards.Any(o => o.cardId == card.cardId))
                        {
                            cardContext.Cards.Attach(card);
                            cardContext.Entry(card).State = System.Data.Entity.EntityState.Modified;
                        }
                    }

                    //foreach (var dbEntityEntry in db.ChangeTracker.Entries<Card>())
                    //{
                    //    System.Diagnostics.Debug.WriteLine(dbEntityEntry.State);
                    //    System.Diagnostics.Debug.WriteLine(dbEntityEntry.Entity.cardId + " " + dbEntityEntry.Entity.name);
                    //}

                    //foreach (var dbEntityEntry in db.ChangeTracker.Entries<CardMechanic>())
                    //{
                    //    System.Diagnostics.Debug.WriteLine(dbEntityEntry.State);
                    //    System.Diagnostics.Debug.WriteLine(dbEntityEntry.Entity.cardMechanicId + " " + dbEntityEntry.Entity.name);
                    //}

                    //db.Database.Log = Console.WriteLine;

                    cardContext.SaveChanges();

                    count = (from c in cardContext.Cards
                                 select c).Count();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Diagnostics.Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }

                return count;
             }
        }
    }
}
