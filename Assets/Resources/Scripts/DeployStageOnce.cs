using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class DeployStageOnce : MonoBehaviour
{


public void OnInteractiveHitTest(HitTestResult result)
    {
        var listenerBehaviour = GetComponent<AnchorInputListenerBehaviour>();
        if (listenerBehaviour != null)
        {
            listenerBehaviour.enabled = true;
        }
    }
}
