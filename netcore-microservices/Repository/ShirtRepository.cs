using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using netcore_microservices.Model;

namespace netcore_microservices.Repository
{
    public class ShirtRepository
    {

        public List<Shirt> shirts = new List<Shirt>
        {
            new Shirt { ShirtId = 1, Brand = "nike", Color = "blue", Gender = "men", Size = 20, Price = 100 },
            new Shirt { ShirtId = 2, Brand = "nike", Color = "blake", Gender = "men", Size = 20, Price = 100 },
            new Shirt { ShirtId = 3, Brand = "nike", Color = "red", Gender = "men", Size = 20, Price = 100 },
            new Shirt { ShirtId = 4, Brand = "nike", Color = "green", Gender = "women", Size = 20, Price = 100 },
            new Shirt { ShirtId = 5, Brand = "nike", Color = "yelow", Gender = "women", Size = 20, Price = 100 },
        };


        public List<Shirt> GetAllShirts(){
            return shirts;
            //return "Reading all the shirts!!";
        }

        public Shirt? GetShirtsbyId(int id){
            var _shirts = shirts.FirstOrDefault(s => s.ShirtId == id);
            //return $"Reading the shirt: {id}";
            return _shirts;
        }
        public Shirt CreateShirts(Shirt shirt){
            int maxId = shirts.Max(s => s.ShirtId);
            shirt.ShirtId = maxId+1;
            shirts.Add(shirt);
            //string shirtsLocal = JsonSerializer.Serialize(shirt);
            //return $"Creating the shirts!! : {shirtsLocal}";
            return shirt;
        }
        public Shirt UpdateShirts(Shirt shirt){
            var shirtUpdate = shirts.First(s => s.ShirtId == shirt.ShirtId);
            shirtUpdate.Brand = shirt.Brand;
            shirtUpdate.Color = shirt.Color;
            shirtUpdate.Gender = shirt.Gender;
            shirtUpdate.Size = shirt.Size;
            shirtUpdate.Price = shirt.Price;

            //shirts[shirt.ShirtId] = shirt;
            // return $"Updating the shirt: {shirt.ShirtId}";
            return shirtUpdate;
        }
        public string DeleteShirts(int id){
            var shirtRemove = GetShirtsbyId(id);
            if(shirtRemove != null)
            {
                shirts.Remove(shirtRemove);
            }
            return $"Deleting the shirt: {id}";
        }

        public bool ShirtsExistsId(int id){
            return shirts.Any(s => s.ShirtId == id);
        }

        // public bool ShirtsExistsId(int id){
        //     return shirts.Any(s => s.ShirtId == id);
        // }

    }
}