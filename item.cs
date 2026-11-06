

// ======================================================================
// HOW THIS WORKS
//
// The fields and the first constructor are done. Read them first.
//
// Every TODO below is something you write, inside this class.
// The early TODOs give you the exact signature to copy.
// The later ones only tell you what the method does - you decide the
// return type and the parameters. That decision IS today's lesson.
//
// Then open ItemWorkbench.cs and use what you built.
// ======================================================================

using System;
using System.Runtime.InteropServices;
using System.Xml.Linq;

/// <author> Omri Shalom </author>
/// <remarks>I pledge my word of honor that I have abided
/// by the CSN Academic Integrity Policy while completing
/// this assignment.</remarks>
/// <file>Item.cs</file>
/// <date>YYYY-MM-DD</date>
/// <summary>An Item is a handful of values - a name, a value, a weight,
/// and a durability - that together represent one thing in the game.
/// Nothing outside this class can touch those values directly. The only
/// way in is through the methods you write below.</summary>
/// <remarks>Time taken to develop, write, test and debug: 1 hour </remarks>
/// <summary>
/// One item a player can carry. Not a MonoBehaviour: it can't be
/// attached to a GameObject. It lives inside other scripts.
/// </summary>
public class Item
{
    /// <summary>What the item is called.</summary>
    private string itemName;

    /// <summary>What the item is worth in gold, undamaged.</summary>
    private int goldValue;

    /// <summary>How heavy the item is, in kilograms.</summary>
    private float weight;

    /// <summary>Uses left before the item breaks.</summary>
    private int durability;

    /// <summary>Durability when new or fully repaired.</summary>
    private int maxDurability = 1;

    /// <summary>
    /// Builds an item with every value specified. A new item starts at
    /// full durability.
    /// </summary>
    /// <param name="name">What the item is called.</param>
    /// <param name="value">Worth in gold, undamaged.</param>
    /// <param name="itemWeight">Weight in kilograms.</param>
    /// <param name="maxUses">Uses before breaking. At least 1.</param>
    public Item(string name, int value, float itemWeight, int maxUses)
    {
        itemName = name;
        goldValue = value;
        weight = itemWeight;
        maxDurability = maxUses;
        durability = maxUses;
    }

    // ------------------------------------------------------------------
    // TODO 1 - A SECOND CONSTRUCTOR
    //
    // Write a constructor that takes ONLY a name:
    //
    
    public Item(string name)
    {
        itemName = name;
    }
    //
    // Everything else gets a default: worth 1 gold, weighs 0.5 kg,
    // 10 durability.
    //
    // First, write it the long way: set all five fields yourself.
    //
    // Then rewrite it so it hands the work to the constructor above,
    // using  : this(...)  after the parentheses. Keep that version.
    //
    // In a comment above it, answer: why is the second version better?
    // (Hint: what happens if someone adds a sixth field next week?)
    // ------------------------------------------------------------------


    // ------------------------------------------------------------------
    // TODO 2 - GetName
    //
    // Hand back this item's name.
    //
         public string GetName() { return itemName; }
    // ------------------------------------------------------------------


    // ------------------------------------------------------------------
    // TODO 3 - GetValue
    //
    // Hand back what this item is worth in gold.
    //
         public int GetValue() { return goldValue; }
    // ------------------------------------------------------------------


    // ------------------------------------------------------------------
    // TODO 4 - GetWeight
    //
    // Hand back how heavy this item is.
    // You write the signature. What type does it need to return?
    // Look at the field.
        public float GetWeight() { if (weight < 0) { Console.WriteLine("balloons?"); } return weight; }
    // ------------------------------------------------------------------


    // ------------------------------------------------------------------
    // TODO 5 - GetDurability
    //
    // Hand back how many uses this item has left.
    // You write the signature.
        public int GetDurability() { return durability; }
    // ------------------------------------------------------------------


    // ------------------------------------------------------------------
    // TODO 6 - Use
    //
    // Call this every time the item gets used. It takes away one point
    // of durability. Durability must never drop below zero.
    //
    // Does this method need to hand anything back? Does it need anything
    // handed to it? Your signature should answer both questions.

    public void useItem() { durability--; if(isBroken()) { goldValue = 0; Console.WriteLine(itemName + " broken somehow"); } }

    // ------------------------------------------------------------------


    // ------------------------------------------------------------------
    // TODO 7 - IsBroken
    //
    // Answer one question: is this item out of durability?
    // You write the signature. What type is the answer to a yes/no
    // question?
    public Boolean isBroken() { if(durability <= 0) { return true; } else { return false; } }
    // ------------------------------------------------------------------


    // ------------------------------------------------------------------
    // TODO 8 - Repair
    //
    // Restore the item to full durability.
    public void repair() { durability = maxDurability; }
    // ------------------------------------------------------------------


    // ------------------------------------------------------------------
    // TODO 9 - Repair, again
    //
    // Write a SECOND method, also called Repair, that restores only some
    // durability. The caller says how much. Durability must never go
    // above the maximum.
    //
    // Two methods. Same name. C# allows it.
    //
    // In a comment above it, answer: when someone writes
    //     sword.Repair(3);
    // how does C# know which Repair to run?

    // if you do repair(3) it will play the method below because its the only repair that takes an int parameter
    public void repair(int amount) { if (amount > maxDurability) { amount = maxDurability; } else if(amount < 0){ amount = 0; } durability = durability + amount; }
    // ------------------------------------------------------------------


    // ------------------------------------------------------------------
    // TODO 10 - GetSellPrice
    //
    // A damaged item sells for less. Hand back its value scaled by how
    // much durability is left: at half durability it's worth half its
    // gold value. A whole number of gold is fine.
    //
    // CAREFUL: in C#, what is  5 / 10  when both are ints?
    // Test this one with a damaged item before you trust it.

    public int getSellPrice() { double sellPrice = (durability * goldValue)/maxDurability; return (int)sellPrice; } // chops off the decimal

    // ------------------------------------------------------------------


    // ------------------------------------------------------------------
    // TODO 11 - Describe
    //
    // Hand back a single line of text describing the item, like:
    //
    //     Iron Sword (12/20) - 30g, 3.5kg
    //
    // Use the fields. Don't type the numbers in by hand.

    public void describe() { Console.WriteLine(itemName + " has a durability of " + durability + "/" + maxDurability + ", weighing " + weight + "g, worth " + getSellPrice() + " gold"); }

    // ------------------------------------------------------------------


    // ==================================================================
    // STRETCH A - A COPY CONSTRUCTOR
    //
    // Write a third constructor that takes another Item and makes a
    // brand-new item with all the same values - including its CURRENT
    // durability, not its maximum.
    //
    //     public Item(Item original)
    //
    // Then, in a comment, answer:
    //
    //     Item a = new Item("Shield", 20, 4.0f, 30);
    //     Item b = a;
    //     Item c = new Item(a);
    //
    // How many Item objects exist after these three lines?
    // If you call b.Use(), does a change? If you call c.Use()?
    // (Session 7. Draw the boxes and arrows.) no, im too lazy

    public void copy(Item copy, Boolean takeName)
    {
        if (takeName)
        {
            itemName = copy.GetName();
        }

        goldValue = copy.GetValue();
        weight = copy.GetWeight();
        maxDurability = copy.GetMaxDurability();
        durability = copy.GetDurability();
    }

    public int GetMaxDurability() { return maxDurability; }

    // ==================================================================


    // ==================================================================
    // STRETCH B - A STATIC METHOD
    //
    // Write a method that takes TWO items and hands back whichever one
    // is heavier.
    //
    //     public static Item Heavier(Item first, Item second)
    //
    // Then, in a comment, answer: GetWeight() needs no parameters.
    // Why does Heavier need two? What does "static" take away?
    // (Session 16.)

    //Static makes the method belong to the class, not each indiviual object. Thius means it does not know which object you call it from, so you have to put it your self.
    public static Boolean heavier(Item HeavierThan, Item itemTwo)
    {
        if(HeavierThan.GetWeight() > itemTwo.GetWeight()) // is item one heavier
        {
            return true;
        }
        else { return false; } // if its not heavier but equal or less than, return true.
    }
    // ==================================================================
}
