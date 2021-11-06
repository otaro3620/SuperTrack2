using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTutorial : MonoBehaviour
{
    public GameObject[] tutorial;
    public GameObject menuTutorial;
    public Tutorial scripTutorial;
    public int q;
    public int n;
    // Start is called before the first frame update
    void Start()
    {
        n = scripTutorial.n;
    }

    // Update is called once per frame
    void Update()
    {
        if (scripTutorial.q==0&&q==0&&n==0)
        {
            tutorial[0].SetActive(true);
            tutorial[1].SetActive(false);
            menuTutorial.SetActive(false);

        }
        else if (scripTutorial.q==1&&q==1||n==2)
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
