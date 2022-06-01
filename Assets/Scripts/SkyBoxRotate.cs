using UnityEngine;

public class SkyBoxRotate : MonoBehaviour
{
    public float RotationPerSecond = 1f;
    private bool _rotate;

    protected void Update()
    {
        //if (_rotate) 
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotationPerSecond);
    }

    public void ToggleSkyboxRotation()
    {
        //_rotate = !_rotate;
    }
}