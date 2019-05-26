using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EtherRealm{
public class DirectionalField : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 speed = new Vector3(0,1,0);
    public float strength = 1;
    void Start()
    {
        Debug.Log("Field Initialized");
    }
    // Update is called once per frame
    public Vector4 GetFieldStrength(){
        var fieldStrength = new Vector4(speed.x,speed.y,speed.z, strength);

        return fieldStrength;
    }
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered Field");
        Component target = other.GetComponent("EthericBody");
        if (target != null){
            ((EthericBody)target).AddField(this.gameObject);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        //Debug.Log("Exited Field");
        Component target = other.GetComponent("EthericBody");
        if (target != null){
            ((EthericBody)target).DelField(this.gameObject);
        }
    }
}
}