using Unity.VisualScripting;
using UnityEngine;


public interface IUse
{
    void Use();
}

public interface IPrintDescription
{
    void Print();
}
public class Item
{
    protected int id;
    protected string name;
    protected string description;
    protected int count;

    
}

public class LiquidMedicine : Item, IUse, IPrintDescription
{
    int addHp;
    public void Use()
    {
        count--;

    }

    public void Print()
    {
        Debug.Log(description);
    }

    public int AddHp(int hp)
    {
        return hp + addHp;
    }
}

public class SpeedUpItem : Item, IUse, IPrintDescription
{
    int addSpeed;
    public void Print()
    {
        Debug.Log(description);
    }

    public void Use()
    {
        count--;
    }

    public int SpeedUp(int speed)
    {
        return speed + addSpeed;
    }
}


