using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ThermocoupleConverter : MonoBehaviour
{
    // Переменная для хранения значения в милливольтах от термопары
    public float millivolt;

    // Переменная для хранения значения в миллиамперах для ИПМ 0399/М0
    public float milliampere;

    // Переменная для хранения значения в градусах Цельсия от термопары
    public float celsius;

    // Переменная для хранения ссылки на другой скрипт, где определена переменная isBroken
    public Cables_Black1 cableScript1;
    public Cables_Black2 cableScript2;
    public Cables_Black3 cableScript3;
    public Cables_Black4 cableScript4;

    // Функция для перевода милливольтов в градусы Цельсия по таблице градуировки для термопары типа L
    //public float MillivoltToCelsius(float mv)
    //{
    //    // Таблица градуировки для термопары типа L (извлечена из [1])
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

    //    // Проверка на выход за пределы диапазона
    //    if (mv < table[0, 1] || mv > table[table.GetLength(0) - 1, 1])
    //    {
    //        Debug.LogError("Значение в милливольтах выходит за пределы диапазона");
    //        return float.NaN;
    //    }

    //    // Поиск ближайших двух точек в таблице по значению в милливольтах
    //    int i = 0;
    //    while (mv > table[i + 1, 1])
    //    {
    //        i++;
    //    }

    //    // Интерполяция
    //    float x1 = table[i, 0]; // ближайшее значение температуры слева
    //    float x2 = table[i + 1, 0]; // ближайшее значение температуры справа
    //    float y1 = table[i, 1]; // ближайшее значение в милливольтах слева
    //    float y2 = table[i + 1, 1]; // ближайшее значение в милливольтах справа

    //    // Формула линейной интерполяции
    //    float x = y1 + (mv - y1) * (x2 - x1) / (y2 - y1);

    //    // Возвращаем результат
    //    return x;
    //}

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

    void Update()
    {
        System.Random random = new System.Random();
        double randomNumber = random.NextDouble();
        float randomFloat = (float)(randomNumber * 25);
        millivolt = randomFloat;

        // Вызываем функцию для перевода милливольтов в градусы Цельсия
        celsius = MillivoltToCelsius(millivolt);

        // Вызываем функцию для перевода градусов Цельсия в миллиамперы
        milliampere = CelsiusToMilliampere(celsius);

        // Выводим результат в консоль
        Debug.Log("мВ: " + millivolt + "     °C: " + celsius + "     мА: " + milliampere);
    }
}
    
