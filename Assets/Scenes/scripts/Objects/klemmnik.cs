using UnityEngine;
using UnityEngine.EventSystems;

public class klemmnik : MonoBehaviour, IPointerClickHandler
{
    public bool isPacked = true;

    public GameObject[] cables_black;
    public GameObject[] CabeliBigRed;
    public Planka Planka;

    public Animation anim;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isPacked && isAllPackedBlack() && isAllPackedRed())
        {
            anim.Play("Klemmnik");
            Debug.Log(gameObject.name);
            isPacked = false;
            Debug.Log(isPacked);
        }
        else if(!isPacked && isAllPackedBlack() && isAllPackedRed() && Planka.isPacked)
        {
            anim.Play("KlemmnikR");
            Debug.Log(gameObject.name);
            isPacked = true;
            Debug.Log(isPacked);
        }
        else
        {
            Debug.Log("Error: Провода не отсоединены!");
        }
    }
    public bool isAllPackedBlack()
    {

        if (!cables_black[0].GetComponent<Cables_Black1>().isPacked &&
            !cables_black[1].GetComponent<Cables_Black2>().isPacked &&
            !cables_black[2].GetComponent<Cables_Black3>().isPacked &&
            !cables_black[3].GetComponent<Cables_Black4>().isPacked)
        {
            return true;
        }
        return false;
    }

    public bool isAllPackedRed()
    {

        if (!CabeliBigRed[0].GetComponent<Cables_Red1>().isPacked &&
            !CabeliBigRed[1].GetComponent<Cables_Red2>().isPacked &&
            !CabeliBigRed[2].GetComponent<Cables_Red3>().isPacked &&
            !CabeliBigRed[3].GetComponent<Cables_Red4>().isPacked)
        {
            return true;
        }
        return false;
    }
}
