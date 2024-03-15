using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;using UnityEngine.SceneManagement;

public class DeathText : MonoBehaviour
{
    TextMeshPro texto;
    RectTransform rectTransform;

    private float timeElapsed=0f,timeToFade=2;
    // Start is called before the first frame update
    void Awake()
    {
        rectTransform=GetComponent<RectTransform>();
        texto=GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeElapsed>=timeToFade)
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
