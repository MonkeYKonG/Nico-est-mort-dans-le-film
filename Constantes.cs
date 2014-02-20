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
    class Const
    {
        const int x = 1600, y = 900;
        public const float Zoom = 3;

        public Vector2 Ecran
        {
            get { return new Vector2(x, y); }
        }
    }
}
