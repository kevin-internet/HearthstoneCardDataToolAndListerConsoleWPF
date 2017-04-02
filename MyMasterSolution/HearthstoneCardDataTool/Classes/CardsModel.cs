using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsole.Classes
{
    public class Basic : Card
    {
    }

    public class Classic : Card
    {
    }

    public class Promo : Card
    {
    }

    public class Reward : Card
    {
    }

    public class Naxxrama : Card
    {
    }
    public class GoblinsVsGnome : Card
    {
    }

    public class BlackrockMountain : Card
    {
    }

    public class TheGrandTournament : Card
    {
    }

    public class TheLeagueOfExplorer : Card
    {
    }

    public class WhispersOfTheOldGod : Card
    {
    }

    public class Karazhan : Card
    {
    }

    public class MeanStreetsOfGadgetzan : Card
    {
    }

    public class TavernBrawl : Card
    {
    }

    public class HeroSkin : Card
    {
    }

    public class Mission : Card
    {
    }

    public class Credit : Card
    {
    }

    public class Debug : Card
    {
    }

    public class RootObject
    {
        public List<Basic> Basic { get; set; }
        public List<Classic> Classic { get; set; }
        public List<Promo> Promo { get; set; }
        public List<Reward> Reward { get; set; }
        public List<Naxxrama> Naxxramas { get; set; }

        [JsonProperty("Goblins vs Gnomes")]
        public List<GoblinsVsGnome> GoblinsvsGnomes { get; set; }

        [JsonProperty("Blackrock Mountain")]
        public List<BlackrockMountain> BlackrockMountain { get; set; }

        [JsonProperty("The Grand Tournament")]
        public List<TheGrandTournament> TheGrandTournament { get; set; }

        [JsonProperty("The League of Explorers")]
        public List<TheLeagueOfExplorer> TheLeagueofExplorers { get; set; }

        [JsonProperty("Whispers of the Old Gods")]
        public List<WhispersOfTheOldGod> WhispersoftheOldGods { get; set; }

        public List<Karazhan> Karazhan { get; set; }

        [JsonProperty("Mean Streets of Gadgetzan")]
        public List<MeanStreetsOfGadgetzan> MeanStreetsofGadgetzan { get; set; }

        [JsonProperty("Tavern Brawl")]
        public List<TavernBrawl> TavernBrawl { get; set; }

        [JsonProperty("Hero Skins")]
        public List<HeroSkin> HeroSkins { get; set; }


        public List<Mission> Missions { get; set; }
        public List<Credit> Credits { get; set; }
        public List<object> System { get; set; }
        public List<Debug> Debug { get; set; }
    }
}
