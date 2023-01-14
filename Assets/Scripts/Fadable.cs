using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadable : MonoBehaviour
{
    BoxCollider2D boxCollider2D;
    SpriteRenderer spriteRenderer;
    string status;
    [SerializeField] float fadedAlpha = 0.2f;
    private bool isCollidingWithPlayer = false;

    void Start()
    {
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        if(boxCollider2D == null)
        {
            Debug.LogError("boxCollider2D is null on Fadable script");
        }
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if(spriteRenderer == null)
        {
            Debug.LogError("spriteRenderer is null on Fadable script");
        }
    }

    private void Update()
    {

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(isCollidingWithPlayer)
        {
            HandleFadeIn();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            bool areCharacterFeetAboveCollider = collision.gameObject.transform.position.y >= transform.position.y;
            if (isCollidingWithPlayer)
            {
                if(!areCharacterFeetAboveCollider)
                {
                    HandleFadeIn();
                }
            } else
            {

            }
            {
                if(areCharacterFeetAboveCollider)
                {
                    FadeOut();
                    isCollidingWithPlayer = true;
                }
            }

        }
    }
    void HandleFadeIn()
    {
        isCollidingWithPlayer = false;
        FadeIn();
    }
    void FadeIn()
    {
        if(status != "fading in")
        {
            status = "fading in";
            StartCoroutine(FadeTo(0.2f, 1f));
        }
    }

    void FadeOut()
    {
        if(status != "fading out")
        {
            status = "fading out";
            StartCoroutine(FadeTo(0.2f, fadedAlpha));
        }
    }

    IEnumerator FadeTo(float duration, float newAlpha)
    {

        float t = 0.0f;
        float originalAlpha = spriteRenderer.color.a;
        while (t <= duration)
        {
            float alpha = Mathf.Lerp(originalAlpha, newAlpha, t / duration);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, alpha);

            t += Time.deltaTime;

            yield return null;
        }
        if( t > duration)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha);
        }
    }

}
