using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBulletNor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject effect;
    public float speed;
    public float timeToDestroy;
    public float damageAmount;
    public bool isEggs = true;
    public GameObject hitSound;
    Rigidbody2D m_rb;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        if (isEggs)
        {
            m_rb.angularVelocity = (Random.value < 0.5) ? 90f : -90f;
        }
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("PauseGame", 0) == 1)
        {
            m_rb.velocity = Vector2.zero;
        }
        else
        {
            m_rb.velocity = Vector2.right * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Instantiate(hitSound, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Instantiate(effect, this.transform.position, Quaternion.identity);
        }
    }
}
