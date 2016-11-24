using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntryPoint
{
    public static class Program
    {
		static void Main()
		{
		    var fullscreen = false;
		    
		    Console.WriteLine("Enter number of simulation to run - [1 - 4, q]");
		    
		    while(true)
		    {
				switch(Console.ReadLine())
				{
				    case "1":
						using (var game = VirtualCity.RunAssignment1(SortSpecialBuildingsByDistance,
											     fullscreen))
						    game.Run();
						break;
					
				    case "2":
						using (var game = VirtualCity.RunAssignment2(FindSpecialBuildingsWithinDistanceFromHouse,
											     fullscreen))
						    game.Run();
						break;
					
				    case "3":
						using (var game = VirtualCity.RunAssignment3(FindRoute, fullscreen))
						    game.Run();
						break;
					
				    case "4":
						using (var game = VirtualCity.RunAssignment4(FindRoutesToAll, fullscreen))
						    game.Run();
						break;
					
				    case "q":
						return;
					
					default:
						Console.WriteLine ("Invalid input! Try again! - [1 - 4, q]");
						break;
				}
		    }
		}

		private static IEnumerable<Vector2> SortSpecialBuildingsByDistance(Vector2 house,
										   IEnumerable<Vector2> specialBuildings)
		{
		    return specialBuildings.OrderBy(v => Vector2.Distance(v, house));
		}

		private static IEnumerable<IEnumerable<Vector2>> FindSpecialBuildingsWithinDistanceFromHouse(IEnumerable<Vector2> specialBuildings, 
													     IEnumerable<Tuple<Vector2, float>> housesAndDistances)
		{
		    return
			from h in housesAndDistances
			select
			from s in specialBuildings
			where Vector2.Distance(h.Item1, s) <= h.Item2
			select s;
		}

		private static IEnumerable<Tuple<Vector2, Vector2>> FindRoute(Vector2 startingBuilding, 
									      Vector2 destinationBuilding,
									      IEnumerable<Tuple<Vector2, Vector2>> roads)
		{
		    var startingRoad = roads.Where(x => x.Item1.Equals(startingBuilding)).First();
		    List<Tuple<Vector2, Vector2>> fakeBestPath = new List<Tuple<Vector2, Vector2>>() { startingRoad };
		    var prevRoad = startingRoad;
		    for (int i = 0; i < 30; i++)
		    {
			prevRoad = (roads.Where(x => x.Item1.Equals(prevRoad.Item2)).OrderBy(x => Vector2.Distance(x.Item2, destinationBuilding)).First());
			fakeBestPath.Add(prevRoad);
		    }
		    return fakeBestPath;
		}

		private static IEnumerable<IEnumerable<Tuple<Vector2, Vector2>>> FindRoutesToAll(Vector2 startingBuilding, 
												 IEnumerable<Vector2> destinationBuildings,
												 IEnumerable<Tuple<Vector2,
												 Vector2>> roads)
		{
		    List<List<Tuple<Vector2, Vector2>>> result = new List<List<Tuple<Vector2, Vector2>>>();
		    foreach (var d in destinationBuildings)
		    {
			var startingRoad = roads.Where(x => x.Item1.Equals(startingBuilding)).First();
			List<Tuple<Vector2, Vector2>> fakeBestPath = new List<Tuple<Vector2, Vector2>>() { startingRoad };
			var prevRoad = startingRoad;
			for (int i = 0; i < 30; i++)
			{
			    prevRoad = (roads.Where(x => x.Item1.Equals(prevRoad.Item2)).OrderBy(x => Vector2.Distance(x.Item2, d)).First());
			    fakeBestPath.Add(prevRoad);
			}
			result.Add(fakeBestPath);
		    }
		    return result;
		}
    }
}
