using UnityEngine;

public class TerrainMover : MonoBehaviour
{
    public float speed = 1f;

    public bool shouldMove = true;

    void Update()
    {
        if (shouldMove)
        {
            var pos = this.gameObject.transform.position;
            this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z + (Time.deltaTime * speed));
        }
    }
}