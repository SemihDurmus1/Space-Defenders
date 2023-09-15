using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanManager : MonoBehaviour
{
    public float can;
    public Text canText;

    [SerializeField] GameObject panelOyunBitti;
    [SerializeField] GameObject joystick;

    [SerializeField] Button buttonPause;

    void Start()
    {
        canText = GetComponent<Text>();

        panelOyunBitti.SetActive(false);
        can = 100;
    }

    // Update is called once per frame
    void Update()
    {
        canText.text = can.ToString("0");

        if (can <= 0)
        {
            can = 0;

            panelOyunBitti.SetActive(true);
            buttonPause.gameObject.SetActive(false);
            joystick.gameObject.SetActive(false);

            Time.timeScale = 0;
        }
    }
}
