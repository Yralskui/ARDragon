using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class PlaneMarker : MonoBehaviour
{
    [SerializeField] private GameObject PlaneMarkerPrefab;
    [SerializeField] private Camera ARCamera;

    private ARRaycastManager ARRaycastManagerScript;

    public GameObject objectToSpawn;

    public GameObject scrollView;
    public bool ChooseObject = false;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject SelectedObject;
    private Vector2 TouchPosition;
    void Start()
    {
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();

        PlaneMarkerPrefab.SetActive(false);

        scrollView.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ChooseObject)
        {
            ShowMarker();
        }
        MoveObject();
    }

    void ShowMarker()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            PlaneMarkerPrefab.transform.position = hits[0].pose.position;
            PlaneMarkerPrefab.SetActive(true);
        }

        if ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(objectToSpawn, hits[0].pose.position, objectToSpawn.transform.rotation);
            ChooseObject = false;
            PlaneMarkerPrefab.SetActive(false);
        }
    }

    void MoveObject()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            TouchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = ARCamera.ScreenPointToRay(touch.position);
                RaycastHit hitobject;

                if (Physics.Raycast(ray,out hitobject))
                {
                    if (hitobject.collider.CompareTag("Unselected"))
                    {
                        hitobject.collider.gameObject.tag = "Selected";
                    }
                }
            }
        }
    }
}
