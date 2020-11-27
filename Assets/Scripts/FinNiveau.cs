using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinNiveau : MonoBehaviour
{
    GameObject image;

    // Start is called before the first frame update
    void Start()
    {
        image = GameObject.Find("Image degradee");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            image.SetActive(true);
            GameVariables.lockBouge = true;
            image.GetComponent<Animation>().Play("Image degradee");
            StartCoroutine("Timer");
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Scenes/Niveau " + GameVariables.niveauEnCours);
    }
}
