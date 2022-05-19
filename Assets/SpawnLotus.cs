using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnLotus : MonoBehaviour
{

    public GameObject LotusPrefab;

    public int count;//�����Ǵ� ���� ����

    public float timeSpan;//��� �ð�
    public int checkTime;//Ư�� �ð�

    private List<GameObject> lotus = new List<GameObject>();

    private void Start()
    {
        timeSpan = 0.0f; // ��� �ð� �ʱ�ȭ 
        checkTime = Random.Range(5, 10);

        Invoke("Spawn", checkTime);

    }
    private void Update()
    {
        timeSpan += Time.deltaTime;

  
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {   
            Destroy();
            Debug.Log("���� ȹ��");
        }
    }*/


    private void Spawn()
    {

        count = Random.Range(2, 7);
        Debug.Log("checkTime: " + Mathf.Round(checkTime));
        Debug.Log("count: " + Mathf.Round(count));
        if (timeSpan > checkTime)
        {
            for (int i = 0; i < count; ++i)
            {
                SpawnPosition();
            }
            timeSpan = 0.0f;

        }
    }


    private void SpawnPosition()
    {

        GameObject selectedPrefab = LotusPrefab;

        Vector3 spawnPos = new Vector3(Random.Range(-45, 45), 25, Random.Range(-45, 45));

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        lotus.Add(instance);



    }
}