using UnityEngine;

namespace EatOrDie.InputActions
{
    public struct CustomTouchState
    {
        public bool Jump;
        public bool Backwards;
        public bool Forwards;
        public bool Duck;
        public bool Tap;
        public Vector2 TapPosition;

        public void Clear()
        {
            Jump = false;
            Backwards = false;
            Forwards = false;
            Duck = false;
            Tap = false;
            TapPosition = Vector2.zero;
        }

        public new string ToString() => $"F:{Forwards} B:{Backwards} J:{Jump} D:{Duck} T:{Tap} TP:{TapPosition}";
    }
}