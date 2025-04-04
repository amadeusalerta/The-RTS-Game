using UnityEngine;

public class ReferanceManager : MonoBehaviour
{
    public static ReferanceManager instance;

    public Camera mainCamera;

    private void Awake()
    {
        instance = this;
    }
}
