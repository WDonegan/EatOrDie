using UnityEngine;

namespace EatOrDie.InputActions
{
    public struct CustomInputState
    {
        public bool Forward;
        public bool Backward;
        public bool Jump;
        public bool Duck;
        public bool Escape;
        public bool Tap;
        public Vector2 TapPosition;

        public void Clear()
        {
            Forward = false;
            Backward = false;
            Jump = false;
            Duck = false;
            Escape = false;
            Tap = false;
            TapPosition = Vector2.zero;
        }
        
        public new string ToString() => $"F:{Forward} B:{Backward} J:{Jump} D:{Duck} Esc:{Escape} T:{Tap} TP:{TapPosition}";
    }
}