using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltraLongMonogameTutoriel.Managers
{
    internal static class InputManager
    {
        private static KeyboardState lastKeyboardState;
        private static KeyboardState currentKeyboardState;

        public static bool IsKeyPressed(Keys key)
        {
            return currentKeyboardState.IsKeyDown(key) && lastKeyboardState.IsKeyUp(key);
        }

        public static void Update()
        {
            lastKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }
    }
}
