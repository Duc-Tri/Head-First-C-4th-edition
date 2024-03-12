// See https://aka.ms/new-console-template for more information
using Cafeteria;

void CreateLumberjackAndFlapjacks()
{
    string[] names = new string[] { "Carl", "Kevin", "Gunther", "Dimitri" };
    Queue<Lumberjack> lumberjacks = new Queue<Lumberjack>();

    // Creates each Lumberjack object, calls its TakeFlapjack method with a random flapjacks, and then enqueues the reference.
    foreach (var name in names)
    {
        Lumberjack lj = new Lumberjack(name);
        for (int i = Lumberjack.random.Next(1, 5); i >= 0; i--)
            lj.TakeFlapjack(Lumberjack.RandomFlapjack);

        lumberjacks.Enqueue(lj);
    }

    // When the user is done entering lumberjacks, the Main method uses a while loop to dequeue each Lumberjack and call its EatFlapjacks method.The rest of the output lines are written by each Lumberjack object.

    while (lumberjacks.Count > 0)
        lumberjacks.Dequeue().EatFlapjacks();
}

//=============================================================================
Console.WriteLine("WELCOME TO THE CAFETERIA ! ==============================");

CreateLumberjackAndFlapjacks();
