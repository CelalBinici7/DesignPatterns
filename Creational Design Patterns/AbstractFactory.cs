using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractFactory : MonoBehaviour
{
    private void Start()
    {
        ICharacterFactory mageFactory = new MageFactory();
        ICharacter mage = mageFactory.CreateCharacter();
        IWeapon staff = mageFactory.CreateWeapon();

        mage.Attack();
        staff.Use();

        ICharacterFactory  warriorFactory = new WarriorFactory();
        ICharacter warrior = warriorFactory.CreateCharacter();
        IWeapon sword = warriorFactory.CreateWeapon();

        warrior.Attack();
        sword.Use();
    }
}

public interface ICharacter
{
    void Attack();
}

public interface IWeapon
{
    void Use();
}

public class Mage : ICharacter
{
    public void Attack()
    {
        Debug.Log("Mage casts a spell");
    }
}

public class Warrior : ICharacter
{
    public void Attack()
    {
        Debug.Log("Warrior casts a sword");
    }
}

public class Staff : IWeapon
{
    public void Use()
    {
        Debug.Log("Staff is used to cast a spell.");
    }
}

public class Sword : IWeapon
{
    public void Use()
    {
        Debug.Log("Sword is used to attack.");
    }
}

public interface ICharacterFactory
{
    ICharacter CreateCharacter();
    IWeapon CreateWeapon();
}

public class MageFactory : ICharacterFactory
{
    public ICharacter CreateCharacter()
    {
       return new Mage();   
    }

    public IWeapon CreateWeapon()
    {
        return new Staff();
    }
}

public class WarriorFactory : ICharacterFactory
{
    public ICharacter CreateCharacter()
    {
       return new Warrior();
    }

    public IWeapon CreateWeapon()
    {
       return new Sword();
    }
}

