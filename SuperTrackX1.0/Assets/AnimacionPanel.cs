using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionPanel : MonoBehaviour
{
    public Animator animacionPanel;
    public int az;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (az==1)
        {
            animacionPanel.SetInteger("Open", 1);
        }
        if (az==0)
        {
            animacionPanel.SetInteger("Open", 0);
        }
    }
    public void AnimaPanel(int a)
    {
        az = a;
    }
}
