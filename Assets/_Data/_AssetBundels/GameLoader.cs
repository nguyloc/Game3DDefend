using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace _Data.Test
{
    public class GameLoader : MonoBehaviour
    {
        public GameObject uiMenu;      // UI Menu (Có nút Start)
        public GameObject uiLoading;   // UI Loading (Thanh progress bar)
        public Slider progressBar;     // Thanh loading bar

        public string googleDriveUrl = "https://drive.google.com/uc?export=download&id=1SpjHvWT8uGIx4DKf77iW2B7AmShpDzlD"; 
        private string bundlePath;     // Đường dẫn lưu AssetBundle sau khi tải về

        public string assetName = "test"; // Tên object trong AssetBundle

        void Start()
        {
            uiMenu.SetActive(true);  // Hiện UI Menu khi vào game
            uiLoading.SetActive(false); // Ẩn UI Loading
        }

        public void OnStartGame()  // Gọi khi nhấn nút Start
        {
            Debug.Log("Start Game!");
            uiMenu.SetActive(false);  // Ẩn UI Menu
            uiLoading.SetActive(true);  // Hiện UI Loading
            
            //ClearScene(); // Xóa tất cả GameObject trong Scene trước khi load AssetBundle

            bundlePath = Path.Combine(Application.persistentDataPath, "mybundle"); // Lưu file tải về
            StartCoroutine(DownloadAndLoadBundle()); // Bắt đầu tải AssetBundle
        }

        IEnumerator DownloadAndLoadBundle()
        {
            Debug.Log("Downloading AssetBundle from: " + googleDriveUrl);

            UnityWebRequest request = UnityWebRequest.Get(googleDriveUrl);
            request.downloadHandler = new DownloadHandlerFile(bundlePath);

            request.SendWebRequest(); // Không dùng yield return ở đây

            while (!request.isDone)
            {
                progressBar.value = request.downloadProgress; // Cập nhật thanh progress
                yield return null; // Chờ frame tiếp theo
            }

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Download failed: " + request.error);
                yield break;
            }

            Debug.Log("Download completed! Loading AssetBundle...");

            yield return StartCoroutine(LoadGameObjects()); // Sau khi tải xong, load vào scene

            yield return new WaitForSeconds(0.5f); // Chờ 0.5s để người chơi thấy full progress
            uiLoading.SetActive(false); // Ẩn UI Loading sau khi tải xong
        }

        IEnumerator LoadGameObjects()
        {
            if (!File.Exists(bundlePath))
            {
                Debug.LogError("AssetBundle file not found at: " + bundlePath);
                yield break;
            }

            AssetBundle bundle = AssetBundle.LoadFromFile(bundlePath);
            if (bundle == null)
            {
                Debug.LogError("Failed to load AssetBundle!");
                yield break;
            }

            Debug.Log(" AssetBundle loaded successfully!");

            // Load tất cả Prefabs có trong label "test"
            GameObject[] allPrefabs = bundle.LoadAllAssets<GameObject>();

            if (allPrefabs.Length == 0)
            {
                Debug.LogError(" Không tìm thấy Prefabs nào trong AssetBundle!");
            }
            else
            {
                Debug.Log($" Tìm thấy {allPrefabs.Length} Prefabs, bắt đầu Instantiate...");
            }

            foreach (GameObject objPrefab in allPrefabs)
            {
                Instantiate(objPrefab, Vector3.zero, Quaternion.identity); // Load Object vào Scene
                Debug.Log(" Instantiated: " + objPrefab.name);
            }

            bundle.Unload(false); // Giữ lại object đã instantiate
        }

        // void ClearScene()
        // {
        //     GameObject[] allObjects = FindObjectsOfType<GameObject>();
        //
        //     foreach (GameObject obj in allObjects)
        //     {
        //         // Kiểm tra nếu đó không phải là UI Loading hoặc EventSystem
        //         if (obj != gameObject && obj != uiLoading && obj.GetComponent<EventSystem>() == null)
        //         {
        //             Destroy(obj);
        //         }
        //     }
        //
        //     Debug.Log("Cleared all objects in the scene, except UI Loading & EventSystem.");
        // }
    }
}
