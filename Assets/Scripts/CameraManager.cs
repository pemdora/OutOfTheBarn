using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    // Manage Camera transition
    public Transform player;

    [Header("[Player Animation]")]
    public float playerAnimationSpeed;
    private Vector3 playerTargetPosition;


    [Header("[Camera Animation]")]
    [SerializeField]
    private Vector3 cameraVelocity = Vector3.zero;
    [SerializeField]
    private float cameraSmoothTime;
    //[HideInInspector]
    public bool cameraTransition;
    public bool walkAnimation;
    private Transform mainCamera;
    private Vector3 cameraTargetPosition;
    public bool nextDirectionRight;

    [SerializeField]
    private GameObject waypointsParent;
    [SerializeField]
    private Transform currentFrame;
    public Waypoint[] currentWaypoints; // waypoints of current Frame, each currentWaypoint have a WayPointScript

    public static CameraManager instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    private void Start() {
        mainCamera = this.transform;
        cameraTransition = false;
        cameraTargetPosition = this.transform.position;
        GetWaypoints();
        walkAnimation = false;
    }

    private void GetWaypoints(){
        currentWaypoints = currentFrame.GetComponentsInChildren<Waypoint>();
    }

    // Update is called once per frame
    private void Update () {
        if (!cameraTransition)
        {
            foreach (Waypoint childWaypoint in currentWaypoints) // Check each waypoints in the frame
            {
                if (Vector2.Distance(player.position, childWaypoint.transform.position) <= 0.3f && !cameraTransition)
                {
                    Waypoint waypoint = childWaypoint.GetComponent<Waypoint>();
                    cameraTransition = true;
                    walkAnimation = true;
                    CharacterManager.instance.blockaction = true;
                    CharacterManager.instance.horizontalMove = 0f;
                    cameraTargetPosition = waypoint.nextcameraPosition.position;
                    playerTargetPosition = waypoint.nextplayerPosition.position;
                    nextDirectionRight = waypoint.nextDirectionRight;
                    currentFrame = waypoint.nextFrame;
                    GetWaypoints();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (CharacterManager.instance.blockaction&&cameraTransition && Vector2.Distance(mainCamera.position, cameraTargetPosition) > 0.1f)
        {
            mainCamera.position = Vector3.SmoothDamp(mainCamera.position, cameraTargetPosition, ref cameraVelocity, cameraSmoothTime);
        }
        if (walkAnimation && CharacterManager.instance.blockaction && cameraTransition &&Vector2.Distance(player.position, playerTargetPosition) >= 0.3f)
        {
            Debug.Log(Vector2.Distance(player.position, playerTargetPosition));
            if (nextDirectionRight)
                player.position += Vector3.right * Time.deltaTime * playerAnimationSpeed;
            else
                player.position -= Vector3.right * Time.deltaTime * playerAnimationSpeed;
        }
        else if (cameraTransition&&Vector2.Distance(player.position, playerTargetPosition) < 0.3f)
        {
            Debug.Log("STOP walk");
            CharacterManager.instance.StopWalkingAnim();
            walkAnimation = false;
        }
        
        // Stop animation
        if (!walkAnimation && Vector2.Distance(player.position, playerTargetPosition) < 0.3f && Vector2.Distance(mainCamera.position, cameraTargetPosition) <= 0.1f)
        {
            Debug.Log("STOP transition");
            cameraTransition = false;
            mainCamera.position = cameraTargetPosition;
            CharacterManager.instance.blockaction = false;
        }
    }
    
}


