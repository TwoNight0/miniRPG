using UnityEngine;

namespace RedBjorn.ProtoTiles.Example
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        float Eps = 0.1f;

        // HoldPosition 변수는 초기에 null 값을 가짐
        Vector3? HoldPosition;
        Vector3? ClickPosition;

        //if (HoldPosition.HasValue) 이걸로 값이있는지 확인가능

        public static bool IsMovingByPlayer;

        MapEntity CachedMap;
        MapEntity Map
        {
            get
            {
                if(CachedMap == null)
                {
                    var example = FindObjectOfType<ExampleStart>();
                    if (example)
                    {
                        CachedMap = example.MapEntity;
                    }
                }
                return CachedMap;
            }
        }

        void LateUpdate()
        {
            if (MyInput.GetOnWorldDownFree(Map.Settings.Plane()))
            {
                HoldPosition = MyInput.GroundPositionCameraOffset(Map.Settings.Plane());
                ClickPosition = transform.position;
            }
            else if (MyInput.GetOnWorldUpFree(Map.Settings.Plane()))
            {
                HoldPosition = null;
                ClickPosition = null;
            }
            UpdatePosition();
        }

        void OnDisable()
        {
            IsMovingByPlayer = false;
        }

        void UpdatePosition()
        {
            if (HoldPosition.HasValue)
            {
                var delta = HoldPosition.Value - MyInput.GroundPositionCameraOffset(Map.Settings.Plane());
                transform.position += delta;
                transform.position = ClickPosition.Value + delta;
                if (!IsMovingByPlayer)
                {
                    IsMovingByPlayer = delta.sqrMagnitude > Eps;
                }
            }
            else
            {
                IsMovingByPlayer = false;
            }
        }
    }
}
