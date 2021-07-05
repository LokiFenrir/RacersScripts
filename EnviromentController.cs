using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnviromentController : MonoBehaviour
{

    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("DragRacer") || collision.gameObject.CompareTag("DodgeRacer"))
        {

            Instantiate(explosionPrefab, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            StartCoroutine(CarExplosion());

        }

    }//OnCollisionEnter


    IEnumerator CarExplosion()
    {

        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenu");

    }//CarExplosion


}// ENVIROMENT CONTROLLER
