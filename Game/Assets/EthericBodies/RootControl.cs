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
        public float camSpeed = .25f;
        public float panSpeed = .1f;
        public UnityEngine.UI.Text mouseDisp;
        public GameObject Target;
        private ShipControl TargetController;
        //TempVariable for demo purposes until i rebuild to be generalized
        Vector3 ShipThrustVector = new Vector3();
        Vector3 OldThrust = new Vector3();
        //camlock, if locked will control camera only
        private bool CamLock = false;

        private Vector3 oldMouse;
        void Start()
        {
            TargetController = Target.GetComponent(typeof(ShipControl)) as ShipControl;
            oldMouse = new Vector3();
            oldMouse.x = Input.mousePosition.x;
            oldMouse.y = Input.mousePosition.y;
            oldMouse.z = Input.mousePosition.z;

        }

        // Update is called once per frame

        //Need to think of a general control scheme
        void Update()
        {
            ShipThrustVector = new Vector3();
            Vector3 newMouse = new Vector3();
            newMouse.x = Input.mousePosition.x;
            newMouse.y = Input.mousePosition.y;
            newMouse.z = Input.mousePosition.z;

            Vector3 dMouse = (newMouse-oldMouse);
            
            mouseDisp.text = newMouse.ToString();
            foreach(KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyUp(kcode)){
                    Debug.Log("KeyCode up: " + kcode);
                    
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
                    else if (kcode == KeyCode.LeftControl){
                        CamLock = true;
                    }
                    else if (kcode == KeyCode.LeftAlt){
                        CamLock = !CamLock;
                    }
                    
                }

                if(Input.GetKeyDown(kcode)){
                    Debug.Log("KeyCode down: " + kcode);
                    if(kcode == KeyCode.A){
                        ShipThrustVector.x+=-1f;
                    }
                    else if(kcode == KeyCode.D){
                        ShipThrustVector.x+=1f;
                    }
                    else if(kcode == KeyCode.C){
                        ShipThrustVector.y+=-1f;
                    }
                    else if(kcode == KeyCode.Space){
                        ShipThrustVector.y+=1f;
                    }
                    else if(kcode == KeyCode.W){
                        ShipThrustVector.z+=-1f;
                    }
                    else if(kcode == KeyCode.S){
                        ShipThrustVector.z+=1f;
                    }
                    else if (kcode == KeyCode.LeftControl){
                        CamLock = true;
                    }
                }

                if (Input.GetKey(kcode))
                {    
                    
                }

                if (CamLock){
                    float dT = Time.deltaTime;
                    //camera controls
                    Debug.Log("CamStep; "+ ShipThrustVector.ToString()); 
                    this.transform.position += camSpeed * ShipThrustVector*dT;
                    Quaternion camRotate = Quaternion.Euler(0,dMouse.x*panSpeed*dT,0);
                    camRotate.Normalize();
                    this.transform.rotation *= camRotate;
                }
                else if (ShipThrustVector!=OldThrust){

                    //target controls, default ship target because i haven't generalized it yet
                    //eventually designed for player body and other controllable entities, and internal state changes
                    if(TargetController){
                        TargetController.Input(ShipThrustVector);
                        Debug.Log("Input Detected: " + ShipThrustVector);
                    }
                }


                //post loop stuff(update old states)
                OldThrust = ShipThrustVector;
                oldMouse = newMouse;
            }
        }
    }
}
