using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeMouvante : MonoBehaviour
{
    [System.Serializable]
    public struct PathBot
    {
        public float timeTravel;
        public Transform routes;
    }

    [SerializeField]
    private PathBot[] routes;
    private int routeToGo;
    private float tParam;
    private Vector3 position;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        routeToGo = 0;
        tParam = 0f;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        move();
    }

    public void move()
    {
        if (routes.Length > 0) GoByRoute();
    }

    protected void GoByRoute()
    {

        if (routes[routeToGo].routes != null)
        {
            Vector3 p0 = routes[routeToGo].routes.GetChild(0).position;
            Vector3 p1 = routes[routeToGo].routes.GetChild(1).position;
            Vector3 p2 = routes[routeToGo].routes.GetChild(2).position;
            Vector3 p3 = routes[routeToGo].routes.GetChild(3).position;
            float percentT = tParam / routes[routeToGo].timeTravel;
            position = Mathf.Pow(1 - percentT, 3) * p0 +
                    3 * Mathf.Pow(1 - percentT, 2) * percentT * p1 +
                    3 * (1 - percentT) * Mathf.Pow(percentT, 2) * p2 +
                    Mathf.Pow(percentT, 3) * p3;
            transform.position = new Vector3(position.x, position.y, position.z);
        }
        else
        {
            transform.position = routes[(routeToGo + 1) % routes.Length].routes.GetChild(0).position;
        }

        tParam += Time.deltaTime;
        tParam = tParam >= routes[routeToGo].timeTravel ? routes[routeToGo].timeTravel : tParam;

        if (tParam == routes[routeToGo].timeTravel)
        {
            routeToGo = (routeToGo + 1) % routes.Length;
            tParam = 0;
        }
    }
}
