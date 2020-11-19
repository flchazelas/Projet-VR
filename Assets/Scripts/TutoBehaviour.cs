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
    }

    // Update is called once per frame
    void Update()
    {
        if (isTuto)
        {
            b1.SetActive(false);
            b2.SetActive(false);
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
                consigne.text = "Entrainez-vous à vous accroupir et à sauter ! \n Ensuite en jeu, regardez à droite et à gauche pour vous déplacer dans ces directions !";
                StartCoroutine("Timer", 10f);
            }
        }
    }

    public void setIsTuto()
    {
        isTuto = true;
        print(isTuto);
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
            StartCoroutine("TimerSaut", 2f);
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
            StartCoroutine("TimerSaut", 2f);
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
        }
    }

    IEnumerator TimerSaut(float time)
    {
        yield return new WaitForSeconds(time);
        saut = true;
        fin = true;
    }
    
    IEnumerator Timer(float time)
    {
        yield return new WaitForSeconds(time);
        isTuto = false;
        consigne.text = "";
        b1.SetActive(true);
        b2.SetActive(true);
    }
}
