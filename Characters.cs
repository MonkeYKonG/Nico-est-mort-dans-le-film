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
    class Character : Sprite
    {
        /* Respecte les régions donnés
         * ce n'est pas grâve si elle reste vide
         * Tu va devoire implementer les methodes
         * de la region *Rollement de tambour*
         * "Methodes" et oui! Bonne chane
         */


        #region Attributs

        int _frameCount;

        #endregion Attributs

        #region Constructeur / Initialisation

        public override void Initialize()
        {
            MaxSpeed = 0.1f;
            base.Initialize();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    SubRects.Add(new Rectangle(j * 64, i * 64, 64, 64));
                }
            }
            _frameCount = 0;
        }

        #endregion

        #region Methodes

        public override void HandleInput(GameTime gameTime)
        {
            // FIXME : Recupère les entrer du jouer avec inputs
            // Grace à cela gere son déplacement avec ces attributs
            // Deplacement et Speed
            // Deplacement est un Vector2 si tu ne sais aps ce que c'est
            // va te renseigner dessus sur internet c'est facile tu va voire
            // Speed un float
            // quand le personnage s'arrète met le speed à 0 ne modifie pas
            // la direction. 
            // Bonus héhé crée un acceleration au personnage hahaha
            // On a vue comment faire en physique :D

            if (InputsManager.IsPressed(Keys.W) || InputsManager.IsPressed(Keys.Up))
            {
                Direction = -Vector2.UnitY;
                Speed = MaxSpeed;
                base.Update(gameTime);
            }
            else if (InputsManager.IsPressed(Keys.S) || InputsManager.IsPressed(Keys.Down))
            {
                Direction = Vector2.UnitY;
                Speed = MaxSpeed;
                base.Update(gameTime);
            }
            else Speed = 0;

            if (InputsManager.IsPressed(Keys.A) || InputsManager.IsPressed(Keys.Left))
            {
                Direction = -Vector2.UnitX;
                Speed = MaxSpeed;
                base.Update(gameTime);
            }
            else if (InputsManager.IsPressed(Keys.D) || InputsManager.IsPressed(Keys.Right))
            {
                Direction = Vector2.UnitX;
                Speed = MaxSpeed;
                base.Update(gameTime);
            }
            else Speed = 0;


            base.HandleInput();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            spriteBatch.Draw(Textures._textureCharacter, Position, SubRects[_anim], Color.White, 0, new Vector2(1, 1), 1, new SpriteEffects(), 0);

            //Supprime cette ligne quant tu auras fini l'autre

        }
        public void Update(GameTime gameTime)
        {
            double x = Position.X - InputsManager.X;
            double y = Position.Y - InputsManager.Y;
            double tangente = Math.Atan(x / y);
            Console.WriteLine(tangente);
            _frameCount = (_frameCount + 1) % 5;
            if (_frameCount == 0)
            {
                if (InputsManager.IsPressed(Keys.W) || InputsManager.IsPressed(Keys.Up) || InputsManager.IsPressed(Keys.S) || InputsManager.IsPressed(Keys.Down) || InputsManager.IsPressed(Keys.A) || InputsManager.IsPressed(Keys.Left) || InputsManager.IsPressed(Keys.D) || InputsManager.IsPressed(Keys.Right))
                {
                    if ((_anim + 1) % 8 == 0)
                    {
                        _anim = 1;
                    }
                    else
                    {
                        _anim = (_anim + 1) % 8;
                    }
                    if (InputsManager.IsPressed(Keys.W) || InputsManager.IsPressed(Keys.Up))
                    {
                        _anim = _anim;
                    }
                    else if (InputsManager.IsPressed(Keys.S) || InputsManager.IsPressed(Keys.Down))
                    {
                        _anim = _anim + 16;
                    }
                    else if (InputsManager.IsPressed(Keys.A) || InputsManager.IsPressed(Keys.Left))
                    {
                        _anim = _anim + 8;
                    }
                    else if (InputsManager.IsPressed(Keys.D) || InputsManager.IsPressed(Keys.Right))
                    {
                        _anim = _anim + 24;
                    }
                }
                else 
                { 
                
                
                }
            }

        }


        #endregion Methodes
    }
}
// float tangente = atan(largeur / hauteur);
// m_sprite.setRotation(-(tangente * 360) / (2 * M_PI) + 90);
