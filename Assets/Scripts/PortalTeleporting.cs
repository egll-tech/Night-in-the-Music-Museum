using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporting : MonoBehaviour
{

    //public int maxDistanceActivation;
    public GameObject player;
    public GameObject portalExit;
    public float height = 1.7f;
    public bool rotateCamera = false;

    private bool isTeleporting;
    private bool isMoving;
    

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Teleport()
    {

        //StartCoroutine(TeleportPlayer());
        DashMove(gameObject.transform.position);
    }

    public void DashMove(Vector3 location)
    {
        iTween.MoveTo(player,
            iTween.Hash(
                "position", new Vector3(location.x, player.transform.position.y, location.z),
                "time", .2F,
                "easetype", iTween.EaseType.linear,
                "oncomplete", "MovePlayerToPortalExit",
                "oncompletetarget", gameObject
            )
        );
    }

    public void MovePlayerToPortalExit()
    {
        player.transform.position = portalExit.transform.position;
        if (rotateCamera)
            player.transform.Rotate(portalExit.transform.rotation.eulerAngles);
    }
}
