using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{

    public float axeGaucheDroite;
    public float axeFreinage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        axeFreinage = Input.GetAxis("Vertical");
        if(axeFreinage >= 0)
        {
            axeFreinage = 0;
        }

        if (axeFreinage != -1)
        {
            axeGaucheDroite = Input.GetAxis("Horizontal");
        }
        transform.Translate(axeGaucheDroite, 0, axeFreinage + 1);
    }
}
