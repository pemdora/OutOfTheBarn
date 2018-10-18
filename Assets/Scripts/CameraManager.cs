using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    // Manage Camera transition
    [Header("[Player Animation]")]
    public float playerAnimationSpeed;


    [Header("[Camera Animation]")]
    [SerializeField]
    private Vector3 cameraVelocity = Vector3.zero;
    [SerializeField]
    private float cameraSmoothTime;
    //[HideInInspector]
    public bool cameraTransition;
    public bool walkAnimation;

    private Transform mainCamera;
    [Header("[Default constants]")]
    public float playerX;
    public float cameraX;
    private Vector3 cameraTargetPosition;
    private Vector3 playerTargetPosition;

    public bool followplayer;
    


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
    private void Start()
    {
        mainCamera = this.transform;
        cameraTransition = false;
        walkAnimation = false;
        followplayer = false;
    }

    // Update is called once per frame
    private void Update()
    {}

    private void FixedUpdate()
    {
        if (!followplayer)
        {
            if (cameraTransition)
            {
                mainCamera.position = Vector3.SmoothDamp(mainCamera.position, cameraTargetPosition, ref cameraVelocity, cameraSmoothTime);

                // The step size is equal to speed times frame time.
                float step = playerAnimationSpeed * Time.deltaTime;

                // Move our position a step closer to the target.
                if (walkAnimation)
                    CharacterManager.instance.player.transform.position = Vector3.MoveTowards(CharacterManager.instance.player.transform.position, playerTargetPosition, step);

                if (Vector2.Distance(CharacterManager.instance.player.transform.position, playerTargetPosition) < 0.2f)
                {
                    walkAnimation = false;
                    CharacterManager.instance.StopWalkingAnim();
                }

                if ((Vector2.Distance(mainCamera.position, cameraTargetPosition) <= 0.1f) && !walkAnimation)
                {
                    mainCamera.position = cameraTargetPosition;
                    CharacterManager.instance.player.transform.position = playerTargetPosition;
                    CharacterManager.instance.blockaction = false;
                    cameraTransition = false;
                }
            }
        }
    }


    public void PlayChangingFrameAnimation()
    {   if (!followplayer)
        {
            if (!cameraTransition && !CharacterManager.instance.blockaction)
            {
                cameraTransition = true;
                walkAnimation = true;
                CharacterManager.instance.blockaction = true;
                if (CharacterManager.instance.rightDirection)
                {
                    cameraTargetPosition = this.mainCamera.position + new Vector3(cameraX, 0f, 0f);
                    playerTargetPosition = CharacterManager.instance.player.transform.position + new Vector3(playerX, 0f, 0f);
                }
                else
                {
                    cameraTargetPosition = this.mainCamera.position + new Vector3(-cameraX, 0f, 0f);
                    playerTargetPosition = CharacterManager.instance.player.transform.position + new Vector3(-playerX, 0f, 0f);
                }
            }
        }
        
    }


    public void ChangeCamera()
    {
        if (!followplayer)
        {
            followplayer = true;
            this.gameObject.transform.SetParent(CharacterManager.instance.player.transform);
        }
        
    }

}

