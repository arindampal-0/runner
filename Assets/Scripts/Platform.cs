using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rowStart = -30.0f;
    [SerializeField] private uint rows = 5;
    [SerializeField] private float rowGap = 10.0f;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject coinPrefab;

    private List<GameObject> gameObjects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObjects = new List<GameObject>();

        if (obstaclePrefab != null && coinPrefab != null)
        {
            for(uint i = 0; i < rows; ++i)
            {
                Vector3 position = new Vector3(
                    this.transform.position.x + rowStart + i * rowGap, this.transform.position.y + 1.0f, this.transform.position.z);
                GameObject obj = Instantiate(obstaclePrefab, position, Quaternion.identity, this.transform);
                gameObjects.Append(obj);

                position.z = this.transform.position.z + 5.0f;
                obj = Instantiate(coinPrefab, position, Quaternion.identity, this.transform);
                gameObjects.Append(obj);
            }
        }
        else
        {
            print("ERROR: prefab not set in Platform.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
