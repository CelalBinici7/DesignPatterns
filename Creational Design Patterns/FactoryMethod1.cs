using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FactoryMethod1 : MonoBehaviour
{
   EnemyGenerator enmyg = new EnemyGenerator();
    private void Start()
    {
        enmyg.deneme(enemyState.weakenemy);
    }
}

public abstract class enemy
{
    public abstract void Attack();
    public abstract void Defend();

    public abstract void Hit();
    public abstract void Dead();


}

public class weakenemy : enemy
{
    public string a;
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Dead()
    {
        throw new System.NotImplementedException();
    }

    public override void Defend()
    {
        throw new System.NotImplementedException();
    }

    public override void Hit()
    {
        throw new System.NotImplementedException();
    }
}

public class strongenemy : enemy
{
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Dead()
    {
        throw new System.NotImplementedException();
    }

    public override void Defend()
    {
        throw new System.NotImplementedException();
    }

    public override void Hit()
    {
        throw new System.NotImplementedException();
    }
}
public class midenemy : enemy
{
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Dead()
    {
        throw new System.NotImplementedException();
    }

    public override void Defend()
    {
        throw new System.NotImplementedException();
    }

    public override void Hit()
    {
        throw new System.NotImplementedException();
    }
}
public enum enemyState
{
    midenemy,
    weakenemy,
    strongenemy
}
public class EnemyGenerator
{
    enemy en;

    
    public enemy createEnemy(enemyState state)
    {
        switch (state)
        {
            case enemyState.midenemy:   
                en =new midenemy();
                break;
            case enemyState.strongenemy:
                en =new strongenemy();
                break;
            case enemyState.weakenemy:
                en =new weakenemy();
                break;
            default:

                break;
        }
        return en;
    }

}










