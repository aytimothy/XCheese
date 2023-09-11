using System;
using BepInEx;
using BepInEx.Unity.IL2CPP;
using BepInEx.Unity.IL2CPP.UnityEngine;
using Il2CppInterop.Runtime.Injection;
using Il2CppSystem.Collections;
using StageLib;
using UnityEngine;
using KeyCode = BepInEx.Unity.IL2CPP.UnityEngine.KeyCode;
using Object = UnityEngine.Object;
using IEnumerator = System.Collections.IEnumerator;
using IEnumerable = System.Collections.IEnumerable;

namespace XCheese;

public static class PluginInfo {
    public const string PLUGIN_GUID = "xyz.aytimothy.bepinex.tw.com.capcom.rxd.xcheese";
    public const string PLUGIN_NAME = "XCheese";
    public const string PLUGIN_VERSION = "1.0";
}

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin {
    public override void Load() {
        try {

            // Initialize
            XCheese.Initialize();

            // Plugin startup logic
            Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }
        catch (Exception ex) {
            Log.LogFatal($"Plugin {MyPluginInfo.PLUGIN_GUID} failed to load!");
            Log.LogError(ex);
        }
    }

    IEnumerable DoInitialization() {
        yield return new WaitForSeconds(3f);

        
    }
}

public class XCheese : MonoBehaviour {
    public static XCheese Instance;

    public static void Initialize() {
        try {
            // Register our custom types
            ClassInjector.RegisterTypeInIl2Cpp<XCheese>();

            // Do actual initialization
            GameObject newGameObject = new GameObject("XCheese");
            DontDestroyOnLoad(newGameObject);
            newGameObject.hideFlags = HideFlags.HideAndDontSave;
            Instance = newGameObject.AddComponent<XCheese>();
            Debug.Log("Initialized XCheese!");
        }
        catch (Exception ex) {
            Debug.LogException(new Il2CppSystem.Exception(ex.Message));
            Debug.LogError("Failed to initialize XCheese (in Unity hook)");
        }

    }

    void Update() {
        if (Input.GetKeyInt(KeyCode.F5) && Event.current.type == EventType.KeyDown) {
            DoCheese();
        }
    }

    public void DoCheese() {
        StageUpdate stageUpdaterObject = FindObjectOfType<StageUpdate>();

        if (stageUpdaterObject != null) {
            stageUpdaterObject.ShowStageRewardUI();
        }
        else {
            Debug.LogError("You are not in a stage!!!");
        }
    }
}