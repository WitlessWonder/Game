using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalField : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Field Initialized");
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered Collision");
    }
    public void OnCollisionStay(Collision other)
    {
        Debug.Log("Stay");
    }
    public void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision Exited");
    }
}
