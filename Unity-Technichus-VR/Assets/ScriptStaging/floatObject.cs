using System.Collections;
using UnityEngine;

public class floatObject : MonoBehaviour
{
    public float degreesPerSecond = 10.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Start is called before the first frame update
    //Gets the position at start to the vector
    void Start()
    {
        posOffset = transform.position;
    }

    // Update is called once per frame
    //Sends the object up and down 
    void Update()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = tempPos;
    }
}
