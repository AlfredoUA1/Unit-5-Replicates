using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectionSystem : MonoBehaviour
{
    public GameManagerScript gameManager;
    public TMP_Text info;
    public Slider bar;
    public IEnumerator collect;
    public float timer;
    public float timerMax = 2f;

    // Start is called before the first frame update
    void Start()
    {
        bar.gameObject.SetActive(false);
        info.text = "";
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            info.text = "Collecting";
            bar.gameObject.SetActive(true);
            collect = Collecting();
            StartCoroutine(collect);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            timer += Time.deltaTime;
            bar.value = (timer / timerMax);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(collect);
        info.text = "";
        bar.gameObject.SetActive(false);
        bar.value = 0;
        timer = 0;
    }

    public IEnumerator Collecting()
    {
        yield return new WaitForSeconds(timerMax);
        gameManager.score += 1;
        Destroy(gameObject);
    }
}
