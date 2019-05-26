using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Control{
    public class RootControl : MonoBehaviour
    {
        //Internal Variables


        //key Updates

        //keyboard.state
            //index for every key, has 3 pointers for every key that redirect 

        //rootcontrol.state
            //

        //target.control

        // Start is called before the first frame update

        public GameObject Target;
        private ShipControl TargetController;
        //TempVariable for demo purposes until i rebuild to be generalized
        Vector3 ShipThrustVector = new Vector3();
        Vector3 OldThrust = new Vector3();

        void Start()
        {
            TargetController = Target.GetComponent(typeof(ShipControl)) as ShipControl;
        }

        // Update is called once per frame

        //Need to think of a general control scheme
        void Update()
        {
            float mousex = Input.mousePosition.x;
            float mousey = Input.mousePosition.y;
            float mousez = Input.mousePosition.z;
            OldThrust = ShipThrustVector;
            

            foreach(KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyUp(kcode)){
                    //Debug.Log("KeyCode up: " + kcode);
                    ShipThrustVector = new Vector3();
                    if(kcode == KeyCode.A){
                        ShipThrustVector.x=0;
                    }
                    else if(kcode == KeyCode.D){
                        ShipThrustVector.x=0;
                    }
                    else if(kcode == KeyCode.S){
                        ShipThrustVector.y=0;
                    }
                    else if(kcode == KeyCode.W){
                        ShipThrustVector.y=0;
                    }
                    else if(kcode == KeyCode.Q){
                        ShipThrustVector.z=0;
                    }
                    else if(kcode == KeyCode.E){
                        ShipThrustVector.z=0;
                    }
                    
                    
                }

                else if(Input.GetKeyDown(kcode)){
                    //Debug.Log("KeyCode down: " + kcode);
                    if(kcode == KeyCode.A){
                        ShipThrustVector.x=-1f;
                    }
                    else if(kcode == KeyCode.D){
                        ShipThrustVector.x=1f;
                    }
                    else if(kcode == KeyCode.S){
                        ShipThrustVector.y= -1f;
                    }
                    else if(kcode == KeyCode.W){
                        ShipThrustVector.y=1f;
                    }
                    else if(kcode == KeyCode.Q){
                        ShipThrustVector.z=-1f;
                    }
                    else if(kcode == KeyCode.E){
                        ShipThrustVector.z=1f;
                    }
                }

                if (Input.GetKey(kcode))
                {    
                    
                }

                if(TargetController){
                        if (ShipThrustVector!=OldThrust)
                        {
                            TargetController.Input(ShipThrustVector);
                            Debug.Log("Input Detected: " + ShipThrustVector);
                        }
                    }
                
            }
        }
    }
}
