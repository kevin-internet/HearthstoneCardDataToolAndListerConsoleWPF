using System;
using System.Collections.Generic;
using MainConsole.Classes;
using System.Linq;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace MainConsole
{
    class Program
    {
        static int isCollectible = 0;
        private const string QUOTE = "\"";
        private const string ESCAPED_QUOTE = "\"\"";
        private static char[] CHARACTERS_THAT_MUST_BE_QUOTED = { ',', '"', '\n' };

        static void Main(string[] args)
        {
            DisplayConsoleUI();
        }

        private static void DisplayConsoleUI_IsCollectible()
        {
            Console.WriteLine("\r\n");
            Console.WriteLine("0 - Press 0 to get All CARDS from json web api");
            Console.WriteLine("1 - Press 1 to get ONLY COLLECTIBLE CARDS from json web api");
            
            switch (Console.ReadKey().KeyChar)
            {
                case '0':
                    isCollectible = 0;
                    Console.WriteLine("\r\n");
                    Console.WriteLine("You will download data for ALL CARDS from json web api.");
                    break;
                case '1':
                    isCollectible = 1;
                    Console.WriteLine("\r\n");
                    Console.WriteLine("You will download data for COLLECTIBLE CARDS ONLY, from json web api.");
                    break;
                default:
                    break;
            }

            Console.WriteLine("\r\n");
            Console.WriteLine("----------------------");
        }

        private static void DisplayConsoleUI()
        {
            Console.Clear();

            Console.WriteLine("\r\n");
            Console.WriteLine("0 - Press 0 to download json card data from web api");
            Console.WriteLine("1 - Press 1 to download regular card images");
            Console.WriteLine("2 - Press 2 to download gold card images");
            Console.WriteLine("3 - Press 3 to load json card data to database ");
            Console.WriteLine("4 - Press 4 to create csv file from json web api");

            switch (Console.ReadKey().KeyChar)
            {
                case '0':
                    DownloadJsonCardDataUI();
                    break;
                case '1':
                    DownloadAllRegularCardImages();
                    break;
                case '2':
                    DownloadAllGoldCardImages();
                    break;
                case '3':
                    LoadCardDataToDatabase();
                    break;
                case '4':
                    CreateCSVFileFromJsonWebApi();
                    break;
            }

            Console.WriteLine("\r\n");
            Console.WriteLine("----------------------");

            Console.WriteLine("C to continue E to exit");

            if (Console.ReadKey().KeyChar.ToString().ToUpper() == ConsoleKey.C.ToString())
            {
                DisplayConsoleUI();
            }
            else if(Console.ReadKey().KeyChar.ToString().ToUpper() == ConsoleKey.E.ToString())
            {
                Environment.Exit(0);
            }
            
        }

        private static void DownloadJsonCardDataUI()
        {
            Console.Clear();

            Console.WriteLine("\r\n");
            Console.WriteLine("Download Json card data?");
            Console.WriteLine("Y for Yes, N for No");

            if (Console.ReadKey().KeyChar.ToString().ToUpper() == ConsoleKey.Y.ToString().ToUpper())
            {
                DisplayConsoleUI_IsCollectible();

                Console.WriteLine("\r\n");
                Console.WriteLine("DOWNLOADING card data from json api...");
                WebServiceManager.GetAllCards(isCollectible);
                Console.WriteLine("\r\n");

                if (isCollectible == 0)
                {
                    Console.WriteLine("DONE downloading card data from json api. Json card data for ALL CARDS is now in memory.");
                    Console.WriteLine("----------------------");
                }
                else
                {
                    Console.WriteLine("DONE downloading card data from json api. Json card data for COLLECTIBLE CARDS ONLY, is now in memory.");
                    Console.WriteLine("----------------------");
                }
                
            }
            else
            {
                Console.WriteLine("\r\n");
                Console.WriteLine("----------------------");
                Console.WriteLine("C to continue E to exit");

                if (Console.ReadKey().KeyChar.ToString().ToUpper() == ConsoleKey.C.ToString())
                {
                    DisplayConsoleUI();
                }
                else if (Console.ReadKey().KeyChar.ToString().ToUpper() == ConsoleKey.E.ToString())
                {
                    Environment.Exit(0);
                }
            }
        }

        private static void DownloadAllRegularCardImages()
        {
            Console.Clear();
            Console.WriteLine("\r\n");
            if (WebServiceManager.JSON_Content == null)
            {
                Console.WriteLine("The json card data has not been downloaded, you must download the data first.");
                DownloadJsonCardDataUI();
            }

            int count = 0;

            Uri regularImagesPath = new Uri(WebServiceManager.RegularImagesFilePath);
            DirectoryInfo di = Directory.CreateDirectory(regularImagesPath.LocalPath);
            Console.WriteLine("\r\n");
            Console.WriteLine("Regular Card Images will be downloaded to: " + regularImagesPath.LocalPath);
            Console.WriteLine("\r\n");
            Console.WriteLine("Do you want to change the path for downloaded Regular Card Images?");
            Console.WriteLine("Enter Y for Yes or N for No");

            switch (Console.ReadKey().KeyChar.ToString().ToUpper())
            {
                case "Y":
                    Console.WriteLine("\r\n");
                    Console.WriteLine("Enter new path for downloaded Regular Card Images:");
                    WebServiceManager.RegularImagesFilePath = @"file:///" + Console.ReadLine();
                    Console.WriteLine("\r\n");
                    Console.WriteLine("Regular Card Images will be downloaded to: " + WebServiceManager.RegularImagesFilePath);
                    break;
                case "N":
                    Console.WriteLine("\r\n");
                    Console.WriteLine("Regular Card Images will be downloaded to: " + WebServiceManager.RegularImagesFilePath);
                    break;
                default:
                    break;
            }

            Console.WriteLine("\r\n");
            Console.WriteLine("DOWNLOADING regular image files...");

            count = WebServiceManager.DownloadRegularImageFiles();

            Console.WriteLine("\r\n");
            Console.WriteLine("DOWNLOADED" + count + " regular image files.");

            Console.WriteLine("\r\n");
            Console.WriteLine("DONE downloading regular image files.");

            Console.WriteLine("\r\n");
            Console.WriteLine("----------------------");

            DisplayConsoleUI();
        }

        private static void DownloadAllGoldCardImages()
        {
            Console.Clear();
            Console.WriteLine("\r\n");
            if (WebServiceManager.JSON_Content == null)
            {
                Console.WriteLine("The json card data has not been downloaded, you must download the data first.");
                DownloadJsonCardDataUI();
            }

            int count = 0;

            Uri goldImagesPath = new Uri(WebServiceManager.GoldImagesFilePath);
            DirectoryInfo di = Directory.CreateDirectory(goldImagesPath.LocalPath);

            Console.WriteLine("\r\n");
            Console.WriteLine("Gold Card Images will be downloaded to: " + goldImagesPath.LocalPath);

            Console.WriteLine("\r\n");
            Console.WriteLine("Do you want to change the path for downloaded Gold Card Images?");
            Console.WriteLine("Enter Y for Yes or N for No");

            switch (Console.ReadKey().KeyChar.ToString().ToUpper())
            {
                case "Y":
                    Console.WriteLine("\r\n");
                    Console.WriteLine("Enter new path for downloaded Gold Card Images:");
                    WebServiceManager.GoldImagesFilePath = @"file:///" + Console.ReadLine();
                    Console.WriteLine("\r\n");
                    Console.WriteLine("Gold Card Images will be downloaded to: " + WebServiceManager.GoldImagesFilePath);
                    break;
                case "N":
                    Console.WriteLine("\r\n");
                    Console.WriteLine("Gold Card Images will be downloaded to: " + WebServiceManager.GoldImagesFilePath);
                    break;
                default:
                    break;
            }

            Console.WriteLine("\r\n");
            Console.WriteLine("DOWNLOADING gold image files...");

            count = WebServiceManager.DownloadGoldImageFiles();

            Console.WriteLine("\r\n");
            Console.WriteLine("DOWNLOADED" + count + " gold image files...");
            Console.WriteLine("\r\n");
            Console.WriteLine("DONE downloading gold image files.");

            Console.WriteLine("\r\n");
            Console.WriteLine("----------------------");

            DisplayConsoleUI();
        }


        private static void LoadCardDataToDatabase()
        {
            Console.Clear();
            Console.WriteLine("\r\n");
            if (WebServiceManager.JSON_Content == null)
            {
                Console.WriteLine("The json card data has not been downloaded, you must download the data first.");
                DownloadJsonCardDataUI();
            }

            int count = 0;

            // entity framework will create the database if it doesn't exist
            Console.WriteLine("\r\n");

            if (!WebServiceManager.CheckIfDatabaseExists())
            {
                Console.WriteLine("Database does not exist.");
                Console.WriteLine("\r\n");
                Console.WriteLine("CREATING database...");
                Console.WriteLine("\r\n");
                Console.WriteLine("ADDING card data to database...");
            }
            else
            {
                Console.WriteLine("Database already exists.");
                Console.WriteLine("\r\n");
                Console.WriteLine("ADDING or MODIFYING card data in database...");
            }
            
            

            count = WebServiceManager.CreateLoadDatabase();

            Console.WriteLine("\r\n");
            Console.WriteLine("LOADED " + count + " card records to the database.");

            Console.WriteLine("\r\n");
            Console.WriteLine("----------------------");

            DisplayConsoleUI();
        }

        public static string Escape(string s)
        {
            if (!String.IsNullOrEmpty(s))
            {
                if (s.Contains(QUOTE))
                    s = s.Replace(QUOTE, ESCAPED_QUOTE);

                if (s.IndexOfAny(CHARACTERS_THAT_MUST_BE_QUOTED) > -1)
                    s = QUOTE + s + QUOTE;
            }
 
            return s;
        }

        private static void CreateCSVFileFromJsonWebApi()
        {
            Console.WriteLine("\r\n");
            if (WebServiceManager.JSON_Content == null)
            {
                Console.WriteLine("The json card data has not been downloaded, you must download the data first.");
                DownloadJsonCardDataUI();
            }

            Uri uriCsvFilePath = new Uri(WebServiceManager.CSVFilePath);

            List<Card> listCards = WebServiceManager.ProvideCardList();

            StringBuilder builder = new StringBuilder();

            Console.WriteLine("\r\n");
            Console.WriteLine("The CSV will be created in: " + uriCsvFilePath.LocalPath);
            Console.WriteLine("\r\n");
            Console.WriteLine("Do you want to change the path for the CSV file?");
            Console.WriteLine("Enter Y for Yes or N for No");



            switch (Console.ReadKey().KeyChar.ToString().ToUpper())
            {
                case "Y":
                    Console.WriteLine("\r\n");
                    Console.WriteLine("Enter new path for the CSV file:");

                    uriCsvFilePath = new Uri(@"file:///" + Console.ReadLine());
                    break;
                default:
                    break;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(uriCsvFilePath.LocalPath));
            Console.WriteLine("\r\n");


            string filename = "";

            if (isCollectible == 1)
            {
                filename = "HS_Cards.csv";
            }
            else
            {
                filename = "HS_Cards_All.csv";
            }

            Console.WriteLine("CSV will be created as: " + uriCsvFilePath.LocalPath + filename);

            using (FileStream fs = new FileStream(uriCsvFilePath.LocalPath + filename, FileMode.Create))
            using (TextWriter writer = new StreamWriter(fs))
            {
                builder.Append("cardId,name,cardSet,type,rarity,text,playerClass,locale,mechanics,faction,health,collectible,img,imgSource,imgIcon,imgGold,attack,race,cost,flavor,artist,howToGet,howToGetGold,durability,elite");

                Console.WriteLine("\r\n");
                Console.WriteLine("WRITING header columns to CSV file...");
                writer.WriteLine(builder);

                Console.WriteLine("\r\n");
                Console.WriteLine("WRITING rows to CSV file...");

                foreach (var item in listCards)
                {
                    builder.Clear();

                    builder.Append(Escape(item.cardId) + "," + Escape(item.name) + "," + Escape(item.cardSet) + "," + Escape(item.type) + "," + Escape(item.rarity) + "," + Escape(item.text) + "," + Escape(item.playerClass) + "," + Escape(item.locale) + ",");
                    
                    if (item.mechanics != null)
                    {
                        for (int i = 0; i < item.mechanics.Count; i++)
                        {
                            builder.Append(Escape(item.mechanics[i].name));

                            if (i != item.mechanics.Count - 1)
                            {
                                builder.Append("    ");
                            }
                        }
                    }
                    else
                    {
                        builder.Append(" ");
                    }

                    builder.Append("," + Escape(item.faction) + "," + Escape(item.health.ToString()) + "," + Escape(item.collectible.ToString()) + "," + Escape(item.img) + "," + Escape(item.imgSource) + "," + Escape(item.imgIcon) + "," + Escape(item.imgGold) + "," + Escape(item.attack.ToString()) + "," + Escape(item.race) + "," + Escape(item.cost.ToString()) + "," + Escape(item.flavor) + "," + Escape(item.artist) + "," + Escape(item.howToGet) + "," + Escape(item.howToGetGold) + "," + Escape(item.durability.ToString()) + "," + Escape(item.elite.ToString()));

                    
                    writer.WriteLine(builder);
                }

                Console.WriteLine("\r\n");
                Console.WriteLine("DONE writing CSV file.");
            }

            using (FileStream fs = new FileStream(uriCsvFilePath.LocalPath + "HS_Card_Mechanics.csv", FileMode.Create))
            using (TextWriter writer = new StreamWriter(fs))
            {
                builder.Clear();
                builder.Append("Mechanic_name,Card_cardId,cardMechanicId");

                Console.WriteLine("\r\n");
                Console.WriteLine("WRITING header columns to Mechanic CSV file...");
                writer.WriteLine(builder);

                Console.WriteLine("\r\n");
                Console.WriteLine("WRITING rows to Mechanic CSV file...");

                foreach (var item in listCards)
                {
                    if (item.mechanics != null)
                    {
                        for (int i = 0; i < item.mechanics.Count; i++)
                        {

                            builder.Clear();
                            builder.Append(Escape(item.mechanics[i].name) + "," + Escape(item.cardId) + "," + Escape(item.mechanics[i].cardMechanicId.ToString()));

                            writer.WriteLine(builder);
                        }
                    }
                }

                Console.WriteLine("\r\n");
                Console.WriteLine("DONE writing mechanic CSV file.");
            }

            Console.WriteLine("\r\n");
            Console.WriteLine("----------------------");

            DisplayConsoleUI();
        }
    }
}
