using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PokemonWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonWebApi.Data
{
    public class PSeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new PokemonContext(
                serviceProvider.GetRequiredService<DbContextOptions<PokemonContext>>()))
            {
                if (!context.Region.Any())
                {
                    context.Region.AddRange(
                        new Region
                        {
                            RegionName = "Kanto"
                        },

                        new Region
                        {
                            RegionName = "Jhoto"
                        },

                        new Region
                        {
                            RegionName = "Hoenn"
                        },
                        /* Commented out for less code, this still works of course.
                        new Region
                        {
                            RegionName = "Sinnoh"
                        },

                        new Region
                        {
                            RegionName = "Unova"
                        },

                        new Region
                        {
                            RegionName = "Kalos"
                        },

                        new Region
                        {
                            RegionName = "Alola"
                        },
                        */
                        new Region
                        {
                            RegionName = "Misc."
                        });
                    context.SaveChanges();
                }

                if (!context.Route.Any())
                {
                    context.Route.AddRange(
                        /******************Non-traditional Methods******************/

                        new Route
                        {
                            RouteName = "Unavailable",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Misc.").ID
                        },

                        new Route
                        {
                            RouteName = "Requires Trade",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Misc.").ID
                        },

                        new Route
                        {
                            RouteName = "Special Event",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Misc.").ID
                        },

                        new Route
                        {
                            RouteName = "Requires Game Completion",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Misc.").ID
                        },

                        new Route
                        {
                            RouteName = "Starter",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Misc.").ID
                        },

                        new Route
                        {
                            RouteName = "Evolution",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Misc.").ID
                        },

                        new Route
                        {
                            RouteName = "Safari Zone",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Misc.").ID
                        },

                        /******************Kanto Routes******************/

                        new Route
                        {
                            RouteName = "Route 1",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 2",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 3",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 4",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 5",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 6",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 7",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 8",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 9",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 10",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 11",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 12",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 13",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 14",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 15",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 16",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 17",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 18",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 19",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 20",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 21",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 22",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 23",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 24",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 25",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 26",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 27",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 28",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Kanto").ID
                        },

                        /******************Jhoto Routes******************/

                        new Route
                        {
                            RouteName = "Route 29",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 30",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 31",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 32",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 33",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 34",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 35",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 36",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 37",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 38",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 39",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 40",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 41",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 42",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 43",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 44",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 45",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 46",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 47",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        new Route
                        {
                            RouteName = "Route 48",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Jhoto").ID
                        },

                        /******************Hoenn Routes******************/

                        new Route
                        {
                            RouteName = "Route 101",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 102",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 103",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 104",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 105",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 106",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 107",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 108",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 109",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 110",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 111",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 112",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 113",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 114",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 115",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 116",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 117",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 118",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 119",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 120",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 121",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 122",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 123",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 124",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 125",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 126",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 127",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 128",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 129",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 130",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 131",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 132",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 133",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        },

                        new Route
                        {
                            RouteName = "Route 134",
                            RegionID = context.Region.FirstOrDefault(g => g.RegionName == "Hoenn").ID
                        }

                        );
                    context.SaveChanges();
                }

                if (!context.Types.Any())
                {
                    context.Types.AddRange(
                        /****FIRE****/
                        new Types
                        {
                            TypeName = "Fire",
                            TypeOne = "Fire"
                        },
                        /***FIRE DUAL TYPES***/
                        new Types
                        {
                            TypeName = "Fire-Water",
                            TypeOne = "Fire",
                            TypeTwo = "Water"
                        },

                        new Types
                        {
                            TypeName = "Fire-Electric",
                            TypeOne = "Fire",
                            TypeTwo = "Electric"
                        },

                        new Types
                        {
                            TypeName = "Fire-Psychic",
                            TypeOne = "Fire",
                            TypeTwo = "Psychic"
                        },

                        new Types
                        {
                            TypeName = "Fire-Dragon",
                            TypeOne = "Fire",
                            TypeTwo = "Dragon"
                        },

                        new Types
                        {
                            TypeName = "Fire-Dark",
                            TypeOne = "Fire",
                            TypeTwo = "Dark"
                        },

                        /****WATER****/
                        new Types
                        {
                            TypeName = "Water",
                            TypeOne = "Water"
                        },
                        /***WATER DUAL TYPES***/
                        new Types
                        {
                            TypeName = "Water-Grass",
                            TypeOne = "Water",
                            TypeTwo = "Grass"
                        },

                        new Types
                        {
                            TypeName = "Water-Electric",
                            TypeOne = "Water",
                            TypeTwo = "Electric"
                        },

                        new Types
                        {
                            TypeName = "Water-Psychic",
                            TypeOne = "Water",
                            TypeTwo = "Psychic"
                        },

                        new Types
                        {
                            TypeName = "Water-Ice",
                            TypeOne = "Water",
                            TypeTwo = "Ice"
                        },

                        new Types
                        {
                            TypeName = "Water-Dragon",
                            TypeOne = "Water",
                            TypeTwo = "Dragon"
                        },

                        new Types
                        {
                            TypeName = "Water-Dark",
                            TypeOne = "Water",
                            TypeTwo = "Dark"
                        },

                        new Types
                        {
                            TypeName = "Water-Fairy",
                            TypeOne = "Water",
                            TypeTwo = "Fairy"
                        },

                        /****GRASS****/
                        new Types
                        {
                            TypeName = "Grass",
                            TypeOne = "Grass"
                        },
                        /***GRASS DUAL TYPES***/
                        new Types
                        {
                            TypeName = "Grass-Poison",
                            TypeOne = "Grass",
                            TypeTwo = "Poison"
                        },

                        /****ELECTRIC****/
                        new Types
                        {
                            TypeName = "Electric",
                            TypeOne = "Electric"
                        },
                        /****PSYCHIC****/
                        new Types
                        {
                            TypeName = "Psychic",
                            TypeOne = "Psychic"
                        },
                        /***PSYCHIC DUAL TYPES***/
                        new Types
                        {
                            TypeName = "Psychic-Flying",
                            TypeOne = "Psychic",
                            TypeTwo = "Flying"
                        },

                        new Types
                        {
                            TypeName = "Psychic-Grass",
                            TypeOne = "Psychic",
                            TypeTwo = "Grass"
                        },

                        new Types
                        {
                            TypeName = "Psychic-Fairy",
                            TypeOne = "Psychic",
                            TypeTwo = "Fairy"
                        },

                        /****ICE****/
                        new Types
                        {
                            TypeName = "Ice",
                            TypeOne = "Ice"
                        },
                        /***ICE DUAL TYPES***/
                        new Types
                        {
                            TypeName = "Ice-Ghost",
                            TypeOne = "Ice",
                            TypeTwo = "Ghost"
                        },

                        /****DRAGON****/
                        new Types
                        {
                            TypeName = "Dragon",
                            TypeOne = "Dragon"
                        },
                        /****DARK****/
                        new Types
                        {
                            TypeName = "Dark",
                            TypeOne = "Dark"
                        },
                        /****FAIRY****/
                        new Types
                        {
                            TypeName = "Fairy",
                            TypeOne = "Fairy"
                        },
                        /****NORMAL****/
                        new Types
                        {
                            TypeName = "Normal",
                            TypeOne = "Normal"
                        },
                        /***NORMAL DUAL TYPES***/
                        new Types
                        {
                            TypeName = "Normal-Fighting",
                            TypeOne = "Normal",
                            TypeTwo = "Fighting",
                        },

                        new Types
                        {
                            TypeName = "Normal-Flying",
                            TypeOne = "Normal",
                            TypeTwo = "Flying"
                        },

                        new Types
                        {
                            TypeName = "Normal-Ground",
                            TypeOne = "Normal",
                            TypeTwo = "Ground"
                        },

                        new Types
                        {
                            TypeName = "Normal-Fire",
                            TypeOne = "Normal",
                            TypeTwo = "Fire"
                        },

                        new Types
                        {
                            TypeName = "Normal-Water",
                            TypeOne = "Normal",
                            TypeTwo = "Water"
                        },

                        new Types
                        {
                            TypeName = "Normal-Grass",
                            TypeOne = "Normal",
                            TypeTwo = "Grass"
                        },

                        new Types
                        {
                            TypeName = "Normal-Electric",
                            TypeOne = "Normal",
                            TypeTwo = "Electric"
                        },

                        new Types
                        {
                            TypeName = "Normal-Psychic",
                            TypeOne = "Normal",
                            TypeTwo = "Psychic"
                        },

                        new Types
                        {
                            TypeName = "Normal-Dragon",
                            TypeOne = "Normal",
                            TypeTwo = "Dragon"
                        },

                        new Types
                        {
                            TypeName = "Normal-Dark",
                            TypeOne = "Normal",
                            TypeTwo = "Dark"
                        },

                        new Types
                        {
                            TypeName = "Normal-Fairy",
                            TypeOne = "Normal",
                            TypeTwo = "Fairy"
                        },

                        /****FIGHTING****/
                        new Types
                        {
                            TypeName = "Fighting",
                            TypeOne = "Fighting"
                        },
                        /***FIGHTING DUAL TYPES***/
                        /****FLYING****/
                        new Types
                        {
                            TypeName = "Flying",
                            TypeOne = "Flying"
                        },
                        /****POISON****/
                        new Types
                        {
                            TypeName = "Poison",
                            TypeOne = "Poison"
                        },
                        /****GROUND****/
                        new Types
                        {
                            TypeName = "Ground",
                            TypeOne = "Ground"
                        },
                        /****ROCK****/
                        new Types
                        {
                            TypeName = "Rock",
                            TypeOne = "Rock"
                        },
                        /***ROCK DUAL TYPES***/
                        new Types
                        {
                            TypeName = "Rock-Dark",
                            TypeOne = "Rock",
                            TypeTwo = "Dark"
                        },

                        /****BUG****/
                        new Types
                        {
                            TypeName = "Bug",
                            TypeOne = "Bug"
                        },
                        /***BUG DUAL TYPES***/
                        new Types
                        {
                            TypeName = "Bug-Ghost",
                            TypeOne = "Bug",
                            TypeTwo = "Ghost"
                        },

                        new Types
                        {
                            TypeName = "Bug-Rock",
                            TypeOne = "Bug",
                            TypeTwo = "Rock"
                        },

                        /****GHOST****/
                        new Types
                        {
                            TypeName = "Ghost",
                            TypeOne = "Ghost"
                        },

                        /****STEEL****/
                        new Types
                        {
                            TypeName = "Steel",
                            TypeOne = "Steel"
                        },
                        /***STEEL DUAL TYPES***/
                        new Types
                        {
                            TypeName = "Steel-Rock",
                            TypeOne = "Steel",
                            TypeTwo = "Rock"
                        },

                        new Types
                        {
                            TypeName = "Steel-Psychic",
                            TypeOne = "Steel",
                            TypeTwo = "Psychic"
                        });
                    context.SaveChanges();
                }

                if (!context.Pokemon.Any())
                {
                    context.Pokemon.AddRange(
                        new Pokemon
                        {
                            Name = "Bulbasaur",
                            Number = 1,
                            Description = "A strange seed was planted on its back at birth. The plant sprouts and grows with this pokemon.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Grass-Poison").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Starter").ID

                        },

                        new Pokemon
                        {
                            Name = "Ivysaur",
                            Number = 2,
                            Description = "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Grass-Poison").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Evolution").ID
                        },

                        new Pokemon
                        {
                            Name = "Tyranitar",
                            Number = 248,
                            Description = "Its body can't be harmed by any sort of attack, so it is very eager to make challenges against enemies.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Rock-Dark").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Evolution").ID
                        },

                        new Pokemon
                        {
                            Name = "Shedinja",
                            Number = 292,
                            Description = "A Peculiar Pokemon that floats in air even though its wings remain completely still. The inside of its body is hollow and utterly dark",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Bug-Ghost").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Evolution").ID,
                        },

                        new Pokemon
                        {
                            Name = "Snorunt",
                            Number = 361,
                            Description = "They tend to move about in groups of around five Snorunt. In snowy regions, it is said that when they are seen late at night, snow fall will arrive by morning.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Ice").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Route 125").ID,
                        },

                        new Pokemon
                        {
                            Name = "Metagross",
                            Number = 376,
                            Description = "Metagross has four brains that are joined by a complex neural network. As a result of integration, this Pokemon is smarter than a supercomputer.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Steel-Psychic").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Evolution").ID,
                        },

                        new Pokemon
                        {
                            Name = "Sudowoodo",
                            Number = 185,
                            Description = "It mimics a tree to avoid being attacked by enemies. But since its forelegs remain green throughout the year, it is easily identified as a fake in the winter.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Rock").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Route 36").ID,
                        },

                        new Pokemon
                        {
                            Name = "Sunflora",
                            Number = 192,
                            Description = "Sunflora converts solar energy intro nutrtion. They are highly active in the warm daytime but suddenly stop moving as soon as the sun sets.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Grass").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Evolution").ID,
                        },

                        new Pokemon
                        {
                            Name = "Caterpie",
                            Number = 10,
                            Description = "Its voracious appetite compels it to devour leaves bigger than itself without hesitation. It releases a terribly strong odor from its antennae.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Bug").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Route 25").ID,
                        },

                        new Pokemon
                        {
                            Name = "Wailmer",
                            Number = 320,
                            Description = "While this Pokemon usually lives in the sea, it can survive on land, although not too long. It loses vitality if its body becomes dried out.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Water").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Route 103").ID,
                        },

                        new Pokemon
                        {
                            Name = "Jirachi",
                            Number = 385,
                            Description = "Jirachi is said to make wishes come true. While it sleeps, a tough crystaline shell envelops the body to protect it from enemies.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Psychic").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Special Event").ID,
                        },

                        new Pokemon
                        {
                            Name = "Alakazam",
                            Number = 65,
                            Description = "While it has strong psychic abilities and high intelligence, an Alakazams muscles are very weak. It uses psychic power to move its body.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Psychic").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Evolution").ID,
                        },

                        new Pokemon
                        {
                            Name = "Feebas",
                            Number = 349,
                            Description = "Feebas live in ponds that are heavily infested with weeds. Because of its hopelessly shabby appearance, it seems as if few trainers raise it.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Water").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Route 119").ID,
                        },
                        new Pokemon
                        {
                            Name = "Venusaur",
                            Number = 3,
                            Description = "Veenusaur's flower is said to take on vivid colours if it gets plenty of nutrition and sunlight. The flower's aroma soothes the emotions of people.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Grass-Poison").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Evolution").ID
                        },

                        new Pokemon
                        {
                            Name = "Abra",
                            Number = 63,
                            Description = "A Pokemon that sleeps 18 hours a day. Observation revealed that it uses Teleport to change its location once every hour.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Psychic").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Route 24").ID
                        },

                        new Pokemon
                        {
                            Name = "Mew",
                            Number = 151,
                            Description = "A Mew is said to possess the genes of all Pokemon. It is capable of making itself invisible at will, so it entirely avoids notice even if it approaches people.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Psychic").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Special Event").ID
                        },

                        new Pokemon
                        {
                            Name = "Natu",
                            Number = 177,
                            Description = "It runs up short trees that grow on the savanna to peck at new shoots. A Natu's eyes look as if they are always observing something.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Psychic-Flying").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Route 36").ID
                        },

                        new Pokemon
                        {
                            Name = "Shuckle",
                            Number = 213,
                            Description = "A Shuckle hides under rocks, keeping its body concealed inside its shell while eating stored berries. The berries mix with its body fluids to become a juice.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Bug-Rock").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Route 40").ID
                        },

                        new Pokemon
                        {
                            Name = "Celebi",
                            Number = 251,
                            Description = "This Pokemon came from the future by crossing over time. It is thought that so long as Celebi appears, a bright and shining future awats us.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Psychic-Grass").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Special Event").ID
                        },

                        new Pokemon
                        {
                            Name = "Mudkip",
                            Number = 258,
                            Description = "On land, it can powerfully lift boulders by planting its four feet and heaving. It sleeps by burying istelf in soil at the water's edge.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Water").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Starter").ID
                        },

                        new Pokemon
                        {
                            Name = "Ralts",
                            Number = 280,
                            Description = "A Ralts has the power to sense the emotions of people and Poekmon with the horns on its head. It takes cover if it senses any hostility.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Psychic-Fairy").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Route 102").ID
                        },

                        new Pokemon
                        {
                            Name = "Aron",
                            Number = 304,
                            Description = "A Pokemon that is clad in steel armour. A new suit of armour is made when it evolves. The old, discarded armour is salvaged as metal for making iron products.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Steel-Rock").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Route 106").ID
                        },

                        new Pokemon
                        {
                            Name = "Froslass",
                            Number = 478,
                            Description = "Legends in snowy regions say that a woman who was lost on an icy mountain was reborn as Froslass",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Ice-Ghost").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Evolution").ID
                        },

                        new Pokemon
                        {
                            Name = "Milotic",
                            Number = 350,
                            Description = "It is said to live at the bottom of large lakes. Considered to be the most beautiful of all Pokemon, it has been depicted in paintings and statues.",
                            TypesID = context.Types.FirstOrDefault(t => t.TypeName == "Water").ID,
                            RouteID = context.Route.FirstOrDefault(r => r.RouteName == "Evolution").ID
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
