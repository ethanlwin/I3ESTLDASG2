using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrance : MonoBehaviour
{
    [Header("Scene Picker")]
    public int entranceNum;

    [HideInInspector]
    public bool opening;

    public IEnumerator Move()
    {
        opening = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(entranceNum);
    }

    public void MoveScene()
    {
        StartCoroutine(Move());
    }
}
