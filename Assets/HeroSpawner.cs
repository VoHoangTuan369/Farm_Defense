using System.Collections;
using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform heroPrefab;
    [SerializeField]
    private LayerMask cellMask;

    private Transform newHero;
    private Camera mainCamera;
    private Gold gold;

    public Hero hero;

    private void Start()
    {
        mainCamera = Camera.main;
        // assign the reference to an instance of the Gold class
        gold = FindObjectOfType<Gold>();
    }

    private void OnMouseDown() => SpawnHero();

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
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        var hitCollider = Physics2D.OverlapCircle(mousePosition, 0.1f, cellMask);
        if (hitCollider && hitCollider.transform.childCount == 0)
        {
            newHero.SetParent(hitCollider.transform.transform, worldPositionStays: true);
            newHero.localPosition = Vector3.zero;
            gold.RemoveGold(hero.goldToBuy);

            // temporarily disable mouse click event on HeroSpawner
            GetComponent<Collider2D>().enabled = false;
            // change the sprite of HeroSpawner to black color
            GetComponent<SpriteRenderer>().color = Color.black;
            // start coroutine to reset the HeroSpawner sprite after 5 seconds
            StartCoroutine(ResetHeroSpawnerSprite());
        }
        else
        {
            Destroy(newHero.gameObject);
        }
        newHero = null;
    }
    private IEnumerator ResetHeroSpawnerSprite()
    {
        // wait for 5 seconds
        yield return new WaitForSeconds(5f);
        // reset the sprite of HeroSpawner and enable mouse click event
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
        var collider = GetComponent<Collider2D>();
        collider.enabled = true;
    }
}
