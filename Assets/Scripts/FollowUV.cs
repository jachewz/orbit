using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUV : MonoBehaviour
{
    public float Parallax = 1f;
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x = transform.position.x / transform.localScale.x / Parallax;
        offset.y = transform.position.y / transform.localScale.y / Parallax;

        mat.mainTextureOffset = offset;
    }
}
