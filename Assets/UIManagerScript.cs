using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    public GameObject textoMuerte;
    public Canvas  gameCanvas;
    // Start is called before the first frame update
    void CharacterDied(GameObject character)
    {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);    
        TMP_Text text = Instantiate(textoMuerte,spawnPosition,Quaternion.identity,gameCanvas.transform)
            .GetComponent<TMP_Text>() ;   

        text.text="HAS MUERTO";
    }
        
    // Update is called once per frame
    void Awake()
    {
        gameCanvas= FindObjectOfType<Canvas>();
    }
}
