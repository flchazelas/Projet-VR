using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameVariables
{
    public static int allowedTime = 0;
    public static int currentTime = GameVariables.allowedTime;

    public static int nbVie = 3;
    public static int niveauEnCours = 0;
    public static int score = 0;
    
    //Blocage des différentes actions
    public static bool lockSaut = true;
    public static bool lockAccroupi = true;
    public static bool lockBouge = true;
}
