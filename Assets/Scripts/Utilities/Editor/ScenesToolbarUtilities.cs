using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.UIElements;

[InitializeOnLoad]
public static class ScenesToolbarUtilities
{
    private static ScriptableObject _toolbar;
    private static string[] _scenePaths;
    private static string[] _sceneNames;

    static ScenesToolbarUtilities()
    {
        EditorApplication.delayCall += () =>
        {
            EditorApplication.update -= Update;
            EditorApplication.update += Update;
        };
    }

    private static void Update()
    {
        if (_toolbar == null)
        {
            Assembly editorAssembly = typeof(Editor).Assembly;
            UnityEngine.Object[] toolbars = Resources.FindObjectsOfTypeAll(editorAssembly.GetType("UnityEditor.Toolbar"));
            _toolbar = toolbars.Length > 0 ? (ScriptableObject)toolbars[0] : null;

            if (_toolbar != null)
            {
                var root = _toolbar.GetType().GetField("m_Root", BindingFlags.NonPublic | BindingFlags.Instance);
                var rawRoot = root.GetValue(_toolbar);
                var mRoot = rawRoot as VisualElement;
                RegisterCallback("ToolbarZoneRightAlign", OnGUI);   //Otra opcion: "ToolbarZoneLeftAlign"

                void RegisterCallback(string root, Action cb)
                {
                    var toolbarZone = mRoot.Q(root);
                    if (toolbarZone != null)
                    {
                        var parent = new VisualElement()
                        {
                            style = {
                                flexGrow = 1,
                                flexDirection = FlexDirection.Row,
                            }
                        };
                        var container = new IMGUIContainer();
                        container.onGUIHandler += () =>
                        {
                            cb?.Invoke();
                        };
                        parent.Add(container);
                        toolbarZone.Add(parent);
                    }
                }
            }
        }

        if (_scenePaths == null || _scenePaths.Length != EditorBuildSettings.scenes.Length)
        {
            List<string> scenePaths = new List<string>();
            List<string> sceneNames = new List<string>();

            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
            {
                if (scene.path == null || scene.path.StartsWith("Assets") == false)
                    continue;

                string scenePath = Application.dataPath + scene.path.Substring(6);

                scenePaths.Add(scenePath);
                sceneNames.Add(Path.GetFileNameWithoutExtension(scenePath));
            }

            _scenePaths = scenePaths.ToArray();
            _sceneNames = sceneNames.ToArray();
        }
    }

    private static void OnGUI()
    {
        using (new EditorGUI.DisabledScope(Application.isPlaying))
        {
            string sceneName = EditorSceneManager.GetActiveScene().name;
            int sceneIndex = -1;

            for (int i = 0; i < _sceneNames.Length; ++i)
            {
                if (sceneName == _sceneNames[i])
                {
                    sceneIndex = i;
                    break;
                }
            }

            int newSceneIndex = EditorGUILayout.Popup(sceneIndex, _sceneNames, GUILayout.Width(200.0f));
            if (newSceneIndex != sceneIndex)
            {
                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    EditorSceneManager.OpenScene(_scenePaths[newSceneIndex], OpenSceneMode.Single);
                }
            }
        }
    }
}