using System;
using UnityEngine;
using Extension;

public class TestScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private SpriteRenderer _toSet;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;

        SpriteEdge();
        CameraEdge();
    }

    private void Update()
    {
        SpriteEdge();
    }

    private void SpriteEdge()
    {
        var spriteEdgeSide = Extension.SpriteEdge.Right;
        var edge = _renderer.GetEdgePosition(_renderer.GetComponent<Transform>(), spriteEdgeSide);
        Debug.Log($"SpriteEdge {edge.x}");
        _toSet.transform.position = _toSet.GetTransformFromEdge(_toSet.transform, edge, spriteEdgeSide);
    }

    private void CameraEdge()
    {
        var screenBounds = _camera.GetScreenBounds();
        Debug.Log($"CameraEdge {screenBounds.x}");
    }
}
