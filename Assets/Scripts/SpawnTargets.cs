using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnTargets : MonoBehaviour
{
    public bool gameChoice;
    public bool[,,] positions;
    public GameObject Target;
    public Vector3 pos;
    
    
    public int limit = 6;
    public int count = 0;

    public void Start()
    {
        positions = new bool[10, 10, 10];
        StartCoroutine(SpawnT());
    }

    IEnumerator SpawnT()
    {
        while (count < limit)
        {
            pos = new Vector3(Random.Range(0, 4), Random.Range(0, 8), Random.Range(0, 7));
            if (positions[(int)pos.x, (int)pos.y, (int)pos.z] == false)
            {
                count++;
                
                Instantiate(Target, new Vector3(pos.x + 6, pos.y + 1, pos.z - 3), Quaternion.identity);
                positions[(int)pos.x, (int)pos.y, (int)pos.z] = true;

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
