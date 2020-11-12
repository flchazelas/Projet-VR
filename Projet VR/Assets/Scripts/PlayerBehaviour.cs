using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Camera mainCamera;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + mainCamera.transform.forward.x * speed * Time.deltaTime, 1, transform.position.z + mainCamera.transform.forward.z * speed * Time.deltaTime);
    }
}
