using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZZBase.Lession09
{
    public sealed class Rotator : MonoBehaviour
    {

        [PathToObject]
        public string pathToObject;

        public Material material;
        public float speed;
        public Renderer render;

        private void Awake()
        {
            ResetMaterial();
        }
        void Update()
        {
            transform.Rotate(new Vector3(0f, 90f * Time.deltaTime * speed, 0f));
        }

        public void ResetMaterial()
        {
            render = GetComponent<Renderer>();
            material = new Material(render.sharedMaterial);
            render.material = material;
        }

        public void ChangeColor()
        {
            material.color = Random.ColorHSV();
        }
    }
}
