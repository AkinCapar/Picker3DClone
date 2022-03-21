using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collectable : MonoBehaviour
{
    [SerializeField] GameObject poppedVersionPrefab; // toplama alanına geldikten sonraki patlamış hali
    private Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Collector") 
        {
            StartCoroutine(PopTheCollectable());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CollectableCleaner")
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator PopTheCollectable()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        myRigidbody.AddForce(Vector3.up * 2);
        Instantiate(poppedVersionPrefab, transform.position, Quaternion.identity);
        StopCoroutine(PopTheCollectable());
    }
}
