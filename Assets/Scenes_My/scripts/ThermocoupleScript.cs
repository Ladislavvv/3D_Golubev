using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static System.Random;

public class ThermocoupleScript : MonoBehaviour
{
    // Коэффициенты для термопары типа L
    private const float a0 = -1.667f;
    private const float a1 = 25.343f;
    private const float a2 = -0.207608f;
    private const float a3 = 0.006602f;

    // Минимальная и максимальная температура измерения
    private const float Tmin = -50f;
    private const float Tmax = 600f;

    // Минимальный и максимальный ток выходного сигнала
    private const float Imin = 4f; // для t420
    private const float Imax = 20f; // для t420
    //private const float Imin = 0f; // для HE
    //private const float Imax = 5f; // для HE

    // Тип выходного сигнала
    private string outputType = "t420"; // или "HE"

    // Ссылки на скрипты с переменной isBroken для каждого провода
    public Cables_Black1 cable1;
    public Cables_Black2 cable2;
    public Cables_Black3 cable3;
    public Cables_Black4 cable4;

    // Ссылка на модульный преобразователь ИПМ 0399/М0
    //public IPMScript IPM;

    void Start()
    {
        //// Получить значение ЭДС от термопары в мВ
        ////float E = IPM.GetVoltage();

        //System.Random random = new System.Random();
        //double randomNumber = random.NextDouble();
        //float randomFloat = (float)(randomNumber * 50);
        //float E = randomFloat;

        //// Получить значение температуры от термопары в °C по формуле
        //float T = a0 + a1 * E + a2 * Mathf.Pow(E, 2) + a3 * Mathf.Pow(E, 3);

        //// Проверить, не обрезаны ли провода
        //if (cable1.isBroken || cable2.isBroken || cable3.isBroken || cable4.isBroken)
        //{
        //    // Вывести сообщение об ошибке и остановить скрипт
        //    Debug.LogError("One or more cables are broken!");
        //    return;
        //}

        //// Передать значение температуры в ИПМ и выбрать тип выходного сигнала
        ////IPM.SetTemperature(T);
        ////IPM.SetOutputType(outputType);

        //// Получить значение тока от ИПМ по формуле
        //float I = (T - Tmin) / (Tmax - Tmin) * (Imax - Imin) + Imin;

        //// Вывести значение тока на экран или передать его в другой скрипт
        ////Debug.Log("Current: " + I + " mA");Voltage
        //Debug.Log("Current mV: " + E + " ___ Current mA: " + I + " mA" + " ___ T°C: " + T);
    }

    private void Update()
    {
        // Получить значение ЭДС от термопары в мВ
        //float E = IPM.GetVoltage();

        System.Random random = new System.Random();
        double randomNumber = random.NextDouble();
        float randomFloat = (float)(randomNumber * 50);
        float E = randomFloat;

        // Получить значение температуры от термопары в °C по формуле
        float T = a0 + a1 * E + a2 * Mathf.Pow(E, 2) + a3 * Mathf.Pow(E, 3);

        // Проверить, не обрезаны ли провода
        if (cable1.isBroken || cable2.isBroken || cable3.isBroken || cable4.isBroken)
        {
            // Вывести сообщение об ошибке и остановить скрипт
            Debug.LogError("One or more cables are broken!");
            return;
        }

        // Передать значение температуры в ИПМ и выбрать тип выходного сигнала
        //IPM.SetTemperature(T);
        //IPM.SetOutputType(outputType);

        // Получить значение тока от ИПМ по формуле
        float I = (T - Tmin) / (Tmax - Tmin) * (Imax - Imin) + Imin;

        // Вывести значение тока на экран или передать его в другой скрипт
        //Debug.Log("Current: " + I + " mA");Voltage
        Debug.Log("mV: " + Math.Round(E, 1) + " mA: " + Math.Round(I, 1) + " mA" + " °C: " + Math.Round(T, 1));
    }
}
