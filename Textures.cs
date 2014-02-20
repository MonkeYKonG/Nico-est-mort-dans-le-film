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
    static class Textures
    {
        public static Texture2D _textureCorresp;
        public static List<Texture2D> _texturesTileSet;
        public static List<Texture2D[]> _texturesMap;
        public static List<Texture2D> _textureEnnemies;
        public static List<Texture2D> _textureBoss;
        public static Texture2D _textureCharacter;

        public static void Initialize()
        {
            _texturesTileSet = new List<Texture2D>();
            _texturesMap = new List<Texture2D[]>();
            _textureEnnemies = new List<Texture2D>();
            _textureBoss = new List<Texture2D>();
        }

        public static void LoadContent(ContentManager cm)
        {
            _textureCorresp = cm.Load<Texture2D>("Textures/corresp");
            _textureCharacter = cm.Load<Texture2D>("Textures/Image1");
            _texturesTileSet.Add(cm.Load<Texture2D>("Textures/tileSet1"));
            _textureEnnemies.Add(cm.Load<Texture2D>("Textures/zombie"));
            _texturesMap.Add(new Texture2D[3]);
            for (int i = 1; i < 2; i++)
			{
			    for (int j = 0; j < 3; j++)
			    {
			            _texturesMap[i][j]=cm.Load<Texture2D>("Textures/map"+i+j);
			    }
			}
        }
    }
}
