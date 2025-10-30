using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class SwitchCameraTrigger : MonoBehaviour
{
    [SerializeField] GameObject camerasRoot;
    [SerializeField] CinemachineCamera newCam;
    [SerializeField] bool disableSelfAfter = true;
    List<CinemachineCamera> cinemachineCameras = new();

    private void Start()
    {
        if (camerasRoot == null)
        {
            Debug.LogWarning("No camera root!");
            return;
        }
        camerasRoot.GetComponentsInChildren<CinemachineCamera>(true, cinemachineCameras);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        newCam.gameObject.SetActive(true);
        DisableAllCameras();
        if (disableSelfAfter) gameObject.SetActive(false);
    }

    public void DisableAllCameras()
    {
        foreach (var cam in cinemachineCameras)
        {
            if (cam != newCam) cam.gameObject.SetActive(false);
        }
    }
}
