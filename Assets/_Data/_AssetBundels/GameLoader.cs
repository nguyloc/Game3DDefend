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

       // public string googleDriveUrl ="https://drive.googleusercontent.com/uc?export=download&id=1LI22iZFU6E6cwaeezikH6E18MQXQhQJg";
        public string googleDriveUrl = "https://drive.google.com/uc?export=download&id=1LI22iZFU6E6cwaeezikH6E18MQXQhQJg"; 
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
            UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle("file://" + bundlePath);
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to load AssetBundle: " + request.error);
                yield break;
            }

            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
            if (bundle == null)
            {
                Debug.LogError("Failed to get AssetBundle content!");
                yield break;
            }

            Debug.Log("AssetBundle loaded successfully!");

            GameObject[] allPrefabs = bundle.LoadAllAssets<GameObject>();
            foreach (GameObject objPrefab in allPrefabs)
            {
                Instantiate(objPrefab);
            }

        }
    }
}
