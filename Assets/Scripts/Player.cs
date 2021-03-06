using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    LevelManager levelManager;
    UI ui;

    [SerializeField] private GameObject playerStopper2;
    [SerializeField] private GameObject playerStopper3;
    [SerializeField] private GameObject playerStopper1;



    // Start is called before the first frame update
    void Start()
    {
        levelManager = LevelManager.instance;
        ui = UI.instance;
    }

    // Update is called once per frame
    void Update()
    {
        MasterMakePlayerMoveAgain();

    }


    private void MasterMakePlayerMoveAgain()
    {
        if (levelManager.collectedObjectsAmount1 >= levelManager.neededObjectsAmount1)
        {
            StartCoroutine(MakePlayerMoveAgain(playerStopper1));
        }

        if (levelManager.collectedObjectsAmount2 >= levelManager.neededObjectsAmount2)
        {
            StartCoroutine(MakePlayerMoveAgain(playerStopper2));
        }

        if (levelManager.collectedObjectsAmount3 >= levelManager.neededObjectsAmount3)
        {
            StartCoroutine(MakePlayerMoveAgain(playerStopper3));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerStopper")
        {
            StartCoroutine(CheckIfLoseGame(collision.gameObject));
            StartCoroutine(CheckIfLoseGame(collision.gameObject));
            StartCoroutine(CheckIfLoseGame(collision.gameObject));
        }
    }

    private IEnumerator MakePlayerMoveAgain(GameObject playerStopper)
    {
        yield return new WaitForSeconds(6.5f);
        playerStopper.gameObject.SetActive(false);
        StopCoroutine(MakePlayerMoveAgain(playerStopper));
    }

    private IEnumerator CheckIfLoseGame(GameObject collider)
    {
        yield return new WaitForSeconds(10f);
        Debug.Log("checked");
        if(collider.activeSelf == true)
        {
            ui.loseCanvas.SetActive(true);
        }
        StopCoroutine(CheckIfLoseGame(collider));
    }
}
