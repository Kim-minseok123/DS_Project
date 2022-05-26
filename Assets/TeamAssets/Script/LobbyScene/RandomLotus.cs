using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomLotus : MonoBehaviour
{

    public GameObject LotusPrefab;

    public int count; //�����Ǵ� ���� ����
    public float TimeSpan; // ��� �ð�
    public int CheckTime;// Ư�� �ð�

    public GameObject[] L_count;//ȹ���� ������ ���� ���� ���� �迭 ����
    public int len = 0;//�迭�� ���� Ȯ��


    public GameObject lotusUI;
    public TextMeshProUGUI lotusTxt;

    public GameObject wordUI;
    public TextMeshProUGUI wordTxt;
    public Button Wordbtn;

    string word = "Ÿ���� �ʸ� �������� �����ϴ����� �߿�ġ �ʴ�. ������ �����ϴ� �� �ڽ��� ���� ��� ���̴�.";
    public string[] TodayWord;//�ܾ�� �����ϱ� ���� �迭
    public int letter;//�������� ���õ� �迭 index
    public bool A ;//button Ȱ��ȭ,��Ȱ��ȭ ����



    void Start()
    {   
        
        A = false;
        TimeSpan = 0.0f;
        CheckTime = Random.Range(5, 10);

        Invoke("Spawn", CheckTime);

        InvokeRepeating("phrase", 10, 60);

    }

    // Update is called once per frame
    void Update()
    {
        if (wordUI.activeSelf == false)
        {
            A = false;
        }
        else if(wordUI.activeSelf ==true)
            A = true;

        TimeSpan += Time.deltaTime;
        DestroyLotus();

    }

    public void Spawn()
    {
        count = Random.Range(5, 8);


        if (TimeSpan > CheckTime)
        {
            for (int i = 0; i < count; i++)
            {
                SpawnPosition();
            }
            TimeSpan = 0.0f;

        }


    }

    public void SpawnPosition()
    {
        GameObject selectedPrefab = LotusPrefab;

        Vector3 spawnPos = new Vector3(Random.Range(-300, -170), 20, Random.Range(-60, 60));

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);


    }

    public void DestroyLotus()
    {
        L_count = GameObject.FindGameObjectsWithTag("lotus");//������ ������ �迭�� ����
        len = L_count.Length;//�����ִ� ������ ���� 


        for (int i = 1; i < count + 1; i++)
        {
            if (len == count - i)
            {
                lotusTxt.text = ": " + i.ToString();

                
                if (i != 0 && i % 5 == 0 && A==false )
                {
                    
                    wordTxt.text = TodayWord[letter].ToString();

                    wordUI.SetActive(true);

                    A = true;
                }

            }
        }
    }

    public void phrase()
    {
        TodayWord = word.Split(new char[] { ' ' });
        letter = Random.Range(0, TodayWord.Length);
    }

    public void button()
    {
        if(A==true)
        {
            wordUI.SetActive(false);
            A = false;
        }
        
    }
   
}



