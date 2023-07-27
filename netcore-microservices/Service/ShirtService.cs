using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netcore_microservices.Model;
using netcore_microservices.Repository;

namespace netcore_microservices.Service
{
    public class ShirtService
    {
        private ShirtRepository shirtRepository;
        public ShirtService(ShirtRepository shirtRepository)
        {
            this.shirtRepository = shirtRepository;
        }
        
        public List<Shirt> GetAllShirts(){
            return shirtRepository.GetAllShirts();
            //return "Reading all the shirts!!";
        }

        public Shirt? GetShirtsbyId(int id){
            return shirtRepository.GetShirtsbyId(id);
        }
        public Shirt CreateShirts(Shirt shirt){
            return shirtRepository.CreateShirts(shirt);
            // shirts.Add(shirt);
            // string shirtsLocal = JsonSerializer.Serialize(shirt);
            // //return $"Creating the shirts!! : {shirtsLocal}";
            // return shirt;
        }
        public Shirt UpdateShirts(Shirt shirt){
            return shirtRepository.UpdateShirts(shirt);

            // shirts[shirt.ShirtId] = shirt;
            // // return $"Updating the shirt: {shirt.ShirtId}";
            // return shirts[shirt.ShirtId];
        }
        public string DeleteShirts(int id){
            return shirtRepository.DeleteShirts(id);
            // shirts.RemoveAt(id);
            // return $"Deleting the shirt: {id}";
        }

        public bool ShirtsExistsId(int id){
            return shirtRepository.ShirtsExistsId(id);
        }

        public Shirt? ShirtByProperties(String? brand, String? gender, String? color, int? size)
        {
            return shirtRepository.shirts.FirstOrDefault(x => 
            !string.IsNullOrWhiteSpace(brand) 
            &&  !string.IsNullOrWhiteSpace(x.Brand)
            && x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)
            &&
            !string.IsNullOrWhiteSpace(gender) 
            &&  !string.IsNullOrWhiteSpace(x.Gender)
            && x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase)
            &&
            !string.IsNullOrWhiteSpace(color) 
            &&  !string.IsNullOrWhiteSpace(x.Color)
            && x.Color.Equals(color, StringComparison.OrdinalIgnoreCase)
            &&
            size.HasValue
            && x.Size.HasValue
            && size.Value == x.Size.Value 
            );
        }

    }
}