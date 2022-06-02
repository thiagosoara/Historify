using Firebase;
using Firebase.Analytics;
using UnityEngine;

public class firebase : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
       
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);

        };
    }
}
