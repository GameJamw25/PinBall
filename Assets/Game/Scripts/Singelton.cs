using UnityEngine;

public class Singelton<T> : MonoBehaviour where T : MonoBehaviour
{
   private static T _instance;
   public static T Instance
   {
      get
      {
         if (_instance == null)
         {
            _instance = FindObjectOfType<T>();
            if (_instance == null)
            {
               Debug.LogError(typeof(T).Name + " is missing from the scene!");
            }
         }
         return _instance;
      }
   }

   protected virtual void Awake()
   {
      if (_instance == null)
      {
         _instance = this as T;
      }
      else
      {
         Destroy(gameObject);
      }
   }
}
