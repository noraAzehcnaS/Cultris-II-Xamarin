using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;

using Cultris_II.Models;
using Cultris_II.Services;
using Firebase.Firestore;
using Java.Interop;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.KotlinX.Coroutines;

[assembly:Dependency(typeof(Cultris_II.Droid.Dependencies.FireStore))]
namespace Cultris_II.Droid.Dependencies
{
    public class FireStore : Java.Lang.Object, IDataService, IOnCompleteListener
    {
        private readonly List<Player> players;
        bool hasReadPlayers = false;
        public FireStore() 
        {
            players = new List<Player>();
        }

        public JniManagedPeerStates JniManagedPeerState => throw new NotImplementedException();

        public bool Delete(Player player)       
        {
            var collection = FirebaseFirestore.Instance.Collection("followedPlayers");
            collection.Document(player.Id).Delete();
            return true;
        }

        public void Disposed()
        {
            throw new NotImplementedException();
        }

        public void DisposeUnlessReferenced()
        {
            throw new NotImplementedException();
        }

        public void Finalized()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Player player)
        {
            var playerDocument = new Dictionary<string, Java.Lang.Object>
            {
                {"name", player.Name}, 
                {"rank",player.Rank},
                {"countryCode", player.CountryCode},
                {"imageSource", player.ImageSource},
                {"userId", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid},
            };
            var collection = FirebaseFirestore.Instance.Collection("followedPlayers");
            collection.Add(new HashMap(playerDocument));
            return true;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                var documents = (QuerySnapshot)task.Result;
                players.Clear();
                foreach (var document in documents.Documents)
                {
                    Player newPlayer = new Player()
                    {
                        Name = document.GetString("name"),
                        Rank = (int)document.Get("rank"),
                        CountryCode = document.GetString("countryCode"),
                        ImageSource = document.GetString("imageSource"),
                        Id = document.Id
                    };

                    players.Add(newPlayer);
                }
            }
            else 
            {
                players.Clear();
            }
            hasReadPlayers = true;
        }

        public async Task<List<Player>> Read()
        {
            hasReadPlayers = false;
            var collection = FirebaseFirestore.Instance.Collection("followedPlayers");
            var query = collection.WhereEqualTo("userId", Firebase.Auth.FirebaseAuth.Instance.Uid);
            query.Get().AddOnCompleteListener(this);

            for (var i = 0; i < 10; i++)
            {
                await System.Threading.Tasks.Task.Delay(100);
                if (hasReadPlayers) { break; }
            }
            return players;
        }

        public void SetJniIdentityHashCode(int value)
        {
            throw new NotImplementedException();
        }

        public void SetJniManagedPeerState(JniManagedPeerStates value)
        {
            throw new NotImplementedException();
        }

        public void SetPeerReference(JniObjectReference reference)
        {
            throw new NotImplementedException();
        }

    }
}