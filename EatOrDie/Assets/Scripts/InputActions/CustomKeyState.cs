namespace EatOrDie.InputActions
{
    public struct CustomKeyState
    {
        public bool Jump;
        public bool Backwards;
        public bool Forwards;
        public bool Duck;
        public bool Escape;
        
        public void Clear()
        {
            Jump = false;
            Backwards = false;
            Forwards = false;
            Duck = false;
            Escape = false;
        }

        public new string ToString() => $"F:{Forwards} B:{Backwards} J:{Jump} D:{Duck} Esc:{Escape}";
    }
}