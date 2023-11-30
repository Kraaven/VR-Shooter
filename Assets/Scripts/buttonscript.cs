using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonscript : MonoBehaviour
{
    // Start is called before the first frame update

    public bool hovertoggle;
    void Start()
    {
        hovertoggle = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void pushButton()
    {
        gameObject.GetComponent<Animator>().Play("PushButton");
        
    }
}
