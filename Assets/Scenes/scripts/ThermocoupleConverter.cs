using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ThermocoupleConverter : MonoBehaviour
{
    // ���������� ��� �������� �������� � ������������ �� ���������
    public float millivolt;

    // ���������� ��� �������� �������� � ������������ ��� ��� 0399/�0
    public float milliampere;

    // ���������� ��� �������� �������� � �������� ������� �� ���������
    public float celsius;

    // ���������� ��� �������� ������ �� ������ ������, ��� ���������� ���������� isBroken
    public Cables_Black1 cableScript1;
    public Cables_Black2 cableScript2;
    public Cables_Black3 cableScript3;
    public Cables_Black4 cableScript4;

    // ������� ��� �������� ������������ � ������� ������� �� ������� ����������� ��� ��������� ���� L
    //public float MillivoltToCelsius(float mv)
    //{
    //    // ������� ����������� ��� ��������� ���� L (��������� �� [1])
    //    float[,] table = new float[,]
    //    {
    //        {-10f, -0.403f},
    //        {0f, 0f},
    //        {10f, 0.404f},
    //        {20f, 0.809f},
    //        {30f, 1.215f},
    //        {40f, 1.622f},
    //        {50f, 2.030f},
    //        {60f, 2.440f},
    //        {70f, 2.851f},
    //        {80f, 3.263f},
    //        {90f, 3.677f},
    //        {100f, 4.092f},
    //        {110f, 4.509f},
    //        {120f, 4.927f},
    //        {130f, 5.347f},
    //        {140f, 5.768f},
    //        {150f, 6.191f},
    //        {160f, 6.615f},
    //        {170f, 7.041f},
    //        {180f, 7.468f},
    //        {190f, 7.897f},
    //        {200f, 8.327f},
    //        {210f, 8.759f},
    //        {220f, 9.192f},
    //        {230f, 9.627f},
    //        {240f, 10.063f},
    //        {250f, 10.501f}
    //    };

    //    // �������� �� ����� �� ������� ���������
    //    if (mv < table[0, 1] || mv > table[table.GetLength(0) - 1, 1])
    //    {
    //        Debug.LogError("�������� � ������������ ������� �� ������� ���������");
    //        return float.NaN;
    //    }

    //    // ����� ��������� ���� ����� � ������� �� �������� � ������������
    //    int i = 0;
    //    while (mv > table[i + 1, 1])
    //    {
    //        i++;
    //    }

    //    // ������������
    //    float x1 = table[i, 0]; // ��������� �������� ����������� �����
    //    float x2 = table[i + 1, 0]; // ��������� �������� ����������� ������
    //    float y1 = table[i, 1]; // ��������� �������� � ������������ �����
    //    float y2 = table[i + 1, 1]; // ��������� �������� � ������������ ������

    //    // ������� �������� ������������
    //    float x = y1 + (mv - y1) * (x2 - x1) / (y2 - y1);

    //    // ���������� ���������
    //    return x;
    //}

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

    void Update()
    {
        System.Random random = new System.Random();
        double randomNumber = random.NextDouble();
        float randomFloat = (float)(randomNumber * 25);
        millivolt = randomFloat;

        // �������� ������� ��� �������� ������������ � ������� �������
        celsius = MillivoltToCelsius(millivolt);

        // �������� ������� ��� �������� �������� ������� � �����������
        milliampere = CelsiusToMilliampere(celsius);

        // ������� ��������� � �������
        Debug.Log("��: " + millivolt + "     �C: " + celsius + "     ��: " + milliampere);
    }
}
    
