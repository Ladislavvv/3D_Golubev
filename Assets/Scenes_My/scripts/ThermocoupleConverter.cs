using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class ThermocoupleConverter : MonoBehaviour
{
    public Termopara TermoparaScript;

    // ���������� ��� �������� �������� � ������������ �� ���������
    public float millivolt;
    public float millivolt2;

    // ���������� ��� �������� �������� � ������������ ��� ��� 0399/�0
    public float milliampere;
    public float milliampere2;

    // ���������� ��� �������� �������� � �������� ������� �� ���������
    public float celsius;
    public float celsius2;

    // ���������� ��� �������� ������ �� ������ ������, ��� ���������� ���������� isBroken

    GameObject Korpus_1;
    public Korpus1 Korpus1;

    GameObject Korpus_2;
    public Korpus2 Korpus2;

    public Cables_Black1 cableScript1;
    public Cables_Black2 cableScript2;

    public Cables_Black3 cableScript3;
    public Cables_Black4 cableScript4;

    public Cables_Red1 red1;
    public Cables_Red2 red2;

    public Cables_Red3 red3;
    public Cables_Red4 red4;

    [SerializeField] TextMeshProUGUI milliVolOut;
    [SerializeField] TextMeshProUGUI celsiusOut;
    [SerializeField] TextMeshProUGUI milliAmpereOut;

    [SerializeField] TextMeshProUGUI milliVolOut2;
    [SerializeField] TextMeshProUGUI celsiusOut2;
    [SerializeField] TextMeshProUGUI milliAmpereOut2;

    void Start()
    {
        Korpus_1 = GameObject.Find("Korpus_1");
        Korpus_2 = GameObject.Find("Korpus_2");
        Korpus1 = Korpus_1.GetComponent<Korpus1>();
        Korpus2 = Korpus_2.GetComponent<Korpus2>();

        cableScript1 = GameObject.Find("Provod1").GetComponent<Cables_Black1>();
        cableScript2 = GameObject.Find("Provod2").GetComponent<Cables_Black2>();

        cableScript3 = GameObject.Find("Provod3").GetComponent<Cables_Black3>();
        cableScript4 = GameObject.Find("Provod4").GetComponent<Cables_Black4>();

        red1 = GameObject.Find("Red1").GetComponent<Cables_Red1>();
        red2 = GameObject.Find("Red2").GetComponent<Cables_Red2>();

        red3 = GameObject.Find("Red3").GetComponent<Cables_Red3>();
        red4 = GameObject.Find("Red4").GetComponent<Cables_Red4>();
        TermoparaScript = GameObject.Find("Termopara").GetComponent<Termopara>();
        StartCoroutine(UpdateParams());
    }

    // ������� ��� �������� �������� ������� � ����������� �� ����������� ��� 0399/�0
    public float CelsiusToMilliampere(float c)
    {
        // ����������� ��� 0399/�0 
        float minTemp = -50f; // ����������� ����������� � �������� �������
        float maxTemp = 600f; // ������������ ����������� � �������� �������
        float minSignal = 4f; // ����������� �������� ������ � ������������
        float maxSignal = 20f; // ������������ �������� ������ � ������������

        // �������� �� ����� �� ������� ���������
        if (c < minTemp || c > maxTemp)
        {
            Debug.LogError("�������� � �������� ������� ������� �� ������� ���������");
            return float.NaN;
        }

        // ���������������� ��������������
        float m = (maxSignal - minSignal) / (maxTemp - minTemp); // ����������� ������������������
        float b = minSignal - m * minTemp; // ��������

        // ������� ����������������� ��������������
        float ma = m * c + b;

        // ���������� ���������
        return ma;
    }

    public float MillivoltToCelsius(float x)
    {
        // �������� ������� ��������
        float minInput = 0f; // ����������� ������� ��������
        float maxInput = 25f; // ������������ ������� ��������

        // �������� �������� ��������
        float minOutput = -50f; // ����������� �������� ��������
        float maxOutput = 600f; // ������������ �������� ��������

        // �������� �� ����� �� ������� ���������
        if (x < minInput || x > maxInput)
        {
            Debug.LogError("�������� �������� ��������� ������� �� ������� ���������");
            return float.NaN;
        }

        // ���������������� ��������������
        float m = (maxOutput - minOutput) / (maxInput - minInput); // ����������� ������������������
        float b = minOutput - m * minInput; // ��������

        // ������� ����������������� ��������������
        float y = m * x + b;

        // ���������� ���������
        return y;
    }


    // ������� ��� �������� ��������� �������� �� ������� �������
    // public bool CheckWireState()
    // {
    //     // ���������, ���� �� ������ �� ������ ������
    //     //if (cable

    //// ���������, ���� �� ���������� isBroken � ������ �������
    //         //if (!cableScript.GetType().GetField("isBroken"))
    //         //{
    //         //    Debug.LogError("�� ������� ���������� isBroken � ������� Cables_Black");
    //         //    return false;
    //         //}

    //     // �������� �������� ���������� isBroken �� ������� �������
    //     bool isBroken = (bool)cableScript.GetType().GetField("isBroken").GetValue(cableScript);

    //     // ���������� ���������
    //     return !isBroken;
    // }

    // �������, ������� ���������� ��� ������� �����
    //void Start()
    //{
    //    // �������� ������� ��� �������� ������������ � ������� �������
    //    celsius = MillivoltToCelsius(millivolt);

    //    // �������� ������� ��� �������� �������� ������� � �����������
    //    milliampere = CelsiusToMilliampere(celsius);

    //    // �������� ������� ��� �������� ��������� ��������
    //    //bool wireState = CheckWireState();

    //    // ������� ��������� � �������
    //    Debug.Log("��: " + millivolt + " �C" + celsius + " ��" + milliampere);
    //    //Debug.Log("�������� � �������� �������: " + celsius + " �C");
    //    //Debug.Log("�������� � ������������: " + milliampere + " ��");
    //    //Debug.Log("��������� ��������: " + (wireState ? "�����" : "������"));
    //}

    //void Update()
    //{
    //    //System.Random random = new System.Random();
    //    //double randomNumber = random.NextDouble();
    //    //float randomFloat = (float)(randomNumber * 25);
    //    //millivolt = randomFloat;
    //    millivolt = TermoparaScript.GetVoltage();

    //    // �������� ������� ��� �������� ������������ � ������� �������
    //    celsius = MillivoltToCelsius(millivolt);

    //    // �������� ������� ��� �������� �������� ������� � �����������
    //    milliampere = CelsiusToMilliampere(celsius);

    //    // ������� ��������� � �������
    //    Debug.Log("��: " + millivolt + "     �C: " + celsius + "     ��: " + milliampere);
    //}

    IEnumerator UpdateParams()
    {
        if (this.gameObject == Korpus_1)
        {
            Debug.Log("Korpus_1");
            if (!cableScript1.isBroken && !cableScript2.isBroken && !red3.isBroken && !red4.isBroken && Korpus1.isPacked)
            {
                if (cableScript1.isPacked && cableScript2.isPacked && red3.isPacked && red4.isPacked)
                {
                    millivolt = TermoparaScript.GetVoltage();
                }
                else
                    millivolt = 0;
            }
            else
                millivolt = 0;
        }
        if (this.gameObject == Korpus_2)
        {
            Debug.Log("Korpus_2");
            if (!cableScript3.isBroken && !cableScript4.isBroken && !red1.isBroken && !red2.isBroken && Korpus2.isPacked)
            {
                if (cableScript3.isPacked && cableScript4.isPacked && red1.isPacked && red2.isPacked)
                {
                    millivolt2 = TermoparaScript.GetVoltage();
                    //��� ������ ��������� ����� ����������
                }
                else
                    millivolt2 = 0;
            }
            else
                millivolt2 = 0;
        }
        if(this.gameObject == Korpus_1)
        {
            celsius = MillivoltToCelsius(millivolt);
            milliampere = CelsiusToMilliampere(celsius);
        }

        if (this.gameObject == Korpus_2)
        {
            celsius2 = MillivoltToCelsius(millivolt2);
            milliampere2 = CelsiusToMilliampere(celsius2);
        }


        if (this.gameObject == Korpus_1)
        {
            milliVolOut.text = Math.Round(millivolt, 2).ToString() + " mV";
            celsiusOut.text = Math.Round(celsius, 2).ToString() + " �C";
            milliAmpereOut.text = Math.Round(milliampere, 2).ToString() + " mA";
        }
        if (this.gameObject == Korpus_2)
        {
            milliVolOut2.text = Math.Round(millivolt2, 2).ToString() + " mV";
            celsiusOut2.text = Math.Round(celsius2, 2).ToString() + " �C";
            milliAmpereOut2.text = Math.Round(milliampere2, 2).ToString() + " mA";
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(UpdateParams());
    }
}
    
