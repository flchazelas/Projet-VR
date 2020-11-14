using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Jouer : MonoBehaviour
{
    GameObject plateforme;
    GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        plateforme = GameObject.Find("Area plateforme (6)");
        plateforme.SetActive(false);

        canvas = GameObject.Find("Canvas Tuto");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void jouer()
    {
        canvas.transform.Find("Consigne").GetComponent<TMP_Text>().text = "Début du jeu ! \n Atteignez la fin du parcours pour passer au niveau suivant !";
        StartCoroutine("Timer", 1f);
        GameObject.Find("Button Tuto").SetActive(false);
        GameObject.Find("Button Jouer").SetActive(false);
    }

    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        plateforme.SetActive(true);
        GameVariables.lockBouge = false;
        GameVariables.lockSaut = false;
        GameVariables.lockAccroupi = false;
        canvas.SetActive(false);
    }
}
