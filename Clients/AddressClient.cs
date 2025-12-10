using IsabelliDoces.Dtos.AddressDtos;

namespace IsabelliDoces.Clients;

public class AddressClient(HttpClient httpClient)
{
        public async Task<AddressDto> GetClientAsync(int id) =>
        await httpClient.GetFromJsonAsync<AddressDto>($"addresses/{id}") ??
        throw new Exception("Couldn't find address!");
}
