using System;
using System.Collections;
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
    private Vector3 currentpos;
    void Start()
    {
        spawner = GameObject.FindWithTag("Spawner");
        currentpos = spawner.GetComponent<SpawnTargets>().pos;
        ren = GetComponent<Renderer>();
        ren.enabled = false;
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

        gameObject.transform.parent.gameObject.transform.SetParent(spawner.transform); 
        StartCoroutine(ShowTarget());

    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            touch = true;
        }
    }

    IEnumerator ShowTarget()
    {
        yield return new WaitForSeconds(0.01f);
        if (touch == false)
        {
            ren.enabled = true;
        }
        else
        {
            spawner.GetComponent<SpawnTargets>().count--;
            spawner.GetComponent<SpawnTargets>().positions[(int)currentpos.x, (int)currentpos.y, (int)currentpos.z] = false;
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    public void KillTarget()
    {
        if (ren.enabled)
        {
            spawner.GetComponent<SpawnTargets>().count--;
            spawner.GetComponent<SpawnTargets>().positions[(int)currentpos.x, (int)currentpos.y, (int)currentpos.z] = false;
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
    

}
