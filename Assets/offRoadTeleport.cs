using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class offRoadTeleport : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    private Vector3 hitPoint;

    

    // Update is called once per frame
    void Update()
    {


        if (SteamVR_Input.GetStateDown("offRoadTeleport", SteamVR_Input_Sources.LeftHand))
        {
            Ray raycast = new(transform.position, transform.forward);
            RaycastHit hit;

            bool bHit = Physics.Raycast(raycast, out hit);
            if (bHit)
            {
                hitPoint = hit.point;
                print(hit.point);

                gameObject.GetComponent<LineRenderer>().SetPosition(0, transform.position);
                gameObject.GetComponent<LineRenderer>().SetPosition(1, hitPoint);
            }
        }
        if (SteamVR_Input.GetStateUp("offRoadTeleport", SteamVR_Input_Sources.LeftHand))
        {
            playerPrefab.transform.position = hitPoint;
        }

    }
}
