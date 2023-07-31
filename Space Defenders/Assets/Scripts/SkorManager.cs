using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkorManager : MonoBehaviour
{
    public float skor;
    public Text skorText;


    private void Start()
    {
        skorText = GetComponent<Text>();
        //skorText = GetComponent<Text>();
        skor = 0;
        
    }

    private void Update()
    {
        skorText.text = skor.ToString("0");
    }
}
