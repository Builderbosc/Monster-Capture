using UnityEngine;

public abstract class Car : MonoBehaviour
{
    [SerializeField] private string owner = "";

    protected string colour = "Green";

    public float speed = 5;
    public int wheelCount = 4;
    
    //Constructor
    public Car()
    {
        Debug.Log("Constructor");
        owner = "KOTOR";
    }

    //Overloaded constructor
    public Car(string name)
    {
        owner = name;
    }

    public string VictorySpeech()
    {
        return owner + " proves that " + wheelCount + " wheels is fastest. ";
    }

    public virtual void SetOwner(string name)
    {
        owner = name;
    }

    public abstract string Honk();
}

public class F1 : Car
{
    public F1()
    {
        speed = 10;
        colour = "Red";
        wheelCount = 8;
        SetOwner("Andrew");
    }

    public override string Honk()
    {
        return "VROOOOMM";
    }

    public override void SetOwner(string name)
    {
        base.SetOwner("F1 Driver " + name);
    }
    
}

public class Clown : Car
{
    public override string Honk()
    {
        return "Honk!";
    }

    public void EjectClown()
    {
        Debug.Log("Clown goes flying");
    }
    //Overloaded Function
    public void EjectClown(int number)
    {
        Debug.Log(number + "of clowns goes flying");
    }
}