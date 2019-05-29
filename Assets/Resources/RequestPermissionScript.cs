using UnityEngine;
using UnityEngine.Android;
using Vuforia;

public class RequestPermissionScript : MonoBehaviour
{
    private bool mVuforiaInitialized = false;
    
    void Start()
    {
        if (Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            InitializeVuforia();
        }
        else
        {
            Permission.RequestUserPermission(Permission.Camera);
        }
    }

    void Update()
    {
        if (!mVuforiaInitialized && Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            InitializeVuforia();
        }
    }

    private void InitializeVuforia()
    {
        VuforiaRuntime.Instance.InitVuforia();
        GetComponent<VuforiaBehaviour>().enabled = true;
        mVuforiaInitialized = true;
    }
}
