using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;
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

        StartCoroutine(ShowTarget());

    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        if (other.CompareTag("Target"))
        {
            touch = true;
        }
    }

    IEnumerator ShowTarget()
    {
        Debug.Log("Cheking for touching");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Done checking");
        if (touch == false)
        {
            Debug.Log("Showed");
            ren.enabled = true;
        }
        else
        {   Debug.Log("Deleted");
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
    
}
