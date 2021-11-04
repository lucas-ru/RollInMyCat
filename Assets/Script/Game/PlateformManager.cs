using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlateformManager : MonoBehaviour
{
    private GameManager m_Game;
    
    public GameObject[] MovementObjX;
    public GameObject[] MovementObjY;
    public GameObject[] MovementObjZ;
    
    public bool active;

    public float[] ArrayspeedX;
    public float[] ArrayspeedY;
    public float[] ArrayspeedZ;

    public int[] minX;
    public int[] minY;
    public int[] minZ;
    
    public int[] maxX;
    public int[] maxY;
    public int[] maxZ;

    private int Key;

    private void Awake()
    {
        m_Game = GameManager.Instance;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_3"))
        {
            if (active)
            {
                Translation(MovementObjX,"x");

            }
            Translation(MovementObjZ,"z");
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_7"))
        {
            
            Translation(MovementObjY,"y");
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Map_10"))
        {
            
            Translation(MovementObjX,"x");

        }
    }

    public void Translation(GameObject[] mvt, string orientation) 
    {
        foreach (var Obj in mvt)
        {
            switch (orientation)
            {
                case "x":
                    Obj.transform.position += new Vector3(ArrayspeedX[Key], 0, 0);
                    if (Obj.transform.position.x < minX[Key] || Obj.transform.position.x > maxX[Key])
                    {
                        ArrayspeedX[Key] = -ArrayspeedX[Key];
                    }

                    break;
                case "y":
                    Obj.transform.position += new Vector3(0, ArrayspeedY[Key], 0);
                    if (Obj.transform.position.y < minY[Key] || Obj.transform.position.y > maxY[Key])
                    {

                        ArrayspeedY[Key] = -ArrayspeedY[Key];
                    }
                    break;
                case "z":
                    Obj.transform.position += new Vector3(0, 0, ArrayspeedZ[Key]);
                    if (Obj.transform.position.z < minZ[Key] || Obj.transform.position.z > maxZ[Key])
                    {
                        ArrayspeedZ[Key] = -ArrayspeedZ[Key];
                    }
                    break;
            }

            Key++;
        }
        Key = 0;
    }
}
