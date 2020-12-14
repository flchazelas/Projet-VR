using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiegeBehaviour : MonoBehaviour
{
    public GameObject anim;
    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.GetComponent<Animation>().Play();
            if(explosion != null)
            {
                StartCoroutine("Timer");
            }
        }
    }

    IEnumerator Timer()
    {
        explosion.Play();
        yield return new WaitForSeconds(1.5f);
        explosion.Stop();
    }
}
