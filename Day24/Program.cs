using System;
using System.Collections.Generic;
using System.Linq;

namespace Day24
{
    class Program
    {
        static void Main(string[] args)
        {
            var testData = @"C:\JM\Stuff\Advent of Code 2020\Day24\TestData.txt";
            var data = @"C:\JM\Stuff\Advent of Code 2020\Day24\Data.txt";

            var reader = new TileNavigationReader();
            //var stepList = reader.ReadSteps(testData);
            var stepList = reader.ReadSteps(data);

            //var steps = reader.ReadLine("esew");
            //var steps = reader.ReadLine("nwwswee");
            //var steps = reader.ReadLine("sesenwnenenewseeswwswswwnenewsewsw");

            var tileMap = new TileMap();
            var referencePosition = tileMap.AddTile(new AxialCoordinate(0, 0, 0));

            //
            // Part one
            //
            foreach (var steps in stepList)
            {
                AxialCoordinate position = referencePosition.Position;
                for (int n = 0; n < steps.Count; n++)
                {
                    var step = steps[n];

                    var nextPosition = position.Move(step);
                    var finalStep = (n == steps.Count - 1);

                    // only add tiles as we navigate to them
                    if (!tileMap.ContainsTile(nextPosition))
                    {
                        tileMap.AddTile(nextPosition);
                    }

                    if (finalStep)
                    {
                        // found the last step, so flip this tile
                        var tileToFlip = tileMap.GetTile(nextPosition);
                        tileToFlip.FlipTile();

                        Console.WriteLine($"Moving in direction {step,2}: from {position} to {nextPosition}; flipped final tile ({tileToFlip.FlipCount}, {tileToFlip.Colour})");
                    }
                    else
                    {
                        Console.WriteLine($"Moving in direction {step,2}: from {position} to {nextPosition}");
                    }

                    position = nextPosition;
                }
            }

            var blackTiles = tileMap.CountTiles("black"); // 500
            var whiteTiles = tileMap.CountTiles("white"); // 443

            Console.WriteLine($"{tileMap.Count} tiles: {blackTiles} black tile(s), {whiteTiles} white tile(s)");

            //
            // Part two (slow)
            //
            //for (int day = 1; day <= 100; day++)
            //{
            //    var tilesToBeFlipped = new List<Tile>();

            //    var min = tileMap.Min;
            //    var max = tileMap.Max;

            //    for (int x = min.X - 1; x <= max.X + 1; x++)
            //    {
            //        for (int y = min.Y - 1; y <= max.Y + 1; y++)
            //        {
            //            for (int z = min.Z - 1; z <= max.Z + 1; z++)
            //            {
            //                var pos = new AxialCoordinate(x, y, z);

            //                if (!tileMap.ContainsTile(pos))
            //                {
            //                    tileMap.AddTile(pos);
            //                }

            //                var tile = tileMap.GetTile(pos);

            //                var adjacentTilesPositions = tileMap.GetAdjacentTilePositions(pos);
            //                // ensure we have tiles for these positions
            //                foreach (var adjacentPosition in adjacentTilesPositions)
            //                {
            //                    if (!tileMap.ContainsTile(adjacentPosition))
            //                    {
            //                        tileMap.AddTile(adjacentPosition);
            //                    }
            //                }

            //                var adjacentTiles = tileMap.GetAdjacentTiles(pos);

            //                var adjacentBlackTileCount = adjacentTiles.Count(a => a.Colour == "black");

            //                if (tile.Colour == "black")
            //                {
            //                    if (adjacentBlackTileCount == 0 || adjacentBlackTileCount > 2)
            //                    {
            //                        tilesToBeFlipped.Add(tile); // flip the tile with adjacent tiles, not flip the adjacent tiles
            //                    }
            //                }
            //                else
            //                {
            //                    // white
            //                    if (adjacentBlackTileCount == 2)
            //                    {
            //                        tilesToBeFlipped.Add(tile);
            //                    }
            //                }
            //            }
            //        }
            //    }

            //    foreach (var t in tilesToBeFlipped)
            //    {
            //        t.FlipTile();
            //    }

            //    Console.WriteLine($"Day {day,3} : flip {tilesToBeFlipped.Count}, black {tileMap.Tiles.Count(x => x.Colour == "black")}, count {tileMap.Count}");
            //}

            for (int day = 1; day <= 100; day++)
            {
                var tilesToBeFlipped = new List<Tile>();

                var min = tileMap.Min;
                var max = tileMap.Max;

                // allow 1 additional value in coordinates to cover adjacent tiles of tiles within map
                for (int x = min.X - 1; x <= max.X + 1; x++)
                {
                    for (int y = min.Y - 1; y <= max.Y + 1; y++)
                    {
                        for (int z = min.Z - 1; z <= max.Z + 1; z++)
                        {
                            var pos = new AxialCoordinate(x, y, z);

                            Tile tile = null;
                            bool isNewTile = false;
                            if (tileMap.ContainsTile(pos))
                            {
                                tile = tileMap.GetTile(pos);
                            }
                            else
                            {
                                // new tile (white)
                                tile = new Tile(pos);
                                isNewTile = true;
                            }

                            var adjacentTilePositions = pos.GetNeighbours();

                            var adjacentBlackTileCount = adjacentTilePositions.Count(a => tileMap.ContainsTile(a) && tileMap[a].Colour == "black");

                            if (tile.Colour == "black")
                            {
                                if (adjacentBlackTileCount == 0 || adjacentBlackTileCount > 2)
                                {
                                    tilesToBeFlipped.Add(tile); // flip the tile with adjacent tiles, not flip the adjacent tiles
                                }
                            }
                            else
                            {
                                // white
                                if (adjacentBlackTileCount == 2)
                                {
                                    tilesToBeFlipped.Add(tile);

                                    if (isNewTile) // only add the new tile to the map if we will flip the tile (perf)
                                    {
                                        tileMap.AddTile(tile);
                                    }
                                }
                            }
                        }
                    }
                }

                tilesToBeFlipped.ForEach(t => t.FlipTile());

                // 4280 after 100 days
                Console.WriteLine($"Day {day,3} : flip {tilesToBeFlipped.Count}, black {tileMap.Tiles.Count(x => x.Colour == "black")}, count {tileMap.Count}");
            }
        }
    }
}
