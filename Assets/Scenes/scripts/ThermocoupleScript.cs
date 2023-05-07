using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static System.Random;

public class ThermocoupleScript : MonoBehaviour
{
    // ������������ ��� ��������� ���� L
    private const float a0 = -1.667f;
    private const float a1 = 25.343f;
    private const float a2 = -0.207608f;
    private const float a3 = 0.006602f;

    // ����������� � ������������ ����������� ���������
    private const float Tmin = -50f;
    private const float Tmax = 600f;

    // ����������� � ������������ ��� ��������� �������
    private const float Imin = 4f; // ��� t420
    private const float Imax = 20f; // ��� t420
    //private const float Imin = 0f; // ��� HE
    //private const float Imax = 5f; // ��� HE

    // ��� ��������� �������
    private string outputType = "t420"; // ��� "HE"

    // ������ �� ������� � ���������� isBroken ��� ������� �������
    public Cables_Black1 cable1;
    public Cables_Black2 cable2;
    public Cables_Black3 cable3;
    public Cables_Black4 cable4;

    // ������ �� ��������� ��������������� ��� 0399/�0
    //public IPMScript IPM;

    void Start()
    {
        //// �������� �������� ��� �� ��������� � ��
        ////float E = IPM.GetVoltage();

        //System.Random random = new System.Random();
        //double randomNumber = random.NextDouble();
        //float randomFloat = (float)(randomNumber * 50);
        //float E = randomFloat;

        //// �������� �������� ����������� �� ��������� � �C �� �������
        //float T = a0 + a1 * E + a2 * Mathf.Pow(E, 2) + a3 * Mathf.Pow(E, 3);

        //// ���������, �� �������� �� �������
        //if (cable1.isBroken || cable2.isBroken || cable3.isBroken || cable4.isBroken)
        //{
        //    // ������� ��������� �� ������ � ���������� ������
        //    Debug.LogError("One or more cables are broken!");
        //    return;
        //}

        //// �������� �������� ����������� � ��� � ������� ��� ��������� �������
        ////IPM.SetTemperature(T);
        ////IPM.SetOutputType(outputType);

        //// �������� �������� ���� �� ��� �� �������
        //float I = (T - Tmin) / (Tmax - Tmin) * (Imax - Imin) + Imin;

        //// ������� �������� ���� �� ����� ��� �������� ��� � ������ ������
        ////Debug.Log("Current: " + I + " mA");Voltage
        //Debug.Log("Current mV: " + E + " ___ Current mA: " + I + " mA" + " ___ T�C: " + T);
    }

    private void Update()
    {
        // �������� �������� ��� �� ��������� � ��
        //float E = IPM.GetVoltage();

        System.Random random = new System.Random();
        double randomNumber = random.NextDouble();
        float randomFloat = (float)(randomNumber * 50);
        float E = randomFloat;

        // �������� �������� ����������� �� ��������� � �C �� �������
        float T = a0 + a1 * E + a2 * Mathf.Pow(E, 2) + a3 * Mathf.Pow(E, 3);

        // ���������, �� �������� �� �������
        if (cable1.isBroken || cable2.isBroken || cable3.isBroken || cable4.isBroken)
        {
            // ������� ��������� �� ������ � ���������� ������
            Debug.LogError("One or more cables are broken!");
            return;
        }

        // �������� �������� ����������� � ��� � ������� ��� ��������� �������
        //IPM.SetTemperature(T);
        //IPM.SetOutputType(outputType);

        // �������� �������� ���� �� ��� �� �������
        float I = (T - Tmin) / (Tmax - Tmin) * (Imax - Imin) + Imin;

        // ������� �������� ���� �� ����� ��� �������� ��� � ������ ������
        //Debug.Log("Current: " + I + " mA");Voltage
        Debug.Log("mV: " + Math.Round(E, 1) + " mA: " + Math.Round(I, 1) + " mA" + " �C: " + Math.Round(T, 1));
    }
}
