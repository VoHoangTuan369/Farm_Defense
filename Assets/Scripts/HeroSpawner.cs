using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeroSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform heroPrefab;
    [SerializeField]
    private LayerMask cellMask;

    private Transform newHero;
    private Camera mainCamera;
    private Gold gold;
    private AudioSource audioSource;

    public Hero hero;
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
        if (newHero == null && gold.goldValue >= hero.goldToBuy)
        {
            newHero = Instantiate(heroPrefab, this.gameObject.transform.position, Quaternion.identity);
        }
    }

    private void OnMouseDrag()
    {
        if (newHero != null)
        {
            Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0;
            newHero.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        if (newHero)
        {
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            var hitCollider = Physics2D.OverlapCircle(mousePosition, 0.1f, cellMask);
            if (hitCollider && hitCollider.transform.childCount == 0)
            {
                newHero.SetParent(hitCollider.transform.transform, worldPositionStays: true);
                newHero.localPosition = new Vector3(0, 0, -1);
                gold.RemoveGold(hero.goldToBuy);
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
                Destroy(newHero.gameObject);
            }
            newHero = null;
        }
    }
    private IEnumerator ResetHeroSpawnerSprite()
    {
        var image = cooldown.GetComponent<Image>();
        image.enabled = true;
        cooldown.fillAmount = 0f;
        float counter = 0f;
        while (counter < 5f)
        {
            counter += Time.deltaTime;

            // lerp the fill amount from 0 to 1 over the duration of 5 seconds
            float fillAmount = Mathf.Lerp(0f, 1f, counter / 5f);
            cooldown.fillAmount = fillAmount;

            if (fillAmount >= 1f)
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
