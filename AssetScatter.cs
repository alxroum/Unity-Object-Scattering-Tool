using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class AssetScatter : MonoBehaviour
{
    public GameObject[] scatterObjects;
    public Terrain terrain;

    private float terrainWidth;
    private float terrainLength;

    private float terrainPosX;
    private float terrainPosZ;
    private float yOffset; 

    //public string name;

    public int amountObjects;
    private Quaternion rotation;

    public int xMaxRotation;
    public int yMaxRotation;
    public int zMaxRotation;

    public int maxSlope;
    public int minSlope;

    public string PrefabName;

    //private ArrayList points = new ArrayList();

    int pointCounter = 0;

    GameObject empty;

    //public InputField file;
    private Vector3 location;
   
    // Start is called before the first frame update
    void Start()
    {
        empty = new GameObject(PrefabName);

        terrainWidth = terrain.terrainData.size.x;
        terrainLength = terrain.terrainData.size.z;

    //Get terrain position
        terrainPosX = terrain.transform.position.x;
        terrainPosZ = terrain.transform.position.z;

        for(int i = 1; i <= amountObjects; i++) { //looping over the total amount of rocks requested and finding a random point within constraints to place the object

            float xRand = Random.Range(1, xMaxRotation); //generating random ints.
            float yRand = Random.Range(1, yMaxRotation); 
            float zRand = Random.Range(1, zMaxRotation);

            generatePoints(xRand, yRand, zRand);
        }

        SavePrefab(empty);
    }

    public void generatePoints(float xRand, float yRand, float zRand) { //method to generate the points with the specified xyz locations above
        float x = UnityEngine.Random.Range(terrainPosX, terrainPosX + terrainWidth);
        float z = UnityEngine.Random.Range(terrainPosX, terrainPosX + terrainLength);
        float y = Terrain.activeTerrain.SampleHeight(new Vector3(x, 0, z));

        location = new Vector3(x, y, z); //making the random values into one location vector3

        y += yOffset;

        pointCounter++;

        rotation = new Quaternion(xRand, yRand, zRand, 1); //creating new rotation for the objects

        
        //points.Add(location); //adding points to the arraylist

        int rand = UnityEngine.Random.Range(0, scatterObjects.Length); //generating random value

        Object.Instantiate(scatterObjects[rand], location, rotation, empty.transform); //instantiating or creating the objects while also picking a random object out of the list, if there is multiple
    }

    public void SavePrefab(GameObject empty) {

        string PrefabLocation = "" + PrefabName;
        string localPath = "Assets/Resources/" + PrefabLocation + ".prefab";
        //saving the scattered objects to a prefab
        localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
        PrefabUtility.SaveAsPrefabAsset(empty, localPath);
    }
}