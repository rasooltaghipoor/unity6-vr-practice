using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public List<GameObject> breakablePieces;
    private float timeToBreak = 2;
    private float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var item in breakablePieces)
            item.SetActive(false);
    }

    public void Break()
    {
        timer += Time.deltaTime;
        if (timer > timeToBreak)
        {
            timer = 0;
            foreach (var item in breakablePieces)
            {
                item.SetActive(true);
                item.transform.parent = null;
            }
            gameObject.SetActive(false);
        }

    }
}
