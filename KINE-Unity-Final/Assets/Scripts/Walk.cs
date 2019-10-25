using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class Walk : MonoBehaviour
    {

        public SteamVR_Action_Vector2 walkingAction;
        public Hand hand;
        public GameObject player;

        private void OnEnable()
        {
            if (hand == null)
                hand = this.GetComponent<Hand>();

            if (walkingAction == null)
            {
                Debug.LogError("<b>[SteamVR Interaction]</b> No walking action assigned"); return;
            }

            walkingAction.AddOnChangeListener(OnWalkingActionChange, hand.handType);
        }

        private void OnDisable()
        {
            
        }

        private void OnWalkingActionChange(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta)
        {
            Debug.Log("AXIS VECTOR: " + axis);
            Debug.Log("DELTA VECTOR: " + delta);
        }

    }
}
