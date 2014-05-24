using UnityEngine;

[AddComponentMenu("NGUI/Sun/RotatingCard")]
public class RotatingCard : MonoBehaviour
{
    private Transform cacheTrans;

    public Vector3 fromEulerAngle;
    public Vector3 toEulerAngle;
    public float factor = 1;

    public iTween.EaseType easeType = iTween.EaseType.easeOutBack;

    void Start()
    {
        cacheTrans = transform;
    }

    public void OnStartRotate()
    {
        if (UIToggle.current.value== false)
            return;
        Vector3 v = toEulerAngle;
        v.x /= factor;
        v.y /= factor;
        v.z /= factor;
        toEulerAngle = v;
        iTween.ValueTo(gameObject,iTween.Hash("from", fromEulerAngle, "to", toEulerAngle, "onupdate", "UpdateRotate","easetype", easeType));
    }

    void UpdateRotate(Vector3 rotateAngle)
    {
        cacheTrans.localEulerAngles = rotateAngle * factor;
    }
}
