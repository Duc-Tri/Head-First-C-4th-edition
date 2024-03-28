using System.Runtime.InteropServices;

namespace GoldenCrustacean
{
    // Henry “Flatfoot” Hodgkins is a TreasureHunter. He’s hot on the trail of one of the most prized possessions in the rare and unusual aquatic-themed jewelry markets: a jade‑encrusted translucent gold crab… but so are lots of other TreasureHunters.They all got a reference to the same crab in their constructor, but Henry wants to claim the prize first. In a stolen set of class diagrams, Henry discovers that the GoldenCrab class raises a RunForCover event every time anyone gets close to it.Even better, the event includes NewLocationArgs, which detail where the crab is moving to.But none of the other treasure hunters know about the event, so Henry figures he can cash in. Henry adds code to his constructor to register his treasure_RunForCover method as an event handler for the RunForCover event on the crab reference he’s got. Then, he sends a lowly underling after the crab, knowing it will run away, hide, and raise the RunForCover event—giving Henry’s treasure_RunForCover method all the information he needs. Everything goes according to plan, until Henry gets the new location and rushes to grab the crab.He’s stunned to see three other TreasureHunters already there, fighting over the crab. How did the other treasure hunters beat Henry to the crab?

    // How did the other treasure hunters beat Henry to the crab ? The crux of the mystery lies in how the treasure hunter seeks his quarry. First, we’ll need to see exactly what Henry found in the stolen diagrams. In a stolen set of class diagrams, Henry discovers that the GoldenCrab class raises a RunForCover event every time anyone gets close to it.Even better, the event includes NewLocationArgs, which detail where the crab is moving to.But none of the other treasure hunters know about the event, so Henry figures he can cash in.

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
