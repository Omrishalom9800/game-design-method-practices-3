

using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

/// <author>Omri Shalom</author>
/// <remarks>I pledge my word of honor that I have abided
/// by the CSN Academic Integrity Policy while completing
/// this assignment.</remarks>
/// <file>ItemWorkbench.cs</file>
/// <date>YYYY-MM-DD</date>
/// <summary>Builds Items and uses them through their methods. Attach
/// this to an empty GameObject and press Play.</summary>
/// <remarks>Time taken to develop, write, test and debug: </remarks>
/// <summary>
/// The other side of the Item class: the code that calls it.
/// </summary>
public class ItemWorkbench 
{
    /// <summary>
    /// Runs once when you press Play. All of your TODOs go in here.
    /// </summary>
    public void Start()
    {
        // Done for you: an item built with the four-value constructor.
        Item sword = new Item("Iron Sword", 30, 3.5f, 20);

        // TODO A
        // Make a second item using YOUR one-argument constructor from
        // TODO 1. Call it whatever you like - a torch, a rope, a rock.
        Item sandwich = new Item("yum yum sandwich", 9999, 1, 1); // egg is the best sandwich

        // TODO B
        // Print each item's name, value, and weight using the methods
        // you wrote. One Debug.Log per value is fine.
        //
        // Notice: you can't write  sword.goldValue  here. Try it once
        // and read the error. The methods are the only way in.
        sword.describe();
        sandwich.describe();


        // TODO C
        // Use the sword 15 times. (A loop is fine.)
        // Then print its durability AND its sell price.
        // If the sell price is 0, go back and look at TODO 10.


        for (int i =0; i <15; i++)
        {
            sword.useItem();
        }

        Console.WriteLine(sword.getSellPrice()); // prints 7

        // TODO D
        // Repair the sword by 3 and print Describe().
        // Then fully repair it and print Describe() again.
        // You are calling two different Repair methods. Which line
        // calls which?

        // its calling two different reapirs
        sword.repair(3); // this line calls the second repair method
        sword.describe();
        Console.WriteLine("");
        sword.repair(); // this line calls the first repair method
        sword.describe();

        // TODO E
        // Keep using your second item until IsBroken() says it's broken.
        // Count how many uses that took, and print the count.
        Boolean notBroke = false;
        int uses = 0;
        while(!notBroke)
        {
            sword.useItem();

            if (sword.isBroken())
            {
                notBroke = true;
            }
            uses++;
        }
        Console.WriteLine("its was used "+uses+" times\n\n");

        // STRETCH (only if you did STRETCH A and B in Item.cs) no
        // Make a copy of the sword with your copy constructor. Use the
        // copy 5 times. Print Describe() on BOTH the sword and the copy.
        // Then print the name of Item.Heavier(sword, yourSecondItem).



        Item otherSword = new Item("swordLarper");
        otherSword.copy(sword, false);

        otherSword.repair();

        for (int i = 0; i < 5; i++)
        {
            otherSword.useItem();
        }

        Item item1 = sword;
        Item item2 = otherSword;
        if (Item.heavier(sword, otherSword))
        {
            Console.WriteLine(sword.GetName()+" is heavier then " + otherSword.GetName());
        }
        else
        {
            Console.WriteLine(sword.GetName() + " is not heavier then " + otherSword.GetName());

        }

    }
}
