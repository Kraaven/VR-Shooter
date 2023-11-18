using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Material Dart;
    public Material Classic;
    private Renderer ren;
    public bool touch;
    public GameObject spawner;
    void Start()
    {
        spawner = GameObject.FindWithTag("Spawner");
        ren = GetComponent<Renderer>();
        GetComponent<Renderer>().enabled = false;
        int r = Random.Range(0, 2);
        switch (r)
        {
            case 0:
                ren.material = Dart;
                break;
            case 1:
                ren.material = Classic;
                break;
        }
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            touch = true;
        }
    }

    IEnumerator ShowTarget()
    {
        yield return new WaitForSeconds(0.5f);
        if (touch == false)
        {
            ren.enabled = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
