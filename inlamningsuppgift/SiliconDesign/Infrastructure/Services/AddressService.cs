using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Services;
public class AddressService(AddressRepository addressRepository) {

    private readonly AddressRepository _addressRepository = addressRepository;

    public async Task<AddressEntity> CreateAsync(string userID, string streetName, string postalCode, string city, string? streetname2) {
        try {
            var tAddress = new AddressEntity {
                StreetName = streetName,
                StreetName2 = streetname2,
                PostalCode = postalCode,
                City = city,
                UserId = userID,
            };

            if (await _addressRepository.Exists(tAddress))
                return null!;

            return await _addressRepository.Create(tAddress);

        } catch (Exception e) { Debug.WriteLine(e); }
        return null!;
    }

    public async Task<AddressEntity> CreateOrUpdateAsync(string userId, string streetName, string postalCode, string city, string? streetname2) {
        try {
            var tAddress = new AddressEntity {
                StreetName = streetName,
                StreetName2 = streetname2!,
                PostalCode = postalCode,
                City = city,
                UserId = userId,
            };

            Expression<Func<AddressEntity, bool>> tExp = x => x.UserId == userId;

            if (await _addressRepository.Exists(tExp)) {
                if (await _addressRepository.UpdateEntity(tExp, tAddress))
                    return tAddress;
                else
                    return null!;
            } else
                return await _addressRepository.Create(tAddress);

        } catch (Exception e) { Debug.WriteLine(e); }
        return null!;
    }

    public async Task<AddressEntity> GetAddressAsync(string userId) {

        try {
            return await _addressRepository.GetOne(x => x.UserId == userId);

        } catch (Exception e) { Debug.WriteLine(e); }
        return null!;
    }
}
