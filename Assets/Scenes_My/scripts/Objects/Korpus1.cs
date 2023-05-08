using UnityEngine;
using UnityEngine.EventSystems;

public class Korpus1 : MonoBehaviour, IPointerClickHandler
{

    public bool isPacked = true;

    public GameObject[] cables_black;
    public GameObject[] CabeliBigRed;
    public Planka Planka;

    public Animation anim;


    public main Main;



    void Start()
    {
        cables_black[0] = GameObject.Find("Provod1");
        cables_black[1] = GameObject.Find("Provod2");

        CabeliBigRed[0] = GameObject.Find("Red5");
        CabeliBigRed[1] = GameObject.Find("Red6");
    }

    public void OnPointerClick(PointerEventData eventData)
    {


        if (isPacked && isAllPackedBlack() && isAllPackedRed())
        {
            anim.Play("Korpus1");
            Debug.Log(gameObject.name);
            isPacked = false;
        }
        else if(!isPacked && isAllPackedBlack() && isAllPackedRed() && Planka.isPacked)
        {
            anim.Play("Korpus1R");
            Debug.Log(gameObject.name);
            isPacked = true;
        }
        else
        {
            Debug.Log("Error: Провода не отсоединены!");
        }
    }

    public bool isAllPackedBlack()
    {
        
        if (!cables_black[0].GetComponent<Cables_Black1>().isPacked &&
            !cables_black[1].GetComponent<Cables_Black2>().isPacked)
        {
            return true;
        }

        return false;
    }

    //public bool isAllUnPackedBlack()
    //{

    //    if (!cables_black[0].GetComponent<Cables_Black1>().isPacked &&
    //        !cables_black[1].GetComponent<Cables_Black2>().isPacked)
    //    {
    //        return true;
    //    }

    //    return false;
    //}

    public bool isAllPackedRed()
    {

        if (!CabeliBigRed[0].GetComponent<Cables_Red5>().isPacked &&
            !CabeliBigRed[1].GetComponent<Cables_Red6>().isPacked)
        {
            return true;
        }
        return false;
    }
}
