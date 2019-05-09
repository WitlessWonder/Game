using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EtherRealm{
//Object Requires Rigid Body, Collider
public class EthericBody : MonoBehaviour
{
    //inherit RigidBody Stuff
    //etheric mass
    //velocity, acceleration, rotation versions
    //Drag Profile
        //

    //Current Drag

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


    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //calculate net field, weighted sum of connected fields
        //Note something is funky with this don't use for more than one field my weighted average is retarded
        Vector3 Direction = new Vector3();
        float Strength = 0;

        foreach (Field f in fields){
            Component targetField = f.field.GetComponent("DirectionalField");
            Vector4 fieldStrength = ((DirectionalField)targetField).GetFieldStrength();
            Direction.x += fieldStrength.x*fieldStrength.w;
            Direction.y += fieldStrength.y*fieldStrength.w;
            Direction.z += fieldStrength.z*fieldStrength.w;
            Strength += fieldStrength.w;
        }
        Direction = Direction/Strength;

        //acceleration and rotation form and rotation based on velocity, drag profile, and field direction/weight
    }

    //Add To List
    public void AddField(GameObject f){
        Component  c = f.GetComponent("DirectonalField");
        if(c != null){
            Field F = new Field(f,fieldType.directional);
            fields.Add(F);
        }
        return;
    }
    //Brute force remove from list, note this and the above are not scalable for large numbers of overlapping fields
    public void DelField(GameObject f){
        foreach (Field F in fields){
            if (F.field == f){
                fields.Remove(F);
                return;
            }
        }
        return;
    }
}
}