using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAtack : MonoBehaviour
{
    private Transform player;
    public float atackRange = 5f;
    private Enemy EnemyScript;

    public Renderer ren;
    public Material defaultMaterial;
    public Material allertMaterial;

    private bool foundPlayer;



    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyScript = GetComponent<Enemy>();
        ren = GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,player.position ) <= atackRange)
        {
           ren.sharedMaterial = allertMaterial; // change material
            EnemyScript.agent.SetDestination(player.position); // set destination to player pos
            foundPlayer = true; //enable bool for chasing
        }
        else if(foundPlayer)
        {
            ren.sharedMaterial = defaultMaterial; // set material back to default
            EnemyScript.newLocation(); // call enemy script
            foundPlayer = false; 
        }
        
           
        
     
}
   
}
