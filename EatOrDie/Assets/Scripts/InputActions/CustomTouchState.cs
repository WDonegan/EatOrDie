namespace EatOrDie.InputActions
{
    public struct CustomTouchState
    {
        public bool Jump;
        public bool Backwards;
        public bool Forwards;
        public bool Duck;

        public void Clear()
        {
            Jump = false;
            Backwards = false;
            Forwards = false;
            Duck = false;
        }

        public new string ToString() => $"F:{Forwards} B:{Backwards} J:{Jump} D:{Duck}";
    }
}