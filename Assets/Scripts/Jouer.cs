using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jouer : MonoBehaviour
{
    GameObject plateforme;
    GameObject canvas;
    GameObject image;

    Text nbVie;

    // Start is called before the first frame update
    void Start()
    {
        GameVariables.lockBouge = false;
        GameVariables.lockSaut = false;
        GameVariables.lockAccroupi = false;
        canvas = GameObject.Find("Canvas Tuto");
        nbVie = GameObject.Find("NbVie").GetComponent<Text>();

        image = GameObject.Find("Image degradee");
        image.SetActive(false);
        if (GameVariables.niveauEnCours != 0)
        {
            image.SetActive(true);
            image.GetComponent<Animation>().clip = image.GetComponent<Animation>().GetClip("Image degradee inversee");
            image.GetComponent<Animation>().Play();
            StartCoroutine("Timer2", 2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        nbVie.text = "Nombre de vie : "+GameVariables.nbVie;

        if (GameVariables.nbVie <= 0)
        {
            if (GameVariables.niveauEnCours != 1)
            {
                GameVariables.niveauEnCours--;
            }
            GameVariables.nbVie = 3;
            SceneManager.LoadScene("Niveau " + GameVariables.niveauEnCours);
            StartCoroutine("Timer3", 2f);
        }
    }

    public void jouer()
    {
        GameObject.Find("Button Tuto").SetActive(false);
        GameObject.Find("Button Jouer").SetActive(false);

        StartCoroutine("Timer");
    }

    IEnumerator Timer()
    {
        GameVariables.niveauEnCours = 1;
        canvas.transform.Find("Consigne").GetComponent<TMP_Text>().text = "Début du jeu ! \n Atteignez la fin du parcours pour passer au niveau suivant !";
        yield return new WaitForSeconds(2);
        image.SetActive(true);
        image.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Scenes/Niveau "+GameVariables.niveauEnCours);
    }

    IEnumerator Timer2(float time)
    {
        GameVariables.lockBouge = true;
        GameVariables.lockSaut = true;
        GameVariables.lockAccroupi = true;
        yield return new WaitForSeconds(time);
        GameVariables.lockBouge = false;
        GameVariables.lockSaut = false;
        GameVariables.lockAccroupi = false;
        image.SetActive(false);
    }
    
    IEnumerator Timer3(float time)
    {
        /*image.SetActive(true);
        image.GetComponent<Animation>().clip = image.GetComponent<Animation>().GetClip("Image degradee");
        image.GetComponent<Animation>().Play();
        GameVariables.nbVie = 3;*/
        GameVariables.lockBouge = true;
        GameVariables.lockSaut = true;
        GameVariables.lockAccroupi = true;
        yield return new WaitForSeconds(time);
        GameVariables.lockBouge = false;
        GameVariables.lockSaut = false;
        GameVariables.lockAccroupi = false;
        /*SceneManager.LoadScene("Niveau " + GameVariables.niveauEnCours);*/
    }
}
