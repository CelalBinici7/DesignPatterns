using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderMethod : MonoBehaviour
{
    void Start()
    {
        ICharacterBuilder builder = new CharacterBuilder();
        CharacterDirector director = new CharacterDirector(builder);

        director.ConstructWarrior();
        Character warrior = builder.GetCharacter();
        warrior.ShowInfo();

        director.ConstructArcher();
        Character archer = builder.GetCharacter();
        archer.ShowInfo();
    }
}

public class Character
{
    public string Name { get; set; }
    public float Health { get; set; }
    public float Speed { get; set; }
    public GameObject CharacterModel { get; set; }

    public void ShowInfo()
    {
        Debug.Log($"Name: {Name}, Health: {Health}, Speed: {Speed}");
    }

   
}

public interface ICharacterBuilder
{
    void SetName(string name);
    void SetHealth(float health);
    void SetSpeed(float speed);
    void SetCharacterModel(GameObject model);
    Character GetCharacter();
}

public class CharacterBuilder : ICharacterBuilder
{
    private Character _character = new Character();

    public void SetName(string name)
    {
        _character.Name = name;
    }

    public void SetHealth(float health)
    {
        _character.Health = health;
    }

    public void SetSpeed(float speed)
    {
        _character.Speed = speed;
    }

    public void SetCharacterModel(GameObject model)
    {
        _character.CharacterModel = model;
    }

    public Character GetCharacter()
    {
        return _character;
    }
}

public class CharacterDirector
{
    private ICharacterBuilder _builder;

    public CharacterDirector(ICharacterBuilder builder)
    {
        _builder = builder;
    }

    public void ConstructWarrior()
    {
        _builder.SetName("Warrior");
        _builder.SetHealth(100);
        _builder.SetSpeed(5);
        _builder.SetCharacterModel(Resources.Load<GameObject>("WarriorModel"));
    }

    public void ConstructArcher()
    {
        _builder.SetName("Archer");
        _builder.SetHealth(70);
        _builder.SetSpeed(7);
        _builder.SetCharacterModel(Resources.Load<GameObject>("ArcherModel"));
    }
}
