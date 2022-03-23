using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int neededObjectsAmount1; //1 designates the first collecting place. Which each level has 3.
    public int collectedObjectsAmount1;
    public int neededObjectsAmount2;
    public int collectedObjectsAmount2;
    public int neededObjectsAmount3;
    public int collectedObjectsAmount3;
    public GameObject nextLevelStartingPlace;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
