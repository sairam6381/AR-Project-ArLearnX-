using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wait : MonoBehaviour
{
    public float waittime=5f;   
     void Start()
    {
        StartCoroutine(Wait_for_intro());
    }

    IEnumerator Wait_for_intro(){
        yield return new WaitForSeconds(waittime);
        SceneManager.LoadScene(1);
    }
}
