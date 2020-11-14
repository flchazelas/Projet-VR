using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoutonBehaviour : MonoBehaviour
{
    Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activer()
    {
        anim.Play();
    }
}
