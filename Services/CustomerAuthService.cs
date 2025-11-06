using Ban_Caffee.Models.Dto;
using Ban_Caffee.Models.ViewModel;
using System.Text;
using System.Text.Json;

namespace Ban_Caffee.Services
{
    public class CustomerAuthService : ICustomerAuthService
    {
        private readonly HttpClient _httpClient;

        public CustomerAuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TokenResponseDto> LoginAsync(CustomerLoginViewModel model)
        {
            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/customers/login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var token = JsonSerializer.Deserialize<TokenResponseDto>(responseContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return token;
            }

            return null;
        }

        public async Task<ApiResponseDto> RegisterAsync(CustomerRegisterViewModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/customer/register", model);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ApiResponseDto>();
            }
            return new ApiResponseDto { IsSuccess = false, Message = "Đăng ký không thành công." };
        }
    }
}
