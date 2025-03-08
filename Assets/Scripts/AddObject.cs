using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddObject : MonoBehaviour
{

    private Button button;
    private PlaneMarker planeMarkerScript;
    // Start is called before the first frame update
    void Start()
    {
        planeMarkerScript = FindObjectOfType<PlaneMarker>();
        button = GetComponent<Button>();
        button.onClick.AddListener(addObject);
    }

    void addObject()
    {
        planeMarkerScript.scrollView.SetActive(true);
    }
}
