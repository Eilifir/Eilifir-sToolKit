using UnityEngine;

public static class FlyweightPointer
{
    public static readonly Flyweight FastGuy = new Flyweight
    {
        speed = 10
    };

    public static readonly Flyweight RegularGuy = new Flyweight
    {
        speed = 5
    };

    public static readonly Flyweight SlowGuy = new Flyweight
    {
        speed = 3
    };

    public static Flyweight Get(TypesOfGuy type)
    {
        switch(type)
        {
            case TypesOfGuy.FastGuy: return FastGuy;
            case TypesOfGuy.RegularGuy: return RegularGuy;
            case TypesOfGuy.SlowGuy: return SlowGuy;
            default: return RegularGuy;
        }
    }
}
