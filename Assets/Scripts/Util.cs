using UnityEngine;

public class Util : MonoBehaviour
{
    private Material material;
    private float distance;
    [Range(0f, 0.5f)]
    public float speed = 0.2f;
    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }
    private void Update()
    {
        if(!Manager.Instance.isPlay) return;

        distance += Time.deltaTime * speed;
        material.SetTextureOffset("_MainTex", Vector2.right * distance);
    }
}
