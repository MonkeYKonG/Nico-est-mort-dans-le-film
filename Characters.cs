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
    class Character:Sprite
    {
        /* Respecte les régions donnés
         * ce n'est pas grâve si elle reste vide
         * Tu va devoire implementer les methodes
         * de la region *Rollement de tambour*
         * "Methodes" et oui! Bonne chane
         */
        

        #region Attributs

        int Nb_rect;

        #endregion Attributs

        #region Constructeur / Initialisation

        public override void Initialize()
        {
            MaxSpeed = 1;
            base.Initialize();
            SubRects.Add(new Rectangle(8,2,11,30));
            SubRects.Add(new Rectangle(44, 2, 10, 30));
            SubRects.Add(new Rectangle(81,2,6,30));
            SubRects.Add(new Rectangle(101,1,11,29));
            SubRects.Add(new Rectangle(137,1,10,29));
            SubRects.Add(new Rectangle(74, 1, 6, 29));
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
            // FIXME: Comme tu as du le remarquer, le personnage
            // est afficher de manère ... tu m'as compris.
            // appel la fonction ci-dessous avec les bon argument
            // Pour quel n'affiche qu'un rectangle de l'image
            // Place ce rectangle dans _tabAnnim pour gerer les
            // annimation des perso
            // utilise la constance Zoom de la classe Constantes
            // Ne t'en fait pas si l'image n'est pas a la bonne taille
            // pour le terrain on la changera plus tard

            spriteBatch.Draw(Texture, Position, SubRects[1], Color.White, 0, new Vector2(1,1),5 , new SpriteEffects(), 0);
            //Supprime cette ligne quant tu auras fini l'autre
                
        }
