using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EtherRealm;

namespace Control{
    public class ShipControl : MonoBehaviour
    {
        // Start is called before the first frame update

        //temp controller
        private Vector3 ForceTarget = new Vector3();
        public float speed;

        //links to other relavent components

        ShipThrust thrusters = null;
        EthericBody body = null;
        void Start()
        {
            thrusters = gameObject.GetComponent(typeof(ShipThrust)) as ShipThrust;
            body = gameObject.GetComponent(typeof(EthericBody)) as EthericBody;

        }

        // Update is called once per frame
        void Update()
        {
            thrusters.setTarget(ForceTarget*speed);

        }

        public void Input(Vector3 targetforce){
            
            ForceTarget = targetforce*speed;
            Debug.Log("Ship Controller Target: "+ ForceTarget);
        }
    }

}
