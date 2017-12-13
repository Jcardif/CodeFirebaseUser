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
        private Android.Net.Uri PhotoUrl;
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
        public async void GetUserDetails(FirebaseClient firebase, string child, AflameUser user)
        {
            var items = await firebase
                .Child(child)
                .Child(Email)
                .OnceAsync<AflameUser>();
            foreach (var item in items)
            {
                user = new AflameUser()
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
            }
                      
        }
    }
}
