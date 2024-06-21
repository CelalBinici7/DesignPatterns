using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrategyDesignPattern : MonoBehaviour
{
   public Enemy enemy;
    void Start()
    {
        enemy.setAttackStrategy(new MeeleAttackStrategy());
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            enemy.setAttackStrategy(new MeeleAttackStrategy());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            enemy.setAttackStrategy(new RangedAttackStrategy());
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            enemy.PerformAttack();
        }
    }
}

public interface IAttackStrategy
{
    void Attack(GameObject enemy);
}

public class MeeleAttackStrategy : IAttackStrategy
{
    public void Attack(GameObject enemy)
    {
        //melee codes and animations
    }
}

public class RangedAttackStrategy : IAttackStrategy
{
    public void Attack(GameObject enemy)
    {
        //range attack codes and animations
    }
}

public class Enemy : MonoBehaviour
{

    private IAttackStrategy m_AttackStrategy;
   
    public void setAttackStrategy(IAttackStrategy strategy)
    {
       m_AttackStrategy= strategy;
    }

    public void PerformAttack()
    {
        m_AttackStrategy.Attack(gameObject);
    }
}
