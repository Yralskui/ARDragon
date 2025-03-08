using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseObject : MonoBehaviour
{

    private PlaneMarker planeMarkerScript;
    private Button button;
    public GameObject choosedObject;

    // Start is called before the first frame update
    void Start()
    {
        planeMarkerScript = FindObjectOfType<PlaneMarker>();
        button = GetComponent<Button>();
        button.onClick.AddListener(chooseObject);
    }

    void chooseObject()
    {
        planeMarkerScript.objectToSpawn = choosedObject;
        planeMarkerScript.scrollView.SetActive(false);
        planeMarkerScript.ChooseObject = true;
    }
}
