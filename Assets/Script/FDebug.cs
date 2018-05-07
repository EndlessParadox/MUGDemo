using UnityEngine;
using System.Collections;

//火游Debug,强！无敌！
public class FDebug {
    public static void Log(object szLog)
    {
        if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            Debug.Log(szLog);
        }
    }

    public static void LogWarning(object szLog)
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            Debug.LogWarning(szLog);
        }
    }

    public static void LogError(object szLog)
    {
        Debug.LogError(szLog);
    }
}
