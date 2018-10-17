using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public Transform player;
    public Transform waypoint1;

    private Vector3 cameraTargetPosition;
    private Transform mainCamera;
    private Vector3 velocity = Vector3.zero;
    private bool cameraChanged;
    [SerializeField]
    private float cameraSmoothTime;


    public GameObject currentFrame;
    public Transform[] currentWaypoints;
    public GameObject[] frames;

    // Use this for initialization
    void Start() {
        mainCamera = this.transform;
        cameraChanged = false;
        cameraTargetPosition = this.transform.position;
        currentFrame = frames[0];
        GetWaypoints();
    }

    private void GetWaypoints(){
        currentWaypoints = currentFrame.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    private void Update () {

        foreach (Transform child in currentWaypoints)
        {
            if (Vector2.Distance(player.position, child.position) <= 0.5f && !cameraChanged)
            {
                cameraChanged = true;
                cameraTargetPosition = new Vector3(16f, 0.0f, -10f);
                currentFrame = frames[1];
            }
        }
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(mainCamera.position, cameraTargetPosition) >= 0.001f)
            mainCamera.position = Vector3.SmoothDamp(mainCamera.position, cameraTargetPosition, ref velocity, cameraSmoothTime);
    }
}
