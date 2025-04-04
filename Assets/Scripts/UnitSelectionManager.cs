using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectionManager : MonoBehaviour
{
    public static UnitSelectionManager instance { get; set; }
    
    public List<GameObject> allUnitsList=new List<GameObject>();
    public List<GameObject> unitsSelected=new List<GameObject>();

    public LayerMask clickables;
    public LayerMask ground;
    public GameObject groundMarker;

    private Camera cam;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cam = ReferanceManager.instance.mainCamera;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickables))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    MultipleSelect(hit.collider.gameObject);
                }

                else
                {
                    SelectByClicking(hit.collider.gameObject);
                }
            }

            else
            {
                if (!Input.GetKey(KeyCode.LeftShift))
                {
                    DeselectAll();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && unitsSelected.Count>0)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickables))
            {
                groundMarker.transform.position=hit.point;
                groundMarker.SetActive(false);
                groundMarker.SetActive(true);
            }
        }
    }

    private void SelectUnit(GameObject unit, bool trigger)
    {
        TriggerSelection(unit, trigger);
        EnableUnitMovement(unit, trigger);
    }

    private void MultipleSelect(GameObject unit)
    {
        if(!unitsSelected.Contains(unit))
        {
            unitsSelected.Add(unit);
            SelectUnit(unit, true);
        }

        else
        {
            SelectUnit(unit, false);
            unitsSelected.Remove(unit);
        }
    }

    private void DeselectAll()
    {
        foreach(var unit in unitsSelected)
        {
            SelectUnit(unit, false);
        }

        groundMarker.SetActive(false);
        unitsSelected.Clear();
    }

    private void SelectByClicking(GameObject unit)
    {
        DeselectAll();
        unitsSelected.Add(unit);

        SelectUnit(unit, true);
    }

    private void EnableUnitMovement(GameObject unit,bool trigger)
    {
        unit.GetComponent<UnitMovement>().enabled = trigger;
    }

    private void TriggerSelection(GameObject unit,bool isVisible)
    {
        unit.transform.GetChild(0).gameObject.SetActive(isVisible);
    }

    internal void DragSelect(GameObject unit)
    {
        if(!unitsSelected.Contains(unit))
        {
            unitsSelected.Add(unit);
            SelectUnit(unit, true);
        }
    }
}
