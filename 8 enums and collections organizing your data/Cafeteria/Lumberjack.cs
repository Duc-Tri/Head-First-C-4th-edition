namespace Cafeteria
{
    internal class Lumberjack
    {
        public string Name { get; set; }
        // Here’s the stack of Flapjack enums. It gets filled up when the Main method calls TakeFlapjack with random flapjacks, and drained when it calls the EatFlapjacks method.
        private Stack<Flapjack> flapjackStack = new Stack<Flapjack>();
        private int v;
        public static Random random = new Random();

        public static Flapjack RandomFlapjack => (Flapjack)random.Next(0, Enum.GetNames(typeof(Flapjack)).Length);

        public Lumberjack(int nFlap)
        {
            for (int i = 0; i < nFlap; i++)
            {
                TakeFlapjack(RandomFlapjack);
            }
        }

        public Lumberjack(string name)
        {
            Name = name;
        }

        public void TakeFlapjack(Flapjack flapjack)
        {
            flapjackStack.Push(flapjack);
        }

        public void EatFlapjacks()
        {
            Console.WriteLine($" ----- {Name} is eating {flapjackStack.Count} flapjacks !");

            while (flapjackStack.Count > 0)
            {
                Console.WriteLine($"{Name} ate {flapjackStack.Pop()}");
            }
        }

    }

}
