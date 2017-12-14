using Android.Widget;
using Firebase.Auth;
using System;
using Firebase.Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;

namespace CodeFirebaseUser
{
    public class FirebaseUserCode
    {
        public string Email, Name;
        private AflameUser user = new AflameUser();
        public Android.Net.Uri PhotoUrl;
        public List<AflameUser> userList = new List<AflameUser>();

        public FirebaseUserCode()
        {
            var user = FirebaseAuth.Instance.CurrentUser;

            if (user != null)
            {
                Name = user.DisplayName;
                PhotoUrl = user.PhotoUrl;
                Email = user.Email;
            }
        }
        public async void GetListOfUsers(FirebaseClient firebase, string child)
        {
            var items = await firebase
                .Child(child)
                .OnceAsync<AflameUser>();
            foreach (var item in items)
            {
               var  myUser = new AflameUser()
                {
                    Name=item.Object.Name,
                    ID=item.Key,
                    Cell=item.Object.Cell,
                    Email=item.Object.Email,
                    Minisry=item.Object.Minisry,
                    PhoneNo=item.Object.PhoneNo,
                    Occupation=item.Object.Occupation,
                    Password=item.Object.Password,
                    PhotoUrl=item.Object.PhotoUrl,
                    Residence=item.Object.Residence,
                    Username=item.Object.Username,                 
                };
                userList.Add(myUser);
            }
                                 
        }
        public AflameUser GetUser()
        {
            AflameUser testUser = userList.Find(delegate(AflameUser x)
            {
                return  x.Email ==Email;
            });
            user = testUser;
            return user;
        }
    }
}
