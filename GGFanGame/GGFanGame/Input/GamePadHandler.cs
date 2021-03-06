﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace GGFanGame.Input
{
    /// <summary>
    /// The thumbsticks on a GamePad.
    /// </summary>
    enum ThumbStick
    {
        Left,
        Right
    }

    /// <summary>
    /// Handles GamePad input.
    /// </summary>
    class GamePadHandler
    {
        private static GamePadState[] _oldStates = new GamePadState[4];
        private static GamePadState[] _currentStates = new GamePadState[4];

        /// <summary>
        /// Updates the GamePadHandler's states.
        /// </summary>
        public static void update()
        {
            for (int i = 0; i < _oldStates.Length; i++)
            {
                _oldStates[i] = _currentStates[i];
            }

            _currentStates[0] = GamePad.GetState(PlayerIndex.One);
            _currentStates[1] = GamePad.GetState(PlayerIndex.Two);
            _currentStates[2] = GamePad.GetState(PlayerIndex.Three);
            _currentStates[3] = GamePad.GetState(PlayerIndex.Four);
        }

        /// <summary>
        /// Returns if a specific button on a GamePad is pressed.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="playerIndex"></param>
        /// <returns></returns>
        public static bool buttonPressed(PlayerIndex playerIndex, Buttons button)
        {
            int index = (int)playerIndex;
            return (!_oldStates[index].IsButtonDown(button) && _currentStates[index].IsButtonDown(button));
        }

        /// <summary>
        /// Returns is a button is currently being held down on a GamePad.
        /// </summary>
        /// <param name="button"></param>
        /// <param name="playerIndex"></param>
        /// <returns></returns>
        public static bool buttonDown(PlayerIndex playerIndex, Buttons button)
        {
            int index = (int)playerIndex;
            return _currentStates[index].IsButtonDown(button);
        }

        /// <summary>
        /// Returns if the GamePad at the given player index is connected.
        /// </summary>
        /// <param name="playerIndex"></param>
        /// <returns></returns>
        public static bool isConnected(PlayerIndex playerIndex)
        {
            int index = (int)playerIndex;
            return _currentStates[index].IsConnected;
        }

        /// <summary>
        /// Returns a value from 0 to 1 how much a thumbstick is pressed in one direction.
        /// </summary>
        /// <param name="playerIndex"></param>
        /// <param name="thumbStick"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public static float thumbStickDirection(PlayerIndex playerIndex, ThumbStick thumbStick, InputDirection direction)
        {
            Vector2 v;
            float result = 0f;
            int index = (int)playerIndex;

            if (thumbStick == ThumbStick.Left)
                v = _currentStates[index].ThumbSticks.Left;
            else
                v = _currentStates[index].ThumbSticks.Right;

            switch (direction)
            {
                case InputDirection.Up:
                    result = v.Y;
                    break;
                case InputDirection.Left:
                    result = v.X * -1f;
                    break;
                case InputDirection.Down:
                    result = v.Y * -1f;
                    break;
                case InputDirection.Right:
                    result = v.X;
                    break;
            }

            if (result < 0f)
                result = 0f;

            return result;
        }
    }
}