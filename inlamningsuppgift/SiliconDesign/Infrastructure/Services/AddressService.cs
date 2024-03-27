//using Infrastructure.Entities;
//using Shared.Repositories;
//using System.Diagnostics;

//namespace Infrastructure.Services;
//public class AddressService(AddressRepository addressRepository) {
//    private readonly AddressRepository _addressRepository = addressRepository;

//    public async Task<AddressEntity> CreateAddressAsync(string streetName, string postalCode, string city) {
//        try {
//            var tAddress = new AddressEntity {
//                StreetName = streetName,
//                PostalCode = postalCode,
//                City = city
//            };

//            if (await _addressRepository.Exists(tAddress))
//                return null!;

//            return await _addressRepository.Create(tAddress);

//        } catch (Exception e) { Debug.WriteLine(e); }
//        return null!;
//    }

//    public async Task<AddressEntity> GetAddressAsync(string streetName, string postalCode, string city) {

//        try {
//            return await _addressRepository.GetOne(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);

//        } catch (Exception e) { Debug.WriteLine(e); }

//        return null!;
//    }
//}
