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
            if(GameVariables.niveauEnCours != 5)
            {
                GameVariables.niveauEnCours++;
                image.SetActive(true);
                GameVariables.lockBouge = true;
                image.GetComponent<Animation>().Play("Image degradee");
                StartCoroutine("Timer");
            }
            else
            {
                GameVariables.niveauEnCours = 0;
                image.SetActive(true);
                GameVariables.lockBouge = true;
                image.GetComponent<Animation>().Play("Image degradee");
                GameVariables.score = CalculScore();
                GameObject.Find("Fin").GetComponent<Text>().text = "Félicitation !\nVous avez fini le jeu !\nVotre score est de "+GameVariables.score + " points";
                GameObject.Find("Fin").GetComponent<Text>().enabled = true;
                StartCoroutine("Timer2");
            }
        }
    }

    public int CalculScore()
    {
        int score = 0;
        int time = GameVariables.currentTime;
        score = 3000 - time;
        return score;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Scenes/Niveau " + GameVariables.niveauEnCours);
    }

    IEnumerator Timer2()
    {
        yield return new WaitForSeconds(10);
        GameVariables.currentTime = GameVariables.allowedTime;
        GameObject.Find("Fin").GetComponent<Text>().enabled = false;
        SceneManager.LoadScene("Scenes/SampleScene");
    }
}
