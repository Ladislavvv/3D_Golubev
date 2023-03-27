using UnityEngine;
using UnityEngine.EventSystems;

public class main : MonoBehaviour, IPointerClickHandler
{
    #region gdfg
    // Передняя крышка
    public GameObject Front_Box;
    #endregion

    #region dfgdfg
    // Корпус
    public GameObject Main_Box;
    #endregion
    // Клеммник
    public GameObject Klemmnik;

    public GameObject Klemmnik_Center1;
    public GameObject Klemmnik_Center2;
    public GameObject Klemmnik_Center3;
    public GameObject Klemmnik_Center4;
    public GameObject Klemmnik_Center5;

    public GameObject Klemmnik_Left;
    public GameObject Klemmnik_Right;

    public GameObject Klemmnik_Vint1;
    public GameObject Klemmnik_Vint2;

    // Винты крышки
    public GameObject Big_Vints;

    public GameObject Big_Vint1;
    public GameObject Big_Vint2;
    public GameObject Big_Vint3;
    public GameObject Big_Vint4;

    // Кабели
    public GameObject Cables_red;

    public GameObject Cable_Red1;
    public GameObject Cable_Red2;
    public GameObject Cable_Red3;
    public GameObject Cable_Red4;

    public GameObject Cables_black;

    public GameObject Cable_black1;
    public GameObject Cable_black2;
    public GameObject Cable_black3;
    public GameObject Cable_black4;

    // Планка
    public GameObject Planka;
    public GameObject Planka_Vint1;
    public GameObject Planka_Vint2;


    // Корпус 1
    public GameObject Korpus1;

    public GameObject Korpus1_Vints;
    public GameObject Korpus1_Vint1;
    public GameObject Korpus1_Vint2;
    public GameObject Korpus1_Vint3;
    public GameObject Korpus1_Vint4;
    public GameObject Korpus1_Vint5;
    public GameObject Korpus1_Vint6;
    public GameObject Korpus1_Vint7;
    public GameObject Korpus1_Vint8;

    // Корпус 2
    public GameObject Korpus2;

    public GameObject Korpus2_Vints;
    public GameObject Korpus2_Vint1;
    public GameObject Korpus2_Vint2;
    public GameObject Korpus2_Vint3;
    public GameObject Korpus2_Vint4;
    public GameObject Korpus2_Vint5;
    public GameObject Korpus2_Vint6;
    public GameObject Korpus2_Vint7;
    public GameObject Korpus2_Vint8;

    public void OnPointerClick(PointerEventData eventData)
    {
        //if(eventData.pointerId == -1)
        //{
        //    Debug.Log("Click");
        //}

        if (eventData.pointerPress != null)
        {
            GameObject clickedObject = eventData.pointerPress.gameObject;
            if (clickedObject.transform.IsChildOf(transform))
            {
                // The clicked object is a child of this parent object
                Debug.Log("Clicked on child object: " + clickedObject.name);
                Debug.Log(Korpus2_Vints.name);
            }
        }

        //if( Planka.gameObject.name)

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
