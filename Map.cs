using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Projet_epita
{
    /*
     * Cette classe est la classe principale du jeu, 
     * elle contiendra toutes les classe type Sprite
     * comme le personnage, les ennemis ou toutes
     * les conneries dans le genre
     */

    class Map
    {
        // Declaration des proprietes de la classe
        Texture2D[] _map;
        Texture2D _corresp;
        Texture2D _tilesSet;
        Color[] _mapArray;
        Color[] _correspArray;
        List<List<int>> _tab;

        public Vector2 NbTiles
        {
            get { return _nbTiles; }
            set { _nbTiles = value; }
        }
        Vector2 _nbTiles;

        public Vector2 TilesSize
        {
            get { return _tilesSize; }
            set { _tilesSize = value; }
        }
        Vector2 _tilesSize;

        public Map() { }

        public void Initialize()
        {
            _tilesSize = Vector2.Zero;
            _nbTiles = Vector2.Zero;
            _tab = new List<List<int>>();
            _map = new Texture2D[3];
        }

        #region Load

        public void LoadContent(ContentManager content, string mapName, string tileSetName)
        {
            for (int i = 0; i < 3; ++i)
                _map[i] = content.Load<Texture2D>("Textures/"+mapName + i);

            _corresp = content.Load<Texture2D>("Textures/corresp");
            _tilesSet = content.Load<Texture2D>("Textures/"+tileSetName);

            _correspArray = new Color[_corresp.Width * _corresp.Height];
            _corresp.GetData(_correspArray);
            Generate();
        }

        public void LoadMap(ContentManager content, string mapName)
        {
            for (int i = 0; i < 3; ++i)
                _map[i] = content.Load<Texture2D>(mapName + i);

            Generate();
        }

        public void LoadTileSet(ContentManager content, string mapName, string tileSetName)
        {
            for (int i = 0; i < 3; ++i)
                _map[i] = content.Load<Texture2D>(mapName + i);

            _tilesSet=content.Load<Texture2D>(tileSetName);
            Generate();
        }

        #endregion

        public void Draw1(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < _tab.Count; i++)
            {
                for (int j = 0; j < _tab[i].Count; j++)
                {
                    if (_tab[i][j] != -1)
                        spriteBatch.Draw(_tilesSet,
                            new Vector2(j * _tilesSize.X * Const.Zoom, i * _tilesSize.Y * Const.Zoom),
                            new Rectangle((int)(_tab[i][j] % _nbTiles.X * _tilesSize.X), (int)((int)(_tab[i][j] / _nbTiles.Y) * _tilesSize.Y), (int)_tilesSize.X, (int)_tilesSize.Y),
                            Color.White, 0, Vector2.Zero, Const.Zoom, new SpriteEffects(), 1);
                }
            }
        }

        public void Draw2(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < _tab.Count; i++)
            {
                for (int j = 0; j < _tab[i].Count; j++)
                {
                    if (_tab[i][j] != -1)
                        spriteBatch.Draw(_tilesSet,
                            new Vector2(j * _tilesSize.X * Const.Zoom, i * _tilesSize.Y * Const.Zoom),
                            new Rectangle((int)(_tab[i][j] % _nbTiles.X * _tilesSize.X), (int)((int)(_tab[i][j] / _nbTiles.Y) * _tilesSize.Y), (int)_tilesSize.X, (int)_tilesSize.Y),
                            Color.White, 0, Vector2.Zero, Const.Zoom, new SpriteEffects(), 1);
                }
            }
        }

        public void Draw3(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < _tab.Count; i++)
            {
                for (int j = 0; j < _tab[i].Count; j++)
                {
                    if (_tab[i][j] != -1)
                        spriteBatch.Draw(_tilesSet,
                            new Vector2(j * _tilesSize.X * Const.Zoom, i * _tilesSize.Y * Const.Zoom),
                            new Rectangle((int)(_tab[i][j] % _nbTiles.X * _tilesSize.X), (int)((int)(_tab[i][j] / _nbTiles.Y) * _tilesSize.Y), (int)_tilesSize.X, (int)_tilesSize.Y),
                            Color.White, 0, Vector2.Zero, Const.Zoom, new SpriteEffects(), 1);
                }
            }
        }

        private void Generate() 
        {
            _tab.Clear();
            _mapArray = new Color[_map[0].Width*_map[0].Height];
            _map[0].GetData(_mapArray);

            for (int i = 0; i < _map[0].Height; i++)
            {
                _tab.Add(new List<int>());

                for (int j = 0; j < _map[0].Width; j++)
                {
                    bool ok = false;
                    for (int k = 0; k < _correspArray.Length; k++)
                    {
                        if (_mapArray[i * _map[0].Width + j] == _correspArray[k])
                        {
                            _tab[i].Add(k);
                            ok = true;
                            break;
                        }
                        else if (_mapArray[i * _map[0].Width + j] == Color.White)
                        {
                            _tab[i].Add(-1);
                            ok = true;
                            break;
                        }
                    }
                    if (!ok)
                        _tab[i].Add(-1);
                }   
            }
            Console.WriteLine(_map[0].Width +" "+_map[0].Height);
        }
    }
}
