using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    float speed = 5f;
    float jumpSpeed = 10f;
    //public float jumpForce = 10f;
    
    bool jumped = false;
    //int jumpCount = 0;
    bool isDead = false;



    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    /*void Update(){

        //if (isDead) {
            //return;
        //}

        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float zSpeed = Input.GetAxis("Vertical") * speed;

        Vector3 newVelocit = new Vector3(xSpeed, rb.velocity.y, zSpeed);
        rb.velocity = newVelocit;

        if (Input.GetButtonDown("Jump") && jumpCount < 2) {
            jumped = true;
            jumpCount++;
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
        else if (Input.GetButtonDown("Jump") && rb.velocity.y > 0) {
            rb.velocity = rb.velocity * 0.5f;

        }
    }*/
    void Update() {

        if (isDead) {  return; }

        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");

        transform.position += new Vector3(xDir * speed * Time.deltaTime, 0, zDir * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && !jumped) {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            jumped = true;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Platform") {
            jumped = false;
            //jumpCount++;
        }
    }

    private void Die() {

        Debug.Log("Player Died");
        rb.velocity = Vector3.zero;
        isDead = true;
        GameManager.instance.OnPlayerDead();

    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Item") {
            other.gameObject.SetActive(false);
            GameManager.instance.AddScore(1);
        }
        if (other.gameObject.tag == "DeadZone") {
            //GameManager.instance.isGameover = true;
            //GameManager.Find(
            Die();
            gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Finish") {
            GameManager.instance.FinishPoint();
        }
        
    }
    /*public void LoadNextScene() {
        // 현재 씬의 빌드 인덱스를 가져와서 다음 씬의 인덱스를 계산
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // 모든 씬을 다 플레이한 경우 첫 번째 씬으로 돌아감
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings) {
            nextSceneIndex = 0;
        }

        // 다음 씬으로 전환
        SceneManager.LoadScene(nextSceneIndex);
    }*/
}
