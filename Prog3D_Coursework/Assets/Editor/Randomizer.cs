using System;
using UnityEngine;
using UnityEditor;
using Random = UnityEngine.Random;

public class Randomiser : EditorWindow
// https://www.youtube.com/watch?v=3X4beMh6Lec
// Comp-3 Interactive Video Tutorial
{
    bool randomXrot = false,
 randomYrot, randomZrot;
    bool randomScale = false;
    float minScale, maxScale;

    private string myString = "Hello World";
    private bool randomise;


    // Add menu named "My Window" to the Window menu
    [MenuItem("MyUtility/My Window")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        Randomiser window = (Randomiser)EditorWindow.GetWindow(typeof(Randomiser));
        window.Show();
    }

    private void OnGUI()
    {
        GUILayout.Label("Randomise selected objects", EditorStyles.boldLabel);
        randomXrot = EditorGUILayout.Toggle("Randomise X", randomXrot);
        randomYrot = EditorGUILayout.Toggle("Randomise Y", randomYrot);
        randomZrot = EditorGUILayout.Toggle("Randomise Z", randomZrot);

        GUILayout.Label("Rotations");
        randomScale = EditorGUILayout.Toggle("Randomise Scale", randomScale);
        minScale = EditorGUILayout.FloatField("Min Scale", minScale);
        maxScale = EditorGUILayout.FloatField("Max Scale", maxScale);

        if (GUILayout.Button("Randomise"))
        {
            foreach (GameObject go in Selection.gameObjects)
            {
                go.transform.rotation = Quaternion.Euler(GetRandomRotations(go.transform.rotation.eulerAngles));

                if (randomScale)
                {
                    float scaleVal = Random.Range(minScale, maxScale);
                    go.transform.localScale = new Vector3(scaleVal, scaleVal, scaleVal);
                }
            }
        }
    }

    private Vector3 GetRandomRotations(Vector3 currentRotation)
    {
        float x = randomXrot ? Random.Range(0f, 360f) : currentRotation.x;
        float y = randomYrot ? Random.Range(0f, 360f) : currentRotation.y;
        float z = randomZrot ? Random.Range(0f, 360f) : currentRotation.z;
        
        return new Vector3(x, y, z);

    }
    }
