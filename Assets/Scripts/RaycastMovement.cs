using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class RaycastMovement : MonoBehaviour
{
    private GvrPointerPhysicsRaycaster raycastHolder;
    private GameObject player;
    public GameObject raycastIndicator;

    public float height = 1.7f;
    public float maxMoveDistance = 15;

    private bool isMoving = false;
    private RaycastHit hit;
    

    void Start()
    {
        raycastHolder = gameObject.GetComponent<GvrPointerPhysicsRaycaster>();
        player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forwardDir = raycastHolder.transform.TransformDirection(Vector3.forward) * 100;
        //Debug.DrawRay (raycastHolder.transform.position, forwardDir, Color.green);

        if (Physics.Raycast(raycastHolder.transform.position, (forwardDir), out hit))
        {
            if (hit.collider.gameObject.tag == "MovementCapable")
            {
                ManageIndicator();
                if (hit.distance <= maxMoveDistance)
                {
                    //If the indicator isn't active already make it active.
                    ActivateIndicator();
                    if (Input.GetMouseButtonDown(0))
                    {
                        DashMove(hit.point);
                    }
                }
                else
                {
                    DeactivateIndicator();
                }
            }

        }

    }
    public void ManageIndicator()
    {
        if (isMoving != true)
        {
            raycastIndicator.transform.position = hit.point;
        }
        if (Vector3.Distance(raycastIndicator.transform.position, player.transform.position) <= 2.5)
        {
            isMoving = false;
        }
    }
    public void DashMove(Vector3 location)
    {
        isMoving = true;
        iTween.MoveTo(player,
            iTween.Hash(
                "position", new Vector3(location.x, location.y + height, location.z),
                "time", .2F,
                "easetype", "linear"
            )
        );
    }

    public void ActivateIndicator()
    {
        if (raycastIndicator.activeSelf == false)
        {
            raycastIndicator.SetActive(true);
        }
    }

    public void DeactivateIndicator()
    {
        if (raycastIndicator.activeSelf)
        {
            raycastIndicator.SetActive(false);
        }
    }
}
