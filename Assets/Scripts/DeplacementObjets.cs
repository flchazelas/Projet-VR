using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementObjets : MonoBehaviour
{
    GameObject mainCamera;
    bool deplacer = false;

    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (deplacer)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(GetComponent<Rigidbody>().velocity.x + mainCamera.transform.forward.x * speed, GetComponent<Rigidbody>().velocity.y + mainCamera.transform.forward.y * speed, GetComponent<Rigidbody>().velocity.z));
        }
    }

    public void SetIsDeplacer()
    {
        deplacer = true;
    }

    public void SetIsNotDeplacer()
    {
        deplacer = false;
    }
}
