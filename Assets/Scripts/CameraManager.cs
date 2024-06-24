using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public GameObject virtualCameraPrefab;
    private GameObject currentVirtualCamera;

    void Start()
    {
        InstantiateVirtualCamera();
    }

    void InstantiateVirtualCamera()
    {
        if (virtualCameraPrefab == null)
        {
            currentVirtualCamera = Instantiate(virtualCameraPrefab, Vector3.zero, Quaternion.identity);
        }
        else
        {
            currentVirtualCamera = virtualCameraPrefab;
        }
        ConfigureVirtualCamera(currentVirtualCamera.GetComponent<CinemachineVirtualCamera>());

    }

    void ConfigureVirtualCamera(CinemachineVirtualCamera virtualCamera)
    {
        if (virtualCamera != null)
        {
            // Set the follow and look at targets, assuming you have player or target GameObjects in the scene
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                virtualCamera.Follow = player.transform;
            }

            // Additional configuration, if needed
        }
    }
}
