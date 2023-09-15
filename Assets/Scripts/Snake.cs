using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField]
    Transform coin;
    [SerializeField]
    GameObject panelOver;
    [SerializeField]
    TextMeshProUGUI txtCoin;
    [SerializeField]
    TextMeshProUGUI txtTime;

    int coinCnt = 0;
    float startTime;

    List<Transform> tails = new List<Transform>();

    float speedMove = 3f;
    float speedRot = 120f;

    bool isDead = false;


    private void Awake()
    {
        startTime = Time.time;
        panelOver.SetActive(false);
    }
    void Update()
    {
        if(!isDead)
        {
            MoveHead();
            MoveTail();
            SetTime();
        }
    }

    void SetTime()
    {
        txtCoin.text = coinCnt.ToString("Coin : 0");

        float span = Time.time - startTime;
        int h = Mathf.FloorToInt(span / 3600);
        int m = Mathf.FloorToInt(span / 60 % 60);
        float s = span % 60;

        txtTime.text = string.Format("Time : {0:0}:{1:0}:{2:00.0}", h, m, s);
    }
    void MoveTail()
    {
        Transform target = transform;

        foreach(Transform tail in tails)
        {
            Vector3 pos = target.position;
            Quaternion rot = target.rotation;

            tail.position = Vector3.Lerp(tail.position, pos, 4 * Time.deltaTime);
            tail.rotation = Quaternion.Lerp(tail.rotation, rot, 4 * Time.deltaTime);

            target = tail;
        }
    }

    void AddTail()
    {
        GameObject tail = Instantiate(Resources.Load("Tail")) as GameObject;
        
        Vector3 pos = transform.position;

        int cnt = tails.Count;

        if(cnt ==0)
        {
            tail.tag = "Untagged";
        }
        else
        {
            pos = tails[cnt - 1].position;
        }

        tail.transform.position = pos;

        Color[] colors = { new Color(0, 0.5f, 0, 1), new Color(0, 0.5f, 1, 1) };
        int n = cnt / 3 % 2;
        tail.GetComponent<Renderer>().material.color = colors[n];

        tails.Add(tail.transform);

    }
    void MoveHead()
    {
        float amount = speedMove * Time.deltaTime;
        transform.Translate(Vector3.forward * amount);

        amount = Input.GetAxis("Horizontal") * speedRot;
        transform.Rotate(Vector3.up * amount * Time.deltaTime);

    }

    void MoveCoin()
    {
        coinCnt++;
        float x = Random.Range(-9f, 9f);
        float z = Random.Range(-4f, 4f);

        coin.position = new Vector3(x, 0, z);

    }

    public void OnButtonClick(Button button)
    {
        switch(button.name)
        {
            case "BtnYes":
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            case "BtnNo":
                Application.Quit();
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.transform.tag)
        {
            case "Coin":
                MoveCoin();
                AddTail();
                break;

            case "Wall":
            case "Tail":
                isDead = true;
                panelOver.SetActive(isDead);
                break;
        }
    }
}
