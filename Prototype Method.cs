using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeMethod: MonoBehaviour
{
    //Enemy Spawner
   
    private void Start()
    {
        Enemy enemy = new Enemy("Original",100,23);

        for (int i = 0; i < 10; i++)
        {
            Enemy clone = enemy.Clone() as Enemy;
        }
    }

}

public interface ICloneable
{
    ICloneable Clone();
}

public class Enemy : MonoBehaviour, ICloneable
{
    public string enemyName;
    public int helth;
    public float speed;
    public GameObject prefab;//vs vs

    public Enemy(string enemyName, int helth, float speed)
    {
        this.enemyName = enemyName;
        this.helth = helth;
        this.speed = speed;
    }

    public ICloneable Clone()
    {
      return this.MemberwiseClone() as ICloneable;
    }
}
