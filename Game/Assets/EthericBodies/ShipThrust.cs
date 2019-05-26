using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EtherRealm;

namespace EtherRealm{
    public class ShipThrust : MonoBehaviour
    {
        // Start is called before the first frame update
        Vector3 forceTarget = new Vector3();

        private EthericBody body = null;
        void Start()
        {
            Component  b = this.gameObject.GetComponent("EthericBody");
            body = (EthericBody)b;
        }

        // Update is called once per frame
        void Update()
        {
            body.ControlForce(forceTarget);
        }

        public void setTarget(Vector3 newTarget){
            if (newTarget != forceTarget)
            {
                Debug.Log("net targetForce = "+ newTarget.ToString());
                forceTarget = newTarget;
            }
        }
    }
}