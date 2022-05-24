using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLotus : MonoBehaviour
{
    public GameObject LotusPrefab;

    public int count; //�����Ǵ� ���� ����
    public float TimeSpan; // ��� �ð�
    public int CheckTime;// Ư�� �ð�

    void Start()
    {
        TimeSpan = 0.0f;
        CheckTime = Random.Range(5, 10);

        Invoke("Spawn", CheckTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan += Time.deltaTime;

    }

    private void Spawn()
    {
        count = Random.Range(2, 7);
        Debug.Log("ChechTime" + Mathf.Round(CheckTime));
        Debug.Log("count" + Mathf.Round(count));

        if(TimeSpan>CheckTime)
        {
            for(int i=0;i<count;i++)
            {
                SpawnPosition();
            }
            TimeSpan = 0.0f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("ȹ��1");
            Destruction();
        }
    }

    private void Destruction()
    {
        Debug.Log("ȹ��2");
        Destroy(this.gameObject);
    }
    private void SpawnPosition()
    {
        GameObject selectedPrefab = LotusPrefab;

        Vector3 spawnPos = new Vector3(Random.Range(-45, 45), 20, Random.Range(-45, 45));

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        

    }
}
