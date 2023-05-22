using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.UI;

public class Termopara : MonoBehaviour
{
    [SerializeField] InputField inputGradus;
    [SerializeField] UnityEngine.UI.Button tempNagreva; // кнопка огонька
    [SerializeField] TextMeshProUGUI Temp; // Вывод температуры слева на спрайте огонька
    [SerializeField] AnimProvod provodLeft; // в данном классе получаем событие левого провода 
    [SerializeField] AnimProvod provodRight; // в данном классе получаем событие правого провода 
    [SerializeField] TextMeshProUGUI EdsInp; // ЭДС слева выводится
    [SerializeField] TextMeshProUGUI EdsOut; // ЭДС справа выводится (на табло)
    [SerializeField] TextMeshProUGUI TempOut; // Вывод температуры на табло справа
    [SerializeField] Graduirovka GradLeft; // градуировка слева
    [SerializeField] Graduirovka GradRight; // градуировка справа   
    private float T2 = 25f; // температура измерения
    private float T2r; // выводим темперутуру спава на табло
    private float T1 = 25f; // комнатная температура
    private float deltaT;
    private float EdsLeft;
    private bool flagOpen = false;

    public float voltage;
    // Start is called before the first frame update
    void Start()
    {
        tempNagreva.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (float.Parse(inputGradus.text) > 600)
            T2 = 600f;
        else if (float.Parse(inputGradus.text) < 30)
            T2 = 30;
        else
            T2 = float.Parse(inputGradus.text);
    }

    void Update()
    {
        Temp.text = Math.Round(T2, 1).ToString();
        // считаем ЭДС слева
        deltaT = T2 - T1;
        EdsLeft = deltaT * GradLeft.alpha / 1000;
        EdsInp.text = "e = " + Math.Round(EdsLeft, 3).ToString() + " мВ";
        if (provodLeft.isOpen || provodRight.isOpen)
        {
            TempOut.text = 25.ToString();

            voltage = 0;
            EdsOut.text = voltage.ToString();
        }
        else
        {
            EdsOut.text = Math.Round(EdsLeft, 3).ToString();
            voltage = (float)Math.Round(EdsLeft, 3);
            T2r = T1 + EdsLeft * 1000 / GradRight.alpha; // считаем Температуру справа
            TempOut.text = Math.Round(T2r, 1).ToString(); // выводим температуру справа
        }
    }

    public float GetVoltage()
    {
        return voltage;
    }
}
