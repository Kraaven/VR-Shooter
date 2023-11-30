using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleLever : MonoBehaviour
{
    public bool moving;
    public bool mode;
    private SkinnedMeshRenderer blren;
    private float speed;
    private bool hovertoggle;

    public void Start()
    {
        blren = gameObject.GetComponent<SkinnedMeshRenderer>();
        mode = true;
        speed = 0.0004f;
        hovertoggle = false;
        gameObject.GetComponent<Outline>().enabled = false;
    }

    public void toggle()
    {
        if (moving == false)
        {
            mode = !mode;
            moving = true;
            switch (mode)
            {
                case true:
                    StartCoroutine(downup());
                    break;
                case false:
                    StartCoroutine(updown());
                    break;
            }
        }
    }

    IEnumerator updown()
    {
        for (int i = 101; i > 0; i--)
        {
            blren.SetBlendShapeWeight(0,i);
            yield return new WaitForSeconds(speed);
        }
        blren.SetBlendShapeWeight(0,0);
        for (int i = 0; i < 101; i++)
        {
            blren.SetBlendShapeWeight(1,i);
            yield return new WaitForSeconds(speed);
        }
        blren.SetBlendShapeWeight(1,100);
        moving = false;
    }

    IEnumerator downup()
    {
        for (int i = 101; i > 0; i--)
        {
            blren.SetBlendShapeWeight(1,i);
            yield return new WaitForSeconds(speed);
        }
        blren.SetBlendShapeWeight(1,0);
        for (int i = 0; i < 101; i++)
        {
            blren.SetBlendShapeWeight(0,i);
            yield return new WaitForSeconds(speed);
        }
        blren.SetBlendShapeWeight(0,100);
        moving = false;
    }

    public void togglehover()
    {
        hovertoggle = !hovertoggle;

        if (hovertoggle)
        {
            gameObject.GetComponent<Outline>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Outline>().enabled = false;
        }
    }
}
