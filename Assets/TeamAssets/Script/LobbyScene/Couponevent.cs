using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couponevent : MonoBehaviour
{
    public Camera getCamera;
    private RaycastHit hit;
    public GameObject CouponUI;
    public GameObject lobbyscript;
    public int couponcheck = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && couponcheck == 0)
        {
            Debug.Log("������ ȹ���մϴ�.");
            couponcheck = 1;
            CouponUI.gameObject.SetActive(true);
        }
        else if (couponcheck == 1)
        {
            Debug.Log("������ �̹� ȹ���ϼ̽��ϴ�. ������ �Ϸ翡 �� �常 ���� �� �ֽ��ϴ�.");
        }
    }

    public void CheckButtonClick()
    {
        CouponUI.gameObject.SetActive(false);
    }
}
