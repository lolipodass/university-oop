namespace RunProgram
{


    class User
    {
        public delegate void Move(int distance);
        public event Move? EventMove;

        public delegate void Shrink(int percent);
        public event Shrink? EventShrink;

        public void Moving(int distance)
        {
            EventMove?.Invoke(distance);
        }
        public void Shrinking(int distance)
        {
            EventShrink?.Invoke(distance);
        }

    }

}