using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0;
        float y = 0;
        float z = 0;
        float dT = Time.deltaTime;
        if(Input.GetKey(KeyCode.W)){
            x+=speed;
        }
        else if (Input.GetKey(KeyCode.S)){
            x-=speed;
        }
        if(Input.GetKey(KeyCode.A)){
            y+=speed;
        }
        else if (Input.GetKey(KeyCode.D)){
            y-=speed;
        }
        if(Input.GetKey(KeyCode.Q)){
            z+=speed;
        }
        else if (Input.GetKey(KeyCode.E)){
            z-=speed;
        }
        Vector3 velocity = new Vector3(x,y,z);
        this.transform.position += velocity*dT;

    }
    
}
