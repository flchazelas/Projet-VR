﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Camera mainCamera;
    public float speed = 2f;
    public float speedJump = 200f;
    bool peutSauter;
    bool peutaccroupir;

    Rigidbody r;
    BoxCollider b;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        r = GetComponent<Rigidbody>();
        b = transform.Find("Corps").GetComponent<BoxCollider>();
        peutSauter = true;
        peutaccroupir = true;
    }

    private void FixedUpdate()
    {
        //transform.position = new Vector3(transform.position.x + mainCamera.transform.forward.x * speed * Time.deltaTime, 1, transform.position.z + mainCamera.transform.forward.z * speed * Time.deltaTime);
        if (!GameVariables.lockBouge)
        {
            r.MovePosition(new Vector3(transform.position.x + mainCamera.transform.forward.x * speed * Time.deltaTime, transform.position.y, transform.position.z + mainCamera.transform.forward.z * speed * Time.deltaTime));
        }

        if (mainCamera.transform.forward.y > 0.3f && peutSauter && !GameVariables.lockSaut)
        {
            r.AddForce(new Vector3(r.velocity.x, r.velocity.y + speedJump, r.velocity.z));
            peutSauter = false;
        }

        if (mainCamera.transform.forward.y < -0.5f && peutaccroupir && !GameVariables.lockAccroupi)
        {
            //b.size = new Vector3(b.size.x, b.size.y - 0.5f, b.size.z);
            transform.Find("Corps").localScale = new Vector3(transform.Find("Corps").localScale.x, transform.Find("Corps").localScale.y - 0.5f, transform.Find("Corps").localScale.z);
            speed /= 2f;
            speedJump /= 1.5f;
            peutaccroupir = false;
            peutSauter = false;
        }
        else if (mainCamera.transform.forward.y > 0.3f && !peutaccroupir && !GameVariables.lockAccroupi)
        {
            //b.size = new Vector3(b.size.x, b.size.y + 0.5f, b.size.z);
            transform.Find("Corps").localScale = new Vector3(transform.Find("Corps").localScale.x, transform.Find("Corps").localScale.y + 0.5f, transform.Find("Corps").localScale.z);
            speed *= 2f;
            speedJump *= 1.5f;
            peutaccroupir = true;
            StartCoroutine("TimerSaut");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("plateforme") && peutaccroupir)
        {
            peutSauter = true;
        }
    }

    IEnumerator TimerSaut()
    {
        yield return new WaitForSeconds(0.5f);
        peutSauter = true;
    }
}
