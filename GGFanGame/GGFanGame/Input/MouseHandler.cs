﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace GGFanGame.Input
{
    /// <summary>
    /// Buttons on a mouse.
    /// </summary>
    enum MouseButton
    {
        Left,
        Right,
        Middle
    }

    /// <summary>
    /// Handles mouse input.
    /// </summary>
    class MouseHandler
    {
        private static MouseState _oldState;
        private static MouseState _currentState;

        /// <summary>
        /// Updates the MouseHandler's states.
        /// </summary>
        public static void update()
        {
            _oldState = _currentState;
            _currentState = Mouse.GetState();
        }

        /// <summary>
        /// Returns if a specific mouse button is pressed.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public static bool buttonPressed(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left:
                    return (_oldState.LeftButton == ButtonState.Released && _currentState.LeftButton == ButtonState.Pressed);
                case MouseButton.Right:
                    return (_oldState.RightButton == ButtonState.Released && _currentState.RightButton == ButtonState.Pressed);
                case MouseButton.Middle:
                    return (_oldState.MiddleButton == ButtonState.Released && _currentState.MiddleButton == ButtonState.Pressed);
            }
            return false;
        }

        /// <summary>
        /// Returns if a specific mouse button is being held down.
        /// </summary>
        /// <param name="button"></param>
        /// <returns></returns>
        public static bool buttonDown(MouseButton button)
        {
            switch (button)
            {
                case MouseButton.Left:
                    return (_currentState.LeftButton == ButtonState.Pressed);
                case MouseButton.Right:
                    return (_currentState.RightButton == ButtonState.Pressed);
                case MouseButton.Middle:
                    return (_currentState.MiddleButton == ButtonState.Pressed);
            }
            return false;
        }

        /// <summary>
        /// Returns the position of the mouse in the window.
        /// </summary>
        /// <returns></returns>
        public static Point mousePosition()
        {
            return new Point(_currentState.X, _currentState.Y);
        }
    }
}