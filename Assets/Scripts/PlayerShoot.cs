using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public static Action shootInput;
    public static Action reloadInput;

    [SerializeField] private KeyCode reloadKey;
    private RaycastHit rayHit;
    private Ray ray;
    public Camera cam;

    private void Update()

    {
        if (Input.GetMouseButton(0)) { 
        
            shootInput?.Invoke();
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out rayHit))
        {
            Debug.Log("You are going to die");
        
        if (rayHit.collider.tag.Equals("NPC"))
        {
            Destroy(rayHit.collider.gameObject);
            Debug.Log("youre going to die");
        }
      }
    }
        if (Input.GetKeyDown(reloadKey)) 
            reloadInput?.Invoke();
        
    }

}
