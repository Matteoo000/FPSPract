using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    // Start is called before the first frame update


    public float health = 100f;
   
    public void takedamage(float damage)
    {
       health -= damage;
        if (health <= 0)
        { 
            Destroy(gameObject);
        }
    }
}
