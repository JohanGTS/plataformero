using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{

    Collider2D col;


    public List<Collider2D> DetectionList = new List<Collider2D>();

    // Start is called before the first frame update
    void Awake()
    {
        col= GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D colision)
    {
        DetectionList.Add(colision);
    }

    private void OnTriggerExit2D(Collider2D colision)
    {
        DetectionList.Remove(colision);
    }
}
