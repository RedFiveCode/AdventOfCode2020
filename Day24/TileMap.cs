using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    class TileMap
    {
        private Dictionary<AxialCoordinate, Tile> m_tiles;

        public TileMap()
        {
            m_tiles = new Dictionary<AxialCoordinate, Tile>();
        }

        public TileMap(Dictionary<AxialCoordinate, Tile> map)
        {
            m_tiles = map;
        }

        public bool ContainsTile(AxialCoordinate position)
        {
            return m_tiles.ContainsKey(position);
        }

        public Tile GetTile(AxialCoordinate position)
        {
            if (m_tiles.ContainsKey(position))
            {
                return m_tiles[position];
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public Tile this[AxialCoordinate pos]
        {
            get { return GetTile(pos);  }
        }

        public void AddTile(Tile tile)
        {
            if (m_tiles.ContainsKey(tile.Position))
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                m_tiles[tile.Position] = tile;
            }
        }
        public Tile AddTile(AxialCoordinate position)
        {
            if (m_tiles.ContainsKey(position))
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                var tile = new Tile(position);
                m_tiles[position] = tile;

                return tile;
            }
        }

        public List<AxialCoordinate> GetAdjacentTilePositions(AxialCoordinate position)
        {
            var tile = GetTile(position);

            return tile.GetNeighbours().ToList();
        }

        public List<Tile> GetAdjacentTiles(AxialCoordinate position)
        {
            var tile = GetTile(position);

            var adjacentTilesPositions = tile.GetNeighbours();

            return adjacentTilesPositions.Select(p => GetTile(p)).ToList();
        }

        public IEnumerable<Tile> Tiles
        {
            get { return m_tiles.Values; } 
        }

        public int CountTiles(string colour)
        {
            return m_tiles.Values.Count(t => t.Colour == colour);
        }

        public int Count
        {
            get { return m_tiles.Count; }
        }

        public AxialCoordinate Min
        {
            get
            {
                return new AxialCoordinate(m_tiles.Values.Min(p => p.Position.X),
                                           m_tiles.Values.Min(p => p.Position.Y),
                                           m_tiles.Values.Min(p => p.Position.Z));
            }
        }

        public AxialCoordinate Max
        {
            get
            {
                return new AxialCoordinate(m_tiles.Values.Max(p => p.Position.X),
                                            m_tiles.Values.Max(p => p.Position.Y),
                                            m_tiles.Values.Max(p => p.Position.Z));
            }
        }

        public void RemoveWhiteTiles()
        {
            var tilesToRemove = m_tiles.Where(kvp => kvp.Value.Colour == "white").Select(kvp => kvp.Key).ToList();

            tilesToRemove.ForEach(p => m_tiles.Remove(p));
        }
    }
}
