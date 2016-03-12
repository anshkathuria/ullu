using FireSharp;
using FireSharp.Config;
using FireSharp.EventStreaming;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ullu.Constants;
using ullu.Models;
using Utilities;

namespace ullu.Services
{
    public sealed class FireSharpClient
    {
        private IFirebaseClient _firebaseClient;
        public FireSharpClient()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                AuthSecret = AppConstants.FIREBASE_AUTH,
                BasePath = AppConstants.FIREBASE_URL
            };
            _firebaseClient = new FirebaseClient(config);
        }
        public async Task<T> Set<T>(string path, T data)
        {
            SetResponse response = await _firebaseClient.SetAsync(path, data);
            return response.ResultAs<T>();
        }
        public async Task<string> Push<T>(string path, T data)
        {
            PushResponse response = await _firebaseClient.PushAsync(path, data);
            return response.Result.name;
        }
        public async Task<T> Get<T>(string path)
        {
            FirebaseResponse response = await _firebaseClient.GetAsync(path);
            return response.ResultAs<T>();
        }
        public async Task<Dictionary<string,T>> GetAll<T>(string path)
        {
            FirebaseResponse response = await _firebaseClient.GetAsync(path);
            return response.ResultAs<Dictionary<string, T>>();
        }
        public async Task<T> Update<T>(string path, T data)
        {
            FirebaseResponse response = await _firebaseClient.UpdateAsync(path, data);
            return response.ResultAs<T>();
        }
        public async Task<HttpStatusCode> Delete(string path)
        {
            FirebaseResponse response = await _firebaseClient.DeleteAsync(path);
            return response.StatusCode;
        }
        public Task<EventStreamResponse> On<T>(string path, ValueAddedEventHandler added = null, ValueChangedEventHandler changed = null, ValueRemovedEventHandler removed = null) 
        {
            return _firebaseClient.OnAsync(path, added, changed, removed);
        }
        public Task<EventRootResponse<T>> OnChange<T>(string path, ValueRootAddedEventHandler<T> added = null)
        {
            return _firebaseClient.OnChangeGetAsync(path, added);
        }

        /// <summary>
        /// Get Observable Collection
        /// </summary>
        private EventStreamResponse eventResponse;
        public async void OnAddAll<T>(string path, ObservableDictionary<string, T> dict) where T : BaseModel, new()
        {
            ObservableDictionary<string, T> returnDictionary = dict;
            T t;
            eventResponse = await On<T>(path, (sender, args) =>
            {
                string[] tokens = args.Path.Split('/');
                string key = tokens[1];
                string property = tokens[2];
                if (returnDictionary.ContainsKey(key))
                {
                    t = returnDictionary[key];
                }
                else
                {
                    t = new T();
                    returnDictionary[key] = t;
                }
                t.SetProperty(property, args.Data);
            });
        }
        public void DisposeEventResponse()
        {
            if(eventResponse != null)
                eventResponse.Dispose();
        }
        //public static FireSharpClient Instance { get { return Nested.instance; } }
        //private class Nested
        //{
        //    // Explicit static constructor to tell C# compiler
        //    // not to mark type as beforefieldinit
        //    static Nested()
        //    {
        //    }

        //    internal static readonly FireSharpClient instance = new FireSharpClient();
        //}

        private static readonly FireSharpClient instance = new FireSharpClient();
        static FireSharpClient()
        {
        }
        public static FireSharpClient Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
