using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Hand : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform headCameraTransform;

    [Header("Tweaking")]
    [SerializeField] private E_HandType handType;

    List<XRNodeState> nodesStates = new List<XRNodeState>();
    private XRNodeState controllerNode;
    private Vector3 controllerPosition;
    private Vector3 lastKnowedControllerPosition;
    private Quaternion controllerRotation;
    private Quaternion lastKnowedControllerRotation;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateControllerNode();
        if (controllerNode.tracked)
        {
            controllerNode.TryGetPosition(out controllerPosition);
            controllerNode.TryGetRotation(out controllerRotation);

            if (controllerPosition != Vector3.zero)
                lastKnowedControllerPosition = controllerPosition;
            if (controllerRotation != Quaternion.identity)
                lastKnowedControllerRotation = controllerRotation;

            //Debug.Log($"controller {controllerNode.nodeType} is tracked and its position = {controllerPosition}", this);
        }
        else
        {
            Debug.Log($"controller {controllerNode.nodeType} is not tracked", this);
        }
        transform.localPosition = lastKnowedControllerPosition;
        transform.localRotation = lastKnowedControllerRotation;
    }

    /// <summary>
    /// Try to get the XR controller to setup the hand
    /// </summary>
    /// <returns>Return true if it has succeeded to find the controller</returns>
    private bool UpdateControllerNode()
    {
        InputTracking.GetNodeStates(nodesStates);
        foreach (XRNodeState s in nodesStates)
        {
            if (handType == E_HandType.Left)
            {
                if (s.nodeType == XRNode.LeftHand)
                {
                    controllerNode = s;
                    return true;
                }
            }
            else
            {
                if (s.nodeType == XRNode.RightHand)
                {
                    controllerNode = s;
                    return true;
                }
            }
        }
        return false;
    }
}

enum E_HandType
{
    Left,
    Right
}
