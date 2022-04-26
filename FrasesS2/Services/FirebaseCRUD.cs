using Firebase.Database;
using Firebase.Database.Query;
using FrasesS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrasesS2.Services
{
    public class FirebaseCRUD
    {
        private readonly string ChildName = "MURALS2";

        readonly FirebaseClient firebase = new FirebaseClient("https://murals2-default-rtdb.firebaseio.com/");

        public async Task<List<UserMural>> GetAllPersons()
        {
            return (await firebase
                .Child(ChildName)
                .OnceAsync<UserMural>()).Select(item => new UserMural
                {
                    Nome = item.Object.Nome,
                    UserMuralId = item.Object.UserMuralId,
                    Disponivel = item.Object.Disponivel,
                    Descricao = item.Object.Descricao,
                   

                }).ToList();
        }

        public async Task AddPerson(string nome, string descricao)
        {
            await firebase
                .Child(ChildName)
                .PostAsync(new UserMural()
                {
                    UserMuralId = Guid.NewGuid(),
                    Nome = nome,
                    Disponivel = false,
                    Descricao = descricao,
                    Data = DateTime.Now
                });
        }

        public async Task<UserMural> GetPerson(Guid userMuralid)
        {
            var allPersons = await GetAllPersons();
            await firebase
                .Child(ChildName)
                .OnceAsync<UserMural>();
            return allPersons.FirstOrDefault(a => a.UserMuralId == userMuralid);
        }

        public async Task<UserMural> GetPerson(string name)
        {
            var allPersons = await GetAllPersons();
            await firebase
                .Child(ChildName)
                .OnceAsync<UserMural>();
            return allPersons.FirstOrDefault(a => a.Nome == name);
        }

        public async Task Update(Guid userMuralid, bool status)
        {
            var toUpdatePerson = (await firebase
                .Child(ChildName)
                .OnceAsync<UserMural>()).FirstOrDefault(a => a.Object.UserMuralId == userMuralid);

            await firebase
                .Child(ChildName)
                .Child(toUpdatePerson.Key)
                .PutAsync(new UserMural() { UserMuralId = userMuralid, Disponivel = status });

        
        }

        public async Task DeletePerson(Guid userMuralid)
        {
            var toDeletePerson = (await firebase
                .Child(ChildName)
                .OnceAsync<UserMural>()).FirstOrDefault(a => a.Object.UserMuralId == userMuralid);
            await firebase.Child(ChildName).Child(toDeletePerson.Key).DeleteAsync();
        }
    }
}
