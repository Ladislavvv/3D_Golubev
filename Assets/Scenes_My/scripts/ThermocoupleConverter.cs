using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class ThermocoupleConverter : MonoBehaviour
{
    public Termopara TermoparaScript;

    // Переменная для хранения значения в милливольтах от термопары
    public float millivolt;
    public float millivolt2;

    // Переменная для хранения значения в миллиамперах для ИПМ 0399/М0
    public float milliampere;
    public float milliampere2;

    // Переменная для хранения значения в градусах Цельсия от термопары
    public float celsius;
    public float celsius2;

    // Переменная для хранения ссылки на другой скрипт, где определена переменная isBroken

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

    // Функция для перевода градусов Цельсия в миллиамперы по градуировке ИПМ 0399/М0
    public float CelsiusToMilliampere(float c)
    {
        // Градуировка ИПМ 0399/М0 
        float minTemp = -50f; // минимальная температура в градусах Цельсия
        float maxTemp = 600f; // максимальная температура в градусах Цельсия
        float minSignal = 4f; // минимальный выходной сигнал в миллиамперах
        float maxSignal = 20f; // максимальный выходной сигнал в миллиамперах

        // Проверка на выход за пределы диапазона
        if (c < minTemp || c > maxTemp)
        {
            Debug.LogError("Значение в градусах Цельсия выходит за пределы диапазона");
            return float.NaN;
        }

        // Пропорциональное преобразование
        float m = (maxSignal - minSignal) / (maxTemp - minTemp); // коэффициент пропорциональности
        float b = minSignal - m * minTemp; // смещение

        // Формула пропорционального преобразования
        float ma = m * c + b;

        // Возвращаем результат
        return ma;
    }

    public float MillivoltToCelsius(float x)
    {
        // Диапазон входных значений
        float minInput = 0f; // минимальное входное значение
        float maxInput = 25f; // максимальное входное значение

        // Диапазон выходных значений
        float minOutput = -50f; // минимальное выходное значение
        float maxOutput = 600f; // максимальное выходное значение

        // Проверка на выход за пределы диапазона
        if (x < minInput || x > maxInput)
        {
            Debug.LogError("Значение входного параметра выходит за пределы диапазона");
            return float.NaN;
        }

        // Пропорциональное преобразование
        float m = (maxOutput - minOutput) / (maxInput - minInput); // коэффициент пропорциональности
        float b = minOutput - m * minInput; // смещение

        // Формула пропорционального преобразования
        float y = m * x + b;

        // Возвращаем результат
        return y;
    }


    // Функция для проверки состояния проводов из другого скрипта
    // public bool CheckWireState()
    // {
    //     // Проверяем, есть ли ссылка на другой скрипт
    //     //if (cable

    //// Проверяем, есть ли переменная isBroken в другом скрипте
    //         //if (!cableScript.GetType().GetField("isBroken"))
    //         //{
    //         //    Debug.LogError("Не найдена переменная isBroken в скрипте Cables_Black");
    //         //    return false;
    //         //}

    //     // Получаем значение переменной isBroken из другого скрипта
    //     bool isBroken = (bool)cableScript.GetType().GetField("isBroken").GetValue(cableScript);

    //     // Возвращаем результат
    //     return !isBroken;
    // }

    // Функция, которая вызывается при запуске сцены
    //void Start()
    //{
    //    // Вызываем функцию для перевода милливольтов в градусы Цельсия
    //    celsius = MillivoltToCelsius(millivolt);

    //    // Вызываем функцию для перевода градусов Цельсия в миллиамперы
    //    milliampere = CelsiusToMilliampere(celsius);

    //    // Вызываем функцию для проверки состояния проводов
    //    //bool wireState = CheckWireState();

    //    // Выводим результат в консоль
    //    Debug.Log("мВ: " + millivolt + " °C" + celsius + " мА" + milliampere);
    //    //Debug.Log("Значение в градусах Цельсия: " + celsius + " °C");
    //    //Debug.Log("Значение в миллиамперах: " + milliampere + " мА");
    //    //Debug.Log("Состояние проводов: " + (wireState ? "норма" : "авария"));
    //}

    //void Update()
    //{
    //    //System.Random random = new System.Random();
    //    //double randomNumber = random.NextDouble();
    //    //float randomFloat = (float)(randomNumber * 25);
    //    //millivolt = randomFloat;
    //    millivolt = TermoparaScript.GetVoltage();

    //    // Вызываем функцию для перевода милливольтов в градусы Цельсия
    //    celsius = MillivoltToCelsius(millivolt);

    //    // Вызываем функцию для перевода градусов Цельсия в миллиамперы
    //    milliampere = CelsiusToMilliampere(celsius);

    //    // Выводим результат в консоль
    //    Debug.Log("мВ: " + millivolt + "     °C: " + celsius + "     мА: " + milliampere);
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
                    //тут вторую термопару нужно подключить
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
            celsiusOut.text = Math.Round(celsius, 2).ToString() + " °C";
            milliAmpereOut.text = Math.Round(milliampere, 2).ToString() + " mA";
        }
        if (this.gameObject == Korpus_2)
        {
            milliVolOut2.text = Math.Round(millivolt2, 2).ToString() + " mV";
            celsiusOut2.text = Math.Round(celsius2, 2).ToString() + " °C";
            milliAmpereOut2.text = Math.Round(milliampere2, 2).ToString() + " mA";
        }
        yield return new WaitForSeconds(1);
        StartCoroutine(UpdateParams());
    }
}
    
