using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToCarry : MonoBehaviour {

    [HideInInspector]
    public static ObjectToCarry instance = null;
    public enum Type {key};
    public int id;
    public bool keyFall;

    public float keyGroundYPosition;
    public float keyFallspeed = 2f;

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
    void Start () { }

    // Dedicated for physics, Called a fixed amount (fixed amount of time per second) 
    public void FixedUpdate()
    {
        if (keyFall && this.transform.position.y >= keyGroundYPosition) // cant move player when a cinematic is playing
        {
            this.transform.position -= new Vector3(0f, keyFallspeed*Time.deltaTime, 0f);
        }
        else if (keyFall && this.transform.position.y < keyGroundYPosition) // cant move player when a cinematic is playing
        {
            keyFall = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (CharacterManager.instance.objectInteraction)
            CharacterManager.instance.CarryObject(this.gameObject);
    }

    public void KeyFall()
    {
        keyFall = true;
    }
}
