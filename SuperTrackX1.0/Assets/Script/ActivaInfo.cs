using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaInfo : MonoBehaviour
{
    public GameObject[] Info;
    public int x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Info[x].SetActive(true);
    }
}
