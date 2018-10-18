using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToCarry : MonoBehaviour {

    [HideInInspector]
    public enum Type { key, waterBucket};
    public Type type;
    public int id;
    public bool objectFall;
    public bool objectUp;

    public float objectGroundYPosition;
    public float objectUpYPosition;
    public float objectAnimationSpeed = 2f;

    // Use this for initialization
    void Start () { }

    // Dedicated for physics, Called a fixed amount (fixed amount of time per second) 
    public void FixedUpdate()
    {
        if (objectUp && this.transform.position.y <= objectUpYPosition)
        {
            this.transform.position += new Vector3(0f, objectAnimationSpeed * Time.deltaTime, 0f);
        }
        else if (objectUp && this.transform.position.y > objectUpYPosition)
        {
            objectUp = false;
        }
        
        if (objectFall && this.transform.position.y >= objectGroundYPosition)
        {
            this.transform.position -= new Vector3(0f, objectAnimationSpeed*Time.deltaTime, 0f);
        }
        else if (objectFall && this.transform.position.y < objectGroundYPosition) 
        {
            objectFall = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (CharacterManager.instance.carryButtonDown && !CharacterManager.instance.blockaction)
            CharacterManager.instance.CarryObject(this.gameObject);
    }

    public void ObjFall()
    {
        objectFall = true;
    }

    public void ObjUp()
    {
        objectUp = true;
    }
}
