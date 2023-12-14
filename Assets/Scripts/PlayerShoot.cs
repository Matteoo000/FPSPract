using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public static Action shootInput;
    public static Action reloadInput;

    [SerializeField] private KeyCode reloadKey;
    private RaycastHit rayHit;
    private Ray ray;
    public Camera cam;

    private Enemy enemyScript;

    private void Update()

    {
        if (Input.GetMouseButton(0)) { 
        
            shootInput?.Invoke();
            ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out rayHit))
        {
                enemyScript = rayHit.collider.GetComponent<Enemy>();
                
            //Debug.Log("You are going to die");

        if (rayHit.collider.tag.Equals("NPC"))
        {
                    Debug.Log(enemyScript.Health);
                    enemyScript.Health--;
                    if (enemyScript.Health < 0)
                    {
                        Destroy(rayHit.collider.gameObject);

                    }
                    else
                    {
                        
                    }
                    
            
            Debug.Log("youre going to die");
        }
      }
    }
        if (Input.GetKeyDown(reloadKey)) 
            reloadInput?.Invoke();
        
    }

}
