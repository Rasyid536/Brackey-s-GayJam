using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera renderCamera;  // kamera yang render ke RenderTexture
    public RawImage renderImage; // RawImage tempat Render Texture ditampilkan

    float x, y;

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        RotateToMouse();
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(x, y, 0f).normalized;
        transform.position += move * moveSpeed * Time.fixedDeltaTime;
    }


/*
Just in case kalian berhadapan sama fungsi ini, fungsi ini sebenarnya cuma rotasi player ke arah kursor, 
alasan kenapa kok ini panjang banget adalah karena kita pakai render texture resolusi rendah buat ditampilin di kamera
dan input koordinat kursor kita itu jadi sesuai dengan resoulusi render texture, sedangkan objeknya enggak, jadi gak sinkron.
Gitu lah kira kira, intinya ini cuma buat player rotasi ke arah kursor.
*/
    void RotateToMouse()
    {
        RectTransform rt = renderImage.rectTransform;

        // mouse ke posisi lokal RawImage
        Vector2 localMouse;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rt,
            Input.mousePosition,
            null,
            out localMouse
        );

        // normalisasi ke RenderTexture
        Vector2 normalized = Rect.PointToNormalized(rt.rect, localMouse);

        // ke world
        Vector3 worldPos = renderCamera.ViewportToWorldPoint(
            new Vector3(normalized.x, normalized.y, renderCamera.nearClipPlane)
        );

        Vector2 dir = worldPos - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }
}
