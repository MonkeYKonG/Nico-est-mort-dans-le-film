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
        /*Texture2D[] _map;
        Texture2D _corresp;
        Texture2D _tilesSet;*/

        int _map, _corresp, _tilesSet;
        Color[] _mapArray;
        Color[] _correspArray;
        List<List<List<int>>> _tab;

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

        public List<Rectangle> RectColli
        {
            get{return _rectColli;}
        }
        List<Rectangle> _rectColli;
        List<int> _tabColli;

        public Map() { }

        public void Initialize()
        {
            _tilesSize = Vector2.Zero;
            _nbTiles = Vector2.Zero;
            _tab = new List<List<List<int>>>();
            _tabColli = new List<int>();
            _rectColli = new List<Rectangle>();
            _map = 0;
            _corresp = 0;
            _tilesSet = 0;
            _mapArray = new Color[3];
        }

        #region Load

        public void LoadContent(int mapNumber)
        {
            _correspArray = new Color[Textures._textureCorresp.Width * Textures._textureCorresp.Height];
            Textures._textureCorresp.GetData(_correspArray);

            genTabColli();
            Generate();
        }

        public void LoadMap(int mapNumber)
        {
            _map = mapNumber;

            Generate();
        }

        public void LoadTileSet(int mapNumber, int tileSetNumber)
        {
            _map = mapNumber;
            _tilesSet = tileSetNumber;

            genTabColli();
            Generate();
        }

        private void genTabColli()
        {
            _tabColli.Clear();
            string[] line = System.IO.File.ReadAllLines(@"C:\Users\epita\Desktop\Progra\Projet\Projet epita\Projet epita\Projet epitaContent\Murs\Mur1.txt");
            foreach (string numb in line)
                _tabColli.Add(Convert.ToInt32(numb));
        }

        #endregion

        public void Draw1(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < _tab[0].Count; i++)
            {
                for (int j = 0; j < _tab[0][i].Count; j++)
                {
                    if (_tab[0][i][j] != -1)
                        spriteBatch.Draw(Textures._texturesTileSet[_tilesSet],
                            new Vector2(j * _tilesSize.X * Const.Zoom, i * _tilesSize.Y * Const.Zoom),
                            new Rectangle((int)(_tab[0][i][j] % _nbTiles.X * _tilesSize.X), (int)((int)(_tab[0][i][j] / _nbTiles.Y) * _tilesSize.Y), (int)_tilesSize.X, (int)_tilesSize.Y),
                            Color.White, 0, Vector2.Zero, Const.Zoom, new SpriteEffects(), 1);
                }
            }
        }

        public void Draw2(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < _tab[1].Count; i++)
            {
                for (int j = 0; j < _tab[1][i].Count; j++)
                {
                    if (_tab[1][i][j] != -1)
                        spriteBatch.Draw(Textures._texturesTileSet[_tilesSet],
                            new Vector2(j * _tilesSize.X * Const.Zoom, i * _tilesSize.Y * Const.Zoom),
                            new Rectangle((int)(_tab[1][i][j] % _nbTiles.X * _tilesSize.X), (int)((int)(_tab[1][i][j] / _nbTiles.Y) * _tilesSize.Y), (int)_tilesSize.X, (int)_tilesSize.Y),
                            Color.White, 0, Vector2.Zero, Const.Zoom, new SpriteEffects(), 1);
                }
            }
        }

        public void Draw3(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < _tab[2].Count; i++)
            {
                for (int j = 0; j < _tab[2][i].Count; j++)
                {
                    if (_tab[2][i][j] != -1)
                        spriteBatch.Draw(Textures._texturesTileSet[_tilesSet],
                            new Vector2(j * _tilesSize.X * Const.Zoom, i * _tilesSize.Y * Const.Zoom),
                            new Rectangle((int)(_tab[2][i][j] % _nbTiles.X * _tilesSize.X), (int)((int)(_tab[2][i][j] / _nbTiles.Y) * _tilesSize.Y), (int)_tilesSize.X, (int)_tilesSize.Y),
                            Color.White, 0, Vector2.Zero, Const.Zoom, new SpriteEffects(), 1);
                }
            }
        }

        private void Generate() 
        {
            _tab.Clear();
            _rectColli.Clear();

            for (int l = 0; l < 3; l++)
            {
                _mapArray = new Color[Textures._texturesMap[_map][0].Width * Textures._texturesMap[_map][0].Height];
                Textures._texturesMap[_map][l].GetData(_mapArray);
                _tab.Add(new List<List<int>>());
                for (int i = 0; i < Textures._texturesMap[_map][0].Height; i++)
                {
                    _tab[l].Add(new List<int>());

                    for (int j = 0; j < Textures._texturesMap[_map][0].Width; j++)
                    {
                        bool ok = false;
                        for (int k = 0; k < _correspArray.Length; k++)
                        {
                            if (_mapArray[i * Textures._texturesMap[_map][0].Width + j] == _correspArray[k])
                            {
                                if (_tabColli.Contains(k))
                                    _rectColli.Add(new Rectangle(j * (int)_tilesSize.X, i * (int)_tilesSize.Y, 32, 32));
                                _tab[l][i].Add(k);
                                ok = true;
                                break;
                            }
                            else if (_mapArray[i * Textures._texturesMap[_map][0].Width + j] == Color.White)
                            {
                                _tab[l][i].Add(-1);
                                ok = true;
                                break;
                            }
                        }
                        if (!ok)
                            _tab[l][i].Add(-1);
                    }
                }
            }
        }
    }
}
