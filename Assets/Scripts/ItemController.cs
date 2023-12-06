using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

    public float moveSpeed = 10f;
    public float rotationAngle = 360f;
    private float startTime;

    void Start () {
        startTime = Time.time + Random.Range(-8f, 8f);

    }
    
    // Update is called once per frame
    void Update() {
        float horizontalMovement = Mathf.PingPong((Time.time - startTime) * moveSpeed, 16f) - 8f;
        //float horizontalMovement = Mathf.Sin(Time.time) * moveSpeed; // Sin 함수를 사용하여 좌우로 이동
        transform.Translate(Vector3.right * horizontalMovement * Time.deltaTime, Space.World);



        transform.Rotate(Vector3.up, rotationAngle * Time.deltaTime, Space.World);

    }
}
