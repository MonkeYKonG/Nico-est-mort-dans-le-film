using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Projet_epita
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class InputsManager
    {
        //initialisation des variables State
        KeyboardState _keyboardState;
        KeyboardState _lastKeyboardState;
        MouseState _mouseState;
        MouseState _lastMouseState;

        public int X
        {
            get { return _mouseState.X; }
        }
        public int Y
        {
            get { return _mouseState.Y; }
        }
        public Vector2 Position
        {
            get { return new Vector2(_mouseState.X, _mouseState.Y); }
        }
        public int ScrollWheelValue
        {
            get { return _mouseState.ScrollWheelValue; }
        }

        public InputsManager()
        {
            // TODO: Construct any child components here
            _keyboardState = Keyboard.GetState();
            _mouseState = Mouse.GetState();
        }

        public void Initialize() { }

        public void Update()
        {
            _lastKeyboardState = _keyboardState;
            _keyboardState = Keyboard.GetState();
            _lastMouseState = _mouseState;
            _mouseState = Mouse.GetState();
        }

        // Les fontions publiques de comparaisons

        public bool IsPressedOne(Keys keys)
        {
            return _keyboardState.IsKeyDown(keys) &&
                _lastKeyboardState.IsKeyUp(keys);
        }

        public bool IsPressed(Keys keys)
        {
            return _keyboardState.IsKeyDown(keys);
        }

        public bool IsReleasedOne(Keys keys)
        {
            return _keyboardState.IsKeyUp(keys) &&
                _lastKeyboardState.IsKeyDown(keys);
        }

        public bool IsReleased(Keys keys)
        {
            return _keyboardState.IsKeyUp(keys);
        }

        public bool LeftClickedOne()
        {
            return _mouseState.LeftButton == ButtonState.Pressed &&
                _lastMouseState.LeftButton == ButtonState.Released;
        }

        public bool RightClickedOne()
        {
            return _mouseState.RightButton == ButtonState.Pressed;
        }

        public bool LeftClicked()
        {
            return _mouseState.LeftButton == ButtonState.Pressed;
        }

        public bool RightClicked()
        {
            return _mouseState.RightButton == ButtonState.Pressed;
        }

        public bool LeftReleasedOne()
        {
            return _mouseState.LeftButton == ButtonState.Released &&
                _lastMouseState.LeftButton == ButtonState.Pressed;
        }

        public bool RightReleasedOne()
        {
            return _mouseState.RightButton == ButtonState.Pressed &&
                _lastMouseState.RightButton == ButtonState.Released;
        }

        public bool LeftReleased()
        {
            return _mouseState.LeftButton == ButtonState.Released;
        }

        public bool RightReleased()
        {
            return _mouseState.RightButton == ButtonState.Released;
        }

        public bool ScrollWheelChange()
        {
            return _lastMouseState.ScrollWheelValue != _mouseState.ScrollWheelValue;
        }
    }
}
