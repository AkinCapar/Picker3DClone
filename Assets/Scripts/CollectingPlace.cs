using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectingPlace : MonoBehaviour
{
    [SerializeField] private GameObject fillingPlane; // will fill the road gap if the needed amount of object collected
    [SerializeField] private GameObject gapToFill;
    [SerializeField] private int collectingPlaceNo;
    LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = LevelManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Collectable" && collectingPlaceNo == 1)
        {
            levelManager.collectedObjectsAmount1++;
        }
       
        if(levelManager.collectedObjectsAmount1 >= levelManager.neededObjectsAmount1)
        {
            StartCoroutine(FillTheGap());
        }

        if (collision.gameObject.tag == "Collectable" && collectingPlaceNo == 2)
        {
            levelManager.collectedObjectsAmount2++;
        }

        if (levelManager.collectedObjectsAmount2 >= levelManager.neededObjectsAmount2)
        {
            StartCoroutine(FillTheGap());
        }

        if (collision.gameObject.tag == "Collectable" && collectingPlaceNo == 3)
        {
            levelManager.collectedObjectsAmount3++;
        }

        if (levelManager.collectedObjectsAmount3 >= levelManager.neededObjectsAmount3)
        {
            StartCoroutine(FillTheGap());
        }
    }

    private IEnumerator FillTheGap()
    {
        yield return new WaitForSeconds(5);
        fillingPlane.transform.DOScale(gapToFill.transform.localScale, 1f);
        fillingPlane.transform.DOMove(gapToFill.transform.position, 1f);
        StopCoroutine(FillTheGap());
    }
}
