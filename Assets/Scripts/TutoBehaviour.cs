using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutoBehaviour : MonoBehaviour
{
    private bool isTuto;
    private Camera mainCamera;

    GameObject b1;
    GameObject b2;
    GameObject canvas;
    GameObject plateforme;
    GameObject player;

    TMP_Text consigne;
    Image cercle;
    Image cercle1;

    bool bas = false;
    bool haut = false;
    bool saut = false;
    bool fin = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        isTuto = false;
        b1 = GameObject.Find("Button Tuto");
        b2 = GameObject.Find("Button Jouer");
        canvas = GameObject.Find("Canvas Tuto");
        consigne = canvas.transform.Find("Consigne").GetComponent<TMP_Text>();
        cercle = canvas.transform.Find("Cercle").GetComponent<Image>();
        cercle1 = canvas.transform.Find("Cercle 1").GetComponent<Image>();
        cercle.enabled = false;
        cercle1.enabled = false;

        player = GameObject.Find("Player");
        plateforme = GameObject.Find("Area plateforme (1)");
        plateforme.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTuto)
        {
            if (!bas) {
                regarderEnBas();
            }
            else if (!haut)
            {
                regarderEnHaut();
            }
            else if (saut)
            {
                GameVariables.lockAccroupi = true;
                sauter();
            }
            else if(fin)
            {
                GameVariables.lockAccroupi = false;
                consigne.text = "Entrainez-vous à vous accroupir et à sauter ! \n Ensuite en jeu, regardez à droite et à gauche pour vous déplacer dans ces directions ! \n Vous avez 30 secondes de test !";
                StartCoroutine("Timer", 10f);
            }
        }
    }

    public void setIsTuto()
    {
        isTuto = true;
        b1.SetActive(false);
        b2.SetActive(false);
    }

    public void regarderEnBas() {
        bool fait = false;
        GameVariables.lockAccroupi = false;
        cercle1.enabled = true;
        consigne.text = "Veuillez viser la croix inférieure pour vous accroupir !";

        if (mainCamera.transform.forward.y < -0.5f && !fait)
        {
            fait = true;
            cercle1.enabled = false;
            bas = true;
        }
    }

    public void regarderEnHaut()
    {
        bool fait = false;
        cercle.enabled = true;
        consigne.text = "Veuillez viser la croix supérieure pour vous relever !";

        if (mainCamera.transform.forward.y > 0.3f && !fait)
        {
            fait = true;
            cercle.enabled = false;
            StartCoroutine("TimerSaut", 1f);
            consigne.text = "";
            haut = true;
        }
    }

    public void sauter()
    {
        bool fait = false;
        GameVariables.lockSaut = false;
        cercle.enabled = true;
        consigne.text = "Veuillez viser la croix supérieure pour sauter !";

        if (mainCamera.transform.forward.y > 0.3f && !fait)
        {
            fait = true;
            cercle.enabled = false;
            saut = false;
            fin = true;
        }
    }

    IEnumerator TimerSaut(float time)
    {
        yield return new WaitForSeconds(time);
        saut = true;
    }
    
    IEnumerator Timer(float time)
    {
        isTuto = false;
        yield return new WaitForSeconds(time);
        consigne.text = "";
        canvas.SetActive(false);
        GameVariables.lockBouge = false;
        GameVariables.lockSaut = false;
        GameVariables.lockAccroupi = false;
        plateforme.SetActive(true);
        StartCoroutine("Tuto", 30f);
    }

    IEnumerator Tuto(float time)
    {
        yield return new WaitForSeconds(time);
        canvas.SetActive(true);
        GameVariables.lockBouge = true;
        GameVariables.lockSaut = true;
        GameVariables.lockAccroupi = true;
        player.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        plateforme.SetActive(false);
        b1.SetActive(true);
        b2.SetActive(true);
    }
}
