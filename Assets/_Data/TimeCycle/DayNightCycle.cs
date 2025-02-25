using _Data.Scripts;
using UnityEngine;

namespace _Data.TimeCycle
{
    public class DayNightCycle : LocSingleton<DayNightCycle>
    {
        [Header("Time Settings")]
        [SerializeField] private float minutePerDay = 5f;  // Một ngày trong game kéo dài bao lâu (phút)
        [SerializeField] private int startHour = 6;        // Giờ bắt đầu game
        [SerializeField] private float timeScale = 1f;    // Tốc độ thời gian
        private float timeElapsed;                        // Thời gian đã trôi qua trong ngày
        private float secondsPerDay;                      // Tổng số giây trong 1 ngày game

        [Header("Sunlight Settings")]
        [SerializeField] private Light directionalLight;  // Mặt trời (Directional Light)
        [SerializeField] private Gradient lightColorGradient;  // Đổi màu theo thời gian
        [SerializeField] private AnimationCurve lightIntensityCurve; // Đổi độ sáng theo thời gian

        public bool isNight { get; private set; } // Biến kiểm tra ban đêm
        public int currentHour { get; private set; }  // Giờ hiện tại trong game
        public int currentMinute { get; private set; }  // Phút hiện tại trong game

        protected override void Start()
        {
            secondsPerDay = minutePerDay * 60f;
            timeElapsed = (startHour / 24f) * secondsPerDay; // Bắt đầu từ giờ đã đặt
            //UpdateTime(); // Cập nhật giờ ngay khi bắt đầu
        }

        private void Update()
        {
            SimulateTime();
            RotateSun();
            UpdateLighting();
        }

        private void SimulateTime()
        {
            timeElapsed += Time.deltaTime * timeScale;
            float timeOfDayNormalized = (timeElapsed / secondsPerDay) % 1f; // 0.0 - 1.0

            currentHour = Mathf.FloorToInt(timeOfDayNormalized * 24f);
            currentMinute = Mathf.FloorToInt((timeOfDayNormalized * 1440f) % 60);

            isNight = (currentHour >= 18 || currentHour < 6); // Trời tối từ 18h - 6h sáng
        }

        private void RotateSun()
        {
            if (directionalLight == null) return;

            float timeOfDayNormalized = (timeElapsed / secondsPerDay) % 1f;
            float sunRotationX = Mathf.Lerp(-90f, 270f, timeOfDayNormalized);
            directionalLight.transform.rotation = Quaternion.Euler(sunRotationX, 0f, 0f);
        }

        private void UpdateLighting()
        {
            if (directionalLight == null) return;

            float timeOfDayNormalized = (timeElapsed / secondsPerDay) % 1f;
            directionalLight.color = lightColorGradient.Evaluate(timeOfDayNormalized);
            directionalLight.intensity = lightIntensityCurve.Evaluate(timeOfDayNormalized);
        }

        public string GetTimeString()
        {
            return $"{currentHour:D2}:{currentMinute:D2}";
        }
    }
}
