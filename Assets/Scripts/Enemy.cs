using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent EnemyAgent;
    public int damageAmount = 10;
    public int Health = 100;

    private float squareOfMovement = 20f;
    public float xMin, xMax, zMin, zMax;
    private float xPosition, yPosition, zPosition;
    private float closeEnough = 3f;

    void Start()
    {
        xMin = -squareOfMovement;
        xMax = squareOfMovement;
        zMin = -squareOfMovement;
        zMax = squareOfMovement;

        newLocation();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(xPosition, yPosition, zPosition)) <= closeEnough)
        {
           
            newLocation();
        }
    }

    public void newLocation()
    {
        xPosition = Random.Range(xMin, xMax);
        yPosition = transform.position.y;
        zPosition = Random.Range(zMin, zMax);
        EnemyAgent.SetDestination(new Vector3(xPosition, yPosition, zPosition));
    }
}