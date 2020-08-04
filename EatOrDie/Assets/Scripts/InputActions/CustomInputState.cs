namespace EatOrDie.InputActions
{
    public struct CustomInputState
    {
        public bool Forward;
        public bool Backward;
        public bool Jump;
        public bool Duck;
        public bool Escape;

        public void Clear()
        {
            Forward = false;
            Backward = false;
            Jump = false;
            Duck = false;
            Escape = false;
        }
        
        public new string ToString() => $"F:{Forward} B:{Backward} J:{Jump} D:{Duck} Esc:{Escape}";
    }
}