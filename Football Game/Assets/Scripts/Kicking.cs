using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kicking : MonoBehaviour
{
    Transform bootTransform;
    // Start is called before the first frame update
    void Start()
    {
        bootTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            MoveBoot();
        }
        if (Input.GetKeyUp("space"))
        {
            ResetBoot();
        }
    }

    void MoveBoot()
    {
        bootTransform.Rotate(0f, 0f, 50f);
    }

    void ResetBoot()
    {
        bootTransform.Rotate(0f, 0f, -50f);
    }
}
