using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    // Start is called before the first frame update
    public float squareOffMovement = 20f;
  
    private float xmin;
    private float xmax;
    private float zmin;
    private float zmax;

    private float xPosition;
    private float zPosition;
    private float yPosition;

    public float closeEnough = 3f;
    public int health = 100;
    public float akDamage = 22f;
    void Start()
    {
        xmin = zmin = -squareOffMovement;
        xmax = zmax = squareOffMovement;
        newLocation();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPosition, yPosition, zPosition)) <= closeEnough)
        {
            newLocation();

        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void newLocation()
    {
      
        yPosition = transform.position.y;
        xPosition = Random.Range(xmin, xmax);
        zPosition = Random.Range(zmin, zmax);
        //Debug.Log(yPosition + " --- " + xPosition + " --- " + zPosition);
        agent.SetDestination(new Vector3(xPosition, yPosition, zPosition));
       
    }
   
}
