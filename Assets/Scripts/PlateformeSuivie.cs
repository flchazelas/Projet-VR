using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeSuivie : PlateformeMouvante
{
    bool estDessus = false;
    GameObject player;

    public bool EstDessus { get => estDessus; set => estDessus = value; }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        if (EstDessus)
        {
            move();
            player.GetComponent<Rigidbody>().MovePosition(new Vector3(transform.position.x, player.transform.position.y, transform.position.z));
            //player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        /*
        if (estDessus)
        {
            move();
            player.GetComponent<Rigidbody>().MovePosition(new Vector3(transform.position.x, player.transform.position.y, transform.position.z));
            //player.transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameVariables.lockBouge = true;
            EstDessus = true;
        }
    }
}
