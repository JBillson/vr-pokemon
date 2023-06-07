using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pokemon
{
    public class Pokemon
    {
        [JsonProperty("abilities")] public List<Ability> abilities { get; set; }

        [JsonProperty("base_experience")] public int base_experience { get; set; }

        [JsonProperty("forms")] public List<Form> forms { get; set; }

        [JsonProperty("game_indices")] public List<GameIndex> game_indices { get; set; }

        [JsonProperty("height")] public int height { get; set; }

        [JsonProperty("held_items")] public List<HeldItem> held_items { get; set; }

        [JsonProperty("id")] public int id { get; set; }

        [JsonProperty("is_default")] public bool is_default { get; set; }

        [JsonProperty("location_area_encounters")]
        public string location_area_encounters { get; set; }

        [JsonProperty("moves")] public List<Move> moves { get; set; }

        [JsonProperty("name")] public string name { get; set; }

        [JsonProperty("order")] public int order { get; set; }

        [JsonProperty("past_types")] public List<object> past_types { get; set; }

        [JsonProperty("species")] public Species species { get; set; }

        [JsonProperty("sprites")] public Sprites sprites { get; set; }

        [JsonProperty("stats")] public List<Stat> stats { get; set; }

        [JsonProperty("types")] public List<Type> types { get; set; }

        [JsonProperty("weight")] public int weight { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class Ability
    {
        [JsonProperty("ability")] public Ability ability { get; set; }

        [JsonProperty("is_hidden")] public bool is_hidden { get; set; }

        [JsonProperty("slot")] public int slot { get; set; }
    }

    public class Ability2
    {
        [JsonProperty("name")] public string name { get; set; }

        [JsonProperty("url")] public string url { get; set; }
    }

    public class Animated
    {
        [JsonProperty("back_default")] public string back_default { get; set; }

        [JsonProperty("back_female")] public object back_female { get; set; }

        [JsonProperty("back_shiny")] public string back_shiny { get; set; }

        [JsonProperty("back_shiny_female")] public object back_shiny_female { get; set; }

        [JsonProperty("front_default")] public string front_default { get; set; }

        [JsonProperty("front_female")] public object front_female { get; set; }

        [JsonProperty("front_shiny")] public string front_shiny { get; set; }

        [JsonProperty("front_shiny_female")] public object front_shiny_female { get; set; }
    }

    public class Form
    {
        [JsonProperty("name")] public string name { get; set; }

        [JsonProperty("url")] public string url { get; set; }
    }

    public class GameIndex
    {
        [JsonProperty("game_index")] public int game_index { get; set; }

        [JsonProperty("version")] public Version version { get; set; }
    }

    public class GenerationI
    {
        [JsonProperty("red-blue")] public RedBlue redblue { get; set; }

        [JsonProperty("yellow")] public Yellow yellow { get; set; }
    }

    public class HeldItem
    {
        [JsonProperty("item")] public Item item { get; set; }

        [JsonProperty("version_details")] public List<VersionDetail> version_details { get; set; }
    }

    public class Home
    {
        [JsonProperty("front_default")] public string front_default { get; set; }

        [JsonProperty("front_female")] public object front_female { get; set; }

        [JsonProperty("front_shiny")] public string front_shiny { get; set; }

        [JsonProperty("front_shiny_female")] public object front_shiny_female { get; set; }
    }

    public class Icons
    {
        [JsonProperty("front_default")] public string front_default { get; set; }

        [JsonProperty("front_female")] public object front_female { get; set; }
    }

    public class Item
    {
        [JsonProperty("name")] public string name { get; set; }

        [JsonProperty("url")] public string url { get; set; }
    }

    public class Move
    {
        [JsonProperty("move")] public Move move { get; set; }

        [JsonProperty("version_group_details")]
        public List<VersionGroupDetail> version_group_details { get; set; }
    }

    public class Move2
    {
        [JsonProperty("name")] public string name { get; set; }

        [JsonProperty("url")] public string url { get; set; }
    }

    public class MoveLearnMethod
    {
        [JsonProperty("name")] public string name { get; set; }

        [JsonProperty("url")] public string url { get; set; }
    }

    public class OfficialArtwork
    {
        [JsonProperty("front_default")] public string front_default { get; set; }

        [JsonProperty("front_shiny")] public string front_shiny { get; set; }
    }

    public class RedBlue
    {
        [JsonProperty("back_default")] public string back_default { get; set; }

        [JsonProperty("back_gray")] public string back_gray { get; set; }

        [JsonProperty("back_transparent")] public string back_transparent { get; set; }

        [JsonProperty("front_default")] public string front_default { get; set; }

        [JsonProperty("front_gray")] public string front_gray { get; set; }

        [JsonProperty("front_transparent")] public string front_transparent { get; set; }
    }

    public class Yellow
    {
        [JsonProperty("back_default")] public string back_default { get; set; }

        [JsonProperty("back_gray")] public string back_gray { get; set; }

        [JsonProperty("back_transparent")] public string back_transparent { get; set; }

        [JsonProperty("front_default")] public string front_default { get; set; }

        [JsonProperty("front_gray")] public string front_gray { get; set; }

        [JsonProperty("front_transparent")] public string front_transparent { get; set; }
    }
    public class Species
    {
        [JsonProperty("name")] public string name { get; set; }

        [JsonProperty("url")] public string url { get; set; }
    }

    public class Sprites
    {
        [JsonProperty("back_default")] public string back_default { get; set; }

        [JsonProperty("back_female")] public object back_female { get; set; }

        [JsonProperty("back_shiny")] public string back_shiny { get; set; }

        [JsonProperty("back_shiny_female")] public object back_shiny_female { get; set; }

        [JsonProperty("front_default")] public string front_default { get; set; }

        [JsonProperty("front_female")] public object front_female { get; set; }

        [JsonProperty("front_shiny")] public string front_shiny { get; set; }

        [JsonProperty("front_shiny_female")] public object front_shiny_female { get; set; }
    }

    public class Stat
    {
        [JsonProperty("base_stat")] public int base_stat { get; set; }

        [JsonProperty("effort")] public int effort { get; set; }

        [JsonProperty("stat")] public Stat stat { get; set; }
    }

    public class Stat2
    {
        [JsonProperty("name")] public string name { get; set; }

        [JsonProperty("url")] public string url { get; set; }
    }

    public class Type
    {
        [JsonProperty("slot")] public int slot { get; set; }

        [JsonProperty("type")] public Type type { get; set; }
    }

    public class Type2
    {
        [JsonProperty("name")] public string name { get; set; }

        [JsonProperty("url")] public string url { get; set; }
    }

    public class Version
    {
        [JsonProperty("name")] public string name { get; set; }

        [JsonProperty("url")] public string url { get; set; }
    }

    public class VersionDetail
    {
        [JsonProperty("rarity")] public int rarity { get; set; }

        [JsonProperty("version")] public Version version { get; set; }
    }

    public class VersionGroup
    {
        [JsonProperty("name")] public string name { get; set; }

        [JsonProperty("url")] public string url { get; set; }
    }

    public class VersionGroupDetail
    {
        [JsonProperty("level_learned_at")] public int level_learned_at { get; set; }

        [JsonProperty("move_learn_method")] public MoveLearnMethod move_learn_method { get; set; }

        [JsonProperty("version_group")] public VersionGroup version_group { get; set; }
    }
}