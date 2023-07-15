using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform bombPrefab;
    [SerializeField]
    private LayerMask cellMask;

    private Transform newBomb;
    private Camera mainCamera;
    private Gold gold;
    private AudioSource audioSource;

    public Bomb bomb;
    public Image cooldown;
    public AudioClip soundInit;

    private void Start()
    {
        mainCamera = Camera.main;
        // assign the reference to an instance of the Gold class
        gold = FindObjectOfType<Gold>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundInit;
    }

    private void OnMouseDown()
    {
        SpawnHero();
    }

    private void SpawnHero()
    {
        if (newBomb == null && gold.goldValue >= bomb.goldToBuy)
        {
            newBomb = Instantiate(bombPrefab, this.gameObject.transform.position, Quaternion.identity);
        }
    }

    private void OnMouseDrag()
    {
        if (newBomb != null)
        {
            Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0;
            newBomb.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        if (newBomb)
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            var hitCollider = Physics2D.OverlapCircle(mousePosition, 0.1f, cellMask);
            if (hitCollider && hitCollider.transform.childCount == 0)
            {
                newBomb.SetParent(hitCollider.transform.transform, worldPositionStays: true);
                newBomb.localPosition = new Vector3(0, 0, -1);
                gold.RemoveGold(bomb.goldToBuy);
                if (audioSource && soundInit)
                {
                    audioSource.PlayOneShot(soundInit);
                }

                // temporarily disable mouse click event on HeroSpawner
                GetComponent<Collider2D>().enabled = false;
                // start coroutine to reset the HeroSpawner sprite after 5 seconds
                StartCoroutine(ResetHeroSpawnerSprite());
            }
            else
            {
                Destroy(newBomb.gameObject);
            }
            newBomb = null;
        }
    }
    private IEnumerator ResetHeroSpawnerSprite()
    {
        var image = cooldown.GetComponent<Image>();
        image.enabled = true;
        cooldown.fillAmount = 1f; // Start with fillAmount set to 1f
        float counter = 0f;
        float duration = 5f; // Duration in seconds

        while (counter < duration)
        {
            counter += Time.deltaTime;

            // lerp the fill amount from 1 to 0 over the duration of 5 seconds
            float fillAmount = Mathf.Lerp(1f, 0f, counter / duration);
            cooldown.fillAmount = fillAmount;

            if (fillAmount <= 0f)
            {
                // hide the `cooldown` object by disabling its renderer and collider components
                image.enabled = false;
                var collider = GetComponent<Collider2D>();
                collider.enabled = true;

                // exit the loop
                break;
            }

            // wait for end of frame before continuing the loop
            yield return null;
        }
    }
}
