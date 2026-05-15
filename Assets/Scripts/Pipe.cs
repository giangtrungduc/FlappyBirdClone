using Unity.Mathematics;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float speed = 2f;
    public GameObject coinPrefab;
    public Transform posCoin;
    private void Update()
    {
        if(Manager.Instance.isLoss) Destroy(gameObject);
        if (!Manager.Instance.isPlay) return;

        transform.position += Vector3.left * speed * Time.deltaTime;

        if(coinPrefab != null && posCoin != null)
        {
            if (Manager.Instance.isCoin)
            {
                Instantiate(coinPrefab, posCoin.position, quaternion.identity, gameObject.transform);
                Manager.Instance.isCoin = false;
            }
        }

        if(transform.position.x <= -4f)
        {
            Destroy(gameObject);
        }
    }
}
