using Ban_Caffee.Models.Dto;
using Ban_Caffee.Models.ViewModel;

namespace Ban_Caffee.Services
{
    public interface ICustomerAuthService
    {
        Task<TokenResponseDto> LoginAsync(CustomerLoginViewModel model);
        Task<ApiResponseDto> RegisterAsync(CustomerRegisterViewModel model);

    }
}
