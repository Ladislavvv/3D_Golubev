using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public GameObject canvasUI; // —сылка на объект Canvas UI в иерархии сцены
    public bool a = false;
    // Start is called before the first frame update
    void Start()
    {
        canvasUI.SetActive(!canvasUI.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            // ѕереключаем видимость Canvas UI
            canvasUI.SetActive(!canvasUI.activeSelf);
            a = !a;
        }
    }
}
