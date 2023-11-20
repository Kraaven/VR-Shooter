using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject ShootingOrigin;
    private bool shotThisFrame = false;

    // void Update()
    // {
    //     if (!shotThisFrame)
    //     {
    //         ShootBullet();
    //         shotThisFrame = true;
    //     }
    // }
    // void LateUpdate()
    // {
    //     shotThisFrame = false;
    // }

    public void ShootBullet()
    {
        Ray ray = new Ray(ShootingOrigin.transform.position, ShootingOrigin.transform.forward);
        
        if (Physics.Raycast(ray, out RaycastHit hit, 30f) && hit.collider.gameObject.CompareTag("Target"))
        {
            hit.collider.gameObject.GetComponent<SpawnTarget>().KillTarget();
        }
        

    }
    
    
}
