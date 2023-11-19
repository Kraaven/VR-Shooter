using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnTargets : MonoBehaviour
{
    public bool gameChoice;
    public bool[,,] positions;
    public GameObject Target;
    public Vector3 pos;
    public bool game;
    public GameObject counter;
    public GameObject Limiter;
    public int limit = 6;
    public int count = 0;

    public void Start()
    {
        Limiter.GetComponent<TMP_Text>().text = "Limit: " + limit;
        game = true;
        positions = new bool[10, 10, 15];
        StartCoroutine(SpawnT());
    }

    IEnumerator SpawnT()
    {
        while (game)
        {
            while (count < limit)
            {
                pos = new Vector3(Random.Range(0, 4), Random.Range(0, 8), Random.Range(0,11));
                if (positions[(int)pos.x, (int)pos.y, (int)pos.z] == false)
                {
                    count++;
                    Instantiate(Target, new Vector3(pos.x + 6, pos.y + 1.5f, pos.z - 5), Quaternion.identity);
                    positions[(int)pos.x, (int)pos.y, (int)pos.z] = true;

                    yield return new WaitForSeconds(2f);
                }
                else
                {
                    yield return null;
                }
            }

            yield return null;
        }
       
    }

    public void Update()
    {
        counter.GetComponent<TMP_Text>().text = "Count: " + count;
    }
}
