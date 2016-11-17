using System.Collections.Generic;

namespace Tamagochi.Objects
{
  public class Pet
  {
    private string _name;
    private int _food;
    private int _rest;
    private int _play;
    private static List<Pet> _pets = new List<Pet> {};
    private int _id;


    public Pet(string name, int food = 10, int rest = 10, int play = 10)
    {
      _name = name;
      _food = food;
      _rest = rest;
      _play = play;
      _id =_pets.Count;
      _pets.Add(this);

    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public int GetFood()
    {
      return _food;
    }
    public void SetFood(int newFood)
    {
      _food = newFood;
    }
    public int GetRest()
    {
      return _rest;
    }
    public void SetRest(int newRest)
    {
      _rest = newRest;
    }
    public int GetPlay()
    {
      return _play;
    }
    public void SetPlay(int newPlay)
    {
      _play = newPlay;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Pet> GetAll()
    {
      return _pets;
    }
    public static Pet Find(int searchId)
    {
      return _pets[searchId-1];
    }
    public void ElapsedTime()
    {
      _play -= 2;
      _food -= 3;
      _rest -= 4;
    }
    public void FeedPet()
    {
      _food += 2;
      _play -=1;
      _rest -= 1;
    }
    public void PlayPet()
    {
      _play += 2;
      _food -= 1;
      _rest -= 1;
    }
    public void BedPet()
    {
      _rest += 1;
      _food -= 1;
    }
    public static void ClearAll()
    {
      _pets.Clear();
    }
    public bool PetIsDead()
    {
      if(_play < 1 || _food < 1 || _rest < 1 )
      {
        return true;
      }else
      {
        return false;
      }
    }
  }
}
