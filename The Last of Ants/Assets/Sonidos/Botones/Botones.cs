using UnityEngine;
using UnityEngine.EventSystems;

public class Botones : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Vector3 hoverScale = new Vector3(1.2f, 1.2f, 1f);
    public Vector3 normalScale = new Vector3(1f, 1f, 1f);
    public float scaleSpeed = 5f;

    public AudioClip hoverSound;
    public AudioClip clickSound;

    private AudioSource audioSource;
    private Vector3 targetScale;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        targetScale = normalScale; 
    }

    void Update()
    {
        // Escalado suavizado entre la escala actual y la escala objetivo
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Cambiar la escala objetivo al pasar el mouse
        targetScale = hoverScale;

        PlaySound(hoverSound);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Volver a la escala normal cuando el mouse sale del botón
        targetScale = normalScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PlaySound(clickSound);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
