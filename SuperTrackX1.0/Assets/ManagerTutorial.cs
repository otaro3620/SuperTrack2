using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTutorial : MonoBehaviour
{
    public GameObject[] tutorial;
    public GameObject menuTutorial;
    public Tutorial scripTutorial;
    public int q;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (scripTutorial.q==0&&q==0)
        {
            tutorial[0].SetActive(true);
            tutorial[1].SetActive(false);
            menuTutorial.SetActive(false);

        }
        else if (scripTutorial.q==1&&q==0)
        {
            tutorial[1].SetActive(true);
            tutorial[0].SetActive(false);
            menuTutorial.SetActive(false);
            scripTutorial.q = 1;
        }
    }
    public void Turorial (int tutorial)
    {
        q = tutorial;
        scripTutorial.q = tutorial;
    }
}
