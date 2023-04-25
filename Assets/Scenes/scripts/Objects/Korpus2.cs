using UnityEngine;
using UnityEngine.EventSystems;

public class Korpus2 : MonoBehaviour, IPointerClickHandler
{

    public bool isPacked = true;

    public GameObject[] cables_black;
    public GameObject[] CabeliBigRed;
    public Planka Planka;

    public Animation anim;

    void Start()
    {
        //cables_black[0] = GameObject.Find("Provod1");
        //cables_black[1] = GameObject.Find("Provod2");

        //Debug.Log(cables_black[0]+" "+ cables_black[1]);

        //CabeliBigRed[0] = GameObject.Find("Red7");
        //CabeliBigRed[1] = GameObject.Find("Red8");
    }

    public void OnPointerClick(PointerEventData eventData)
    {


        if (isPacked && isAllPackedBlack() && isAllPackedRed())
        {
            anim.Play("Korpus2");
            Debug.Log(gameObject.name);
            isPacked = false;
        }
        else if (!isPacked && isAllPackedBlack() && isAllPackedRed() && Planka.isPacked)
        {
            anim.Play("Korpus2R");
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

        if (!cables_black[0].GetComponent<Cables_Black3>().isPacked &&
            !cables_black[1].GetComponent<Cables_Black4>().isPacked )
        {
            return true;
        }
        return false;
    }

    public bool isAllPackedRed()
    {

        if (!CabeliBigRed[0].GetComponent<Cables_Red7>().isPacked &&
            !CabeliBigRed[1].GetComponent<Cables_Red8>().isPacked)
        {
            return true;
        }
        return false;
    }
}
