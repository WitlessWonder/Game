using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EtherRealm{
//Object Requires Rigid Body, Collider
public class EthericBody : MonoBehaviour
{
    //inherit RigidBody Stuff
    //etheric mass
    //constant that defines dampening for changing velocity
    public float K = .05f;
    //velocity, acceleration, rotation versions
    //Drag Profile
        //

    //Current Drag
    private Vector3 controlForce = new Vector3();
    //Connected Fields, called in update to calculate net current 
    public enum fieldType{
        directional
    }
    public struct Field{
        public GameObject field;
        public fieldType type;
        public Field(GameObject f, fieldType t){field = f; type = t;}
    }
    private List<Field> fields = new List<Field>();
    //Anchor,resist movement relative to world Grid

    
    private Rigidbody thisBody;
    // Start is called before the first frame update
    void Start()
    {
        thisBody = gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 netForce = new Vector3();
        float dT = Time.deltaTime;
        //calculate net field, weighted sum of connected fields
        //Note something is funky with this don't use for more than one field my weighted average is retarded
        Vector3 Direction = new Vector3(0,0,0);
        float Strength = 0;

        foreach (Field f in fields){
            Component targetField = f.field.GetComponent("DirectionalField");
            Vector4 fieldStrength = ((DirectionalField)targetField).GetFieldStrength();
            //Debug.Log(fieldStrength.ToString());
            Direction.x += fieldStrength.x*fieldStrength.w;
            Direction.y += fieldStrength.y*fieldStrength.w;
            Direction.z += fieldStrength.z*fieldStrength.w;
            Strength += fieldStrength.w;
        }
        if (Strength!=0){
            Direction = Direction/Strength;
            //Debug.Log(Direction.ToString()+ ", "+Strength.ToString()+ ", "+K.ToString());
            //Debug.Log("Velocity"+ thisBody.velocity.ToString());
                //acceleration and rotation form and rotation based on velocity, drag profile, and field direction/weight
            netForce += (Direction - thisBody.velocity)*Strength*K;
            //Debug.Log("dV: "+ dV.ToString());
            //Debug.Log("Velocity"+ thisBody.velocity.ToString());
        }

        netForce += controlForce;

        thisBody.AddForce(netForce.x,netForce.y,netForce.z);
    }

    //Add To List
    public void AddField(GameObject f){
        //Debug.Log(f.ToString());
        Component  c = f.GetComponent("DirectionalField");
        //Debug.Log(c.ToString());
        if(c != null){
            Field F = new Field(f,fieldType.directional);
            fields.Add(F);
            //Debug.Log("Field Added");
        }
    }
    //Brute force remove from list, note this and the above are not scalable for large numbers of overlapping fields
    public void DelField(GameObject f){
        foreach (Field F in fields){
            if (F.field == f){
                fields.Remove(F);
                break;
            }
        }
        //Debug.Log("Field Added");
    }

    public void ControlForce (Vector3 cf){
        controlForce = cf;
    }
}
}