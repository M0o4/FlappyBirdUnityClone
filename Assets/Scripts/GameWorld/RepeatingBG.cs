using System;
using Extension;
using Game;
using UnityEngine;

namespace GameWorld
{
    public class RepeatingBG : MonoBehaviour
    {
        private enum RepeatBG
        {
            BG1,
            BG2,
        }
        
        [SerializeField] private Background _background1;
        [SerializeField] private Background _background2;

        private Camera _mainCamera;
        private RepeatBG _repeatBG;
        private float _screenEdge;

        private void Start()
        {
            _repeatBG = RepeatBG.BG1;
            _mainCamera = Camera.main;
            _screenEdge = -_mainCamera.GetScreenBounds().x;
            
            SetBGTransformToEdge(_background2, _background1.RightEdge);
        }

        private void Update()
        {
            MoveRepeatedly();
        }

        private void MoveRepeatedly()
        { 
            MoveBackgrounds(); 
            ChangeRepeatBG();
        }
        
        private void MoveBackgrounds()
        {
            MoveBG(_background1);
            MoveBG(_background2);
        }

        private void MoveBG(Background background)
        {
            background.transform.Translate(Vector2.left * GameSettings.Singleton.WorldSpeed * Time.deltaTime);
        }

        private void ChangeRepeatBG()
        {
            switch (_repeatBG)
            {
                case RepeatBG.BG1:
                    ChangeBG(_background2, _background1, RepeatBG.BG2);
                    break;
                case RepeatBG.BG2:
                    ChangeBG(_background1, _background2, RepeatBG.BG1);
                    break;
            }
        }

        private void ChangeBG(Background bg, Background bgToChange, RepeatBG repeatBgToChange)
        {
            if (IsBGOnScreenEdge(bgToChange))
            {
                SetBGTransformToEdge(bgToChange, bg.RightEdge);
                _repeatBG = repeatBgToChange;
            }
        }

        private bool IsBGOnScreenEdge(Background background) => background.RightEdge.x < _screenEdge;

        private void SetBGTransformToEdge(Background background, Vector2 edge)
        {
            background.transform.position = background.Renderer
                .GetTransformFromEdge(background.transform, edge, SpriteEdge.Right);
        }
    }
}
