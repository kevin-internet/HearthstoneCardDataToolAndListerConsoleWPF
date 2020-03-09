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

    public class JourneyToUnGoro : Card
    {
    }

    public class KnightsoftheFrozenThrone : Card
    {
    }

    public class KoboldsAndCatacombs : Card
    {
    }

    public class TheWitchwood : Card
    {
    }

    public class TheBoomsdayProject : Card
    {
    }

    public class RastakhansRumble : Card
    {
    }

    public class RiseofShadows : Card
    {
    }

    public class SaviorsofUldum : Card
    {
    }
    public class DescentofDragons : Card
    {
    }
    public class GalakrondsAwakening : Card
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

        [JsonProperty("One Night in Karazhan")]
        public List<Karazhan> Karazhan { get; set; }

        [JsonProperty("Mean Streets of Gadgetzan")]
        public List<MeanStreetsOfGadgetzan> MeanStreetsofGadgetzan { get; set; }

        [JsonProperty("Tavern Brawl")]
        public List<TavernBrawl> TavernBrawl { get; set; }

        [JsonProperty("Hero Skins")]
        public List<HeroSkin> HeroSkins { get; set; }

        [JsonProperty("Journey to Un'Goro")]
        public List<JourneyToUnGoro> JourneyToUnGoro { get; set; }

        [JsonProperty("Knights of the Frozen Throne")]
        public List<KnightsoftheFrozenThrone> KnightsOfTheFrozenThrone { get; set; }

        [JsonProperty("Kobolds & Catacombs")]
        public List<KoboldsAndCatacombs> KoboldsAndCatacombs { get; set; }

        [JsonProperty("The Witchwood")]
        public List<TheWitchwood> TheWitchwood { get; set; }

        [JsonProperty("The Boomsday Project")]
        public List<TheBoomsdayProject> TheBoomsdayProject { get; set; }

        [JsonProperty("Rastakhan's Rumble")]
        public List<RastakhansRumble> RastakhansRumbles { get; set; }

        [JsonProperty("Rise of Shadows")]
        public List<RiseofShadows> RiseofShadows { get; set; }

        [JsonProperty("Saviors of Uldum")]
        public List<SaviorsofUldum> SaviorsofUldum { get; set; }

        [JsonProperty("Descent of Dragons")]
        public List<DescentofDragons> DescentofDragons { get; set; }

        [JsonProperty("Galakrond's Awakening")]
        public List<GalakrondsAwakening> GalakrondsAwakening { get; set; }

        public List<Mission> Missions { get; set; }
        public List<Credit> Credits { get; set; }
        public List<object> System { get; set; }
        public List<Debug> Debug { get; set; }
    }
}
