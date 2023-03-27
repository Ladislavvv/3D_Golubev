using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Front_Box : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        //if(eventData.pointerId == -1)
        //{
        //    Debug.Log("Click");
        //}

        if (eventData.pointerPress != null)
        {
            GameObject clickedObject = eventData.pointerPress.gameObject;
            // Debug.Log("Object Nme: " + clickedObject.name);
            if (clickedObject.transform.IsChildOf(transform))
            {
                // The clicked object is a child of this parent object
                Debug.Log("Clicked on child object: " + clickedObject.name);
            }
        }

        //if( Planka.gameObject.name)

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
