using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.MPE;
using UnityEngine;

public class Termopara : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Button tempNagreva; // ������ �������
    [SerializeField] TextMeshProUGUI Temp; // ����� ����������� ����� �� ������� �������
    [SerializeField] AnimProvod provodLeft; // � ������ ������ �������� ������� ������ ������� 
    [SerializeField] AnimProvod provodRight; // � ������ ������ �������� ������� ������� ������� 
    [SerializeField] TextMeshProUGUI EdsInp; // ��� ����� ���������
    [SerializeField] TextMeshProUGUI EdsOut; // ��� ������ ��������� (�� �����)
    [SerializeField] TextMeshProUGUI TempOut; // ����� ����������� �� ����� ������
    [SerializeField] Graduirovka GradLeft; // ����������� �����
    [SerializeField] Graduirovka GradRight; // ����������� ������   
    private float T2 = 25f; // ����������� ���������
    private float T2r; // ������� ����������� ����� �� �����
    private float T1 = 25f; // ��������� �����������
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
        if (flagOpen)
            flagOpen = false;
        else flagOpen = true;
    }

    void Update()
    {
        Temp.text = Math.Round(T2, 1).ToString();
        if (flagOpen)
        {
            T2 += Time.deltaTime * 10; // ����������� ����� ����������
        }
        // ������� ��� �����
        deltaT = T2 - T1;
        EdsLeft = deltaT * GradLeft.alpha / 1000;
        EdsInp.text = "e = " + Math.Round(EdsLeft, 3).ToString() + " ��";
        if (provodLeft.isOpen || provodRight.isOpen)
        {
            TempOut.text = (T2-25).ToString();

            EdsOut.text = ((deltaT - 25)* GradRight.alpha / 1000).ToString();
            voltage = ((deltaT - 25) * GradRight.alpha / 1000);
            //Debug.Log("voltage: " + voltage);
        }
        else
        {
            EdsOut.text = Math.Round(EdsLeft, 3).ToString();
            voltage = (float)Math.Round(EdsLeft, 3);
            T2r = T1 + EdsLeft * 1000 / GradRight.alpha; // ������� ����������� ������
            TempOut.text = Math.Round(T2r, 1).ToString(); // ������� ����������� ������
        }
    }

    public float GetVoltage()
    {
        return voltage;
    }
}
