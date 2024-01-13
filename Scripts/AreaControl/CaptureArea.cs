using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureArea : MonoBehaviour
{
    private List<PlayerMapAreas> playerMapAreasList=new List<PlayerMapAreas>();
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent<PlayerMapAreas>(out PlayerMapAreas playerMapAreas))
        {
            playerMapAreasList.Add(playerMapAreas);
            Debug.Log("Player In Site");
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.TryGetComponent<PlayerMapAreas>(out PlayerMapAreas playerMapAreas))
        {
            playerMapAreasList.Remove(playerMapAreas);
        }
    }

    public List<PlayerMapAreas> GetPlayerMapAreasList()
    {
        return playerMapAreasList;
    }
}
