using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapArea : MonoBehaviour
{
    private enum State{
    Neutral,
    Captured,
    }
    private List<CaptureArea> captureAreasList;
    private State state;
    private float progress;

    private void Awake()
    {
        captureAreasList=new List<CaptureArea>();
        foreach(Transform child in transform)
        {
            CaptureArea captureArea=child.GetComponent<CaptureArea>();
            if(captureArea!=null)
            {
                captureAreasList.Add(captureArea);
            }
        }

        state=State.Neutral;
    }

    private void Update()
    {
        switch(state)
        {
            case State.Neutral:
            List<PlayerMapAreas>PlayerMapAreasInsideList=new List<PlayerMapAreas>();
                foreach(CaptureArea captureArea in captureAreasList)
                {
                    foreach(PlayerMapAreas playerMapAreas in captureArea.GetPlayerMapAreasList())
                    {
                        if(!PlayerMapAreasInsideList.Contains(playerMapAreas))
                        {
                            PlayerMapAreasInsideList.Add(playerMapAreas);
                        }
                    }
                }

                float progressSpeed=1f;
                progress+=PlayerMapAreasInsideList.Count*progressSpeed*Time.deltaTime;

                Debug.Log("playerCountInsideMapArea:"+PlayerMapAreasInsideList.Count+";Progress:"+progress);
                if(progress>=1f)
                {
                    state=State.Captured;
                    Debug.Log("Captured");

                }
            break;
            case State.Captured:
            break;
        }

    }
}
