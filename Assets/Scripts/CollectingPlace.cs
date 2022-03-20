using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectingPlace : MonoBehaviour
{
    [SerializeField] private GameObject fillingPlane; // will fill the road gap if the needed amount of object collected
    [SerializeField] private GameObject gapToFill;
    [SerializeField] private int neededObjectsAmount;
    [SerializeField] private int collectedObjectsAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Collectable")
        {
            collectedObjectsAmount++;
        }

        if(collectedObjectsAmount >= neededObjectsAmount)
        {
            fillingPlane.transform.DOScale(gapToFill.transform.localScale, 2f);
            fillingPlane.transform.DOMove(gapToFill.transform.position, 2f);
        }
    }

}
