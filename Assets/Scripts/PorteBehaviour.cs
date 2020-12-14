using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteBehaviour : MonoBehaviour
{
    Animation anim;
    public ParticleSystem fumee;

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
        fumee.Play();
    }
}
