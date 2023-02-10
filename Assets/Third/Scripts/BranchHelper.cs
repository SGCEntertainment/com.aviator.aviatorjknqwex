using UnityEngine;

public class BranchHelper : MonoBehaviour
{
    private void Start()
    {
        if (BranchData.Instance.enableLogging)
        {
            Branch.setDebug();
        }

        // disable tracking of analytics for the user
        Branch.setTrackingDisabled(false);

        Branch.initSession(CallbackWithBranchUniversalObject);
    }

    public void CallbackWithBranchUniversalObject(BranchUniversalObject universalObject, BranchLinkProperties linkProperties, string error)
    {
        if (error != null)
        {
            Debug.LogError("Branch Error: " + error);
        }
        else
        {
            Debug.Log("Branch initialization completed: ");

            Debug.Log("Universal Object: " + universalObject.ToJsonString());
            Debug.Log("Link Properties: " + linkProperties.ToJsonString());
        }
    }
}